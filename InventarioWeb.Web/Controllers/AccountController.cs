using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;

namespace InventarioWeb.Web.Controllers;

[AllowAnonymous]
public class AccountController : Controller
{
    private readonly IAuthService _authService;

    public AccountController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return RedirectToAction("Index", "Home");
        }
        return View(new LoginDto());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        if (ModelState.IsValid)
        {
            var resultado = await _authService.LoginAsync(loginDto);

            if (resultado.Success)
            {
                TempData["Mensaje"] = $"Bienvenido, {resultado.Usuario?.NombreCompleto}!";
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", resultado.Mensaje ?? "Error de autenticación");
        }

        return View(loginDto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _authService.LogoutAsync();
        return RedirectToAction("Login");
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult Register()
    {
        return View(new RegistroDto());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Register(RegistroDto registroDto)
    {
        if (ModelState.IsValid)
        {
            var resultado = await _authService.RegistrarAsync(registroDto);

            if (resultado.Success)
            {
                TempData["Mensaje"] = "Usuario registrado exitosamente";
                return RedirectToAction("Usuarios");
            }

            ModelState.AddModelError("", resultado.Mensaje ?? "Error al registrar");
        }

        return View(registroDto);
    }

    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View();
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Usuarios()
    {
        var usuarios = await _authService.GetUsuariosAsync();
        return View(usuarios);
    }
}