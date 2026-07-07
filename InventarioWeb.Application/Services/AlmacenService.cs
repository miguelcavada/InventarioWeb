using InventarioWeb.Application.Common;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Mappings;

namespace InventarioWeb.Infrastructure.Services;

public interface IAlmacenService
{
    Task<Result<IEnumerable<AlmacenDto>>> GetAlmacenesAsync();
    Task<Result<AlmacenDto>> GetAlmacenByIdAsync(int id);
    Task<Result<IEnumerable<StockAlmacenDto>>> GetInventarioAsync(int almacenId);
    Task<Result<AlmacenDto>> CreateAlmacenAsync(AlmacenDto dto);
    Task<Result<AlmacenDto>> UpdateAlmacenAsync(int id, AlmacenDto dto);
    Task<Result> DeleteAlmacenAsync(int id);
}

public class AlmacenService : IAlmacenService
{
    private readonly IUnitOfWork _unitOfWork;

    public AlmacenService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<AlmacenDto>>> GetAlmacenesAsync()
    {
        try
        {
            var almacenes = await _unitOfWork.Almacenes.GetAllAsync();
            return Result<IEnumerable<AlmacenDto>>.Success(almacenes.Select(a => a.ToDto()));
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<AlmacenDto>>.Failure($"Error al obtener almacenes: {ex.Message}");
        }
    }

    public async Task<Result<AlmacenDto>> GetAlmacenByIdAsync(int id)
    {
        try
        {
            var almacen = await _unitOfWork.Almacenes.GetAlmacenConStocksAsync(id);
            if (almacen == null)
                return Result<AlmacenDto>.Failure("Almacén no encontrado");

            return Result<AlmacenDto>.Success(almacen.ToDto());
        }
        catch (Exception ex)
        {
            return Result<AlmacenDto>.Failure($"Error: {ex.Message}");
        }
    }

    public async Task<Result<IEnumerable<StockAlmacenDto>>> GetInventarioAsync(int almacenId)
    {
        try
        {
            var stocks = await _unitOfWork.StockAlmacenes.GetStocksPorAlmacenAsync(almacenId);
            return Result<IEnumerable<StockAlmacenDto>>.Success(stocks.Select(s => s.ToDto()));
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<StockAlmacenDto>>.Failure($"Error al obtener inventario: {ex.Message}");
        }
    }

    public async Task<Result<AlmacenDto>> CreateAlmacenAsync(AlmacenDto dto)
    {
        try
        {
            var almacen = dto.ToEntity();
            almacen.Activo = true;
            almacen.FechaCreacion = DateTime.Now;

            await _unitOfWork.Almacenes.AddAsync(almacen);
            await _unitOfWork.CompleteAsync();

            return Result<AlmacenDto>.Success(almacen.ToDto(), "Almacén creado exitosamente");
        }
        catch (Exception ex)
        {
            return Result<AlmacenDto>.Failure($"Error al crear almacén: {ex.Message}");
        }
    }

    public async Task<Result<AlmacenDto>> UpdateAlmacenAsync(int id, AlmacenDto dto)
    {
        try
        {
            var almacen = await _unitOfWork.Almacenes.GetByIdAsync(id);
            if (almacen == null)
                return Result<AlmacenDto>.Failure("Almacén no encontrado");

            dto.UpdateEntity(almacen);
            await _unitOfWork.Almacenes.UpdateAsync(almacen);
            await _unitOfWork.CompleteAsync();

            return Result<AlmacenDto>.Success(almacen.ToDto(), "Almacén actualizado exitosamente");
        }
        catch (Exception ex)
        {
            return Result<AlmacenDto>.Failure($"Error al actualizar almacén: {ex.Message}");
        }
    }

    public async Task<Result> DeleteAlmacenAsync(int id)
    {
        try
        {
            var almacen = await _unitOfWork.Almacenes.GetAlmacenConStocksAsync(id);
            if (almacen == null)
                return Result.Failure("Almacén no encontrado");

            if (almacen.Stocks != null && almacen.Stocks.Any(s => s.StockActual > 0))
                return Result.Failure("No se puede eliminar porque tiene productos con stock");

            almacen.Activo = false;
            almacen.FechaModificacion = DateTime.Now;
            await _unitOfWork.Almacenes.DeleteAsync(almacen);
            await _unitOfWork.CompleteAsync();

            return Result.Success("Almacén eliminado exitosamente");
        }
        catch (Exception ex)
        {
            return Result.Failure($"Error al eliminar almacén: {ex.Message}");
        }
    }
}