using InventarioWeb.Application.Services;
using Microsoft.AspNetCore.Mvc;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;

namespace InventarioWeb.ApiRest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IProductoService _productoService;

    public ProductosController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string? buscar = null, [FromQuery] string orden = "nombre")
    {
        var result = await _productoService.GetProductosAsync(buscar, orden);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _productoService.GetProductoByIdAsync(id);
        if (result.IsFailure)
            return NotFound(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductoDto dto)
    {
        var result = await _productoService.CreateProductoAsync(dto);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return CreatedAtAction(nameof(GetById), new { id = result.Data!.Id }, 
            new { success = true, data = result.Data, message = result.SuccessMessage });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductoDto dto)
    {
        var result = await _productoService.UpdateProductoAsync(id, dto);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data, message = result.SuccessMessage });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _productoService.DeleteProductoAsync(id);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, message = result.SuccessMessage });
    }

    [HttpGet("{id}/historial-precios")]
    public async Task<IActionResult> GetHistorialPrecios(int id)
    {
        var result = await _productoService.GetHistorialPreciosAsync(id);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data });
    }

    [HttpPost("cambiar-precio")]
    public async Task<IActionResult> CambiarPrecio([FromBody] CambioPrecioDto dto)
    {
        var result = await _productoService.CambiarPrecioAsync(dto, "API");
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, message = result.SuccessMessage });
    }
}