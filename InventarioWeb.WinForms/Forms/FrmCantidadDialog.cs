using System;
using System.Windows.Forms;

namespace InventarioWeb.WinForms.Forms;

public partial class FrmCantidadDialog : Form
{
    public string Titulo { get; set; } = "Cantidad";
    public int CantidadMaxima { get; set; } = 100;
    public string Mensaje { get; set; } = "";
    public int Cantidad { get; private set; }

    public FrmCantidadDialog()
    {
        InitializeComponent();
    }

    private void FrmCantidadDialog_Load(object sender, EventArgs e)
    {
        Text = Titulo;
        lblTitulo.Text = Titulo;
        lblMensaje.Text = Mensaje;
        numCantidad.Maximum = CantidadMaxima;
        numCantidad.Value = 1;
    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
        Cantidad = (int)numCantidad.Value;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}