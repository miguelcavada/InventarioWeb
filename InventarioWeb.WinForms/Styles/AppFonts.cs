using System.Drawing;

namespace InventarioWeb.WinForms.Styles;

public static class AppFonts
{
    private const string FontFamily = "Segoe UI";

    // Títulos
    public static readonly Font Titulo = new(FontFamily, 16, FontStyle.Bold);
    public static readonly Font Subtitulo = new(FontFamily, 12, FontStyle.Bold);
    public static readonly Font Header = new(FontFamily, 14, FontStyle.Bold);

    // Textos normales
    public static readonly Font Normal = new(FontFamily, 10, FontStyle.Regular);
    public static readonly Font NormalBold = new(FontFamily, 10, FontStyle.Bold);
    public static readonly Font Pequeño = new(FontFamily, 8, FontStyle.Regular);
    public static readonly Font PequeñoBold = new(FontFamily, 8, FontStyle.Bold);

    // KPIs
    public static readonly Font KpiValor = new(FontFamily, 24, FontStyle.Bold);
    public static readonly Font KpiTitulo = new(FontFamily, 9, FontStyle.Regular);
    public static readonly Font KpiIcono = new(FontFamily, 32, FontStyle.Regular);

    // Botones
    public static readonly Font Boton = new(FontFamily, 10, FontStyle.Regular);
    public static readonly Font BotonPequeño = new(FontFamily, 8, FontStyle.Regular);

    // Sidebar
    public static readonly Font Sidebar = new(FontFamily, 10, FontStyle.Regular);
    public static readonly Font SidebarBrand = new(FontFamily, 14, FontStyle.Bold);

    // Grids
    public static readonly Font GridHeader = new(FontFamily, 9, FontStyle.Bold);
    public static readonly Font GridCell = new(FontFamily, 9, FontStyle.Regular);
}