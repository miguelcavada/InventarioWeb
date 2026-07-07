using InventarioWeb.Application.Common;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Mappings;

namespace InventarioWeb.Infrastructure.Services;

public interface ICategoriaService
{
    Task<Result<IEnumerable<CategoriaDto>>> GetCategoriasAsync();
    Task<Result<CategoriaDto>> GetCategoriaByIdAsync(int id);
    Task<Result<IEnumerable<ProductoDto>>> GetProductosPorCategoriaAsync(int categoriaId);
    Task<Result<CategoriaDto>> CreateCategoriaAsync(CategoriaDto dto);
    Task<Result<CategoriaDto>> UpdateCategoriaAsync(int id, CategoriaDto dto);
    Task<Result> DeleteCategoriaAsync(int id);
}

public class CategoriaService : ICategoriaService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoriaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<CategoriaDto>>> GetCategoriasAsync()
    {
        try
        {
            var categorias = await _unitOfWork.Categorias.GetCategoriasConProductosAsync();
            return Result<IEnumerable<CategoriaDto>>.Success(categorias.Select(c => c.ToDto()));
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<CategoriaDto>>.Failure($"Error al obtener categorías: {ex.Message}");
        }
    }

    public async Task<Result<CategoriaDto>> GetCategoriaByIdAsync(int id)
    {
        try
        {
            var categoria = await _unitOfWork.Categorias.GetCategoriaConProductosAsync(id);
            if (categoria == null)
                return Result<CategoriaDto>.Failure("Categoría no encontrada");

            return Result<CategoriaDto>.Success(categoria.ToDto());
        }
        catch (Exception ex)
        {
            return Result<CategoriaDto>.Failure($"Error: {ex.Message}");
        }
    }

    public async Task<Result<IEnumerable<ProductoDto>>> GetProductosPorCategoriaAsync(int categoriaId)
    {
        try
        {
            var categoria = await _unitOfWork.Categorias.GetCategoriaConProductosAsync(categoriaId);
            if (categoria == null)
                return Result<IEnumerable<ProductoDto>>.Failure("Categoría no encontrada");

            var productos = categoria.Productos.Where(p => p.Activo).Select(p => p.ToDto());
            return Result<IEnumerable<ProductoDto>>.Success(productos);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<ProductoDto>>.Failure($"Error: {ex.Message}");
        }
    }

    public async Task<Result<CategoriaDto>> CreateCategoriaAsync(CategoriaDto dto)
    {
        try
        {
            var categoria = dto.ToEntity();
            categoria.FechaCreacion = DateTime.Now;
            categoria.Activo = true;

            await _unitOfWork.Categorias.AddAsync(categoria);
            await _unitOfWork.CompleteAsync();

            return Result<CategoriaDto>.Success(categoria.ToDto(), "Categoría creada exitosamente");
        }
        catch (Exception ex)
        {
            return Result<CategoriaDto>.Failure($"Error al crear categoría: {ex.Message}");
        }
    }

    public async Task<Result<CategoriaDto>> UpdateCategoriaAsync(int id, CategoriaDto dto)
    {
        try
        {
            var categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
            if (categoria == null)
                return Result<CategoriaDto>.Failure("Categoría no encontrada");

            dto.UpdateEntity(categoria);
            await _unitOfWork.Categorias.UpdateAsync(categoria);
            await _unitOfWork.CompleteAsync();

            return Result<CategoriaDto>.Success(categoria.ToDto(), "Categoría actualizada exitosamente");
        }
        catch (Exception ex)
        {
            return Result<CategoriaDto>.Failure($"Error al actualizar categoría: {ex.Message}");
        }
    }

    public async Task<Result> DeleteCategoriaAsync(int id)
    {
        try
        {
            var categoria = await _unitOfWork.Categorias.GetCategoriaConProductosAsync(id);
            if (categoria == null)
                return Result.Failure("Categoría no encontrada");

            if (categoria.Productos.Any(p => p.Activo))
                return Result.Failure("No se puede eliminar porque tiene productos activos");

            categoria.Activo = false;
            categoria.FechaModificacion = DateTime.Now;
            await _unitOfWork.Categorias.DeleteAsync(categoria);
            await _unitOfWork.CompleteAsync();

            return Result.Success("Categoría eliminada exitosamente");
        }
        catch (Exception ex)
        {
            return Result.Failure($"Error al eliminar categoría: {ex.Message}");
        }
    }
}