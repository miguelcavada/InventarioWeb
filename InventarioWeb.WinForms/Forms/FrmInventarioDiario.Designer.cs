namespace InventarioWeb.WinForms.Forms
{
    partial class FrmInventarioDiario
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
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFechaConsulta = new System.Windows.Forms.Label();
            this.panelKPIs = new System.Windows.Forms.Panel();
            this.lblValorInventario = new System.Windows.Forms.Label();
            this.lblValorInventarioTitulo = new System.Windows.Forms.Label();
            this.lblTotalSalidas = new System.Windows.Forms.Label();
            this.lblTotalSalidasTitulo = new System.Windows.Forms.Label();
            this.lblTotalEntradas = new System.Windows.Forms.Label();
            this.lblTotalEntradasTitulo = new System.Windows.Forms.Label();
            this.lblTotalProductos = new System.Windows.Forms.Label();
            this.lblTotalProductosTitulo = new System.Windows.Forms.Label();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntradas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalidas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioMinorista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioMayorista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnExportarPdf = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();

            this.panelTop.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.panelKPIs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();

            // ===== panelTop =====
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.panelTop.Controls.Add(this.lblEstado);
            this.panelTop.Controls.Add(this.lblFecha);
            this.panelTop.Controls.Add(this.lblAlmacen);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 90);
            this.panelTop.TabIndex = 0;

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(15, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(250, 25);
            this.lblTitulo.Text = "📅 Inventario Diario";

            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAlmacen.ForeColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.lblAlmacen.Location = new System.Drawing.Point(15, 42);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(150, 20);
            this.lblAlmacen.Text = "🏪 Almacén";

            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(400, 45);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(100, 19);
            this.lblFecha.Text = "📅 Fecha";

            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.lblEstado.Location = new System.Drawing.Point(15, 68);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 15);

            // ===== panelFiltros =====
            this.panelFiltros.BackColor = System.Drawing.Color.White;
            this.panelFiltros.Controls.Add(this.btnRefrescar);
            this.panelFiltros.Controls.Add(this.dtpFecha);
            this.panelFiltros.Controls.Add(this.lblFechaConsulta);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 90);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelFiltros.Size = new System.Drawing.Size(1200, 55);
            this.panelFiltros.TabIndex = 1;

            this.lblFechaConsulta.AutoSize = true;
            this.lblFechaConsulta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaConsulta.Location = new System.Drawing.Point(15, 18);
            this.lblFechaConsulta.Name = "lblFechaConsulta";
            this.lblFechaConsulta.Size = new System.Drawing.Size(100, 15);
            this.lblFechaConsulta.Text = "Consultar fecha:";

            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFecha.Location = new System.Drawing.Point(130, 15);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(250, 23);
            this.dtpFecha.TabIndex = 0;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);

            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(400, 12);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(120, 28);
            this.btnRefrescar.TabIndex = 1;
            this.btnRefrescar.Text = "🔄 Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);

            // ===== panelKPIs =====
            this.panelKPIs.BackColor = System.Drawing.Color.FromArgb(240, 240, 245);
            this.panelKPIs.Controls.Add(this.lblValorInventario);
            this.panelKPIs.Controls.Add(this.lblValorInventarioTitulo);
            this.panelKPIs.Controls.Add(this.lblTotalSalidas);
            this.panelKPIs.Controls.Add(this.lblTotalSalidasTitulo);
            this.panelKPIs.Controls.Add(this.lblTotalEntradas);
            this.panelKPIs.Controls.Add(this.lblTotalEntradasTitulo);
            this.panelKPIs.Controls.Add(this.lblTotalProductos);
            this.panelKPIs.Controls.Add(this.lblTotalProductosTitulo);
            this.panelKPIs.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKPIs.Location = new System.Drawing.Point(0, 145);
            this.panelKPIs.Name = "panelKPIs";
            this.panelKPIs.Size = new System.Drawing.Size(1200, 80);
            this.panelKPIs.TabIndex = 2;

            // KPI Productos
            this.lblTotalProductosTitulo.AutoSize = true;
            this.lblTotalProductosTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalProductosTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalProductosTitulo.Location = new System.Drawing.Point(30, 15);
            this.lblTotalProductosTitulo.Size = new System.Drawing.Size(100, 15);
            this.lblTotalProductosTitulo.Text = "Total Productos";

            this.lblTotalProductos.AutoSize = true;
            this.lblTotalProductos.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalProductos.ForeColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.lblTotalProductos.Location = new System.Drawing.Point(30, 35);
            this.lblTotalProductos.Size = new System.Drawing.Size(40, 32);
            this.lblTotalProductos.Text = "0";

            // KPI Entradas
            this.lblTotalEntradasTitulo.AutoSize = true;
            this.lblTotalEntradasTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalEntradasTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalEntradasTitulo.Location = new System.Drawing.Point(230, 15);
            this.lblTotalEntradasTitulo.Size = new System.Drawing.Size(100, 15);
            this.lblTotalEntradasTitulo.Text = "Entradas del Día";

            this.lblTotalEntradas.AutoSize = true;
            this.lblTotalEntradas.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalEntradas.ForeColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.lblTotalEntradas.Location = new System.Drawing.Point(230, 35);
            this.lblTotalEntradas.Size = new System.Drawing.Size(40, 32);
            this.lblTotalEntradas.Text = "0";

            // KPI Salidas
            this.lblTotalSalidasTitulo.AutoSize = true;
            this.lblTotalSalidasTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalSalidasTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalSalidasTitulo.Location = new System.Drawing.Point(430, 15);
            this.lblTotalSalidasTitulo.Size = new System.Drawing.Size(100, 15);
            this.lblTotalSalidasTitulo.Text = "Salidas del Día";

            this.lblTotalSalidas.AutoSize = true;
            this.lblTotalSalidas.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalSalidas.ForeColor = System.Drawing.Color.FromArgb(231, 29, 54);
            this.lblTotalSalidas.Location = new System.Drawing.Point(430, 35);
            this.lblTotalSalidas.Size = new System.Drawing.Size(40, 32);
            this.lblTotalSalidas.Text = "0";

            // KPI Valor
            this.lblValorInventarioTitulo.AutoSize = true;
            this.lblValorInventarioTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblValorInventarioTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblValorInventarioTitulo.Location = new System.Drawing.Point(630, 15);
            this.lblValorInventarioTitulo.Size = new System.Drawing.Size(100, 15);
            this.lblValorInventarioTitulo.Text = "Valor Inventario";

            this.lblValorInventario.AutoSize = true;
            this.lblValorInventario.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblValorInventario.ForeColor = System.Drawing.Color.FromArgb(255, 159, 28);
            this.lblValorInventario.Location = new System.Drawing.Point(630, 35);
            this.lblValorInventario.Size = new System.Drawing.Size(50, 32);
            this.lblValorInventario.Text = "$0";

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
                this.colCodigo, this.colProducto, this.colUnidad,
                this.colInicial, this.colEntradas, this.colSalidas, this.colFinal,
                this.colPrecioMinorista, this.colPrecioMayorista, this.colValor});
            this.dgvInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventario.Location = new System.Drawing.Point(0, 225);
            this.dgvInventario.MultiSelect = false;
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.ReadOnly = true;
            this.dgvInventario.RowHeadersVisible = false;
            this.dgvInventario.RowTemplate.Height = 28;
            this.dgvInventario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventario.Size = new System.Drawing.Size(1200, 355);
            this.dgvInventario.TabIndex = 3;

            // Columnas
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.FillWeight = 70;

            this.colProducto.Name = "colProducto";
            this.colProducto.HeaderText = "Producto";
            this.colProducto.FillWeight = 180;

            this.colUnidad.Name = "colUnidad";
            this.colUnidad.HeaderText = "Uni";
            this.colUnidad.FillWeight = 50;

            this.colInicial.Name = "colInicial";
            this.colInicial.HeaderText = "Exist. Inicial";
            this.colInicial.FillWeight = 80;

            this.colEntradas.Name = "colEntradas";
            this.colEntradas.HeaderText = "Entradas";
            this.colEntradas.FillWeight = 70;

            this.colSalidas.Name = "colSalidas";
            this.colSalidas.HeaderText = "Salidas";
            this.colSalidas.FillWeight = 70;

            this.colFinal.Name = "colFinal";
            this.colFinal.HeaderText = "Exist. Final";
            this.colFinal.FillWeight = 80;

            this.colPrecioMinorista.Name = "colPrecioMinorista";
            this.colPrecioMinorista.HeaderText = "P. Minorista";
            this.colPrecioMinorista.FillWeight = 90;

            this.colPrecioMayorista.Name = "colPrecioMayorista";
            this.colPrecioMayorista.HeaderText = "P. Mayorista";
            this.colPrecioMayorista.FillWeight = 90;

            this.colValor.Name = "colValor";
            this.colValor.HeaderText = "Valor Inventario";
            this.colValor.FillWeight = 100;

            // ===== panelBottom =====
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.panelBottom.Controls.Add(this.lblTotal);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 580);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1200, 30);
            this.panelBottom.TabIndex = 4;

            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(15, 7);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(150, 15);
            this.lblTotal.Text = "Mostrando 0 producto(s)";

            // ===== panelBotones =====
            this.panelBotones.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.panelBotones.Controls.Add(this.btnExportarPdf);
            this.panelBotones.Controls.Add(this.btnExportarExcel);
            this.panelBotones.Controls.Add(this.btnCerrar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 610);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(1200, 60);
            this.panelBotones.TabIndex = 5;

            // btnCerrar
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1050, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(130, 38);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "✖ Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // btnExportarExcel
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.BackColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportarExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportarExcel.Location = new System.Drawing.Point(720, 12);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(160, 38);
            this.btnExportarExcel.TabIndex = 1;
            this.btnExportarExcel.Text = "📊 Exportar Excel";
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);

            // btnExportarPdf
            this.btnExportarPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarPdf.BackColor = System.Drawing.Color.FromArgb(231, 29, 54);
            this.btnExportarPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPdf.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportarPdf.ForeColor = System.Drawing.Color.White;
            this.btnExportarPdf.Location = new System.Drawing.Point(890, 12);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.Size = new System.Drawing.Size(150, 38);
            this.btnExportarPdf.TabIndex = 2;
            this.btnExportarPdf.Text = "📄 Exportar PDF";
            this.btnExportarPdf.UseVisualStyleBackColor = false;
            this.btnExportarPdf.Click += new System.EventHandler(this.btnExportarPdf_Click);

            // ===== FrmInventarioDiario =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 670);
            this.Controls.Add(this.dgvInventario);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelKPIs);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "FrmInventarioDiario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inventario Diario";
            this.Load += new System.EventHandler(this.FrmInventarioDiario_Load);

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.panelKPIs.ResumeLayout(false);
            this.panelKPIs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Panel panelKPIs;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblFechaConsulta;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Label lblTotalProductosTitulo;
        private System.Windows.Forms.Label lblTotalProductos;
        private System.Windows.Forms.Label lblTotalEntradasTitulo;
        private System.Windows.Forms.Label lblTotalEntradas;
        private System.Windows.Forms.Label lblTotalSalidasTitulo;
        private System.Windows.Forms.Label lblTotalSalidas;
        private System.Windows.Forms.Label lblValorInventarioTitulo;
        private System.Windows.Forms.Label lblValorInventario;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntradas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioMinorista;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioMayorista;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Button btnExportarPdf;
        private System.Windows.Forms.Button btnCerrar;

        #endregion
    }
}