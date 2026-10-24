using System.Drawing;
using System.Windows.Forms;
using InventarioWeb.WinForms.Styles;

namespace InventarioWeb.WinForms.Helpers;

public static class Toast
{
    public static void Success(Form owner, string mensaje) => Show(owner, mensaje, AppColors.Success, "✓");
    public static void Error(Form owner, string mensaje) => Show(owner, mensaje, AppColors.Danger, "✕");
    public static void Warning(Form owner, string mensaje) => Show(owner, mensaje, AppColors.Warning, "⚠");
    public static void Info(Form owner, string mensaje) => Show(owner, mensaje, AppColors.Primary, "ℹ");

    private static void Show(Form owner, string mensaje, Color color, string icono)
    {
        var toast = new Form
        {
            FormBorderStyle = FormBorderStyle.None,
            StartPosition = FormStartPosition.Manual,
            Size = new Size(320, 60),
            BackColor = color,
            TopMost = true,
            ShowInTaskbar = false,
            Opacity = 0.95
        };

        // Posición: arriba a la derecha del owner
        toast.Location = new Point(
            owner.Right - toast.Width - 20,
            owner.Top + 80
        );

        var lblIcono = new Label
        {
            Text = icono,
            Font = new Font("Segoe UI", 16, FontStyle.Bold),
            ForeColor = Color.White,
            Location = new Point(15, 15),
            Size = new Size(30, 30),
            TextAlign = ContentAlignment.MiddleCenter
        };

        var lblMensaje = new Label
        {
            Text = mensaje,
            Font = AppFonts.Normal,
            ForeColor = Color.White,
            Location = new Point(55, 10),
            Size = new Size(250, 40),
            TextAlign = ContentAlignment.MiddleLeft
        };

        toast.Controls.Add(lblIcono);
        toast.Controls.Add(lblMensaje);
        toast.Show(owner);

        // Auto-cerrar después de 3 segundos
        var timer = new System.Windows.Forms.Timer { Interval = 3000 };
        timer.Tick += (s, e) =>
        {
            toast.Close();
            timer.Dispose();
        };
        timer.Start();
    }
}