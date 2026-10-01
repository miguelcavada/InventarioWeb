using InventarioWeb.Application.Services;
using Microsoft.AspNetCore.Mvc;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;

namespace InventarioWeb.ApiRest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConsignacionesController : ControllerBase
{
    private readonly IConsignacionService _consignacionService;

    public ConsignacionesController(IConsignacionService consignacionService)
    {
        _consignacionService = consignacionService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _consignacionService.GetConsignacionesAsync();
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _consignacionService.GetConsignacionByIdAsync(id);
        if (result.IsFailure)
            return NotFound(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ConsignacionDto dto)
    {
        var result = await _consignacionService.CreateConsignacionAsync(dto);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return CreatedAtAction(nameof(GetById), new { id = result.Data!.Id },
            new { success = true, data = result.Data, message = result.SuccessMessage });
    }

    [HttpPost("registrar-venta")]
    public async Task<IActionResult> RegistrarVenta([FromBody] RegistrarVentaDto dto)
    {
        var result = await _consignacionService.RegistrarVentaAsync(dto);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, message = result.SuccessMessage });
    }

    [HttpPost("registrar-devolucion")]
    public async Task<IActionResult> RegistrarDevolucion([FromBody] RegistrarDevolucionDto dto)
    {
        var result = await _consignacionService.RegistrarDevolucionAsync(dto);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, message = result.SuccessMessage });
    }

    [HttpGet("precio-producto")]
    public async Task<IActionResult> GetPrecioProducto([FromQuery] int productoId)
    {
        var result = await _consignacionService.ObtenerPrecioProductoAsync(productoId);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data });
    }
}