using System.Drawing;
using System.Windows.Forms;

namespace InventarioWeb.WinForms.Styles;

public static class GridStyles
{
    public static void Aplicar(DataGridView grid)
    {
        // Encabezado
        grid.ColumnHeadersDefaultCellStyle.BackColor = AppColors.DarkBg;
        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        grid.ColumnHeadersDefaultCellStyle.Font = AppFonts.GridHeader;
        grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
        grid.ColumnHeadersHeight = 40;
        grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        grid.EnableHeadersVisualStyles = false;

        // Filas
        grid.RowTemplate.Height = 32;
        grid.DefaultCellStyle.Font = AppFonts.GridCell;
        grid.DefaultCellStyle.ForeColor = AppColors.TextPrimary;
        grid.DefaultCellStyle.BackColor = Color.White;
        grid.DefaultCellStyle.SelectionBackColor = AppColors.RowSelected;
        grid.DefaultCellStyle.SelectionForeColor = AppColors.TextPrimary;
        grid.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
        grid.AlternatingRowsDefaultCellStyle.BackColor = AppColors.LightBg;

        // Bordes
        grid.BorderStyle = BorderStyle.None;
        grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        grid.GridColor = AppColors.Border;
        grid.BackgroundColor = Color.White;
        grid.RowHeadersVisible = false;
        grid.AllowUserToResizeRows = false;
        grid.MultiSelect = false;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        // Scroll
        grid.ScrollBars = ScrollBars.Vertical;
    }
}