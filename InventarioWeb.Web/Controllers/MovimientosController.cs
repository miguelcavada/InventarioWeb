using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using InventarioWeb.Core.Entities;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Core.Mappings;

namespace InventarioWeb.Web.Controllers;

[Authorize]
public class MovimientosController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public MovimientosController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: Movimientos
    public async Task<IActionResult> Index(string tipo = "TODOS", DateTime? desde = null, DateTime? hasta = null)
    {
        IEnumerable<Movimiento> movimientos;

        if (desde.HasValue && hasta.HasValue)
        {
            movimientos = await _unitOfWork.Movimientos.GetMovimientosPorFechaAsync(desde.Value, hasta.Value);
        }
        else if (tipo != "TODOS")
        {
            movimientos = await _unitOfWork.Movimientos.GetMovimientosPorTipoAsync(tipo);
        }
        else
        {
            movimientos = await _unitOfWork.Movimientos.GetAllAsync();
        }

        var movimientosDto = movimientos
            .OrderByDescending(m => m.FechaMovimiento)
            .Select(m => m.ToDto());

        return View(movimientosDto);
    }

    // GET: Movimientos/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var movimiento = await _unitOfWork.Movimientos.GetMovimientoConDetallesAsync(id);
        if (movimiento == null) return NotFound();

        return View(movimiento.ToDto());
    }

    // GET: Movimientos/Create
    public async Task<IActionResult> Create(string tipo)
    {
        await CargarListasAsync();

        var movimiento = new MovimientoDto
        {
            Tipo = tipo,
            FechaMovimiento = DateTime.Now,
            Detalles = new List<MovimientoDetalleDto>
            {
                new MovimientoDetalleDto()
            }
        };

        return View(movimiento);
    }

    // POST: Movimientos/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MovimientoDto movimientoDto)
    {
        if (ModelState.IsValid)
        {
            var movimiento = movimientoDto.ToEntity();
            movimiento.FechaCreacion = DateTime.Now;
            movimiento.Activo = true;

            foreach (var detalle in movimiento.Detalles)
            {
                // Buscar stock existente
                var stock = await _unitOfWork.StockAlmacenes
                    .GetStockAsync(detalle.ProductoId, movimiento.AlmacenOrigenId);

                if (movimiento.Tipo == "ENTRADA")
                {
                    if (stock == null)
                    {
                        // Crear nuevo stock
                        stock = new StockAlmacen
                        {
                            ProductoId = detalle.ProductoId,
                            AlmacenId = movimiento.AlmacenOrigenId,
                            StockActual = (int)detalle.Cantidad,
                            StockMinimo = 5,
                            StockMaximo = 100,
                            FechaCreacion = DateTime.Now,
                            Activo = true
                        };
                        await _unitOfWork.StockAlmacenes.AddAsync(stock);
                        await _unitOfWork.CompleteAsync(); // Guardar para obtener ID
                    }
                    else
                    {
                        stock.StockActual += (int)detalle.Cantidad;
                        stock.FechaModificacion = DateTime.Now;
                        await _unitOfWork.StockAlmacenes.UpdateAsync(stock);
                    }
                }
                else if (movimiento.Tipo == "SALIDA")
                {
                    if (stock == null || stock.StockActual < detalle.Cantidad)
                    {
                        ModelState.AddModelError("", $"Stock insuficiente en el almacén seleccionado para {detalle.Producto?.Nombre}");
                        await CargarListasAsync();
                        return View(movimientoDto);
                    }
                    stock.StockActual -= (int)detalle.Cantidad;
                    stock.FechaModificacion = DateTime.Now;
                    await _unitOfWork.StockAlmacenes.UpdateAsync(stock);
                }
                else if (movimiento.Tipo == "TRASLADO")
                {
                    if (stock == null || stock.StockActual < detalle.Cantidad)
                    {
                        ModelState.AddModelError("", $"Stock insuficiente para traslado");
                        await CargarListasAsync();
                        return View(movimientoDto);
                    }

                    // Descontar del origen
                    stock.StockActual -= (int)detalle.Cantidad;
                    stock.FechaModificacion = DateTime.Now;
                    await _unitOfWork.StockAlmacenes.UpdateAsync(stock);

                    // Agregar al destino
                    var stockDestino = await _unitOfWork.StockAlmacenes
                        .GetStockAsync(detalle.ProductoId, movimiento.AlmacenDestinoId!.Value);

                    if (stockDestino == null)
                    {
                        stockDestino = new StockAlmacen
                        {
                            ProductoId = detalle.ProductoId,
                            AlmacenId = movimiento.AlmacenDestinoId!.Value,
                            StockActual = (int)detalle.Cantidad,
                            StockMinimo = 5,
                            StockMaximo = 100,
                            FechaCreacion = DateTime.Now,
                            Activo = true
                        };
                        await _unitOfWork.StockAlmacenes.AddAsync(stockDestino);
                        await _unitOfWork.CompleteAsync(); // Guardar para obtener ID
                    }
                    else
                    {
                        stockDestino.StockActual += (int)detalle.Cantidad;
                        stockDestino.FechaModificacion = DateTime.Now;
                        await _unitOfWork.StockAlmacenes.UpdateAsync(stockDestino);
                    }
                }
            }

            await _unitOfWork.Movimientos.AddAsync(movimiento);
            await _unitOfWork.CompleteAsync();

            TempData["Mensaje"] = "Movimiento registrado exitosamente";
            return RedirectToAction(nameof(Index));
        }

        await CargarListasAsync();
        return View(movimientoDto);
    }

    private async Task CargarListasAsync()
    {
        var productos = await _unitOfWork.Productos.FindAsync(p => p.Activo);
        ViewBag.Productos = new SelectList(productos, "Id", "Nombre");

        var almacenes = await _unitOfWork.Almacenes.GetAlmacenesActivosAsync();
        ViewBag.Almacenes = new SelectList(almacenes, "Id", "Nombre");
    }
}