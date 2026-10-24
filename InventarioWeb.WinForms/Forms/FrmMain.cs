using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using InventarioWeb.WinForms.Controls;
using InventarioWeb.WinForms.Helpers;
using InventarioWeb.WinForms.Styles;
using Microsoft.Extensions.DependencyInjection;

namespace InventarioWeb.WinForms.Forms;

public partial class FrmMain : Form
{
    private readonly IDashboardService _dashboardService;

    // KPIs
    private KpiCard? _kpiProductos;
    private KpiCard? _kpiStockBajo;
    private KpiCard? _kpiEntradas;
    private KpiCard? _kpiSalidas;
    private KpiCard? _kpiValorInventario;

    // Paneles del dashboard
    private Panel? _panelGraficoCategorias;
    private Panel? _panelGraficoEstado;
    private Panel? _panelUltimosMovimientos;
    private Label? _lblBienvenida;
    private Label? _lblFechaActual;
    private AppButton? _btnRefrescar;

    public FrmMain(IDashboardService dashboardService)
    {
        InitializeComponent();
        _dashboardService = dashboardService;
    }

    private async void FrmMain_Load(object sender, EventArgs e)
    {
        // Aplicar el renderer oscuro
        menuStrip.Renderer = new DarkMenuRenderer();

        // Configurar menú según rol
        ConfigurarMenuPorRol();

        // Construir dashboard
        ConstruirDashboard();

        // Cargar datos
        await CargarDashboardAsync();
    }

    // ============================================================
    // CONFIGURACIÓN DE MENÚ SEGÚN ROL
    // ============================================================
    private void ConfigurarMenuPorRol()
    {
        // Mostrar nombre del usuario en el menú
        menuSesionUsuario.Text = $"👤 {SessionManager.Usuario?.NombreCompleto} ({SessionManager.Usuario?.Rol})";

        // Solo Admin puede ver Administración
        menuAdministracion.Visible = SessionManager.IsAdmin;

        // Solo Admin y Gerente pueden crear productos/almacenes
        bool puedeGestionar = SessionManager.IsAdmin || SessionManager.IsGerente;

        menuProductosNuevo.Visible = puedeGestionar;
        menuAlmacenesNuevo.Visible = puedeGestionar;
        menuProductosCategorias.Visible = puedeGestionar;
        menuProductosUnidades.Visible = puedeGestionar;

        // Operador y superiores pueden crear movimientos
        bool puedeOperar = SessionManager.IsAdmin || SessionManager.IsGerente || SessionManager.IsOperador;
        menuMovimientosEntrada.Visible = puedeOperar;
        menuMovimientosSalida.Visible = puedeOperar;
    }

    // ============================================================
    // CONSTRUCCIÓN DEL DASHBOARD
    // ============================================================
    private void ConstruirDashboard()
    {
        var panelPrincipal = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = AppColors.LightBg,
            Padding = new Padding(20),
            AutoScroll = true
        };

        // HEADER
        var panelHeader = new Panel
        {
            Dock = DockStyle.Top,
            Height = 70,
            BackColor = AppColors.LightBg
        };

        _lblBienvenida = new Label
        {
            Text = $"¡Bienvenido, {SessionManager.Usuario?.NombreCompleto}! 👋",
            Font = AppFonts.Titulo,
            ForeColor = AppColors.TextPrimary,
            Location = new Point(0, 5),
            AutoSize = true
        };

        _lblFechaActual = new Label
        {
            Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy"),
            Font = AppFonts.Normal,
            ForeColor = AppColors.TextMuted,
            Location = new Point(0, 40),
            AutoSize = true
        };

        _btnRefrescar = new AppButton
        {
            Text = "🔄 Refrescar",
            Style = AppButtonStyle.Primary,
            Size = new Size(140, 38),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Location = new Point(panelHeader.Width - 160, 15)
        };
        _btnRefrescar.Click += async (s, e) => await CargarDashboardAsync();

        panelHeader.Controls.Add(_lblBienvenida);
        panelHeader.Controls.Add(_lblFechaActual);
        panelHeader.Controls.Add(_btnRefrescar);

        panelHeader.Resize += (s, e) =>
        {
            if (_btnRefrescar != null)
                _btnRefrescar.Location = new Point(panelHeader.Width - _btnRefrescar.Width - 10, 15);
        };

        // CONTENEDOR CON SCROLL
        var panelScroll = new Panel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            BackColor = AppColors.LightBg,
            Padding = new Padding(0, 15, 0, 0)
        };

        // KPIs
        var panelKpis = new Panel
        {
            Dock = DockStyle.Top,
            Height = 130,
            BackColor = AppColors.LightBg,
            Padding = new Padding(0, 0, 0, 15)
        };

        _kpiProductos = new KpiCard
        {
            Titulo = "Total Productos",
            Valor = "0",
            Icono = "📦",
            Subtitulo = "registrados",
            Gradient = AppColors.PrimaryGradient,
            Location = new Point(0, 0),
            Size = new Size(220, 110)
        };

        _kpiStockBajo = new KpiCard
        {
            Titulo = "Stock Bajo",
            Valor = "0",
            Icono = "⚠️",
            Subtitulo = "requieren atención",
            Gradient = AppColors.WarningGradient,
            Location = new Point(235, 0),
            Size = new Size(220, 110)
        };

        _kpiEntradas = new KpiCard
        {
            Titulo = "Entradas",
            Valor = "0",
            Icono = "📥",
            Subtitulo = "movimientos",
            Gradient = AppColors.SuccessGradient,
            Location = new Point(470, 0),
            Size = new Size(220, 110)
        };

        _kpiSalidas = new KpiCard
        {
            Titulo = "Salidas",
            Valor = "0",
            Icono = "📤",
            Subtitulo = "movimientos",
            Gradient = AppColors.DangerGradient,
            Location = new Point(705, 0),
            Size = new Size(220, 110)
        };

        _kpiValorInventario = new KpiCard
        {
            Titulo = "Valor Inventario",
            Valor = "$0",
            Icono = "💰",
            Subtitulo = "en productos",
            Gradient = AppColors.InfoGradient,
            Location = new Point(940, 0),
            Size = new Size(220, 110)
        };

        panelKpis.Controls.Add(_kpiProductos);
        panelKpis.Controls.Add(_kpiStockBajo);
        panelKpis.Controls.Add(_kpiEntradas);
        panelKpis.Controls.Add(_kpiSalidas);
        panelKpis.Controls.Add(_kpiValorInventario);

        // GRÁFICOS
        var panelGraficos = new Panel
        {
            Dock = DockStyle.Top,
            Height = 320,
            BackColor = AppColors.LightBg,
            Padding = new Padding(0, 0, 0, 15)
        };

        _panelGraficoCategorias = CrearPanelConTitulo("📊 Productos por Categoría", new Size(620, 300), new Point(0, 0));
        _panelGraficoEstado = CrearPanelConTitulo("🥧 Estado del Inventario", new Size(400, 300), new Point(635, 0));

        panelGraficos.Controls.Add(_panelGraficoCategorias);
        panelGraficos.Controls.Add(_panelGraficoEstado);

        // ÚLTIMOS MOVIMIENTOS
        _panelUltimosMovimientos = CrearPanelConTitulo("📋 Últimos Movimientos", new Size(1030, 280), new Point(0, 0));
        _panelUltimosMovimientos.Dock = DockStyle.Top;
        _panelUltimosMovimientos.Height = 280;

        // Agregar en orden
        panelScroll.Controls.Add(_panelUltimosMovimientos);
        panelScroll.Controls.Add(panelGraficos);
        panelScroll.Controls.Add(panelKpis);

        panelPrincipal.Controls.Add(panelScroll);
        panelPrincipal.Controls.Add(panelHeader);

        Controls.Add(panelPrincipal);
    }

    // ============================================================
    // CARGA DE DATOS
    // ============================================================
    private async Task CargarDashboardAsync()
    {
        try
        {
            if (_btnRefrescar != null) _btnRefrescar.Enabled = false;

            var result = await _dashboardService.GetDashboardDataAsync();

            if (!result.IsSuccess || result.Data == null)
            {
                Toast.Error(this, result.ErrorMessage ?? "Error al cargar el dashboard");
                return;
            }

            var data = result.Data;

            if (_kpiProductos != null) _kpiProductos.Valor = data.TotalProductos.ToString();
            if (_kpiStockBajo != null) _kpiStockBajo.Valor = data.StockBajo.ToString();
            if (_kpiEntradas != null) _kpiEntradas.Valor = data.TotalEntradas.ToString();
            if (_kpiSalidas != null) _kpiSalidas.Valor = data.TotalSalidas.ToString();
            if (_kpiValorInventario != null) _kpiValorInventario.Valor = data.ValorInventario.ToString("C0");

            DibujarGraficoCategorias(data.ProductosPorCategoria);
            DibujarGraficoEstado(data.TotalProductos, data.StockBajo);
            DibujarUltimosMovimientos(data.UltimosMovimientos);
        }
        catch (Exception ex)
        {
            Toast.Error(this, $"Error: {ex.Message}");
        }
        finally
        {
            if (_btnRefrescar != null) _btnRefrescar.Enabled = true;
        }
    }

    // ============================================================
    // GRÁFICOS (mismo código que tenías)
    // ============================================================
    private void DibujarGraficoCategorias(IEnumerable<ProductosPorCategoriaDto> categorias)
    {
        if (_panelGraficoCategorias == null) return;

        var lista = categorias.ToList();

        var picBoxAnterior = _panelGraficoCategorias.Controls.OfType<PictureBox>().FirstOrDefault();
        if (picBoxAnterior != null) _panelGraficoCategorias.Controls.Remove(picBoxAnterior);

        if (!lista.Any()) return;

        var bmp = new Bitmap(_panelGraficoCategorias.Width - 30, _panelGraficoCategorias.Height - 60);
        using var g = Graphics.FromImage(bmp);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Clear(Color.White);

        int margen = 10;
        int anchoDisponible = bmp.Width - margen * 2 - 140;
        int altoBarra = 25;
        int espacio = 12;
        int y = margen;
        int maxValor = lista.Max(d => d.Cantidad);
        if (maxValor == 0) maxValor = 1;

        var colores = new[]
        {
            AppColors.Primary, AppColors.Success, AppColors.Warning, AppColors.Danger,
            Color.FromArgb(156, 102, 255), Color.FromArgb(255, 99, 132),
            Color.FromArgb(54, 162, 235), Color.FromArgb(255, 206, 86)
        };

        var fontItem = new Font("Segoe UI", 9);
        var fontValor = new Font("Segoe UI", 9, FontStyle.Bold);

        int i = 0;
        foreach (var dato in lista.Take(8))
        {
            int ancho = (int)((double)dato.Cantidad / maxValor * anchoDisponible);

            using var brush = new SolidBrush(colores[i % colores.Length]);
            g.FillRectangle(brush, margen + 120, y, ancho, altoBarra);

            var nombre = dato.CategoriaNombre.Length > 15
                ? dato.CategoriaNombre.Substring(0, 15) + "..."
                : dato.CategoriaNombre;
            g.DrawString(nombre, fontItem, Brushes.Black, margen, y + 5);
            g.DrawString(dato.Cantidad.ToString(), fontValor, Brushes.Black, margen + 120 + ancho + 5, y + 5);

            y += altoBarra + espacio;
            i++;
        }

        _panelGraficoCategorias.Controls.Add(new PictureBox
        {
            Location = new Point(15, 45),
            Size = bmp.Size,
            SizeMode = PictureBoxSizeMode.Normal,
            BackColor = Color.Transparent,
            Image = bmp
        });
    }

    private void DibujarGraficoEstado(int totalProductos, int stockBajo)
    {
        if (_panelGraficoEstado == null) return;

        var picBoxAnterior = _panelGraficoEstado.Controls.OfType<PictureBox>().FirstOrDefault();
        if (picBoxAnterior != null) _panelGraficoEstado.Controls.Remove(picBoxAnterior);

        if (totalProductos == 0) return;

        int stockNormal = totalProductos - stockBajo;

        var bmp = new Bitmap(_panelGraficoEstado.Width - 30, _panelGraficoEstado.Height - 60);
        using var g = Graphics.FromImage(bmp);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Clear(Color.White);

        int centroX = bmp.Width / 2;
        int centroY = bmp.Height / 2 - 15;
        int radio = Math.Min(bmp.Width, bmp.Height) / 3 - 15;
        int grosor = 30;

        float anguloInicio = -90;

        if (stockNormal > 0)
        {
            float angulo = (float)stockNormal / totalProductos * 360;
            using var pen = new Pen(AppColors.Success, grosor);
            g.DrawArc(pen, centroX - radio, centroY - radio, radio * 2, radio * 2, anguloInicio, angulo);
            anguloInicio += angulo;
        }

        if (stockBajo > 0)
        {
            float angulo = (float)stockBajo / totalProductos * 360;
            using var pen = new Pen(AppColors.Warning, grosor);
            g.DrawArc(pen, centroX - radio, centroY - radio, radio * 2, radio * 2, anguloInicio, angulo);
        }

        var fontCentro = new Font("Segoe UI", 16, FontStyle.Bold);
        var textoTotal = totalProductos.ToString();
        var sizeTexto = g.MeasureString(textoTotal, fontCentro);
        g.DrawString(textoTotal, fontCentro, Brushes.DarkBlue,
            centroX - sizeTexto.Width / 2, centroY - sizeTexto.Height / 2 - 5);

        var fontLabel = new Font("Segoe UI", 8);
        var sizeLabel = g.MeasureString("Productos", fontLabel);
        g.DrawString("Productos", fontLabel, Brushes.Gray,
            centroX - sizeLabel.Width / 2, centroY + sizeTexto.Height / 2 - 5);

        int leyendaY = bmp.Height - 45;
        int leyendaX = 20;

        g.FillRectangle(new SolidBrush(AppColors.Success), leyendaX, leyendaY, 12, 12);
        g.DrawString($"Normal: {stockNormal}", new Font("Segoe UI", 8), Brushes.Black, leyendaX + 18, leyendaY);

        g.FillRectangle(new SolidBrush(AppColors.Warning), leyendaX + 130, leyendaY, 12, 12);
        g.DrawString($"Bajo: {stockBajo}", new Font("Segoe UI", 8), Brushes.Black, leyendaX + 148, leyendaY);

        _panelGraficoEstado.Controls.Add(new PictureBox
        {
            Location = new Point(15, 45),
            Size = bmp.Size,
            SizeMode = PictureBoxSizeMode.Normal,
            BackColor = Color.Transparent,
            Image = bmp
        });
    }

    private void DibujarUltimosMovimientos(IEnumerable<UltimoMovimientoDto> movimientos)
    {
        if (_panelUltimosMovimientos == null) return;

        var gridExistente = _panelUltimosMovimientos.Controls.OfType<DataGridView>().FirstOrDefault();
        if (gridExistente != null) _panelUltimosMovimientos.Controls.Remove(gridExistente);

        var dgv = new DataGridView
        {
            Location = new Point(15, 45),
            Size = new Size(_panelUltimosMovimientos.Width - 30, _panelUltimosMovimientos.Height - 60),
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            ReadOnly = true
        };

        GridStyles.Aplicar(dgv);

        dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTipo", HeaderText = "Tipo", FillWeight = 60 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDocumento", HeaderText = "Documento", FillWeight = 80 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colFecha", HeaderText = "Fecha", FillWeight = 90 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colOrigen", HeaderText = "Origen", FillWeight = 100 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDestino", HeaderText = "Destino", FillWeight = 100 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTotal", HeaderText = "Total", FillWeight = 70 });

        foreach (var mov in movimientos)
        {
            int index = dgv.Rows.Add(
                mov.Tipo, mov.NumeroDocumento,
                mov.FechaMovimiento.ToString("dd/MM/yyyy HH:mm"),
                mov.AlmacenOrigenNombre ?? "-",
                mov.AlmacenDestinoNombre ?? "-",
                mov.Total.ToString("C2"));

            var cellTipo = dgv.Rows[index].Cells["colTipo"];
            switch (mov.Tipo)
            {
                case "ENTRADA":
                    cellTipo.Style.BackColor = Color.FromArgb(220, 255, 220);
                    cellTipo.Style.ForeColor = Color.DarkGreen;
                    break;
                case "SALIDA":
                    cellTipo.Style.BackColor = Color.FromArgb(255, 220, 220);
                    cellTipo.Style.ForeColor = Color.DarkRed;
                    break;
                case "TRASLADO":
                    cellTipo.Style.BackColor = Color.FromArgb(220, 235, 255);
                    cellTipo.Style.ForeColor = Color.DarkBlue;
                    break;
            }
        }

        _panelUltimosMovimientos.Controls.Add(dgv);
    }

    // ============================================================
    // UTILIDADES
    // ============================================================
    private Panel CrearPanelConTitulo(string titulo, Size size, Point location)
    {
        var panel = new Panel
        {
            Size = size,
            Location = location,
            BackColor = Color.White,
            Padding = new Padding(15)
        };

        panel.Paint += (s, e) =>
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
            using var path = CrearRectanguloRedondeado(rect, 12);
            using var pen = new Pen(AppColors.Border, 1);
            g.DrawPath(pen, path);
        };

        panel.Controls.Add(new Label
        {
            Text = titulo,
            Font = AppFonts.Subtitulo,
            ForeColor = AppColors.TextPrimary,
            Location = new Point(15, 12),
            AutoSize = true,
            BackColor = Color.Transparent
        });

        return panel;
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

    // ============================================================
    // EVENTOS DEL MENÚ
    // ============================================================
    private void MenuInicio_Click(object? sender, EventArgs e) => _ = CargarDashboardAsync();

    private void MenuProductosLista_Click(object? sender, EventArgs e)
    {
        var frm = Program.ServiceProvider.GetRequiredService<FrmProductos>();
        frm.ShowDialog();
        _ = CargarDashboardAsync();
    }

    private void MenuProductosNuevo_Click(object? sender, EventArgs e)
    {
        var frm = Program.ServiceProvider.GetRequiredService<FrmProductoEdit>();
        frm.Modo = ModoEdicion.Nuevo;
        frm.ShowDialog();
        _ = CargarDashboardAsync();
    }

    private void MenuProductosCategorias_Click(object? sender, EventArgs e)
    {
        var frm = Program.ServiceProvider.GetRequiredService<FrmCategorias>();
        frm.ShowDialog();
        _ = CargarDashboardAsync();
    }

    private void MenuProductosUnidades_Click(object? sender, EventArgs e)
    {
        var frm = Program.ServiceProvider.GetRequiredService<FrmUnidadesMedida>();
        frm.ShowDialog();
    }

    private void MenuAlmacenesLista_Click(object? sender, EventArgs e)
    {
        var frm = Program.ServiceProvider.GetRequiredService<FrmAlmacenes>();
        frm.ShowDialog();
        _ = CargarDashboardAsync();
    }

    private void MenuAlmacenesNuevo_Click(object? sender, EventArgs e)
    {
        var frm = Program.ServiceProvider.GetRequiredService<FrmAlmacenEdit>();
        frm.Modo = ModoEdicion.Nuevo;
        frm.ShowDialog();
        _ = CargarDashboardAsync();
    }

    private void MenuMovimientosHistorial_Click(object? sender, EventArgs e)
    {
        var frm = Program.ServiceProvider.GetRequiredService<FrmMovimientos>();
        frm.ShowDialog();
        _ = CargarDashboardAsync();
    }

    private void MenuMovimientosEntrada_Click(object? sender, EventArgs e)
    {
        var frm = Program.ServiceProvider.GetRequiredService<FrmMovimientoEdit>();
        frm.Modo = ModoEdicion.Nuevo;
        frm.TipoInicial = "ENTRADA";
        frm.ShowDialog();
        _ = CargarDashboardAsync();
    }

    private void MenuMovimientosSalida_Click(object? sender, EventArgs e)
    {
        var frm = Program.ServiceProvider.GetRequiredService<FrmMovimientoEdit>();
        frm.Modo = ModoEdicion.Nuevo;
        frm.TipoInicial = "SALIDA";
        frm.ShowDialog();
        _ = CargarDashboardAsync();
    }

    private void MenuConsignaciones_Click(object? sender, EventArgs e)
    {
        var frm = Program.ServiceProvider.GetRequiredService<FrmConsignaciones>();
        frm.ShowDialog();
    }

    private void MenuProveedores_Click(object? sender, EventArgs e)
    {
        var frm = Program.ServiceProvider.GetRequiredService<FrmProveedores>();
        frm.ShowDialog();
    }

    private void MenuReportes_Click(object? sender, EventArgs e)
    {
        var frm = Program.ServiceProvider.GetRequiredService<FrmReportes>();
        frm.ShowDialog();
    }

    private void MenuGraficos_Click(object? sender, EventArgs e)
    {
        var frm = Program.ServiceProvider.GetRequiredService<FrmGraficos>();
        frm.ShowDialog();
    }

    private void MenuAdminUsuarios_Click(object? sender, EventArgs e)
    {
        if (!SessionManager.IsAdmin)
        {
            Toast.Warning(this, "Solo el administrador puede acceder");
            return;
        }

        var frm = Program.ServiceProvider.GetRequiredService<FrmUsuarios>();
        frm.ShowDialog();
    }

    private void MenuSesionSalir_Click(object? sender, EventArgs e)
    {
        var result = MessageBox.Show(
            "¿Está seguro que desea cerrar sesión?",
            "Confirmar",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            // Cerrar sesión y volver al login
            SessionManager.Usuario = null;

            var login = Program.ServiceProvider.GetRequiredService<FrmLogin>();
            login.Show();
            Close();
        }
    }
}