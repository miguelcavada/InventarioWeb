namespace InventarioWeb.WinForms.Forms
{
    partial class FrmConsignacionEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.cmbAlmacen = new System.Windows.Forms.ComboBox();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtNumeroConsignacion = new System.Windows.Forms.TextBox();
            this.lblNumeroConsignacion = new System.Windows.Forms.Label();
            this.panelVendedor = new System.Windows.Forms.Panel();
            this.txtVendedorTelefono = new System.Windows.Forms.TextBox();
            this.lblVendedorTelefono = new System.Windows.Forms.Label();
            this.txtVendedorContacto = new System.Windows.Forms.TextBox();
            this.lblVendedorContacto = new System.Windows.Forms.Label();
            this.txtVendedorNombre = new System.Windows.Forms.TextBox();
            this.lblVendedorNombre = new System.Windows.Forms.Label();
            this.panelDetalle = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.panelAgregar = new System.Windows.Forms.Panel();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            this.panelTop.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelVendedor.SuspendLayout();
            this.panelDetalle.SuspendLayout();
            this.panelAgregar.SuspendLayout();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(950, 60);
            this.panelTop.TabIndex = 0;

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(15, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(250, 25);
            this.lblTitulo.Text = "Nueva Consignación";

            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblMensaje);
            this.panelHeader.Controls.Add(this.txtObservaciones);
            this.panelHeader.Controls.Add(this.lblObservaciones);
            this.panelHeader.Controls.Add(this.cmbAlmacen);
            this.panelHeader.Controls.Add(this.lblAlmacen);
            this.panelHeader.Controls.Add(this.dtpFecha);
            this.panelHeader.Controls.Add(this.lblFecha);
            this.panelHeader.Controls.Add(this.txtNumeroConsignacion);
            this.panelHeader.Controls.Add(this.lblNumeroConsignacion);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 60);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelHeader.Size = new System.Drawing.Size(950, 110);
            this.panelHeader.TabIndex = 1;

            int y = 15;

            this.lblNumeroConsignacion.AutoSize = true;
            this.lblNumeroConsignacion.Location = new System.Drawing.Point(20, y + 3);
            this.lblNumeroConsignacion.Name = "lblNumeroConsignacion";
            this.lblNumeroConsignacion.Size = new System.Drawing.Size(80, 15);
            this.lblNumeroConsignacion.Text = "N° Consignación:";

            this.txtNumeroConsignacion.Location = new System.Drawing.Point(130, y);
            this.txtNumeroConsignacion.Name = "txtNumeroConsignacion";
            this.txtNumeroConsignacion.Size = new System.Drawing.Size(200, 23);
            this.txtNumeroConsignacion.TabIndex = 0;

            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(350, y + 3);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 15);
            this.lblFecha.Text = "Fecha:";

            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(400, y);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(150, 23);
            this.dtpFecha.TabIndex = 1;

            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.Location = new System.Drawing.Point(570, y + 3);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(90, 15);
            this.lblAlmacen.Text = "Almacén Origen:";

            this.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlmacen.Location = new System.Drawing.Point(670, y);
            this.cmbAlmacen.Name = "cmbAlmacen";
            this.cmbAlmacen.Size = new System.Drawing.Size(250, 23);
            this.cmbAlmacen.TabIndex = 2;

            y += 40;

            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(20, y + 3);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(80, 15);
            this.lblObservaciones.Text = "Observaciones:";

            this.txtObservaciones.Location = new System.Drawing.Point(130, y);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(790, 23);
            this.txtObservaciones.TabIndex = 3;

            y += 40;

            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(20, y);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 15);

            // panelVendedor
            this.panelVendedor.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            this.panelVendedor.Controls.Add(this.txtVendedorTelefono);
            this.panelVendedor.Controls.Add(this.lblVendedorTelefono);
            this.panelVendedor.Controls.Add(this.txtVendedorContacto);
            this.panelVendedor.Controls.Add(this.lblVendedorContacto);
            this.panelVendedor.Controls.Add(this.txtVendedorNombre);
            this.panelVendedor.Controls.Add(this.lblVendedorNombre);
            this.panelVendedor.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelVendedor.Location = new System.Drawing.Point(0, 170);
            this.panelVendedor.Name = "panelVendedor";
            this.panelVendedor.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelVendedor.Size = new System.Drawing.Size(950, 60);
            this.panelVendedor.TabIndex = 2;

            this.lblVendedorNombre.AutoSize = true;
            this.lblVendedorNombre.Location = new System.Drawing.Point(20, 20);
            this.lblVendedorNombre.Name = "lblVendedorNombre";
            this.lblVendedorNombre.Size = new System.Drawing.Size(100, 15);
            this.lblVendedorNombre.Text = "Vendedor: *";

            this.txtVendedorNombre.Location = new System.Drawing.Point(130, 17);
            this.txtVendedorNombre.Name = "txtVendedorNombre";
            this.txtVendedorNombre.Size = new System.Drawing.Size(250, 23);
            this.txtVendedorNombre.TabIndex = 0;

            this.lblVendedorContacto.AutoSize = true;
            this.lblVendedorContacto.Location = new System.Drawing.Point(400, 20);
            this.lblVendedorContacto.Name = "lblVendedorContacto";
            this.lblVendedorContacto.Size = new System.Drawing.Size(60, 15);
            this.lblVendedorContacto.Text = "Contacto:";

            this.txtVendedorContacto.Location = new System.Drawing.Point(470, 17);
            this.txtVendedorContacto.Name = "txtVendedorContacto";
            this.txtVendedorContacto.Size = new System.Drawing.Size(200, 23);
            this.txtVendedorContacto.TabIndex = 1;

            this.lblVendedorTelefono.AutoSize = true;
            this.lblVendedorTelefono.Location = new System.Drawing.Point(690, 20);
            this.lblVendedorTelefono.Name = "lblVendedorTelefono";
            this.lblVendedorTelefono.Size = new System.Drawing.Size(60, 15);
            this.lblVendedorTelefono.Text = "Teléfono:";

            this.txtVendedorTelefono.Location = new System.Drawing.Point(760, 17);
            this.txtVendedorTelefono.Name = "txtVendedorTelefono";
            this.txtVendedorTelefono.Size = new System.Drawing.Size(160, 23);
            this.txtVendedorTelefono.TabIndex = 2;

            // panelDetalle
            this.panelDetalle.Controls.Add(this.lblTotal);
            this.panelDetalle.Controls.Add(this.dgvDetalles);
            this.panelDetalle.Controls.Add(this.panelAgregar);
            this.panelDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetalle.Location = new System.Drawing.Point(0, 230);
            this.panelDetalle.Name = "panelDetalle";
            this.panelDetalle.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelDetalle.Size = new System.Drawing.Size(950, 340);
            this.panelDetalle.TabIndex = 3;

            // panelAgregar
            this.panelAgregar.Controls.Add(this.btnAgregarProducto);
            this.panelAgregar.Controls.Add(this.numCantidad);
            this.panelAgregar.Controls.Add(this.lblCantidad);
            this.panelAgregar.Controls.Add(this.cmbProducto);
            this.panelAgregar.Controls.Add(this.lblProducto);
            this.panelAgregar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAgregar.Location = new System.Drawing.Point(20, 10);
            this.panelAgregar.Name = "panelAgregar";
            this.panelAgregar.Size = new System.Drawing.Size(910, 60);
            this.panelAgregar.TabIndex = 0;

            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(0, 20);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(60, 15);
            this.lblProducto.Text = "Producto:";

            this.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducto.Location = new System.Drawing.Point(70, 17);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(350, 23);
            this.cmbProducto.TabIndex = 0;

            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(440, 20);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(60, 15);
            this.lblCantidad.Text = "Cantidad:";

            this.numCantidad.Location = new System.Drawing.Point(510, 17);
            this.numCantidad.Maximum = 9999999;
            this.numCantidad.Minimum = 1;
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(100, 23);
            this.numCantidad.TabIndex = 1;
            this.numCantidad.Value = 1;

            this.btnAgregarProducto.BackColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.btnAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProducto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProducto.Location = new System.Drawing.Point(625, 15);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(85, 28);
            this.btnAgregarProducto.TabIndex = 2;
            this.btnAgregarProducto.Text = "➕ Agregar";
            this.btnAgregarProducto.UseVisualStyleBackColor = false;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);

            // dgvDetalles
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvDetalles.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.dgvDetalles.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDetalles.ColumnHeadersHeight = 30;
            this.dgvDetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalles.Location = new System.Drawing.Point(20, 70);
            this.dgvDetalles.MultiSelect = false;
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.RowHeadersVisible = false;
            this.dgvDetalles.RowTemplate.Height = 28;
            this.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.Size = new System.Drawing.Size(910, 230);
            this.dgvDetalles.TabIndex = 1;
            this.dgvDetalles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalles_CellContentClick);

            this.lblTotal.AutoSize = true;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(20, 300);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(120, 21);
            this.lblTotal.Text = "Total: $0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // panelBotones
            this.panelBotones.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.panelBotones.Controls.Add(this.btnCancelar);
            this.panelBotones.Controls.Add(this.btnGuardar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 570);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(950, 60);
            this.panelBotones.TabIndex = 4;

            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(670, 12);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 38);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "💾 Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(810, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(130, 38);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "✖ Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // FrmConsignacionEdit
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 630);
            this.Controls.Add(this.panelDetalle);
            this.Controls.Add(this.panelVendedor);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(950, 630);
            this.Name = "FrmConsignacionEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nueva Consignación";
            this.Load += new System.EventHandler(this.FrmConsignacionEdit_Load);

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelVendedor.ResumeLayout(false);
            this.panelVendedor.PerformLayout();
            this.panelDetalle.ResumeLayout(false);
            this.panelDetalle.PerformLayout();
            this.panelAgregar.ResumeLayout(false);
            this.panelAgregar.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelVendedor;
        private System.Windows.Forms.Panel panelDetalle;
        private System.Windows.Forms.Panel panelAgregar;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblNumeroConsignacion;
        private System.Windows.Forms.TextBox txtNumeroConsignacion;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.ComboBox cmbAlmacen;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblVendedorNombre;
        private System.Windows.Forms.TextBox txtVendedorNombre;
        private System.Windows.Forms.Label lblVendedorContacto;
        private System.Windows.Forms.TextBox txtVendedorContacto;
        private System.Windows.Forms.Label lblVendedorTelefono;
        private System.Windows.Forms.TextBox txtVendedorTelefono;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        #endregion
    }
}