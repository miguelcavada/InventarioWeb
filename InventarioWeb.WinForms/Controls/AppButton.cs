using System.Drawing;
using System.Drawing.Drawing2D;
using InventarioWeb.WinForms.Styles;

namespace InventarioWeb.WinForms.Controls;

public enum AppButtonStyle
{
    Primary,
    Success,
    Warning,
    Danger,
    Secondary,
    Outline
}

public class AppButton : Button
{
    private AppButtonStyle _style = AppButtonStyle.Primary;
    private int _radius = 8;
    private bool _activo = false;

    public AppButtonStyle Style
    {
        get => _style;
        set { _style = value; AplicarEstilo(); Invalidate(); }
    }

    public int Radius
    {
        get => _radius;
        set { _radius = value; Invalidate(); }
    }

    /// <summary>
    /// Indica si el botón está en estado activo (seleccionado).
    /// Útil para botones de tipo toggle (ej: vista tabla/tarjetas).
    /// </summary>
    public bool Activo
    {
        get => _activo;
        set
        {
            _activo = value;
            AplicarEstilo();
            Invalidate();
        }
    }

    public AppButton()
    {
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Height = 38;
        Font = AppFonts.Boton;
        ForeColor = Color.White;
        Cursor = Cursors.Hand;
        Padding = new Padding(10, 0, 10, 0);

        AplicarEstilo();
    }

    private void AplicarEstilo()
    {
        switch (_style)
        {
            case AppButtonStyle.Primary:
                BackColor = AppColors.Primary;
                ForeColor = Color.White;
                break;
            case AppButtonStyle.Success:
                BackColor = AppColors.Success;
                ForeColor = Color.White;
                break;
            case AppButtonStyle.Warning:
                BackColor = AppColors.Warning;
                ForeColor = Color.White;
                break;
            case AppButtonStyle.Danger:
                BackColor = AppColors.Danger;
                ForeColor = Color.White;
                break;
            case AppButtonStyle.Secondary:
                BackColor = AppColors.Secondary;
                ForeColor = Color.White;
                break;
            case AppButtonStyle.Outline:
                // Si está activo, fondo azul; si no, fondo blanco con borde
                if (_activo)
                {
                    BackColor = AppColors.Primary;
                    ForeColor = Color.White;
                }
                else
                {
                    BackColor = Color.White;
                    ForeColor = AppColors.Primary;
                }
                break;
        }
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        var rect = new Rectangle(0, 0, Width - 1, Height - 1);
        using var path = CrearRectanguloRedondeado(rect, _radius);

        using var brush = new SolidBrush(BackColor);
        pevent.Graphics.FillPath(brush, path);

        if (_style == AppButtonStyle.Outline)
        {
            using var pen = new Pen(AppColors.Primary, 1);
            pevent.Graphics.DrawPath(pen, path);
        }

        TextRenderer.DrawText(
            pevent.Graphics,
            Text,
            Font,
            rect,
            ForeColor,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
        );
    }

    private GraphicsPath CrearRectanguloRedondeado(Rectangle rect, int radius)
    {
        var path = new GraphicsPath();
        path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
        path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
        path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
        path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
        path.CloseFigure();
        return path;
    }
}