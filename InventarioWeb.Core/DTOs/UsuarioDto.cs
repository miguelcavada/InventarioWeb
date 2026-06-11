using System.ComponentModel.DataAnnotations;

namespace InventarioWeb.Core.DTOs;

public class UsuarioDto
{
    public string Id { get; set; } = string.Empty;
    public string NombreCompleto { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public string Rol { get; set; } = string.Empty;
    public bool Activo { get; set; }
    public DateTime FechaRegistro { get; set; }
    public DateTime? UltimoAcceso { get; set; }
}

public class EditarUsuarioDto
{
    public string Id { get; set; } = string.Empty;

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100)]
    [Display(Name = "Nombre Completo")]
    public string NombreCompleto { get; set; } = string.Empty;

    [Required(ErrorMessage = "El email es obligatorio")]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Teléfono")]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "El rol es obligatorio")]
    [Display(Name = "Rol")]
    public string Rol { get; set; } = string.Empty;
}

public class CambiarPasswordDto
{
    public string Id { get; set; } = string.Empty;

    [Required(ErrorMessage = "La contraseña es obligatoria")]
    [StringLength(100, MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Nueva Contraseña")]
    public string NewPassword { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Display(Name = "Confirmar Contraseña")]
    [Compare("NewPassword", ErrorMessage = "Las contraseñas no coinciden")]
    public string ConfirmPassword { get; set; } = string.Empty;
}