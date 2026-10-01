using Microsoft.AspNetCore.Mvc;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;

namespace InventarioWeb.ApiRest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovimientosController : ControllerBase
{
    private readonly IMovimientoService _movimientoService;

    public MovimientosController(IMovimientoService movimientoService)
    {
        _movimientoService = movimientoService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string tipo = "TODOS", 
        [FromQuery] DateTime? desde = null, [FromQuery] DateTime? hasta = null)
    {
        var result = await _movimientoService.GetMovimientosAsync(tipo, desde, hasta);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _movimientoService.GetMovimientoByIdAsync(id);
        if (result.IsFailure)
            return NotFound(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MovimientoDto dto)
    {
        var result = await _movimientoService.CreateMovimientoAsync(dto);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return CreatedAtAction(nameof(GetById), new { id = result.Data!.Id },
            new { success = true, data = result.Data, message = result.SuccessMessage });
    }

    [HttpGet("precio-producto")]
    public async Task<IActionResult> GetPrecioProducto([FromQuery] int productoId, 
        [FromQuery] string tipo, [FromQuery] string tipoPrecio = "MINORISTA")
    {
        var result = await _movimientoService.ObtenerPrecioProductoAsync(productoId, tipo, tipoPrecio);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data });
    }
}