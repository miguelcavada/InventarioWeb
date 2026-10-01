namespace InventarioWeb.WinForms.Forms
{
    partial class FrmConsignaciones
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
            this.btnNuevo = new System.Windows.Forms.Button();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.lblFiltroEstado = new System.Windows.Forms.Label();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvConsignaciones = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntregados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVendidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDevueltos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPendientes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();

            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsignaciones)).BeginInit();
            this.SuspendLayout();

            // ===== panelTop =====
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.panelTop.Controls.Add(this.btnCerrar);
            this.panelTop.Controls.Add(this.btnVerDetalle);
            this.panelTop.Controls.Add(this.btnNuevo);
            this.panelTop.Controls.Add(this.cmbFiltroEstado);
            this.panelTop.Controls.Add(this.lblFiltroEstado);
            this.panelTop.Controls.Add(this.btnRefrescar);
            this.panelTop.Controls.Add(this.btnBuscar);
            this.panelTop.Controls.Add(this.txtBuscar);
            this.panelTop.Controls.Add(this.lblBuscar);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 100);
            this.panelTop.TabIndex = 0;

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(15, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(250, 25);
            this.lblTitulo.Text = "Gestión de Consignaciones";

            // lblBuscar
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.ForeColor = System.Drawing.Color.White;
            this.lblBuscar.Location = new System.Drawing.Point(15, 60);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(45, 15);
            this.lblBuscar.Text = "Buscar:";

            // txtBuscar
            this.txtBuscar.Location = new System.Drawing.Point(70, 57);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(220, 23);
            this.txtBuscar.TabIndex = 1;

            // lblFiltroEstado
            this.lblFiltroEstado.AutoSize = true;
            this.lblFiltroEstado.ForeColor = System.Drawing.Color.White;
            this.lblFiltroEstado.Location = new System.Drawing.Point(310, 60);
            this.lblFiltroEstado.Name = "lblFiltroEstado";
            this.lblFiltroEstado.Size = new System.Drawing.Size(45, 15);
            this.lblFiltroEstado.Text = "Estado:";

            // cmbFiltroEstado
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.Location = new System.Drawing.Point(360, 57);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(160, 23);
            this.cmbFiltroEstado.TabIndex = 2;
            this.cmbFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroEstado_SelectedIndexChanged);

            // btnBuscar
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(540, 55);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 28);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "🔍 Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            // btnRefrescar
            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(630, 55);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(90, 28);
            this.btnRefrescar.TabIndex = 4;
            this.btnRefrescar.Text = "🔄 Limpiar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);

            // btnNuevo
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(850, 55);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(150, 28);
            this.btnNuevo.TabIndex = 5;
            this.btnNuevo.Text = "➕ Nueva Consignación";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            // btnVerDetalle
            this.btnVerDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerDetalle.BackColor = System.Drawing.Color.FromArgb(255, 159, 28);
            this.btnVerDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerDetalle.ForeColor = System.Drawing.Color.White;
            this.btnVerDetalle.Location = new System.Drawing.Point(1010, 55);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(120, 28);
            this.btnVerDetalle.TabIndex = 6;
            this.btnVerDetalle.Text = "👁️ Ver Detalle";
            this.btnVerDetalle.UseVisualStyleBackColor = false;
            this.btnVerDetalle.Click += new System.EventHandler(this.btnVerDetalle_Click);

            // btnCerrar
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(850, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 30);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "✖ Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // ===== dgvConsignaciones =====
            this.dgvConsignaciones.AllowUserToAddRows = false;
            this.dgvConsignaciones.AllowUserToDeleteRows = false;
            this.dgvConsignaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConsignaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvConsignaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvConsignaciones.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.dgvConsignaciones.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvConsignaciones.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvConsignaciones.ColumnHeadersHeight = 35;
            this.dgvConsignaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colId, this.colNumero, this.colFecha, this.colVendedor, this.colAlmacen,
                this.colEntregados, this.colVendidos, this.colDevueltos, this.colPendientes, this.colEstado});
            this.dgvConsignaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConsignaciones.Location = new System.Drawing.Point(0, 100);
            this.dgvConsignaciones.MultiSelect = false;
            this.dgvConsignaciones.Name = "dgvConsignaciones";
            this.dgvConsignaciones.ReadOnly = true;
            this.dgvConsignaciones.RowHeadersVisible = false;
            this.dgvConsignaciones.RowTemplate.Height = 30;
            this.dgvConsignaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsignaciones.Size = new System.Drawing.Size(1200, 470);
            this.dgvConsignaciones.TabIndex = 1;
            this.dgvConsignaciones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsignaciones_CellDoubleClick);

            // Columnas
            this.colId.Name = "colId";
            this.colId.HeaderText = "ID";
            this.colId.Visible = false;

            this.colNumero.Name = "colNumero";
            this.colNumero.HeaderText = "N° Consignación";
            this.colNumero.FillWeight = 100;

            this.colFecha.Name = "colFecha";
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.FillWeight = 80;

            this.colVendedor.Name = "colVendedor";
            this.colVendedor.HeaderText = "Vendedor";
            this.colVendedor.FillWeight = 150;

            this.colAlmacen.Name = "colAlmacen";
            this.colAlmacen.HeaderText = "Almacén";
            this.colAlmacen.FillWeight = 120;

            this.colEntregados.Name = "colEntregados";
            this.colEntregados.HeaderText = "Entregados";
            this.colEntregados.FillWeight = 80;

            this.colVendidos.Name = "colVendidos";
            this.colVendidos.HeaderText = "Vendidos";
            this.colVendidos.FillWeight = 80;

            this.colDevueltos.Name = "colDevueltos";
            this.colDevueltos.HeaderText = "Devueltos";
            this.colDevueltos.FillWeight = 80;

            this.colPendientes.Name = "colPendientes";
            this.colPendientes.HeaderText = "Pendientes";
            this.colPendientes.FillWeight = 80;

            this.colEstado.Name = "colEstado";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.FillWeight = 90;

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
            this.lblTotal.Text = "Total: 0 consignación(es)";

            // ===== FrmConsignaciones =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.dgvConsignaciones);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "FrmConsignaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Consignaciones";
            this.Load += new System.EventHandler(this.FrmConsignaciones_Load);

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsignaciones)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblFiltroEstado;
        private System.Windows.Forms.ComboBox cmbFiltroEstado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvConsignaciones;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntregados;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVendidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDevueltos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPendientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;

        #endregion
    }
}