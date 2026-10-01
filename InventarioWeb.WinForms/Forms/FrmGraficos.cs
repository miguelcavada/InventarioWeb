using InventarioWeb.Application.Services;
using InventarioWeb.Core.DTOs;
using InventarioWeb.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioWeb.WinForms.Forms;

public partial class FrmGraficos : Form
{
    private readonly IProductoService _productoService;
    private readonly IAlmacenService _almacenService;
    private readonly IMovimientoService _movimientoService;

    private List<ProductoDto> _productos = new();
    private List<AlmacenDto> _almacenes = new();

    public FrmGraficos(
        IProductoService productoService,
        IAlmacenService almacenService,
        IMovimientoService movimientoService)
    {
        InitializeComponent();
        _productoService = productoService;
        _almacenService = almacenService;
        _movimientoService = movimientoService;
    }

    private async void FrmGraficos_Load(object sender, EventArgs e)
    {
        await CargarDatosAsync();
    }

    private async Task CargarDatosAsync()
    {
        lblEstado.Text = "Cargando datos...";

        try
        {
            var prodResult = await _productoService.GetProductosAsync();
            if (prodResult.IsSuccess && prodResult.Data != null)
                _productos = prodResult.Data.ToList();

            var almResult = await _almacenService.GetAlmacenesAsync();
            if (almResult.IsSuccess && almResult.Data != null)
                _almacenes = almResult.Data.ToList();

            // KPIs
            lblTotalProductos.Text = _productos.Count.ToString();
            lblStockNormal.Text = _productos.Count(p => p.StockTotal > p.StockMinimoTotal).ToString();
            lblStockBajo.Text = _productos.Count(p => p.StockTotal <= p.StockMinimoTotal && p.StockTotal > 0).ToString();
            lblSinStock.Text = _productos.Count(p => p.StockTotal <= 0).ToString();
            lblTotalAlmacenes.Text = _almacenes.Count.ToString();

            // Dibujar gráficos
            DibujarGraficoCategorias();
            DibujarGraficoEstadoStock();
            DibujarGraficoStockAlmacenes();

            lblEstado.Text = "";
        }
        catch (Exception ex)
        {
            lblEstado.Text = $"Error: {ex.Message}";
        }
    }

    private void DibujarGraficoCategorias()
    {
        // Agrupar productos por categoría
        var datos = _productos
            .Where(p => p.Activo)
            .GroupBy(p => p.CategoriaNombre ?? "Sin categoría")
            .Select(g => new { Categoria = g.Key, Cantidad = g.Count() })
            .OrderByDescending(x => x.Cantidad)
            .ToList();

        if (!datos.Any()) return;

        // Dibujar gráfico de barras horizontales
        var bmp = new Bitmap(panelGraficoCategorias.Width, panelGraficoCategorias.Height);
        using var g = Graphics.FromImage(bmp);
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        g.Clear(Color.White);

        int margen = 20;
        int anchoBarra = panelGraficoCategorias.Width - margen * 2 - 150;
        int altoBarra = 25;
        int espacio = 10;
        int y = margen + 30;
        int maxValor = datos.Max(d => d.Cantidad);

        // Título
        using var fontTitulo = new Font("Segoe UI", 12, FontStyle.Bold);
        g.DrawString("📊 Productos por Categoría", fontTitulo, Brushes.DarkBlue, margen, 5);

        using var fontItem = new Font("Segoe UI", 9);
        using var fontValor = new Font("Segoe UI", 9, FontStyle.Bold);

        Color[] colores = {
            Color.FromArgb(67, 97, 238),
            Color.FromArgb(46, 196, 182),
            Color.FromArgb(255, 159, 28),
            Color.FromArgb(231, 29, 54),
            Color.FromArgb(156, 102, 255),
            Color.FromArgb(255, 99, 132),
            Color.FromArgb(54, 162, 235),
            Color.FromArgb(255, 206, 86)
        };

        for (int i = 0; i < datos.Count && i < 8; i++)
        {
            var dato = datos[i];
            int ancho = (int)((double)dato.Cantidad / maxValor * anchoBarra);

            using var brush = new SolidBrush(colores[i % colores.Length]);
            g.FillRectangle(brush, margen + 100, y, ancho, altoBarra);

            // Nombre de categoría
            g.DrawString(dato.Categoria, fontItem, Brushes.Black, margen, y + 4);

            // Valor
            g.DrawString(dato.Cantidad.ToString(), fontValor, Brushes.Black, margen + 100 + ancho + 5, y + 4);

            y += altoBarra + espacio;
        }

        panelGraficoCategorias.BackgroundImage = bmp;
        panelGraficoCategorias.BackgroundImageLayout = ImageLayout.None;
    }

    private void DibujarGraficoEstadoStock()
    {
        // Datos
        int stockNormal = _productos.Count(p => p.StockTotal > p.StockMinimoTotal);
        int stockBajo = _productos.Count(p => p.StockTotal <= p.StockMinimoTotal && p.StockTotal > 0);
        int sinStock = _productos.Count(p => p.StockTotal <= 0);
        int total = stockNormal + stockBajo + sinStock;

        if (total == 0) return;

        var bmp = new Bitmap(panelGraficoEstado.Width, panelGraficoEstado.Height);
        using var g = Graphics.FromImage(bmp);
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        g.Clear(Color.White);

        // Título
        using var fontTitulo = new Font("Segoe UI", 12, FontStyle.Bold);
        g.DrawString("🥧 Estado del Inventario", fontTitulo, Brushes.DarkBlue, 20, 5);

        // Gráfico de dona
        int centroX = panelGraficoEstado.Width / 2;
        int centroY = panelGraficoEstado.Height / 2 + 10;
        int radio = Math.Min(panelGraficoEstado.Width, panelGraficoEstado.Height) / 3 - 20;
        int grosor = 30;

        var datos = new[]
        {
            new { Nombre = "Normal", Valor = stockNormal, Color = Color.FromArgb(46, 196, 182) },
            new { Nombre = "Bajo", Valor = stockBajo, Color = Color.FromArgb(255, 159, 28) },
            new { Nombre = "Sin Stock", Valor = sinStock, Color = Color.FromArgb(231, 29, 54) }
        };

        float anguloInicio = -90;

        foreach (var dato in datos)
        {
            if (dato.Valor == 0) continue;

            float angulo = (float)dato.Valor / total * 360;

            using var pen = new Pen(dato.Color, grosor);
            g.DrawArc(pen, centroX - radio, centroY - radio, radio * 2, radio * 2, anguloInicio, angulo);

            anguloInicio += angulo;
        }

        // Centro
        using var fontCentro = new Font("Segoe UI", 14, FontStyle.Bold);
        var textoTotal = total.ToString();
        var sizeTexto = g.MeasureString(textoTotal, fontCentro);
        g.DrawString(textoTotal, fontCentro, Brushes.DarkBlue,
            centroX - sizeTexto.Width / 2, centroY - sizeTexto.Height / 2 - 5);
        using var fontLabel = new Font("Segoe UI", 8);
        var sizeLabel = g.MeasureString("Productos", fontLabel);
        g.DrawString("Productos", fontLabel, Brushes.Gray,
            centroX - sizeLabel.Width / 2, centroY + sizeTexto.Height / 2 - 5);

        // Leyenda
        int leyendaY = panelGraficoEstado.Height - 60;
        int leyendaX = 20;
        using var fontLeyenda = new Font("Segoe UI", 9);

        foreach (var dato in datos)
        {
            using var brush = new SolidBrush(dato.Color);
            g.FillRectangle(brush, leyendaX, leyendaY, 15, 15);
            g.DrawString($"{dato.Nombre}: {dato.Valor}", fontLeyenda, Brushes.Black, leyendaX + 20, leyendaY);
            leyendaY += 20;
        }

        panelGraficoEstado.BackgroundImage = bmp;
        panelGraficoEstado.BackgroundImageLayout = ImageLayout.None;
    }

    private void DibujarGraficoStockAlmacenes()
    {
        // Datos
        var datos = _almacenes
            .Where(a => a.Activo)
            .Select(a => new
            {
                Almacen = a.Nombre,
                Tipo = a.Tipo,
                Productos = a.TotalProductos
            })
            .OrderByDescending(x => x.Productos)
            .Take(8)
            .ToList();

        if (!datos.Any()) return;

        var bmp = new Bitmap(panelGraficoAlmacenes.Width, panelGraficoAlmacenes.Height);
        using var g = Graphics.FromImage(bmp);
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        g.Clear(Color.White);

        // Título
        using var fontTitulo = new Font("Segoe UI", 12, FontStyle.Bold);
        g.DrawString("🏪 Productos por Almacén", fontTitulo, Brushes.DarkBlue, 20, 5);

        int margen = 20;
        int anchoBarra = panelGraficoAlmacenes.Width - margen * 2 - 150;
        int altoBarra = 22;
        int espacio = 8;
        int y = margen + 30;
        int maxValor = datos.Max(d => d.Productos);
        if (maxValor == 0) maxValor = 1;

        using var fontItem = new Font("Segoe UI", 9);
        using var fontValor = new Font("Segoe UI", 9, FontStyle.Bold);

        foreach (var dato in datos)
        {
            int ancho = (int)((double)dato.Productos / maxValor * anchoBarra);

            Color color = dato.Tipo == "MERCADO"
                ? Color.FromArgb(46, 196, 182)
                : Color.FromArgb(67, 97, 238);

            using var brush = new SolidBrush(color);
            g.FillRectangle(brush, margen + 100, y, ancho, altoBarra);

            g.DrawString(dato.Almacen, fontItem, Brushes.Black, margen, y + 3);
            g.DrawString(dato.Productos.ToString(), fontValor, Brushes.Black,
                margen + 100 + ancho + 5, y + 3);

            y += altoBarra + espacio;
        }

        panelGraficoAlmacenes.BackgroundImage = bmp;
        panelGraficoAlmacenes.BackgroundImageLayout = ImageLayout.None;
    }

    private async void btnRefrescar_Click(object sender, EventArgs e)
    {
        await CargarDatosAsync();
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
        Close();
    }
}