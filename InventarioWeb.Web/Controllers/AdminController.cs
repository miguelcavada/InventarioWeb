using InventarioWeb.Core.Constants;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventarioWeb.Web.Controllers;

[Authorize(Roles = Roles.AdminOnly)]
public class AdminController : Controller
{
    private readonly IAuthService _authService;

    public AdminController(IAuthService authService)
    {
        _authService = authService;
    }

    // GET: Admin/Usuarios
    [HttpGet]
    public async Task<IActionResult> Usuarios()
    {
        var usuarios = await _authService.GetUsuariosAsync();
        return View(usuarios);
    }

    // GET: Admin/CrearUsuario
    [HttpGet]
    public async Task<IActionResult> CrearUsuario()
    {
        await CargarRolesAsync();
        return View(new RegistroDto());
    }

    // POST: Admin/CrearUsuario
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CrearUsuario(RegistroDto registroDto)
    {
        if (ModelState.IsValid)
        {
            var resultado = await _authService.RegistrarAsync(registroDto);

            if (resultado.Success)
            {
                TempData["Mensaje"] = "Usuario creado exitosamente";
                return RedirectToAction(nameof(Usuarios));
            }

            ModelState.AddModelError("", resultado.Mensaje ?? "Error al crear usuario");
        }

        await CargarRolesAsync();
        return View(registroDto);
    }

    // GET: Admin/EditarUsuario/5
    [HttpGet]
    public async Task<IActionResult> EditarUsuario(string id)
    {
        var usuario = await _authService.GetUsuarioByIdAsync(id);
        if (usuario == null) return NotFound();

        var model = new EditarUsuarioDto
        {
            Id = usuario.Id,
            NombreCompleto = usuario.NombreCompleto,
            Email = usuario.Email,
            PhoneNumber = usuario.PhoneNumber,
            Rol = usuario.Rol
        };

        await CargarRolesAsync(usuario.Rol);
        return View(model);
    }

    // POST: Admin/EditarUsuario/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditarUsuario(EditarUsuarioDto usuarioDto)
    {
        if (ModelState.IsValid)
        {
            var resultado = await _authService.EditarUsuarioAsync(usuarioDto);

            if (resultado)
            {
                TempData["Mensaje"] = "Usuario actualizado exitosamente";
                return RedirectToAction(nameof(Usuarios));
            }

            ModelState.AddModelError("", "Error al actualizar usuario");
        }

        await CargarRolesAsync(usuarioDto.Rol);
        return View(usuarioDto);
    }

    // GET: Admin/CambiarPassword/5
    [HttpGet]
    public async Task<IActionResult> CambiarPassword(string id)
    {
        var usuario = await _authService.GetUsuarioByIdAsync(id);
        if (usuario == null) return NotFound();

        ViewBag.UsuarioNombre = usuario.NombreCompleto;
        return View(new CambiarPasswordDto { Id = id });
    }

    // POST: Admin/CambiarPassword/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CambiarPassword(CambiarPasswordDto passwordDto)
    {
        if (ModelState.IsValid)
        {
            var resultado = await _authService.CambiarPasswordAsync(passwordDto);

            if (resultado)
            {
                TempData["Mensaje"] = "Contraseña cambiada exitosamente";
                return RedirectToAction(nameof(Usuarios));
            }

            ModelState.AddModelError("", "Error al cambiar contraseña");
        }

        var usuario = await _authService.GetUsuarioByIdAsync(passwordDto.Id);
        ViewBag.UsuarioNombre = usuario?.NombreCompleto;
        return View(passwordDto);
    }

    // POST: Admin/CambiarEstado/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CambiarEstado(string id, bool activo)
    {
        var resultado = await _authService.CambiarEstadoUsuarioAsync(id, activo);

        if (resultado)
        {
            TempData["Mensaje"] = activo ? "Usuario activado exitosamente" : "Usuario desactivado exitosamente";
        }
        else
        {
            TempData["Error"] = "Error al cambiar estado del usuario";
        }

        return RedirectToAction(nameof(Usuarios));
    }

    private async Task CargarRolesAsync(string? selectedRole = null)
    {
        var roles = await _authService.GetRolesAsync();
        ViewBag.Roles = new SelectList(roles, selectedRole);
    }
}