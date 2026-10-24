using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using InventarioWeb.WinForms.Controls;
using InventarioWeb.WinForms.Styles;

namespace InventarioWeb.WinForms.Helpers;

/// <summary>
/// Aplica estilos visuales a formularios existentes sin modificar su estructura.
/// Se puede llamar desde cualquier formulario en el evento Load.
/// </summary>
public static class FormStyler
{
    /// <summary>
    /// Aplica estilos a todos los controles del formulario recursivamente.
    /// </summary>
    public static void Apply(Form form)
    {
        form.BackColor = AppColors.LightBg;
        form.Font = AppFonts.Normal;

        AplicarEstilosRecursivo(form);
    }

    private static void AplicarEstilosRecursivo(Control parent)
    {
        foreach (Control ctrl in parent.Controls)
        {
            switch (ctrl)
            {
                case DataGridView grid:
                    GridStyles.Aplicar(grid);
                    break;

                case Button btn when btn.GetType() == typeof(Button):
                    // Solo aplicar a botones estándar (no a AppButton)
                    AplicarEstiloBoton(btn);
                    break;

                case TextBox txt:
                    txt.Font = AppFonts.Normal;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    break;

                case ComboBox cmb:
                    cmb.Font = AppFonts.Normal;
                    cmb.DropDownStyle = ComboBoxStyle.DropDownList;
                    break;

                case NumericUpDown num:
                    num.Font = AppFonts.Normal;
                    break;

                case DateTimePicker dtp:
                    dtp.Font = AppFonts.Normal;
                    break;

                case Label lbl:
                    if (lbl.Font.Size >= 12)
                        lbl.Font = AppFonts.Subtitulo;
                    else if (lbl.Font.Size >= 10)
                        lbl.Font = AppFonts.Normal;
                    else
                        lbl.Font = AppFonts.Pequeño;
                    break;
            }

            // Aplicar recursivamente a hijos
            if (ctrl.HasChildren)
                AplicarEstilosRecursivo(ctrl);
        }
    }

    private static void AplicarEstiloBoton(Button btn)
    {
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.Font = AppFonts.BotonPequeño;
        btn.Height = Math.Max(btn.Height, 30);
        btn.Cursor = Cursors.Hand;

        // Detectar color por el texto
        var texto = btn.Text.ToLower();

        if (texto.Contains("nuevo") || texto.Contains("agregar") || texto.Contains("crear"))
        {
            btn.BackColor = AppColors.Success;
            btn.ForeColor = Color.White;
        }
        else if (texto.Contains("editar") || texto.Contains("modificar"))
        {
            btn.BackColor = AppColors.Warning;
            btn.ForeColor = Color.White;
        }
        else if (texto.Contains("eliminar") || texto.Contains("borrar"))
        {
            btn.BackColor = AppColors.Danger;
            btn.ForeColor = Color.White;
        }
        else if (texto.Contains("cerrar") || texto.Contains("salir") || texto.Contains("cancelar"))
        {
            btn.BackColor = AppColors.Secondary;
            btn.ForeColor = Color.White;
        }
        else if (texto.Contains("buscar") || texto.Contains("filtrar") || texto.Contains("refrescar"))
        {
            btn.BackColor = AppColors.Primary;
            btn.ForeColor = Color.White;
        }
    }
}