using InventarioWeb.Core.Constants;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Entities;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Core.Mappings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventarioWeb.Web.Controllers;

[Authorize(Roles = Roles.AdminGerenteOperador)]
public class ConsignacionesController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ConsignacionesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: Consignaciones
    public async Task<IActionResult> Index()
    {
        var consignaciones = await _unitOfWork.Consignaciones.GetConsignacionesConDetallesAsync();
        var consignacionesDto = consignaciones.Select(c => c.ToDto());
        return View(consignacionesDto);
    }

    // GET: Consignaciones/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var consignacion = await _unitOfWork.Consignaciones.GetConsignacionConDetallesAsync(id);
        if (consignacion == null) return NotFound();

        return View(consignacion.ToDto());
    }

    // GET: Consignaciones/Create
    [Authorize(Roles = Roles.AdminGerenteOperador)]
    public async Task<IActionResult> Create()
    {
        await CargarListasAsync();
        return View(new ConsignacionDto
        {
            Detalles = new List<ConsignacionDetalleDto>
            {
                new ConsignacionDetalleDto()
            }
        });
    }

    // POST: Consignaciones/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminGerenteOperador)]
    public async Task<IActionResult> Create(ConsignacionDto model)
    {
        if (ModelState.IsValid)
        {
            var consignacion = model.ToEntity();
            consignacion.Estado = "PENDIENTE";
            consignacion.FechaCreacion = DateTime.Now;
            consignacion.Activo = true;

            // Crear movimiento de salida automático
            var movimientoSalida = new Movimiento
            {
                Tipo = "SALIDA",
                NumeroDocumento = $"SAL-{model.NumeroConsignacion}",
                FechaMovimiento = model.FechaEntrega,
                AlmacenOrigenId = model.AlmacenOrigenId,
                Observacion = $"Salida por consignación #{model.NumeroConsignacion} - Vendedor: {model.VendedorNombre}",
                FechaCreacion = DateTime.Now,
                Activo = true,
                Detalles = new List<MovimientoDetalle>()
            };

            // Descontar stock del almacén origen y agregar detalles al movimiento
            foreach (var detalle in consignacion.Detalles)
            {
                var stock = await _unitOfWork.StockAlmacenes
                    .GetStockAsync(detalle.ProductoId, consignacion.AlmacenOrigenId);

                if (stock == null)
                {
                    ModelState.AddModelError("", $"No hay stock de {detalle.Producto?.Nombre} en este almacén");
                    await CargarListasAsync();
                    return View(model);
                }

                if (stock.StockActual < detalle.CantidadEntregada)
                {
                    ModelState.AddModelError("", $"Stock insuficiente de {detalle.Producto?.Nombre}. Stock actual: {stock.StockActual}");
                    await CargarListasAsync();
                    return View(model);
                }

                // Descontar del stock
                stock.StockActual -= detalle.CantidadEntregada;
                stock.FechaModificacion = DateTime.Now;
                await _unitOfWork.StockAlmacenes.UpdateAsync(stock);

                // Agregar detalle al movimiento de salida
                movimientoSalida.Detalles.Add(new MovimientoDetalle
                {
                    ProductoId = detalle.ProductoId,
                    Cantidad = detalle.CantidadEntregada,
                    PrecioUnitario = detalle.PrecioUnitario,
                    FechaCreacion = DateTime.Now,
                    Activo = true
                });
            }

            // Guardar movimiento de salida
            await _unitOfWork.Movimientos.AddAsync(movimientoSalida);

            // Guardar consignación
            await _unitOfWork.Consignaciones.AddAsync(consignacion);
            await _unitOfWork.CompleteAsync();

            TempData["Mensaje"] = "Consignación creada exitosamente. Se generó salida de almacén automáticamente.";
            return RedirectToAction(nameof(Index));
        }

        await CargarListasAsync();
        return View(model);
    }

    // POST: Consignaciones/RegistrarVenta
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminGerenteOperador)]
    public async Task<IActionResult> RegistrarVenta(RegistrarVentaDto model)
    {
        var detalle = await _unitOfWork.ConsignacionDetalles.GetByIdAsync(model.ConsignacionDetalleId);
        if (detalle == null) return NotFound();

        // Obtener la consignación con todos sus detalles
        var consignacion = await _unitOfWork.Consignaciones.GetConsignacionConDetallesAsync(detalle.ConsignacionId);
        if (consignacion == null) return NotFound();

        var pendiente = detalle.CantidadEntregada - detalle.CantidadVendida - detalle.CantidadDevuelta;

        if (model.CantidadVendida > pendiente)
        {
            TempData["Error"] = $"La cantidad vendida ({model.CantidadVendida}) no puede superar la pendiente ({pendiente})";
            return RedirectToAction(nameof(Details), new { id = detalle.ConsignacionId });
        }

        if (model.CantidadVendida <= 0)
        {
            TempData["Error"] = "La cantidad vendida debe ser mayor a 0";
            return RedirectToAction(nameof(Details), new { id = detalle.ConsignacionId });
        }

        detalle.CantidadVendida += model.CantidadVendida;
        detalle.FechaModificacion = DateTime.Now;
        await _unitOfWork.ConsignacionDetalles.UpdateAsync(detalle);

        // Actualizar estado de la consignación
        ActualizarEstadoConsignacion(consignacion);
        await _unitOfWork.Consignaciones.UpdateAsync(consignacion);

        await _unitOfWork.CompleteAsync();

        TempData["Mensaje"] = $"Venta de {model.CantidadVendida} unidades registrada exitosamente.";
        return RedirectToAction(nameof(Details), new { id = detalle.ConsignacionId });
    }

    // POST: Consignaciones/RegistrarDevolucion
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.AdminGerenteOperador)]
    public async Task<IActionResult> RegistrarDevolucion(RegistrarDevolucionDto model)
    {
        var detalle = await _unitOfWork.ConsignacionDetalles.GetByIdAsync(model.ConsignacionDetalleId);
        if (detalle == null) return NotFound();

        // Obtener la consignación con todos sus detalles
        var consignacion = await _unitOfWork.Consignaciones.GetConsignacionConDetallesAsync(detalle.ConsignacionId);
        if (consignacion == null) return NotFound();

        var pendiente = detalle.CantidadEntregada - detalle.CantidadVendida - detalle.CantidadDevuelta;

        if (model.CantidadDevuelta > pendiente)
        {
            TempData["Error"] = $"La cantidad devuelta ({model.CantidadDevuelta}) no puede superar la pendiente ({pendiente})";
            return RedirectToAction(nameof(Details), new { id = detalle.ConsignacionId });
        }

        if (model.CantidadDevuelta <= 0)
        {
            TempData["Error"] = "La cantidad devuelta debe ser mayor a 0";
            return RedirectToAction(nameof(Details), new { id = detalle.ConsignacionId });
        }

        // Actualizar detalle
        detalle.CantidadDevuelta += model.CantidadDevuelta;
        detalle.FechaModificacion = DateTime.Now;
        await _unitOfWork.ConsignacionDetalles.UpdateAsync(detalle);

        // Devolver al stock del almacén
        var stock = await _unitOfWork.StockAlmacenes
            .GetStockAsync(detalle.ProductoId, consignacion.AlmacenOrigenId);

        if (stock != null)
        {
            stock.StockActual += model.CantidadDevuelta;
            stock.FechaModificacion = DateTime.Now;
            await _unitOfWork.StockAlmacenes.UpdateAsync(stock);
        }
        else
        {
            // Si no existe stock, crearlo
            stock = new StockAlmacen
            {
                ProductoId = detalle.ProductoId,
                AlmacenId = consignacion.AlmacenOrigenId,
                StockActual = model.CantidadDevuelta,
                StockMinimo = 5,
                StockMaximo = 100,
                FechaCreacion = DateTime.Now,
                Activo = true
            };
            await _unitOfWork.StockAlmacenes.AddAsync(stock);
        }

        // Crear movimiento de entrada por devolución
        var movimientoEntrada = new Movimiento
        {
            Tipo = "ENTRADA",
            NumeroDocumento = $"DEV-{consignacion.NumeroConsignacion}-{DateTime.Now:yyyyMMddHHmmss}",
            FechaMovimiento = DateTime.Now,
            AlmacenOrigenId = consignacion.AlmacenOrigenId,
            Observacion = $"Devolución consignación #{consignacion.NumeroConsignacion} - {detalle.Producto?.Nombre} - Vendedor: {consignacion.VendedorNombre}",
            FechaCreacion = DateTime.Now,
            Activo = true,
            Detalles = new List<MovimientoDetalle>
        {
            new MovimientoDetalle
            {
                ProductoId = detalle.ProductoId,
                Cantidad = model.CantidadDevuelta,
                PrecioUnitario = detalle.PrecioUnitario,
                FechaCreacion = DateTime.Now,
                Activo = true
            }
        }
        };

        await _unitOfWork.Movimientos.AddAsync(movimientoEntrada);

        // Actualizar estado de la consignación
        ActualizarEstadoConsignacion(consignacion);
        await _unitOfWork.Consignaciones.UpdateAsync(consignacion);

        await _unitOfWork.CompleteAsync();

        TempData["Mensaje"] = $"Devolución de {model.CantidadDevuelta} unidades registrada exitosamente.";
        return RedirectToAction(nameof(Details), new { id = detalle.ConsignacionId });
    }

    private void ActualizarEstadoConsignacion(Consignacion consignacion)
    {
        // Recargar los detalles para tener los valores actualizados
        var todosDetalles = consignacion.Detalles;

        // Calcular totales
        var totalPendiente = todosDetalles.Sum(d => d.Pendiente);

        if (totalPendiente == 0)
        {
            // Todos los productos están vendidos o devueltos
            consignacion.Estado = "COMPLETADA";
            consignacion.FechaDevolucion = DateTime.Now;
        }
        else if (todosDetalles.Any(d => d.CantidadVendida > 0 || d.CantidadDevuelta > 0))
        {
            // Al menos un producto tiene movimiento
            consignacion.Estado = "PARCIAL";
        }
        else
        {
            // Ningún producto tiene movimiento aún
            consignacion.Estado = "PENDIENTE";
        }
    }

    private async Task CargarListasAsync()
    {
        var productos = await _unitOfWork.Productos.FindAsync(p => p.Activo);
        ViewBag.Productos = new SelectList(productos, "Id", "Nombre");

        var almacenes = await _unitOfWork.Almacenes.GetAlmacenesActivosAsync();
        ViewBag.Almacenes = new SelectList(almacenes, "Id", "Nombre");
    }
}