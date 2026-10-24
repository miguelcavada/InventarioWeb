using System.Drawing;
using System.Drawing.Drawing2D;
using InventarioWeb.WinForms.Styles;

namespace InventarioWeb.WinForms.Controls;

public class StatCard : Panel
{
    private Label? _lblTitulo;
    private Label? _lblValor;
    private Label? _lblIcono;
    private Color _iconColor = AppColors.Primary;

    public string Titulo
    {
        get => _lblTitulo?.Text ?? "";
        set { if (_lblTitulo != null) _lblTitulo.Text = value; }
    }

    public string Valor
    {
        get => _lblValor?.Text ?? "";
        set { if (_lblValor != null) _lblValor.Text = value; }
    }

    public string Icono
    {
        get => _lblIcono?.Text ?? "";
        set { if (_lblIcono != null) _lblIcono.Text = value; }
    }

    public Color IconColor
    {
        get => _iconColor;
        set
        {
            _iconColor = value;
            if (_lblIcono != null) _lblIcono.ForeColor = value;
            Invalidate();
        }
    }

    public StatCard()
    {
        DoubleBuffered = true;
        Size = new Size(240, 100);
        BackColor = Color.White;
        Margin = new Padding(8);

        _lblIcono = new Label
        {
            Text = "📊",
            Font = new Font("Segoe UI", 24),
            ForeColor = _iconColor,
            Location = new Point(15, 15),
            Size = new Size(50, 50),
            TextAlign = ContentAlignment.MiddleCenter,
            BackColor = Color.Transparent
        };

        _lblTitulo = new Label
        {
            Text = "Título",
            Font = AppFonts.Pequeño,
            ForeColor = AppColors.TextMuted,
            Location = new Point(75, 20),
            AutoSize = true,
            BackColor = Color.Transparent
        };

        _lblValor = new Label
        {
            Text = "0",
            Font = new Font("Segoe UI", 18, FontStyle.Bold),
            ForeColor = AppColors.TextPrimary,
            Location = new Point(75, 42),
            AutoSize = true,
            BackColor = Color.Transparent
        };

        Controls.Add(_lblIcono);
        Controls.Add(_lblTitulo);
        Controls.Add(_lblValor);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        var rect = new Rectangle(0, 0, Width - 1, Height - 1);
        var path = CrearRectanguloRedondeado(rect, 12);

        // Fondo blanco con sombra sutil
        g.FillPath(new SolidBrush(Color.White), path);

        // Borde sutil
        using var pen = new Pen(AppColors.Border, 1);
        g.DrawPath(pen, path);

        // Barra de color a la izquierda
        using var brush = new SolidBrush(_iconColor);
        g.FillRectangle(brush, 0, 15, 4, Height - 30);
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