namespace InventarioWeb.WinForms.Forms
{
    partial class FrmAlmacenInventario
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
            this.chkStockBajo = new System.Windows.Forms.CheckBox();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelKPIs = new System.Windows.Forms.Panel();
            this.lblAgotadosValor = new System.Windows.Forms.Label();
            this.lblAgotadosTitulo = new System.Windows.Forms.Label();
            this.lblStockBajoValor = new System.Windows.Forms.Label();
            this.lblStockBajoTitulo = new System.Windows.Forms.Label();
            this.lblTotalUnidadesValor = new System.Windows.Forms.Label();
            this.lblTotalUnidadesTitulo = new System.Windows.Forms.Label();
            this.lblTotalProductosValor = new System.Windows.Forms.Label();
            this.lblTotalProductosTitulo = new System.Windows.Forms.Label();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaximo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUbicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();

            // Para compatibilidad con el código
            this.lblTotalProductos = new System.Windows.Forms.Label();
            this.lblTotalUnidades = new System.Windows.Forms.Label();
            this.lblStockBajo = new System.Windows.Forms.Label();
            this.lblAgotados = new System.Windows.Forms.Label();

            this.panelTop.SuspendLayout();
            this.panelKPIs.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.SuspendLayout();

            // ===== panelTop =====
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.panelTop.Controls.Add(this.btnCerrar);
            this.panelTop.Controls.Add(this.chkStockBajo);
            this.panelTop.Controls.Add(this.btnRefrescar);
            this.panelTop.Controls.Add(this.btnBuscar);
            this.panelTop.Controls.Add(this.txtBuscar);
            this.panelTop.Controls.Add(this.lblBuscar);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 100);
            this.panelTop.TabIndex = 0;

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(15, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(250, 25);
            this.lblTitulo.Text = "📋 Inventario";

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
            this.txtBuscar.Size = new System.Drawing.Size(250, 23);
            this.txtBuscar.TabIndex = 1;

            // btnBuscar
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(330, 55);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 28);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "🔍 Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            // btnRefrescar
            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(420, 55);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(90, 28);
            this.btnRefrescar.TabIndex = 3;
            this.btnRefrescar.Text = "🔄 Limpiar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);

            // chkStockBajo
            this.chkStockBajo.AutoSize = true;
            this.chkStockBajo.ForeColor = System.Drawing.Color.White;
            this.chkStockBajo.Location = new System.Drawing.Point(530, 62);
            this.chkStockBajo.Name = "chkStockBajo";
            this.chkStockBajo.Size = new System.Drawing.Size(120, 19);
            this.chkStockBajo.TabIndex = 4;
            this.chkStockBajo.Text = "Solo stock bajo";
            this.chkStockBajo.UseVisualStyleBackColor = true;
            this.chkStockBajo.CheckedChanged += new System.EventHandler(this.chkStockBajo_CheckedChanged);

            // btnCerrar
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(880, 55);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(110, 28);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "✖ Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // ===== panelKPIs =====
            this.panelKPIs.BackColor = System.Drawing.Color.FromArgb(240, 240, 245);
            this.panelKPIs.Controls.Add(this.lblAgotadosValor);
            this.panelKPIs.Controls.Add(this.lblAgotadosTitulo);
            this.panelKPIs.Controls.Add(this.lblStockBajoValor);
            this.panelKPIs.Controls.Add(this.lblStockBajoTitulo);
            this.panelKPIs.Controls.Add(this.lblTotalUnidadesValor);
            this.panelKPIs.Controls.Add(this.lblTotalUnidadesTitulo);
            this.panelKPIs.Controls.Add(this.lblTotalProductosValor);
            this.panelKPIs.Controls.Add(this.lblTotalProductosTitulo);
            this.panelKPIs.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKPIs.Location = new System.Drawing.Point(0, 100);
            this.panelKPIs.Name = "panelKPIs";
            this.panelKPIs.Size = new System.Drawing.Size(1000, 80);
            this.panelKPIs.TabIndex = 1;

            // KPI Productos
            this.lblTotalProductosTitulo.AutoSize = true;
            this.lblTotalProductosTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalProductosTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalProductosTitulo.Location = new System.Drawing.Point(30, 15);
            this.lblTotalProductosTitulo.Name = "lblTotalProductosTitulo";
            this.lblTotalProductosTitulo.Size = new System.Drawing.Size(100, 15);
            this.lblTotalProductosTitulo.Text = "Total Productos";

            this.lblTotalProductosValor.AutoSize = true;
            this.lblTotalProductosValor.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalProductosValor.ForeColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.lblTotalProductosValor.Location = new System.Drawing.Point(30, 35);
            this.lblTotalProductosValor.Name = "lblTotalProductosValor";
            this.lblTotalProductosValor.Size = new System.Drawing.Size(40, 32);
            this.lblTotalProductosValor.Text = "0";

            // KPI Unidades
            this.lblTotalUnidadesTitulo.AutoSize = true;
            this.lblTotalUnidadesTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalUnidadesTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalUnidadesTitulo.Location = new System.Drawing.Point(230, 15);
            this.lblTotalUnidadesTitulo.Name = "lblTotalUnidadesTitulo";
            this.lblTotalUnidadesTitulo.Size = new System.Drawing.Size(100, 15);
            this.lblTotalUnidadesTitulo.Text = "Total Unidades";

            this.lblTotalUnidadesValor.AutoSize = true;
            this.lblTotalUnidadesValor.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalUnidadesValor.ForeColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.lblTotalUnidadesValor.Location = new System.Drawing.Point(230, 35);
            this.lblTotalUnidadesValor.Name = "lblTotalUnidadesValor";
            this.lblTotalUnidadesValor.Size = new System.Drawing.Size(40, 32);
            this.lblTotalUnidadesValor.Text = "0";

            // KPI Stock Bajo
            this.lblStockBajoTitulo.AutoSize = true;
            this.lblStockBajoTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStockBajoTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblStockBajoTitulo.Location = new System.Drawing.Point(430, 15);
            this.lblStockBajoTitulo.Name = "lblStockBajoTitulo";
            this.lblStockBajoTitulo.Size = new System.Drawing.Size(100, 15);
            this.lblStockBajoTitulo.Text = "Stock Bajo";

            this.lblStockBajoValor.AutoSize = true;
            this.lblStockBajoValor.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblStockBajoValor.ForeColor = System.Drawing.Color.FromArgb(255, 159, 28);
            this.lblStockBajoValor.Location = new System.Drawing.Point(430, 35);
            this.lblStockBajoValor.Name = "lblStockBajoValor";
            this.lblStockBajoValor.Size = new System.Drawing.Size(40, 32);
            this.lblStockBajoValor.Text = "0";

            // KPI Agotados
            this.lblAgotadosTitulo.AutoSize = true;
            this.lblAgotadosTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAgotadosTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblAgotadosTitulo.Location = new System.Drawing.Point(630, 15);
            this.lblAgotadosTitulo.Name = "lblAgotadosTitulo";
            this.lblAgotadosTitulo.Size = new System.Drawing.Size(100, 15);
            this.lblAgotadosTitulo.Text = "Agotados";

            this.lblAgotadosValor.AutoSize = true;
            this.lblAgotadosValor.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblAgotadosValor.ForeColor = System.Drawing.Color.FromArgb(231, 29, 54);
            this.lblAgotadosValor.Location = new System.Drawing.Point(630, 35);
            this.lblAgotadosValor.Name = "lblAgotadosValor";
            this.lblAgotadosValor.Size = new System.Drawing.Size(40, 32);
            this.lblAgotadosValor.Text = "0";

            // ===== dgvInventario =====
            this.dgvInventario.AllowUserToAddRows = false;
            this.dgvInventario.AllowUserToDeleteRows = false;
            this.dgvInventario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventario.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInventario.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.dgvInventario.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvInventario.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvInventario.ColumnHeadersHeight = 35;
            this.dgvInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colCodigo, this.colProducto, this.colStock, this.colMinimo,
                this.colMaximo, this.colUbicacion, this.colEstado});
            this.dgvInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventario.Location = new System.Drawing.Point(0, 180);
            this.dgvInventario.MultiSelect = false;
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.ReadOnly = true;
            this.dgvInventario.RowHeadersVisible = false;
            this.dgvInventario.RowTemplate.Height = 30;
            this.dgvInventario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventario.Size = new System.Drawing.Size(1000, 390);
            this.dgvInventario.TabIndex = 2;

            // Columnas
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.FillWeight = 80;

            this.colProducto.Name = "colProducto";
            this.colProducto.HeaderText = "Producto";
            this.colProducto.FillWeight = 200;

            this.colStock.Name = "colStock";
            this.colStock.HeaderText = "Stock";
            this.colStock.FillWeight = 70;

            this.colMinimo.Name = "colMinimo";
            this.colMinimo.HeaderText = "Mínimo";
            this.colMinimo.FillWeight = 70;

            this.colMaximo.Name = "colMaximo";
            this.colMaximo.HeaderText = "Máximo";
            this.colMaximo.FillWeight = 70;

            this.colUbicacion.Name = "colUbicacion";
            this.colUbicacion.HeaderText = "Ubicación";
            this.colUbicacion.FillWeight = 100;

            this.colEstado.Name = "colEstado";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.FillWeight = 100;

            // ===== panelBottom =====
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.panelBottom.Controls.Add(this.lblTotal);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 570);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1000, 30);
            this.panelBottom.TabIndex = 3;

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(15, 7);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(150, 15);
            this.lblTotal.Text = "Mostrando 0 producto(s)";

            // ===== FrmAlmacenInventario =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dgvInventario);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelKPIs);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FrmAlmacenInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.FrmAlmacenInventario_Load);

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelKPIs.ResumeLayout(false);
            this.panelKPIs.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelKPIs;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.CheckBox chkStockBajo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaximo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUbicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.Label lblTotal;

        // KPIs
        private System.Windows.Forms.Label lblTotalProductosTitulo;
        private System.Windows.Forms.Label lblTotalProductosValor;
        private System.Windows.Forms.Label lblTotalUnidadesTitulo;
        private System.Windows.Forms.Label lblTotalUnidadesValor;
        private System.Windows.Forms.Label lblStockBajoTitulo;
        private System.Windows.Forms.Label lblStockBajoValor;
        private System.Windows.Forms.Label lblAgotadosTitulo;
        private System.Windows.Forms.Label lblAgotadosValor;

        // Labels de valores (referenciados en código)
        private System.Windows.Forms.Label lblTotalProductos;
        private System.Windows.Forms.Label lblTotalUnidades;
        private System.Windows.Forms.Label lblStockBajo;
        private System.Windows.Forms.Label lblAgotados;

        #endregion
    }
}