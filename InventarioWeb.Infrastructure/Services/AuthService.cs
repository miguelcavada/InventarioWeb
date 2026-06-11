using Microsoft.AspNetCore.Identity;
using InventarioWeb.Core.Entities;
using InventarioWeb.Core.DTOs;

namespace InventarioWeb.Infrastructure.Services;

public interface IAuthService
{
    Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    Task<AuthResponseDto> RegistrarAsync(RegistroDto registroDto);
    Task LogoutAsync();
    Task<List<UsuarioDto>> GetUsuariosAsync();
    Task<UsuarioDto?> GetUsuarioByIdAsync(string id);
    Task<bool> CambiarEstadoUsuarioAsync(string id, bool activo);
    Task<bool> EditarUsuarioAsync(EditarUsuarioDto usuarioDto);
    Task<bool> CambiarPasswordAsync(CambiarPasswordDto passwordDto);
    Task<List<string>> GetRolesAsync();
}

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<ApplicationRole> _roleManager;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<ApplicationRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);

        if (user == null)
        {
            return new AuthResponseDto { Success = false, Mensaje = "Usuario no encontrado" };
        }

        if (!user.Activo)
        {
            return new AuthResponseDto { Success = false, Mensaje = "Usuario desactivado" };
        }

        var result = await _signInManager.PasswordSignInAsync(
            user.UserName ?? user.Email,
            loginDto.Password,
            loginDto.RememberMe,
            lockoutOnFailure: true);

        if (result.Succeeded)
        {
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

        if (result.IsLockedOut)
        {
            return new AuthResponseDto
            {
                Success = false,
                Mensaje = "Cuenta bloqueada. Intente más tarde"
            };
        }

        return new AuthResponseDto { Success = false, Mensaje = "Contraseña incorrecta" };
    }

    public async Task<AuthResponseDto> RegistrarAsync(RegistroDto registroDto)
    {
        var existingUser = await _userManager.FindByEmailAsync(registroDto.Email);
        if (existingUser != null)
        {
            return new AuthResponseDto { Success = false, Mensaje = "El email ya está registrado" };
        }

        var user = new ApplicationUser
        {
            UserName = registroDto.Email,
            Email = registroDto.Email,
            NombreCompleto = registroDto.NombreCompleto,
            EmailConfirmed = true,
            FechaRegistro = DateTime.Now,
            Activo = true
        };

        var result = await _userManager.CreateAsync(user, registroDto.Password);

        if (result.Succeeded)
        {
            if (await _roleManager.RoleExistsAsync(registroDto.Rol))
            {
                await _userManager.AddToRoleAsync(user, registroDto.Rol);
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "Consulta");
            }

            return new AuthResponseDto
            {
                Success = true,
                Mensaje = "Usuario registrado exitosamente",
                Usuario = new UsuarioDto
                {
                    Id = user.Id,
                    NombreCompleto = user.NombreCompleto,
                    Email = user.Email,
                    Rol = registroDto.Rol
                }
            };
        }

        return new AuthResponseDto
        {
            Success = false,
            Mensaje = string.Join(", ", result.Errors.Select(e => e.Description))
        };
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<List<UsuarioDto>> GetUsuariosAsync()
    {
        var users = _userManager.Users.ToList();
        var usuariosDto = new List<UsuarioDto>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            usuariosDto.Add(new UsuarioDto
            {
                Id = user.Id,
                NombreCompleto = user.NombreCompleto,
                Email = user.Email ?? "",
                Rol = roles.FirstOrDefault() ?? "Sin rol",
                Activo = user.Activo,
                FechaRegistro = user.FechaRegistro,
                UltimoAcceso = user.UltimoAcceso
            });
        }

        return usuariosDto;
    }

    public async Task<UsuarioDto?> GetUsuarioByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return null;

        var roles = await _userManager.GetRolesAsync(user);
        return new UsuarioDto
        {
            Id = user.Id,
            NombreCompleto = user.NombreCompleto,
            Email = user.Email ?? "",
            Rol = roles.FirstOrDefault() ?? "Sin rol",
            Activo = user.Activo,
            FechaRegistro = user.FechaRegistro,
            UltimoAcceso = user.UltimoAcceso
        };
    }

    public async Task<bool> CambiarEstadoUsuarioAsync(string id, bool activo)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return false;

        user.Activo = activo;
        var result = await _userManager.UpdateAsync(user);
        return result.Succeeded;
    }

    public async Task<bool> EditarUsuarioAsync(EditarUsuarioDto usuarioDto)
    {
        var user = await _userManager.FindByIdAsync(usuarioDto.Id);
        if (user == null) return false;

        user.NombreCompleto = usuarioDto.NombreCompleto;
        user.Email = usuarioDto.Email;
        user.UserName = usuarioDto.Email;
        user.PhoneNumber = usuarioDto.PhoneNumber;

        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded)
        {
            // Actualizar rol
            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            await _userManager.AddToRoleAsync(user, usuarioDto.Rol);
            return true;
        }

        return false;
    }

    public async Task<bool> CambiarPasswordAsync(CambiarPasswordDto passwordDto)
    {
        var user = await _userManager.FindByIdAsync(passwordDto.Id);
        if (user == null) return false;

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, token, passwordDto.NewPassword);

        return result.Succeeded;
    }

    public async Task<List<string>> GetRolesAsync()
    {
        var roles = _roleManager.Roles.Select(r => r.Name ?? "").ToList();
        return await Task.FromResult(roles);
    }
}