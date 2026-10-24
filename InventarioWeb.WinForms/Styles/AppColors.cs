using System.Drawing;

namespace InventarioWeb.WinForms.Styles;

public static class AppColors
{
    // Colores principales
    public static readonly Color Primary = Color.FromArgb(67, 97, 238);
    public static readonly Color PrimaryDark = Color.FromArgb(58, 12, 163);
    public static readonly Color Success = Color.FromArgb(46, 196, 182);
    public static readonly Color SuccessDark = Color.FromArgb(32, 163, 158);
    public static readonly Color Warning = Color.FromArgb(255, 159, 28);
    public static readonly Color WarningDark = Color.FromArgb(255, 109, 0);
    public static readonly Color Danger = Color.FromArgb(231, 29, 54);
    public static readonly Color DangerDark = Color.FromArgb(201, 24, 74);
    public static readonly Color Info = Color.FromArgb(67, 97, 238);
    public static readonly Color Secondary = Color.FromArgb(108, 117, 125);

    // Fondos
    public static readonly Color DarkBg = Color.FromArgb(26, 26, 46);
    public static readonly Color SidebarBg = Color.FromArgb(26, 26, 46);
    public static readonly Color SidebarHover = Color.FromArgb(40, 40, 60);
    public static readonly Color CardBg = Color.White;
    public static readonly Color LightBg = Color.FromArgb(248, 249, 250);
    public static readonly Color PanelBg = Color.FromArgb(240, 240, 245);

    // Textos
    public static readonly Color TextPrimary = Color.FromArgb(33, 37, 41);
    public static readonly Color TextMuted = Color.FromArgb(108, 117, 125);
    public static readonly Color TextLight = Color.White;
    public static readonly Color TextOnPrimary = Color.White;

    // Estados
    public static readonly Color StockNormal = Color.FromArgb(46, 196, 182);
    public static readonly Color StockBajo = Color.FromArgb(255, 159, 28);
    public static readonly Color StockAgotado = Color.FromArgb(231, 29, 54);
    public static readonly Color RowHover = Color.FromArgb(245, 247, 250);
    public static readonly Color RowSelected = Color.FromArgb(220, 235, 255);

    // Bordes
    public static readonly Color Border = Color.FromArgb(230, 230, 230);
    public static readonly Color BorderDark = Color.FromArgb(200, 200, 200);

    // Gradientes para cards de KPI
    public static Color[] PrimaryGradient => new[] { Primary, PrimaryDark };
    public static Color[] SuccessGradient => new[] { Success, SuccessDark };
    public static Color[] WarningGradient => new[] { Warning, WarningDark };
    public static Color[] DangerGradient => new[] { Danger, DangerDark };
    public static Color[] InfoGradient => new[] { Color.FromArgb(54, 162, 235), Color.FromArgb(30, 100, 180) };
}