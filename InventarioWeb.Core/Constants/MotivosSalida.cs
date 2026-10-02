namespace InventarioWeb.Core.Constants;

public static class MotivosSalida
{
    public const string Venta = "VENTA";
    public const string Merma = "MERMA";
    public const string Devolucion = "DEVOLUCION";
    public const string Ajuste = "AJUSTE";
    public const string Otro = "OTRO";

    public static string GetDescripcion(string? motivo)
    {
        return motivo switch
        {
            Venta => "Venta al público",
            Merma => "Merma / Producto dañado",
            Devolucion => "Devolución a proveedor",
            Ajuste => "Ajuste de inventario",
            Otro => "Otro motivo",
            _ => "Sin especificar"
        };
    }

    public static string GetColor(string? motivo)
    {
        return motivo switch
        {
            Venta => "#28A745",      // Verde
            Merma => "#DC3545",      // Rojo
            Devolucion => "#FFC107", // Amarillo
            Ajuste => "#17A2B8",     // Info
            Otro => "#6C757D",       // Gris
            _ => "#6C757D"
        };
    }
}