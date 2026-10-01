using Microsoft.AspNetCore.Mvc;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;

namespace InventarioWeb.ApiRest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProveedoresController : ControllerBase
{
    private readonly IProveedorService _proveedorService;

    public ProveedoresController(IProveedorService proveedorService)
    {
        _proveedorService = proveedorService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string? buscar = null)
    {
        var result = await _proveedorService.GetProveedoresAsync(buscar);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _proveedorService.GetProveedorByIdAsync(id);
        if (result.IsFailure)
            return NotFound(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProveedorDto dto)
    {
        var result = await _proveedorService.CreateProveedorAsync(dto);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return CreatedAtAction(nameof(GetById), new { id = result.Data!.Id },
            new { success = true, data = result.Data, message = result.SuccessMessage });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProveedorDto dto)
    {
        var result = await _proveedorService.UpdateProveedorAsync(id, dto);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data, message = result.SuccessMessage });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _proveedorService.DeleteProveedorAsync(id);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, message = result.SuccessMessage });
    }
}