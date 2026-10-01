namespace InventarioWeb.WinForms.Forms
{
    partial class FrmMovimientos
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            this.btnNuevoTraslado = new System.Windows.Forms.Button();
            this.btnNuevaSalida = new System.Windows.Forms.Button();
            this.btnNuevaEntrada = new System.Windows.Forms.Button();
            this.chkFecha = new System.Windows.Forms.CheckBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.cmbFiltroTipo = new System.Windows.Forms.ComboBox();
            this.lblFiltroTipo = new System.Windows.Forms.Label();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();

            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.SuspendLayout();

            // ===== panelTop =====
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.panelTop.Controls.Add(this.btnCerrar);
            this.panelTop.Controls.Add(this.btnVerDetalle);
            this.panelTop.Controls.Add(this.btnNuevoTraslado);
            this.panelTop.Controls.Add(this.btnNuevaSalida);
            this.panelTop.Controls.Add(this.btnNuevaEntrada);
            this.panelTop.Controls.Add(this.chkFecha);
            this.panelTop.Controls.Add(this.dtpHasta);
            this.panelTop.Controls.Add(this.lblHasta);
            this.panelTop.Controls.Add(this.dtpDesde);
            this.panelTop.Controls.Add(this.lblDesde);
            this.panelTop.Controls.Add(this.cmbFiltroTipo);
            this.panelTop.Controls.Add(this.lblFiltroTipo);
            this.panelTop.Controls.Add(this.btnRefrescar);
            this.panelTop.Controls.Add(this.btnBuscar);
            this.panelTop.Controls.Add(this.txtBuscar);
            this.panelTop.Controls.Add(this.lblBuscar);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 140);
            this.panelTop.TabIndex = 0;

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(15, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(230, 25);
            this.lblTitulo.Text = "Movimientos de Inventario";

            // Fila 1: Búsqueda + Tipo
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.ForeColor = System.Drawing.Color.White;
            this.lblBuscar.Location = new System.Drawing.Point(15, 50);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(45, 15);
            this.lblBuscar.Text = "Buscar:";

            this.txtBuscar.Location = new System.Drawing.Point(70, 47);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(200, 23);
            this.txtBuscar.TabIndex = 1;

            this.lblFiltroTipo.AutoSize = true;
            this.lblFiltroTipo.ForeColor = System.Drawing.Color.White;
            this.lblFiltroTipo.Location = new System.Drawing.Point(290, 50);
            this.lblFiltroTipo.Name = "lblFiltroTipo";
            this.lblFiltroTipo.Size = new System.Drawing.Size(35, 15);
            this.lblFiltroTipo.Text = "Tipo:";

            this.cmbFiltroTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroTipo.Location = new System.Drawing.Point(330, 47);
            this.cmbFiltroTipo.Name = "cmbFiltroTipo";
            this.cmbFiltroTipo.Size = new System.Drawing.Size(150, 23);
            this.cmbFiltroTipo.TabIndex = 2;
            this.cmbFiltroTipo.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroTipo_SelectedIndexChanged);

            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(500, 45);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 28);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "🔍 Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(590, 45);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(90, 28);
            this.btnRefrescar.TabIndex = 4;
            this.btnRefrescar.Text = "🔄 Limpiar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);

            // Fila 2: Fechas
            this.chkFecha.AutoSize = true;
            this.chkFecha.ForeColor = System.Drawing.Color.White;
            this.chkFecha.Location = new System.Drawing.Point(15, 95);
            this.chkFecha.Name = "chkFecha";
            this.chkFecha.Size = new System.Drawing.Size(100, 19);
            this.chkFecha.TabIndex = 5;
            this.chkFecha.Text = "Filtrar fecha:";
            this.chkFecha.UseVisualStyleBackColor = true;
            this.chkFecha.CheckedChanged += new System.EventHandler(this.chkFecha_CheckedChanged);

            this.lblDesde.AutoSize = true;
            this.lblDesde.ForeColor = System.Drawing.Color.White;
            this.lblDesde.Location = new System.Drawing.Point(130, 96);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(42, 15);
            this.lblDesde.Text = "Desde:";

            this.dtpDesde.Enabled = false;
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(180, 93);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(120, 23);
            this.dtpDesde.TabIndex = 6;

            this.lblHasta.AutoSize = true;
            this.lblHasta.ForeColor = System.Drawing.Color.White;
            this.lblHasta.Location = new System.Drawing.Point(315, 96);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(40, 15);
            this.lblHasta.Text = "Hasta:";

            this.dtpHasta.Enabled = false;
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(360, 93);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(120, 23);
            this.dtpHasta.TabIndex = 7;

            // Botones de acción (fila superior derecha)
            this.btnNuevaEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevaEntrada.BackColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.btnNuevaEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaEntrada.ForeColor = System.Drawing.Color.White;
            this.btnNuevaEntrada.Location = new System.Drawing.Point(520, 10);
            this.btnNuevaEntrada.Name = "btnNuevaEntrada";
            this.btnNuevaEntrada.Size = new System.Drawing.Size(130, 32);
            this.btnNuevaEntrada.TabIndex = 8;
            this.btnNuevaEntrada.Text = "📥 Nueva Entrada";
            this.btnNuevaEntrada.UseVisualStyleBackColor = false;
            this.btnNuevaEntrada.Click += new System.EventHandler(this.btnNuevaEntrada_Click);

            this.btnNuevaSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevaSalida.BackColor = System.Drawing.Color.FromArgb(231, 29, 54);
            this.btnNuevaSalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaSalida.ForeColor = System.Drawing.Color.White;
            this.btnNuevaSalida.Location = new System.Drawing.Point(660, 10);
            this.btnNuevaSalida.Name = "btnNuevaSalida";
            this.btnNuevaSalida.Size = new System.Drawing.Size(130, 32);
            this.btnNuevaSalida.TabIndex = 9;
            this.btnNuevaSalida.Text = "📤 Nueva Salida";
            this.btnNuevaSalida.UseVisualStyleBackColor = false;
            this.btnNuevaSalida.Click += new System.EventHandler(this.btnNuevaSalida_Click);

            this.btnNuevoTraslado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoTraslado.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.btnNuevoTraslado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoTraslado.ForeColor = System.Drawing.Color.White;
            this.btnNuevoTraslado.Location = new System.Drawing.Point(800, 10);
            this.btnNuevoTraslado.Name = "btnNuevoTraslado";
            this.btnNuevoTraslado.Size = new System.Drawing.Size(140, 32);
            this.btnNuevoTraslado.TabIndex = 10;
            this.btnNuevoTraslado.Text = "↔️ Nuevo Traslado";
            this.btnNuevoTraslado.UseVisualStyleBackColor = false;
            this.btnNuevoTraslado.Click += new System.EventHandler(this.btnNuevoTraslado_Click);

            this.btnVerDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerDetalle.BackColor = System.Drawing.Color.FromArgb(255, 159, 28);
            this.btnVerDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerDetalle.ForeColor = System.Drawing.Color.White;
            this.btnVerDetalle.Location = new System.Drawing.Point(950, 10);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(120, 32);
            this.btnVerDetalle.TabIndex = 11;
            this.btnVerDetalle.Text = "👁️ Ver Detalle";
            this.btnVerDetalle.UseVisualStyleBackColor = false;
            this.btnVerDetalle.Click += new System.EventHandler(this.btnVerDetalle_Click);

            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1080, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 32);
            this.btnCerrar.TabIndex = 12;
            this.btnCerrar.Text = "✖ Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // ===== dgvMovimientos =====
            this.dgvMovimientos.AllowUserToAddRows = false;
            this.dgvMovimientos.AllowUserToDeleteRows = false;
            this.dgvMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovimientos.BackgroundColor = System.Drawing.Color.White;
            this.dgvMovimientos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMovimientos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.dgvMovimientos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMovimientos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvMovimientos.ColumnHeadersHeight = 35;
            this.dgvMovimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colId, this.colNumero, this.colTipo, this.colFecha,
                this.colOrigen, this.colDestino, this.colObservacion, this.colTotal});
            this.dgvMovimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovimientos.Location = new System.Drawing.Point(0, 140);
            this.dgvMovimientos.MultiSelect = false;
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly = true;
            this.dgvMovimientos.RowHeadersVisible = false;
            this.dgvMovimientos.RowTemplate.Height = 30;
            this.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimientos.Size = new System.Drawing.Size(1200, 430);
            this.dgvMovimientos.TabIndex = 1;
            this.dgvMovimientos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovimientos_CellDoubleClick);

            // Columnas
            this.colId.Name = "colId";
            this.colId.HeaderText = "ID";
            this.colId.Visible = false;

            this.colNumero.Name = "colNumero";
            this.colNumero.HeaderText = "Documento";
            this.colNumero.FillWeight = 100;

            this.colTipo.Name = "colTipo";
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.FillWeight = 80;

            this.colFecha.Name = "colFecha";
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.FillWeight = 100;

            this.colOrigen.Name = "colOrigen";
            this.colOrigen.HeaderText = "Origen";
            this.colOrigen.FillWeight = 120;

            this.colDestino.Name = "colDestino";
            this.colDestino.HeaderText = "Destino";
            this.colDestino.FillWeight = 120;

            this.colObservacion.Name = "colObservacion";
            this.colObservacion.HeaderText = "Observación";
            this.colObservacion.FillWeight = 150;

            this.colTotal.Name = "colTotal";
            this.colTotal.HeaderText = "Total";
            this.colTotal.FillWeight = 80;

            // ===== panelBottom =====
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.panelBottom.Controls.Add(this.lblTotal);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 570);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1200, 30);
            this.panelBottom.TabIndex = 2;

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(15, 7);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(150, 15);
            this.lblTotal.Text = "Total: 0 movimiento(s)";

            // ===== FrmMovimientos =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.dgvMovimientos);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "FrmMovimientos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Movimientos";
            this.Load += new System.EventHandler(this.FrmMovimientos_Load);

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblFiltroTipo;
        private System.Windows.Forms.ComboBox cmbFiltroTipo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.CheckBox chkFecha;
        private System.Windows.Forms.Button btnNuevaEntrada;
        private System.Windows.Forms.Button btnNuevaSalida;
        private System.Windows.Forms.Button btnNuevoTraslado;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;

        #endregion
    }
}