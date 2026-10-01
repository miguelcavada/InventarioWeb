using Microsoft.AspNetCore.Mvc;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;

namespace InventarioWeb.ApiRest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UnidadesMedidaController : ControllerBase
{
    private readonly IUnidadMedidaService _unidadMedidaService;

    public UnidadesMedidaController(IUnidadMedidaService unidadMedidaService)
    {
        _unidadMedidaService = unidadMedidaService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _unidadMedidaService.GetUnidadesAsync();
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _unidadMedidaService.GetUnidadByIdAsync(id);
        if (result.IsFailure)
            return NotFound(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UnidadMedidaDto dto)
    {
        var result = await _unidadMedidaService.CreateUnidadAsync(dto);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return CreatedAtAction(nameof(GetById), new { id = result.Data!.Id },
            new { success = true, data = result.Data, message = result.SuccessMessage });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UnidadMedidaDto dto)
    {
        var result = await _unidadMedidaService.UpdateUnidadAsync(id, dto);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data, message = result.SuccessMessage });
    }
}