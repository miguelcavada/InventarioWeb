using InventarioWeb.Core.DTOs;

namespace InventarioWeb.WinForms.Helpers;

public static class SessionManager
{
    public static UsuarioDto? Usuario { get; set; }

    public static bool IsAdmin => Usuario?.Rol == "Admin";
    public static bool IsGerente => Usuario?.Rol == "Gerente" || IsAdmin;
    public static bool IsOperador => Usuario?.Rol == "Operador" || IsGerente;
}