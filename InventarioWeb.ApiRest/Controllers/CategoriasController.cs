using Microsoft.AspNetCore.Mvc;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;

namespace InventarioWeb.ApiRest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;

    public CategoriasController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _categoriaService.GetCategoriasAsync();
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _categoriaService.GetCategoriaByIdAsync(id);
        if (result.IsFailure)
            return NotFound(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data });
    }

    [HttpGet("{id}/productos")]
    public async Task<IActionResult> GetProductos(int id)
    {
        var result = await _categoriaService.GetProductosPorCategoriaAsync(id);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoriaDto dto)
    {
        var result = await _categoriaService.CreateCategoriaAsync(dto);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return CreatedAtAction(nameof(GetById), new { id = result.Data!.Id },
            new { success = true, data = result.Data, message = result.SuccessMessage });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CategoriaDto dto)
    {
        var result = await _categoriaService.UpdateCategoriaAsync(id, dto);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, data = result.Data, message = result.SuccessMessage });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _categoriaService.DeleteCategoriaAsync(id);
        if (result.IsFailure)
            return BadRequest(new { success = false, error = result.ErrorMessage });
        return Ok(new { success = true, message = result.SuccessMessage });
    }
}