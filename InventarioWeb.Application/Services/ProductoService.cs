using InventarioWeb.Application.Common;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Mappings;

namespace InventarioWeb.Application.Services;

public interface IProductoService
{
    Task<Result<IEnumerable<ProductoDto>>> GetProductosAsync(string? buscar = null, string orden = "nombre");
    Task<Result<ProductoDto>> GetProductoByIdAsync(int id);
    Task<Result<ProductoDto>> CreateProductoAsync(ProductoDto dto);
    Task<Result<ProductoDto>> UpdateProductoAsync(int id, ProductoDto dto);
    Task<Result> DeleteProductoAsync(int id);
    Task<Result<CambioPrecioDto>> GetCambioPrecioAsync(int id);
    Task<Result> CambiarPrecioAsync(CambioPrecioDto model, string usuario);
    Task<Result<IEnumerable<HistorialPrecioDto>>> GetHistorialPreciosAsync(int productoId);
    Task<Result<bool>> CodigoExisteAsync(string codigo, int? excludeId = null);
    Task<Result<PagedResult<ProductoDto>>> GetProductosPaginadosAsync(
    string? buscar = null,
    string orden = "nombre",
    int pagina = 1,
    int tamañoPagina = 10);
}

public class ProductoService : IProductoService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<ProductoDto>>> GetProductosAsync(string? buscar = null, string orden = "nombre")
    {
        try
        {
            var productos = await _unitOfWork.Productos.GetProductosConCategoriaAsync();

            if (!string.IsNullOrEmpty(buscar))
            {
                productos = productos.Where(p =>
                    p.Nombre.Contains(buscar, StringComparison.OrdinalIgnoreCase) ||
                    p.Codigo.Contains(buscar, StringComparison.OrdinalIgnoreCase));
            }

            productos = orden switch
            {
                "codigo" => productos.OrderBy(p => p.Codigo),
                "stock" => productos.OrderByDescending(p => p.Stocks.Sum(s => s.StockActual)),
                "precio" => productos.OrderBy(p => p.PrecioVentaMinorista),
                _ => productos.OrderBy(p => p.Nombre),
            };

            var result = productos.Select(p => p.ToDto());
            return Result<IEnumerable<ProductoDto>>.Success(result);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<ProductoDto>>.Failure($"Error al obtener productos: {ex.Message}");
        }
    }

    public async Task<Result<ProductoDto>> GetProductoByIdAsync(int id)
    {
        try
        {
            var producto = await _unitOfWork.Productos.GetProductoConCategoriaAsync(id);
            if (producto == null)
                return Result<ProductoDto>.Failure("Producto no encontrado");

            return Result<ProductoDto>.Success(producto.ToDto());
        }
        catch (Exception ex)
        {
            return Result<ProductoDto>.Failure($"Error al obtener producto: {ex.Message}");
        }
    }

    public async Task<Result<ProductoDto>> CreateProductoAsync(ProductoDto dto)
    {
        try
        {
            if (await _unitOfWork.Productos.CodigoExisteAsync(dto.Codigo))
                return Result<ProductoDto>.Failure("El código ya existe");

            var producto = dto.ToEntity();
            producto.FechaCreacion = DateTime.Now;
            producto.Activo = true;

            await _unitOfWork.Productos.AddAsync(producto);
            await _unitOfWork.CompleteAsync();

            return Result<ProductoDto>.Success(producto.ToDto(), "Producto creado exitosamente");
        }
        catch (Exception ex)
        {
            return Result<ProductoDto>.Failure($"Error al crear producto: {ex.Message}");
        }
    }

    public async Task<Result<ProductoDto>> UpdateProductoAsync(int id, ProductoDto dto)
    {
        try
        {
            if (await _unitOfWork.Productos.CodigoExisteAsync(dto.Codigo, id))
                return Result<ProductoDto>.Failure("El código ya existe");

            var producto = await _unitOfWork.Productos.GetByIdAsync(id);
            if (producto == null)
                return Result<ProductoDto>.Failure("Producto no encontrado");

            dto.UpdateEntity(producto);
            await _unitOfWork.Productos.UpdateAsync(producto);
            await _unitOfWork.CompleteAsync();

            return Result<ProductoDto>.Success(producto.ToDto(), "Producto actualizado exitosamente");
        }
        catch (Exception ex)
        {
            return Result<ProductoDto>.Failure($"Error al actualizar producto: {ex.Message}");
        }
    }

    public async Task<Result> DeleteProductoAsync(int id)
    {
        try
        {
            var producto = await _unitOfWork.Productos.GetByIdAsync(id);
            if (producto == null)
                return Result.Failure("Producto no encontrado");

            producto.Activo = false;
            producto.FechaModificacion = DateTime.Now;
            await _unitOfWork.Productos.DeleteAsync(producto);
            await _unitOfWork.CompleteAsync();

            return Result.Success("Producto eliminado exitosamente");
        }
        catch (Exception ex)
        {
            return Result.Failure($"Error al eliminar producto: {ex.Message}");
        }
    }

    public async Task<Result<CambioPrecioDto>> GetCambioPrecioAsync(int id)
    {
        try
        {
            var producto = await _unitOfWork.Productos.GetByIdAsync(id);
            if (producto == null)
                return Result<CambioPrecioDto>.Failure("Producto no encontrado");

            var model = new CambioPrecioDto
            {
                ProductoId = producto.Id,
                PrecioCostoNuevo = producto.PrecioCosto,
                PrecioVentaMinoristaNuevo = producto.PrecioVentaMinorista,
                PrecioVentaMayoristaNuevo = producto.PrecioVentaMayorista
            };

            return Result<CambioPrecioDto>.Success(model);
        }
        catch (Exception ex)
        {
            return Result<CambioPrecioDto>.Failure($"Error: {ex.Message}");
        }
    }

    public async Task<Result> CambiarPrecioAsync(CambioPrecioDto model, string usuario)
    {
        try
        {
            var producto = await _unitOfWork.Productos.GetByIdAsync(model.ProductoId);
            if (producto == null)
                return Result.Failure("Producto no encontrado");

            bool huboCambio = producto.PrecioCosto != model.PrecioCostoNuevo ||
                             producto.PrecioVentaMinorista != model.PrecioVentaMinoristaNuevo ||
                             producto.PrecioVentaMayorista != model.PrecioVentaMayoristaNuevo;

            if (huboCambio)
            {
                var historial = new HistorialPrecio
                {
                    ProductoId = producto.Id,
                    PrecioCostoAnterior = producto.PrecioCosto,
                    PrecioCostoNuevo = model.PrecioCostoNuevo,
                    PrecioVentaAnterior = producto.PrecioVentaMinorista,
                    PrecioVentaNuevo = model.PrecioVentaMinoristaNuevo,
                    Motivo = model.Motivo,
                    FechaCambio = DateTime.Now,
                    UsuarioCambio = usuario,
                    Activo = true,
                    FechaCreacion = DateTime.Now
                };

                await _unitOfWork.HistorialPrecios.AddAsync(historial);
            }

            producto.PrecioCosto = model.PrecioCostoNuevo;
            producto.PrecioVentaMinorista = model.PrecioVentaMinoristaNuevo;
            producto.PrecioVentaMayorista = model.PrecioVentaMayoristaNuevo;
            producto.FechaModificacion = DateTime.Now;

            await _unitOfWork.Productos.UpdateAsync(producto);
            await _unitOfWork.CompleteAsync();

            return Result.Success("Precios actualizados exitosamente");
        }
        catch (Exception ex)
        {
            return Result.Failure($"Error al cambiar precios: {ex.Message}");
        }
    }

    public async Task<Result<IEnumerable<HistorialPrecioDto>>> GetHistorialPreciosAsync(int productoId)
    {
        try
        {
            var historial = await _unitOfWork.HistorialPrecios.GetHistorialPorProductoAsync(productoId);
            return Result<IEnumerable<HistorialPrecioDto>>.Success(historial.Select(h => h.ToDto()));
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<HistorialPrecioDto>>.Failure($"Error: {ex.Message}");
        }
    }

    public async Task<Result<bool>> CodigoExisteAsync(string codigo, int? excludeId = null)
    {
        try
        {
            var existe = await _unitOfWork.Productos.CodigoExisteAsync(codigo, excludeId);
            return Result<bool>.Success(existe);
        }
        catch (Exception ex)
        {
            return Result<bool>.Failure($"Error: {ex.Message}");
        }
    }

    public async Task<Result<PagedResult<ProductoDto>>> GetProductosPaginadosAsync(
    string? buscar = null,
    string orden = "nombre",
    int pagina = 1,
    int tamañoPagina = 10)
    {
        try
        {
            var productos = await _unitOfWork.Productos.GetProductosConCategoriaAsync();

            if (!string.IsNullOrEmpty(buscar))
            {
                productos = productos.Where(p =>
                    p.Nombre.Contains(buscar, StringComparison.OrdinalIgnoreCase) ||
                    p.Codigo.Contains(buscar, StringComparison.OrdinalIgnoreCase));
            }

            productos = orden switch
            {
                "codigo" => productos.OrderBy(p => p.Codigo),
                "stock" => productos.OrderByDescending(p => p.Stocks.Sum(s => s.StockActual)),
                "precio" => productos.OrderBy(p => p.PrecioVentaMinorista),
                _ => productos.OrderBy(p => p.Nombre),
            };

            var total = productos.Count();
            var items = productos
                .Skip((pagina - 1) * tamañoPagina)
                .Take(tamañoPagina)
                .Select(p => p.ToDto())
                .ToList();

            var result = new PagedResult<ProductoDto>
            {
                Data = items,
                Page = pagina,
                PageSize = tamañoPagina,
                TotalCount = total
            };

            return Result<PagedResult<ProductoDto>>.Success(result);
        }
        catch (Exception ex)
        {
            return Result<PagedResult<ProductoDto>>.Failure($"Error: {ex.Message}");
        }
    }
}