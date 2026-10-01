using Microsoft.AspNetCore.Mvc;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;

namespace InventarioWeb.ApiRest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlmacenesController : ControllerBase
{
    private readonly IAlmacenService _almacenService;

    public AlmacenesController(IAlmacenService almacenService)
    {
        _almacenService = almacenService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _almacenService.GetAlmacenesAsync();
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _almacenService.GetAlmacenByIdAsync(id);
        if (result.IsFailure)
            return NotFound(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data });
    }

    [HttpGet("{id}/inventario")]
    public async Task<IActionResult> GetInventario(int id)
    {
        var result = await _almacenService.GetInventarioAsync(id);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AlmacenDto dto)
    {
        var result = await _almacenService.CreateAlmacenAsync(dto);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return CreatedAtAction(nameof(GetById), new { id = result.Data!.Id },
            new { success = true, data = result.Data, message = result.SuccessMessage });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] AlmacenDto dto)
    {
        var result = await _almacenService.UpdateAlmacenAsync(id, dto);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data, message = result.SuccessMessage });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _almacenService.DeleteAlmacenAsync(id);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, message = result.SuccessMessage });
    }
}