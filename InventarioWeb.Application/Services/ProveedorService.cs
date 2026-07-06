using InventarioWeb.Application.Common;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Entities;
using InventarioWeb.Core.Mappings;

namespace InventarioWeb.Infrastructure.Services;

public interface IProveedorService
{
    Task<Result<IEnumerable<ProveedorDto>>> GetProveedoresAsync(string? buscar = null);
    Task<Result<ProveedorDto>> GetProveedorByIdAsync(int id);
    Task<Result<ProveedorDto>> CreateProveedorAsync(ProveedorDto dto);
    Task<Result<ProveedorDto>> UpdateProveedorAsync(int id, ProveedorDto dto);
    Task<Result> DeleteProveedorAsync(int id);
}

public class ProveedorService : IProveedorService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProveedorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<ProveedorDto>>> GetProveedoresAsync(string? buscar = null)
    {
        try
        {
            IEnumerable<Proveedor> proveedores;

            if (!string.IsNullOrEmpty(buscar))
                proveedores = await _unitOfWork.Proveedores.BuscarProveedoresAsync(buscar);
            else
                proveedores = await _unitOfWork.Proveedores.GetProveedoresActivosAsync();

            return Result<IEnumerable<ProveedorDto>>.Success(proveedores.Select(p => p.ToDto()));
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<ProveedorDto>>.Failure($"Error al obtener proveedores: {ex.Message}");
        }
    }

    public async Task<Result<ProveedorDto>> GetProveedorByIdAsync(int id)
    {
        try
        {
            var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);
            if (proveedor == null)
                return Result<ProveedorDto>.Failure("Proveedor no encontrado");

            return Result<ProveedorDto>.Success(proveedor.ToDto());
        }
        catch (Exception ex)
        {
            return Result<ProveedorDto>.Failure($"Error: {ex.Message}");
        }
    }

    public async Task<Result<ProveedorDto>> CreateProveedorAsync(ProveedorDto dto)
    {
        try
        {
            if (!string.IsNullOrEmpty(dto.RUC) && await _unitOfWork.Proveedores.RUCExisteAsync(dto.RUC))
                return Result<ProveedorDto>.Failure("El RUC ya está registrado");

            var proveedor = dto.ToEntity();
            proveedor.Activo = true;
            proveedor.FechaCreacion = DateTime.Now;

            await _unitOfWork.Proveedores.AddAsync(proveedor);
            await _unitOfWork.CompleteAsync();

            return Result<ProveedorDto>.Success(proveedor.ToDto(), "Proveedor creado exitosamente");
        }
        catch (Exception ex)
        {
            return Result<ProveedorDto>.Failure($"Error al crear proveedor: {ex.Message}");
        }
    }

    public async Task<Result<ProveedorDto>> UpdateProveedorAsync(int id, ProveedorDto dto)
    {
        try
        {
            if (!string.IsNullOrEmpty(dto.RUC) && await _unitOfWork.Proveedores.RUCExisteAsync(dto.RUC, id))
                return Result<ProveedorDto>.Failure("El RUC ya está registrado por otro proveedor");

            var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);
            if (proveedor == null)
                return Result<ProveedorDto>.Failure("Proveedor no encontrado");

            dto.UpdateEntity(proveedor);
            await _unitOfWork.Proveedores.UpdateAsync(proveedor);
            await _unitOfWork.CompleteAsync();

            return Result<ProveedorDto>.Success(proveedor.ToDto(), "Proveedor actualizado exitosamente");
        }
        catch (Exception ex)
        {
            return Result<ProveedorDto>.Failure($"Error al actualizar proveedor: {ex.Message}");
        }
    }

    public async Task<Result> DeleteProveedorAsync(int id)
    {
        try
        {
            var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);
            if (proveedor == null)
                return Result.Failure("Proveedor no encontrado");

            proveedor.Activo = false;
            proveedor.FechaModificacion = DateTime.Now;
            await _unitOfWork.Proveedores.UpdateAsync(proveedor);
            await _unitOfWork.CompleteAsync();

            return Result.Success("Proveedor eliminado exitosamente");
        }
        catch (Exception ex)
        {
            return Result.Failure($"Error al eliminar proveedor: {ex.Message}");
        }
    }
}