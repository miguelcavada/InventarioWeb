using System.Drawing;
using System.Windows.Forms;

namespace InventarioWeb.WinForms.Styles;

public class DarkMenuRenderer : ToolStripProfessionalRenderer
{
    public DarkMenuRenderer() : base(new DarkColorTable())
    {
        RoundedEdges = false;
    }

    // Hover de los items del menú principal
    protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
    {
        var g = e.Graphics;
        var rect = new Rectangle(0, 0, e.Item.Width, e.Item.Height);

        if (e.Item.Selected || e.Item.Pressed)
        {
            using var brush = new SolidBrush(AppColors.Primary);
            g.FillRectangle(brush, rect);
        }
        else if (e.Item.IsOnDropDown)
        {
            // Items del dropdown: fondo blanco, texto oscuro
            using var brush = new SolidBrush(e.Item.Selected ? AppColors.RowSelected : Color.White);
            g.FillRectangle(brush, rect);
        }
    }

    // Texto de los items
    protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
    {
        // Si está en un dropdown (menú desplegable), texto oscuro
        if (e.Item.IsOnDropDown)
        {
            e.TextColor = e.Item.Selected ? AppColors.Primary : AppColors.TextPrimary;
        }
        else
        {
            // Menú principal: texto blanco siempre
            e.TextColor = Color.White;
        }

        base.OnRenderItemText(e);
    }

    // Flecha del dropdown
    protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
    {
        e.ArrowColor = e.Item!.IsOnDropDown ? AppColors.TextPrimary : Color.White;
        base.OnRenderArrow(e);
    }

    // Separadores en dropdown
    protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
    {
        var g = e.Graphics;
        var rect = new Rectangle(0, e.Item.Height / 2, e.Item.Width, 1);
        using var pen = new Pen(AppColors.Border);
        g.DrawLine(pen, rect.Left + 4, rect.Top, rect.Right - 4, rect.Top);
    }
}

// Tabla de colores personalizada para el menú
public class DarkColorTable : ProfessionalColorTable
{
    public override Color MenuItemSelected => AppColors.Primary;
    public override Color MenuItemSelectedGradientBegin => AppColors.Primary;
    public override Color MenuItemSelectedGradientEnd => AppColors.Primary;

    public override Color MenuItemBorder => AppColors.Primary;

    public override Color MenuStripGradientBegin => AppColors.DarkBg;
    public override Color MenuStripGradientEnd => AppColors.DarkBg;

    public override Color MenuBorder => Color.FromArgb(50, 50, 70);

    public override Color ToolStripDropDownBackground => Color.White;
    public override Color ImageMarginGradientBegin => Color.White;
    public override Color ImageMarginGradientMiddle => Color.White;
    public override Color ImageMarginGradientEnd => Color.White;
}