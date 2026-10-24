using System.Drawing;
using System.Drawing.Drawing2D;
using InventarioWeb.WinForms.Styles;

namespace InventarioWeb.WinForms.Controls;

public class KpiCard : Panel
{
    private Label? _lblTitulo;
    private Label? _lblValor;
    private Label? _lblIcono;
    private Label? _lblSubtitulo;

    private string _titulo = "Título";
    private string _valor = "0";
    private string _icono = "📊";
    private string _subtitulo = "";
    private Color[] _gradient = AppColors.PrimaryGradient;

    public string Titulo
    {
        get => _titulo;
        set { _titulo = value; if (_lblTitulo != null) _lblTitulo.Text = value; }
    }

    public string Valor
    {
        get => _valor;
        set { _valor = value; if (_lblValor != null) _lblValor.Text = value; }
    }

    public string Icono
    {
        get => _icono;
        set { _icono = value; if (_lblIcono != null) _lblIcono.Text = value; }
    }

    public string Subtitulo
    {
        get => _subtitulo;
        set { _subtitulo = value; if (_lblSubtitulo != null) _lblSubtitulo.Text = value; }
    }

    public Color[] Gradient
    {
        get => _gradient;
        set { _gradient = value; Invalidate(); }
    }

    public KpiCard()
    {
        DoubleBuffered = true;
        Size = new Size(240, 110);
        BackColor = Color.White;
        Margin = new Padding(8);
        Padding = new Padding(0);

        InicializarControles();
    }

    private void InicializarControles()
    {
        // Título (arriba)
        _lblTitulo = new Label
        {
            Text = _titulo,
            Font = AppFonts.KpiTitulo,
            ForeColor = Color.FromArgb(230, 255, 255, 255),
            Location = new Point(18, 15),
            AutoSize = true,
            BackColor = Color.Transparent
        };

        // Valor (grande)
        _lblValor = new Label
        {
            Text = _valor,
            Font = AppFonts.KpiValor,
            ForeColor = Color.White,
            Location = new Point(15, 35),
            AutoSize = true,
            BackColor = Color.Transparent
        };

        // Subtítulo
        _lblSubtitulo = new Label
        {
            Text = _subtitulo,
            Font = AppFonts.Pequeño,
            ForeColor = Color.FromArgb(200, 255, 255, 255),
            Location = new Point(18, 85),
            AutoSize = true,
            BackColor = Color.Transparent
        };

        // Icono (esquina derecha)
        _lblIcono = new Label
        {
            Text = _icono,
            Font = AppFonts.KpiIcono,
            ForeColor = Color.FromArgb(80, 255, 255, 255),
            Location = new Point(160, 20),
            Size = new Size(70, 70),
            TextAlign = ContentAlignment.MiddleCenter,
            BackColor = Color.Transparent
        };

        Controls.Add(_lblTitulo);
        Controls.Add(_lblValor);
        Controls.Add(_lblSubtitulo);
        Controls.Add(_lblIcono);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        // Crear rectángulo redondeado
        var rect = new Rectangle(0, 0, Width - 1, Height - 1);
        var path = CrearRectanguloRedondeado(rect, 15);

        // Gradiente de fondo
        using var brush = new LinearGradientBrush(rect, _gradient[0], _gradient[1], 45f);
        g.FillPath(brush, path);

        // Borde sutil
        using var pen = new Pen(Color.FromArgb(30, 0, 0, 0), 1);
        g.DrawPath(pen, path);
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