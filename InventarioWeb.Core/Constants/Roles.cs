namespace InventarioWeb.Core.Constants;

public static class Roles
{
    public const string Admin = "Admin";
    public const string Gerente = "Gerente";
    public const string Operador = "Operador";
    public const string Consulta = "Consulta";

    // Grupos de roles
    public const string AdminOnly = "Admin";
    public const string AdminOrGerente = "Admin,Gerente";
    public const string AdminGerenteOperador = "Admin,Gerente,Operador";
    public const string AllRoles = "Admin,Gerente,Operador,Consulta";
}