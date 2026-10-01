namespace InventarioWeb.WinForms.Forms
{
    partial class FrmMovimientoEdit
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
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.lblNumeroDocumento = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.panelAlmacenes = new System.Windows.Forms.Panel();
            this.cmbAlmacenDestino = new System.Windows.Forms.ComboBox();
            this.lblAlmacenDestino = new System.Windows.Forms.Label();
            this.cmbAlmacenOrigen = new System.Windows.Forms.ComboBox();
            this.lblAlmacenOrigen = new System.Windows.Forms.Label();
            this.panelDetalle = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.panelAgregar = new System.Windows.Forms.Panel();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.cmbTipoPrecio = new System.Windows.Forms.ComboBox();
            this.lblTipoPrecio = new System.Windows.Forms.Label();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            this.panelTop.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelAlmacenes.SuspendLayout();
            this.panelDetalle.SuspendLayout();
            this.panelAgregar.SuspendLayout();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            this.SuspendLayout();

            // ===== panelTop =====
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(900, 60);
            this.panelTop.TabIndex = 0;

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(15, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(200, 25);
            this.lblTitulo.Text = "Nuevo Movimiento";

            // ===== panelHeader =====
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblMensaje);
            this.panelHeader.Controls.Add(this.txtObservacion);
            this.panelHeader.Controls.Add(this.lblObservacion);
            this.panelHeader.Controls.Add(this.dtpFecha);
            this.panelHeader.Controls.Add(this.lblFecha);
            this.panelHeader.Controls.Add(this.txtNumeroDocumento);
            this.panelHeader.Controls.Add(this.lblNumeroDocumento);
            this.panelHeader.Controls.Add(this.cmbTipo);
            this.panelHeader.Controls.Add(this.lblTipo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 60);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelHeader.Size = new System.Drawing.Size(900, 110);
            this.panelHeader.TabIndex = 1;

            int y = 15;

            // lblTipo
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(20, y + 3);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(50, 15);
            this.lblTipo.Text = "Tipo: *";

            // cmbTipo
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Location = new System.Drawing.Point(80, y);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(150, 23);
            this.cmbTipo.TabIndex = 0;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);

            // lblNumeroDocumento
            this.lblNumeroDocumento.AutoSize = true;
            this.lblNumeroDocumento.Location = new System.Drawing.Point(250, y + 3);
            this.lblNumeroDocumento.Name = "lblNumeroDocumento";
            this.lblNumeroDocumento.Size = new System.Drawing.Size(70, 15);
            this.lblNumeroDocumento.Text = "Documento:";

            // txtNumeroDocumento
            this.txtNumeroDocumento.Location = new System.Drawing.Point(330, y);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(200, 23);
            this.txtNumeroDocumento.TabIndex = 1;

            // lblFecha
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(550, y + 3);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 15);
            this.lblFecha.Text = "Fecha:";

            // dtpFecha
            this.dtpFecha.Location = new System.Drawing.Point(600, y);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(180, 23);
            this.dtpFecha.TabIndex = 2;

            y += 40;

            // lblObservacion
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.Location = new System.Drawing.Point(20, y + 3);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(75, 15);
            this.lblObservacion.Text = "Observación:";

            // txtObservacion
            this.txtObservacion.Location = new System.Drawing.Point(100, y);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(680, 23);
            this.txtObservacion.TabIndex = 3;

            y += 40;

            // lblMensaje
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(20, y);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 15);

            // ===== panelAlmacenes =====
            this.panelAlmacenes.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            this.panelAlmacenes.Controls.Add(this.cmbAlmacenDestino);
            this.panelAlmacenes.Controls.Add(this.lblAlmacenDestino);
            this.panelAlmacenes.Controls.Add(this.cmbAlmacenOrigen);
            this.panelAlmacenes.Controls.Add(this.lblAlmacenOrigen);
            this.panelAlmacenes.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAlmacenes.Location = new System.Drawing.Point(0, 170);
            this.panelAlmacenes.Name = "panelAlmacenes";
            this.panelAlmacenes.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelAlmacenes.Size = new System.Drawing.Size(900, 60);
            this.panelAlmacenes.TabIndex = 2;

            // lblAlmacenOrigen
            this.lblAlmacenOrigen.AutoSize = true;
            this.lblAlmacenOrigen.Location = new System.Drawing.Point(20, 20);
            this.lblAlmacenOrigen.Name = "lblAlmacenOrigen";
            this.lblAlmacenOrigen.Size = new System.Drawing.Size(90, 15);
            this.lblAlmacenOrigen.Text = "Almacén: *";

            // cmbAlmacenOrigen
            this.cmbAlmacenOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlmacenOrigen.Location = new System.Drawing.Point(120, 17);
            this.cmbAlmacenOrigen.Name = "cmbAlmacenOrigen";
            this.cmbAlmacenOrigen.Size = new System.Drawing.Size(300, 23);
            this.cmbAlmacenOrigen.TabIndex = 0;

            // lblAlmacenDestino
            this.lblAlmacenDestino.AutoSize = true;
            this.lblAlmacenDestino.Location = new System.Drawing.Point(450, 20);
            this.lblAlmacenDestino.Name = "lblAlmacenDestino";
            this.lblAlmacenDestino.Size = new System.Drawing.Size(100, 15);
            this.lblAlmacenDestino.Text = "Almacén Destino:";

            // cmbAlmacenDestino
            this.cmbAlmacenDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlmacenDestino.Location = new System.Drawing.Point(560, 17);
            this.cmbAlmacenDestino.Name = "cmbAlmacenDestino";
            this.cmbAlmacenDestino.Size = new System.Drawing.Size(300, 23);
            this.cmbAlmacenDestino.TabIndex = 1;

            // ===== panelDetalle =====
            this.panelDetalle.Controls.Add(this.lblTotal);
            this.panelDetalle.Controls.Add(this.dgvDetalles);
            this.panelDetalle.Controls.Add(this.panelAgregar);
            this.panelDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetalle.Location = new System.Drawing.Point(0, 230);
            this.panelDetalle.Name = "panelDetalle";
            this.panelDetalle.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelDetalle.Size = new System.Drawing.Size(900, 340);
            this.panelDetalle.TabIndex = 3;

            // panelAgregar
            this.panelAgregar.Controls.Add(this.btnAgregarProducto);
            this.panelAgregar.Controls.Add(this.numCantidad);
            this.panelAgregar.Controls.Add(this.lblCantidad);
            this.panelAgregar.Controls.Add(this.cmbTipoPrecio);
            this.panelAgregar.Controls.Add(this.lblTipoPrecio);
            this.panelAgregar.Controls.Add(this.cmbProducto);
            this.panelAgregar.Controls.Add(this.lblProducto);
            this.panelAgregar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAgregar.Location = new System.Drawing.Point(20, 10);
            this.panelAgregar.Name = "panelAgregar";
            this.panelAgregar.Size = new System.Drawing.Size(860, 60);
            this.panelAgregar.TabIndex = 0;

            // lblProducto
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(0, 20);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(60, 15);
            this.lblProducto.Text = "Producto:";

            // cmbProducto
            this.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducto.Location = new System.Drawing.Point(70, 17);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(300, 23);
            this.cmbProducto.TabIndex = 0;

            // lblTipoPrecio
            this.lblTipoPrecio.AutoSize = true;
            this.lblTipoPrecio.Location = new System.Drawing.Point(390, 20);
            this.lblTipoPrecio.Name = "lblTipoPrecio";
            this.lblTipoPrecio.Size = new System.Drawing.Size(60, 15);
            this.lblTipoPrecio.Text = "Precio:";
            this.lblTipoPrecio.Visible = false;

            // cmbTipoPrecio
            this.cmbTipoPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPrecio.Location = new System.Drawing.Point(450, 17);
            this.cmbTipoPrecio.Name = "cmbTipoPrecio";
            this.cmbTipoPrecio.Size = new System.Drawing.Size(120, 23);
            this.cmbTipoPrecio.TabIndex = 1;
            this.cmbTipoPrecio.Visible = false;

            // lblCantidad
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(590, 20);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(60, 15);
            this.lblCantidad.Text = "Cantidad:";

            // numCantidad
            this.numCantidad.DecimalPlaces = 2;
            this.numCantidad.Location = new System.Drawing.Point(660, 17);
            this.numCantidad.Maximum = 9999999;
            this.numCantidad.Minimum = 0.01m;
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(100, 23);
            this.numCantidad.TabIndex = 2;
            this.numCantidad.Value = 1;

            // btnAgregarProducto
            this.btnAgregarProducto.BackColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.btnAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProducto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProducto.Location = new System.Drawing.Point(775, 15);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(85, 28);
            this.btnAgregarProducto.TabIndex = 3;
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
            this.dgvDetalles.Size = new System.Drawing.Size(860, 230);
            this.dgvDetalles.TabIndex = 1;
            this.dgvDetalles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalles_CellContentClick);

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(20, 300);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(120, 21);
            this.lblTotal.Text = "Total: $0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // ===== panelBotones =====
            this.panelBotones.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.panelBotones.Controls.Add(this.btnCancelar);
            this.panelBotones.Controls.Add(this.btnGuardar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 570);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(900, 60);
            this.panelBotones.TabIndex = 4;

            // btnGuardar
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(620, 12);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 38);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "💾 Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // btnCancelar
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(760, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(130, 38);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "✖ Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // ===== FrmMovimientoEdit =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 630);
            this.Controls.Add(this.panelDetalle);
            this.Controls.Add(this.panelAlmacenes);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(900, 630);
            this.Name = "FrmMovimientoEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Movimiento";
            this.Load += new System.EventHandler(this.FrmMovimientoEdit_Load);

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelAlmacenes.ResumeLayout(false);
            this.panelAlmacenes.PerformLayout();
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
        private System.Windows.Forms.Panel panelAlmacenes;
        private System.Windows.Forms.Panel panelDetalle;
        private System.Windows.Forms.Panel panelAgregar;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblNumeroDocumento;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label lblAlmacenOrigen;
        private System.Windows.Forms.ComboBox cmbAlmacenOrigen;
        private System.Windows.Forms.Label lblAlmacenDestino;
        private System.Windows.Forms.ComboBox cmbAlmacenDestino;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.Label lblTipoPrecio;
        private System.Windows.Forms.ComboBox cmbTipoPrecio;
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