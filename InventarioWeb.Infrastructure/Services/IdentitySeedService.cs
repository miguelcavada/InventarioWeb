using InventarioWeb.Core.Constants;
using InventarioWeb.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InventarioWeb.Infrastructure.Services;

public interface IIdentitySeedService
{
    Task SeedAsync();
}

public class IdentitySeedService : IIdentitySeedService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;

    public IdentitySeedService(
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task SeedAsync()
    {
        // Crear roles si no existen
        var roles = new[] { Roles.Admin, Roles.Gerente, Roles.Operador, Roles.Consulta };

        foreach (var roleName in roles)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                await _roleManager.CreateAsync(new ApplicationRole
                {
                    Name = roleName,
                    Descripcion = $"Rol de {roleName}",
                    FechaCreacion = DateTime.Now
                });
            }
        }

        // Crear usuario Admin si no existe
        var adminEmail = "admin@inventario.com";
        var adminUser = await _userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                NombreCompleto = "Administrador del Sistema",
                EmailConfirmed = true,
                FechaRegistro = DateTime.Now,
                Activo = true
            };

            var result = await _userManager.CreateAsync(adminUser, "Admin123!");
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(adminUser, Roles.Admin);
            }
        }

        // Crear usuario Gerente
        var gerenteEmail = "gerente@inventario.com";
        var gerenteUser = await _userManager.FindByEmailAsync(gerenteEmail);

        if (gerenteUser == null)
        {
            gerenteUser = new ApplicationUser
            {
                UserName = gerenteEmail,
                Email = gerenteEmail,
                NombreCompleto = "Gerente de Inventario",
                EmailConfirmed = true,
                FechaRegistro = DateTime.Now,
                Activo = true
            };

            var result = await _userManager.CreateAsync(gerenteUser, "Gerente123!");
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(gerenteUser, Roles.Gerente);
            }
        }

        // Crear usuario Operador
        var operadorEmail = "operador@inventario.com";
        var operadorUser = await _userManager.FindByEmailAsync(operadorEmail);

        if (operadorUser == null)
        {
            operadorUser = new ApplicationUser
            {
                UserName = operadorEmail,
                Email = operadorEmail,
                NombreCompleto = "Operador de Almacén",
                EmailConfirmed = true,
                FechaRegistro = DateTime.Now,
                Activo = true
            };

            var result = await _userManager.CreateAsync(operadorUser, "Operador123!");
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(operadorUser, Roles.Operador);
            }
        }

        // Crear usuario Consulta
        var consultaEmail = "consulta@inventario.com";
        var consultaUser = await _userManager.FindByEmailAsync(consultaEmail);

        if (consultaUser == null)
        {
            consultaUser = new ApplicationUser
            {
                UserName = consultaEmail,
                Email = consultaEmail,
                NombreCompleto = "Usuario de Consulta",
                EmailConfirmed = true,
                FechaRegistro = DateTime.Now,
                Activo = true
            };

            var result = await _userManager.CreateAsync(consultaUser, "Consulta123!");
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(consultaUser, Roles.Consulta);
            }
        }
    }
}