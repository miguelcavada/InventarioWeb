using InventarioWeb.Application.Common;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Core.Mappings;

namespace InventarioWeb.Infrastructure.Services;

public interface IUnidadMedidaService
{
    Task<Result<IEnumerable<UnidadMedidaDto>>> GetUnidadesAsync();
    Task<Result<UnidadMedidaDto>> GetUnidadByIdAsync(int id);
    Task<Result<UnidadMedidaDto>> CreateUnidadAsync(UnidadMedidaDto dto);
    Task<Result<UnidadMedidaDto>> UpdateUnidadAsync(int id, UnidadMedidaDto dto);
}

public class UnidadMedidaService : IUnidadMedidaService
{
    private readonly IUnitOfWork _unitOfWork;

    public UnidadMedidaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<UnidadMedidaDto>>> GetUnidadesAsync()
    {
        try
        {
            var unidades = await _unitOfWork.UnidadesMedida.GetUnidadesConProductosAsync();
            return Result<IEnumerable<UnidadMedidaDto>>.Success(unidades.Select(u => u.ToDto()));
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<UnidadMedidaDto>>.Failure($"Error al obtener unidades: {ex.Message}");
        }
    }

    public async Task<Result<UnidadMedidaDto>> GetUnidadByIdAsync(int id)
    {
        try
        {
            var unidad = await _unitOfWork.UnidadesMedida.GetUnidadConProductosAsync(id);
            if (unidad == null)
                return Result<UnidadMedidaDto>.Failure("Unidad de medida no encontrada");

            return Result<UnidadMedidaDto>.Success(unidad.ToDto());
        }
        catch (Exception ex)
        {
            return Result<UnidadMedidaDto>.Failure($"Error: {ex.Message}");
        }
    }

    public async Task<Result<UnidadMedidaDto>> CreateUnidadAsync(UnidadMedidaDto dto)
    {
        try
        {
            var unidad = dto.ToEntity();
            unidad.Activo = true;
            unidad.FechaCreacion = DateTime.Now;

            await _unitOfWork.UnidadesMedida.AddAsync(unidad);
            await _unitOfWork.CompleteAsync();

            return Result<UnidadMedidaDto>.Success(unidad.ToDto(), "Unidad de medida creada exitosamente");
        }
        catch (Exception ex)
        {
            return Result<UnidadMedidaDto>.Failure($"Error al crear unidad: {ex.Message}");
        }
    }

    public async Task<Result<UnidadMedidaDto>> UpdateUnidadAsync(int id, UnidadMedidaDto dto)
    {
        try
        {
            var unidad = await _unitOfWork.UnidadesMedida.GetByIdAsync(id);
            if (unidad == null)
                return Result<UnidadMedidaDto>.Failure("Unidad de medida no encontrada");

            dto.UpdateEntity(unidad);
            await _unitOfWork.UnidadesMedida.UpdateAsync(unidad);
            await _unitOfWork.CompleteAsync();

            return Result<UnidadMedidaDto>.Success(unidad.ToDto(), "Unidad de medida actualizada exitosamente");
        }
        catch (Exception ex)
        {
            return Result<UnidadMedidaDto>.Failure($"Error al actualizar unidad: {ex.Message}");
        }
    }
}