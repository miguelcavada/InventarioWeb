using InventarioWeb.Core.DTOs;
using Microsoft.AspNetCore.Identity;

namespace InventarioWeb.WinForms.Services;

public interface IWinFormsAuthService
{
    Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    void Logout();
}

public class WinFormsAuthService : IWinFormsAuthService
{
    private readonly UserManager<InventarioWeb.Core.Entities.ApplicationUser> _userManager;
    private readonly RoleManager<InventarioWeb.Core.Entities.ApplicationRole> _roleManager;

    public WinFormsAuthService(
        UserManager<InventarioWeb.Core.Entities.ApplicationUser> userManager,
        RoleManager<InventarioWeb.Core.Entities.ApplicationRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);

        if (user == null)
        {
            return new AuthResponseDto
            {
                Success = false,
                Mensaje = "Usuario no encontrado"
            };
        }

        if (!user.Activo)
        {
            return new AuthResponseDto
            {
                Success = false,
                Mensaje = "Usuario desactivado. Contacte al administrador"
            };
        }

        // Validar contraseña SIN SignInManager (sin cookies)
        var passwordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);

        if (!passwordValid)
        {
            return new AuthResponseDto
            {
                Success = false,
                Mensaje = "Contraseña incorrecta"
            };
        }

        // Actualizar último acceso
        user.UltimoAcceso = DateTime.Now;
        await _userManager.UpdateAsync(user);

        var roles = await _userManager.GetRolesAsync(user);

        return new AuthResponseDto
        {
            Success = true,
            Mensaje = "Login exitoso",
            Usuario = new UsuarioDto
            {
                Id = user.Id,
                NombreCompleto = user.NombreCompleto,
                Email = user.Email ?? "",
                Rol = roles.FirstOrDefault() ?? "Sin rol",
                Activo = user.Activo,
                UltimoAcceso = user.UltimoAcceso
            }
        };
    }

    public void Logout()
    {
        // En WinForms no hay sesión que cerrar
    }
}