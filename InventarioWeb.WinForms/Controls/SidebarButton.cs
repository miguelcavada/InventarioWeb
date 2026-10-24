using System.Drawing;
using InventarioWeb.WinForms.Styles;

namespace InventarioWeb.WinForms.Controls;

public class SidebarButton : Button
{
    private bool _activo = false;
    private string _icono = "";
    private string _texto = "";
    private bool _soloIcono = false;

    public bool Activo
    {
        get => _activo;
        set
        {
            _activo = value;
            BackColor = value ? AppColors.Primary : Color.Transparent;
            Invalidate();
        }
    }

    public string Icono
    {
        get => _icono;
        set { _icono = value; ActualizarTexto(); }
    }

    public string Texto
    {
        get => _texto;
        set { _texto = value; ActualizarTexto(); }
    }

    public bool SoloIcono
    {
        get => _soloIcono;
        set
        {
            _soloIcono = value;
            Padding = value ? new Padding(0) : new Padding(20, 0, 0, 0);
            TextAlign = value ? ContentAlignment.MiddleCenter : ContentAlignment.MiddleLeft;
            ActualizarTexto();
        }
    }

    public SidebarButton()
    {
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        BackColor = Color.Transparent;
        ForeColor = Color.White;
        Font = AppFonts.Sidebar;
        TextAlign = ContentAlignment.MiddleLeft;
        Padding = new Padding(20, 0, 0, 0);
        Height = 45;
        Dock = DockStyle.Top;
        Cursor = Cursors.Hand;

        MouseEnter += (s, e) =>
        {
            if (!_activo)
                BackColor = AppColors.SidebarHover;
        };

        MouseLeave += (s, e) =>
        {
            if (!_activo)
                BackColor = Color.Transparent;
        };
    }

    private void ActualizarTexto()
    {
        Text = _soloIcono ? _icono : $"  {_icono}  {_texto}";
    }
}