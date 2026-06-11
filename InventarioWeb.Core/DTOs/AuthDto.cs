using System.ComponentModel.DataAnnotations;

namespace InventarioWeb.Core.DTOs;

public class LoginDto
{
    [Required(ErrorMessage = "El email es obligatorio")]
    [EmailAddress(ErrorMessage = "Formato de email inválido")]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "La contraseña es obligatoria")]
    [DataType(DataType.Password)]
    [Display(Name = "Contraseña")]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "Recordarme")]
    public bool RememberMe { get; set; }
}

public class RegistroDto
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100)]
    [Display(Name = "Nombre Completo")]
    public string NombreCompleto { get; set; } = string.Empty;

    [Required(ErrorMessage = "El email es obligatorio")]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "La contraseña es obligatoria")]
    [StringLength(100, MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Contraseña")]
    public string Password { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Display(Name = "Confirmar Contraseña")]
    [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
    public string ConfirmPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "El rol es obligatorio")]
    [Display(Name = "Rol")]
    public string Rol { get; set; } = "Consulta";
}

public class AuthResponseDto
{
    public bool Success { get; set; }
    public string? Mensaje { get; set; }
    public UsuarioDto? Usuario { get; set; }
}