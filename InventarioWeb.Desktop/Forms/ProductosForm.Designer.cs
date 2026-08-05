partial class ProductosForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dgvProductos;
    private TextBox txtBuscar;
    private Button btnBuscar;
    private Button btnNuevo;
    private Button btnEditar;
    private Button btnEliminar;
    private Button btnCambiarPrecio;
    private Label lblTotal;
    private Panel panelTop;
    private Panel panelBottom;

    private void InitializeComponent()
    {
        this.panelTop = new Panel();
        this.txtBuscar = new TextBox();
        this.btnBuscar = new Button();
        this.lblTotal = new Label();
        this.dgvProductos = new DataGridView();
        this.panelBottom = new Panel();
        this.btnNuevo = new Button();
        this.btnEditar = new Button();
        this.btnEliminar = new Button();
        this.btnCambiarPrecio = new Button();

        // Panel superior
        this.panelTop.Dock = DockStyle.Top;
        this.panelTop.Height = 60;
        this.panelTop.Padding = new Padding(10);

        this.txtBuscar.Location = new Point(10, 15);
        this.txtBuscar.Size = new Size(300, 30);
        this.txtBuscar.PlaceholderText = "Buscar por código o nombre...";

        this.btnBuscar.Location = new Point(320, 15);
        this.btnBuscar.Size = new Size(80, 30);
        this.btnBuscar.Text = "Buscar";
        this.btnBuscar.Click += btnBuscar_Click;

        this.lblTotal.AutoSize = true;
        this.lblTotal.Location = new Point(420, 20);

        this.panelTop.Controls.AddRange(new Control[] { txtBuscar, btnBuscar, lblTotal });

        // DataGridView
        this.dgvProductos.Dock = DockStyle.Fill;
        this.dgvProductos.AllowUserToAddRows = false;
        this.dgvProductos.AllowUserToDeleteRows = false;
        this.dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvProductos.ReadOnly = true;
        this.dgvProductos.RowHeadersVisible = false;

        // Panel inferior
        this.panelBottom.Dock = DockStyle.Bottom;
        this.panelBottom.Height = 50;
        this.panelBottom.Padding = new Padding(10);

        this.btnNuevo.Text = "Nuevo";
        this.btnNuevo.Size = new Size(80, 30);
        this.btnNuevo.Click += btnNuevo_Click;

        this.btnEditar.Text = "Editar";
        this.btnEditar.Size = new Size(80, 30);
        this.btnEditar.Click += btnEditar_Click;

        this.btnEliminar.Text = "Eliminar";
        this.btnEliminar.Size = new Size(80, 30);
        this.btnEliminar.Click += btnEliminar_Click;

        this.btnCambiarPrecio.Text = "Cambiar Precio";
        this.btnCambiarPrecio.Size = new Size(120, 30);
        this.btnCambiarPrecio.Click += btnCambiarPrecio_Click;

        var flowPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            Padding = new Padding(5)
        };
        flowPanel.Controls.AddRange(new Control[] { btnNuevo, btnEditar, btnEliminar, btnCambiarPrecio });
        this.panelBottom.Controls.Add(flowPanel);

        // Form
        this.Text = "Gestión de Productos";
        this.Size = new Size(1000, 600);
        this.StartPosition = FormStartPosition.CenterParent;
        this.Controls.AddRange(new Control[] { dgvProductos, panelTop, panelBottom });
    }
}