namespace InventarioWeb.WinForms.Forms
{
    partial class FrmReportes
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelBody = new System.Windows.Forms.Panel();

            this.panelInventarioDiario = new System.Windows.Forms.Panel();
            this.btnInventarioDiarioPdf = new System.Windows.Forms.Button();
            this.btnInventarioDiarioExcel = new System.Windows.Forms.Button();
            this.btnInventarioDiarioVer = new System.Windows.Forms.Button();
            this.dtpFechaInventarioDiario = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInventarioDiario = new System.Windows.Forms.Label();
            this.cmbAlmacenInventarioDiario = new System.Windows.Forms.ComboBox();
            this.lblAlmacenInventarioDiario = new System.Windows.Forms.Label();
            this.lblInventarioDiarioTitulo = new System.Windows.Forms.Label();

            this.panelInventario = new System.Windows.Forms.Panel();
            this.btnInventarioPdf = new System.Windows.Forms.Button();
            this.btnInventarioExcel = new System.Windows.Forms.Button();
            this.btnInventarioVer = new System.Windows.Forms.Button();
            this.cmbAlmacenInventario = new System.Windows.Forms.ComboBox();
            this.lblAlmacenInventario = new System.Windows.Forms.Label();
            this.lblInventarioTitulo = new System.Windows.Forms.Label();
            this.panelMovimientos = new System.Windows.Forms.Panel();
            this.btnMovimientosPdf = new System.Windows.Forms.Button();
            this.btnMovimientosExcel = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.cmbTipoMovimiento = new System.Windows.Forms.ComboBox();
            this.lblTipoMovimiento = new System.Windows.Forms.Label();
            this.lblMovimientosTitulo = new System.Windows.Forms.Label();
            this.panelStockBajo = new System.Windows.Forms.Panel();
            this.btnStockBajoPdf = new System.Windows.Forms.Button();
            this.btnStockBajoExcel = new System.Windows.Forms.Button();
            this.lblStockBajoTitulo = new System.Windows.Forms.Label();
            this.panelProductos = new System.Windows.Forms.Panel();
            this.btnProductosPdf = new System.Windows.Forms.Button();
            this.btnProductosExcel = new System.Windows.Forms.Button();
            this.lblProductosTitulo = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();

            this.panelTop.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.panelInventario.SuspendLayout();
            this.panelMovimientos.SuspendLayout();
            this.panelStockBajo.SuspendLayout();
            this.panelProductos.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();

            // ===== panelTop =====
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.panelTop.Controls.Add(this.lblEstado);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(900, 70);
            this.panelTop.TabIndex = 0;

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(200, 25);
            this.lblTitulo.Text = "📊 Centro de Reportes";

            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.lblEstado.Location = new System.Drawing.Point(15, 45);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 15);

            // ===== panelBody =====
            this.panelBody.AutoScroll = true;
            this.panelBody.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.panelBody.Controls.Add(this.panelInventario);
            this.panelBody.Controls.Add(this.panelMovimientos);
            this.panelBody.Controls.Add(this.panelStockBajo);
            this.panelBody.Controls.Add(this.panelProductos);

            this.panelBody.Controls.Add(this.panelInventarioDiario);
            this.panelBody.Controls.Add(this.panelInventario);
            this.panelBody.Controls.Add(this.panelMovimientos);
            this.panelBody.Controls.Add(this.panelStockBajo);
            this.panelBody.Controls.Add(this.panelProductos);

            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 70);
            this.panelBody.Name = "panelBody";
            this.panelBody.Padding = new System.Windows.Forms.Padding(15);
            this.panelBody.Size = new System.Drawing.Size(900, 530);
            this.panelBody.TabIndex = 1;

            // ===== panelProductos =====
            this.panelProductos.BackColor = System.Drawing.Color.White;
            this.panelProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProductos.Controls.Add(this.btnProductosPdf);
            this.panelProductos.Controls.Add(this.btnProductosExcel);
            this.panelProductos.Controls.Add(this.lblProductosTitulo);
            this.panelProductos.Location = new System.Drawing.Point(15, 15);
            this.panelProductos.Name = "panelProductos";
            this.panelProductos.Size = new System.Drawing.Size(850, 100);
            this.panelProductos.TabIndex = 0;

            this.lblProductosTitulo.AutoSize = true;
            this.lblProductosTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblProductosTitulo.ForeColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.lblProductosTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblProductosTitulo.Name = "lblProductosTitulo";
            this.lblProductosTitulo.Size = new System.Drawing.Size(250, 21);
            this.lblProductosTitulo.Text = "📦 Reporte de Productos";

            this.btnProductosExcel.BackColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.btnProductosExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductosExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProductosExcel.ForeColor = System.Drawing.Color.White;
            this.btnProductosExcel.Location = new System.Drawing.Point(15, 50);
            this.btnProductosExcel.Name = "btnProductosExcel";
            this.btnProductosExcel.Size = new System.Drawing.Size(180, 35);
            this.btnProductosExcel.TabIndex = 1;
            this.btnProductosExcel.Text = "📊 Exportar a Excel";
            this.btnProductosExcel.UseVisualStyleBackColor = false;
            this.btnProductosExcel.Click += new System.EventHandler(this.btnProductosExcel_Click);

            this.btnProductosPdf.BackColor = System.Drawing.Color.FromArgb(231, 29, 54);
            this.btnProductosPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductosPdf.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProductosPdf.ForeColor = System.Drawing.Color.White;
            this.btnProductosPdf.Location = new System.Drawing.Point(210, 50);
            this.btnProductosPdf.Name = "btnProductosPdf";
            this.btnProductosPdf.Size = new System.Drawing.Size(180, 35);
            this.btnProductosPdf.TabIndex = 2;
            this.btnProductosPdf.Text = "📄 Exportar a PDF";
            this.btnProductosPdf.UseVisualStyleBackColor = false;
            this.btnProductosPdf.Click += new System.EventHandler(this.btnProductosPdf_Click);

            // ===== panelStockBajo =====
            this.panelStockBajo.BackColor = System.Drawing.Color.White;
            this.panelStockBajo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStockBajo.Controls.Add(this.btnStockBajoPdf);
            this.panelStockBajo.Controls.Add(this.btnStockBajoExcel);
            this.panelStockBajo.Controls.Add(this.lblStockBajoTitulo);
            this.panelStockBajo.Location = new System.Drawing.Point(15, 125);
            this.panelStockBajo.Name = "panelStockBajo";
            this.panelStockBajo.Size = new System.Drawing.Size(850, 100);
            this.panelStockBajo.TabIndex = 1;

            this.lblStockBajoTitulo.AutoSize = true;
            this.lblStockBajoTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStockBajoTitulo.ForeColor = System.Drawing.Color.FromArgb(255, 159, 28);
            this.lblStockBajoTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblStockBajoTitulo.Name = "lblStockBajoTitulo";
            this.lblStockBajoTitulo.Size = new System.Drawing.Size(250, 21);
            this.lblStockBajoTitulo.Text = "⚠️ Reporte de Stock Bajo";

            this.btnStockBajoExcel.BackColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.btnStockBajoExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockBajoExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStockBajoExcel.ForeColor = System.Drawing.Color.White;
            this.btnStockBajoExcel.Location = new System.Drawing.Point(15, 50);
            this.btnStockBajoExcel.Name = "btnStockBajoExcel";
            this.btnStockBajoExcel.Size = new System.Drawing.Size(180, 35);
            this.btnStockBajoExcel.TabIndex = 0;
            this.btnStockBajoExcel.Text = "📊 Exportar a Excel";
            this.btnStockBajoExcel.UseVisualStyleBackColor = false;
            this.btnStockBajoExcel.Click += new System.EventHandler(this.btnStockBajoExcel_Click);

            this.btnStockBajoPdf.BackColor = System.Drawing.Color.FromArgb(231, 29, 54);
            this.btnStockBajoPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockBajoPdf.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStockBajoPdf.ForeColor = System.Drawing.Color.White;
            this.btnStockBajoPdf.Location = new System.Drawing.Point(210, 50);
            this.btnStockBajoPdf.Name = "btnStockBajoPdf";
            this.btnStockBajoPdf.Size = new System.Drawing.Size(180, 35);
            this.btnStockBajoPdf.TabIndex = 1;
            this.btnStockBajoPdf.Text = "📄 Exportar a PDF";
            this.btnStockBajoPdf.UseVisualStyleBackColor = false;
            this.btnStockBajoPdf.Click += new System.EventHandler(this.btnStockBajoPdf_Click);

            // ===== panelMovimientos =====
            this.panelMovimientos.BackColor = System.Drawing.Color.White;
            this.panelMovimientos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMovimientos.Controls.Add(this.btnMovimientosPdf);
            this.panelMovimientos.Controls.Add(this.btnMovimientosExcel);
            this.panelMovimientos.Controls.Add(this.dtpHasta);
            this.panelMovimientos.Controls.Add(this.lblHasta);
            this.panelMovimientos.Controls.Add(this.dtpDesde);
            this.panelMovimientos.Controls.Add(this.lblDesde);
            this.panelMovimientos.Controls.Add(this.cmbTipoMovimiento);
            this.panelMovimientos.Controls.Add(this.lblTipoMovimiento);
            this.panelMovimientos.Controls.Add(this.lblMovimientosTitulo);
            this.panelMovimientos.Location = new System.Drawing.Point(15, 235);
            this.panelMovimientos.Name = "panelMovimientos";
            this.panelMovimientos.Size = new System.Drawing.Size(850, 150);
            this.panelMovimientos.TabIndex = 2;

            this.lblMovimientosTitulo.AutoSize = true;
            this.lblMovimientosTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMovimientosTitulo.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblMovimientosTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblMovimientosTitulo.Name = "lblMovimientosTitulo";
            this.lblMovimientosTitulo.Size = new System.Drawing.Size(250, 21);
            this.lblMovimientosTitulo.Text = "↔️ Reporte de Movimientos";

            this.lblTipoMovimiento.AutoSize = true;
            this.lblTipoMovimiento.Location = new System.Drawing.Point(15, 50);
            this.lblTipoMovimiento.Name = "lblTipoMovimiento";
            this.lblTipoMovimiento.Size = new System.Drawing.Size(35, 15);
            this.lblTipoMovimiento.Text = "Tipo:";

            this.cmbTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoMovimiento.Items.AddRange(new object[] {
                "Todos", "Entradas", "Salidas", "Traslados"});
            this.cmbTipoMovimiento.Location = new System.Drawing.Point(60, 47);
            this.cmbTipoMovimiento.Name = "cmbTipoMovimiento";
            this.cmbTipoMovimiento.Size = new System.Drawing.Size(130, 23);
            this.cmbTipoMovimiento.TabIndex = 0;

            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(210, 50);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(42, 15);
            this.lblDesde.Text = "Desde:";

            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(260, 47);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(120, 23);
            this.dtpDesde.TabIndex = 1;

            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(400, 50);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(40, 15);
            this.lblHasta.Text = "Hasta:";

            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(450, 47);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(120, 23);
            this.dtpHasta.TabIndex = 2;

            this.btnMovimientosExcel.BackColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.btnMovimientosExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMovimientosExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMovimientosExcel.ForeColor = System.Drawing.Color.White;
            this.btnMovimientosExcel.Location = new System.Drawing.Point(15, 90);
            this.btnMovimientosExcel.Name = "btnMovimientosExcel";
            this.btnMovimientosExcel.Size = new System.Drawing.Size(180, 35);
            this.btnMovimientosExcel.TabIndex = 3;
            this.btnMovimientosExcel.Text = "📊 Exportar a Excel";
            this.btnMovimientosExcel.UseVisualStyleBackColor = false;
            this.btnMovimientosExcel.Click += new System.EventHandler(this.btnMovimientosExcel_Click);

            this.btnMovimientosPdf.BackColor = System.Drawing.Color.FromArgb(231, 29, 54);
            this.btnMovimientosPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMovimientosPdf.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMovimientosPdf.ForeColor = System.Drawing.Color.White;
            this.btnMovimientosPdf.Location = new System.Drawing.Point(210, 90);
            this.btnMovimientosPdf.Name = "btnMovimientosPdf";
            this.btnMovimientosPdf.Size = new System.Drawing.Size(180, 35);
            this.btnMovimientosPdf.TabIndex = 4;
            this.btnMovimientosPdf.Text = "📄 Exportar a PDF";
            this.btnMovimientosPdf.UseVisualStyleBackColor = false;
            this.btnMovimientosPdf.Click += new System.EventHandler(this.btnMovimientosPdf_Click);

            // ===== panelInventario =====
            this.panelInventario.BackColor = System.Drawing.Color.White;
            this.panelInventario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInventario.Controls.Add(this.btnInventarioPdf);
            this.panelInventario.Controls.Add(this.btnInventarioExcel);
            this.panelInventario.Controls.Add(this.btnInventarioVer);
            this.panelInventario.Controls.Add(this.cmbAlmacenInventario);
            this.panelInventario.Controls.Add(this.lblAlmacenInventario);
            this.panelInventario.Controls.Add(this.lblInventarioTitulo);
            this.panelInventario.Location = new System.Drawing.Point(15, 395);
            this.panelInventario.Name = "panelInventario";
            this.panelInventario.Size = new System.Drawing.Size(850, 150);
            this.panelInventario.TabIndex = 3;

            this.lblInventarioTitulo.AutoSize = true;
            this.lblInventarioTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblInventarioTitulo.ForeColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.lblInventarioTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblInventarioTitulo.Name = "lblInventarioTitulo";
            this.lblInventarioTitulo.Size = new System.Drawing.Size(350, 21);
            this.lblInventarioTitulo.Text = "🏪 Inventario Actual por Almacén/Mercado";

            this.lblAlmacenInventario.AutoSize = true;
            this.lblAlmacenInventario.Location = new System.Drawing.Point(15, 50);
            this.lblAlmacenInventario.Name = "lblAlmacenInventario";
            this.lblAlmacenInventario.Size = new System.Drawing.Size(90, 15);
            this.lblAlmacenInventario.Text = "Almacén:";

            this.cmbAlmacenInventario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlmacenInventario.Location = new System.Drawing.Point(110, 47);
            this.cmbAlmacenInventario.Name = "cmbAlmacenInventario";
            this.cmbAlmacenInventario.Size = new System.Drawing.Size(300, 23);
            this.cmbAlmacenInventario.TabIndex = 0;

            this.btnInventarioVer.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.btnInventarioVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventarioVer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnInventarioVer.ForeColor = System.Drawing.Color.White;
            this.btnInventarioVer.Location = new System.Drawing.Point(15, 90);
            this.btnInventarioVer.Name = "btnInventarioVer";
            this.btnInventarioVer.Size = new System.Drawing.Size(180, 35);
            this.btnInventarioVer.TabIndex = 1;
            this.btnInventarioVer.Text = "👁️ Ver Inventario";
            this.btnInventarioVer.UseVisualStyleBackColor = false;
            this.btnInventarioVer.Click += new System.EventHandler(this.btnInventarioVer_Click);

            this.btnInventarioExcel.BackColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.btnInventarioExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventarioExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnInventarioExcel.ForeColor = System.Drawing.Color.White;
            this.btnInventarioExcel.Location = new System.Drawing.Point(210, 90);
            this.btnInventarioExcel.Name = "btnInventarioExcel";
            this.btnInventarioExcel.Size = new System.Drawing.Size(180, 35);
            this.btnInventarioExcel.TabIndex = 2;
            this.btnInventarioExcel.Text = "📊 Exportar a Excel";
            this.btnInventarioExcel.UseVisualStyleBackColor = false;
            this.btnInventarioExcel.Click += new System.EventHandler(this.btnInventarioExcel_Click);

            this.btnInventarioPdf.BackColor = System.Drawing.Color.FromArgb(231, 29, 54);
            this.btnInventarioPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventarioPdf.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnInventarioPdf.ForeColor = System.Drawing.Color.White;
            this.btnInventarioPdf.Location = new System.Drawing.Point(405, 90);
            this.btnInventarioPdf.Name = "btnInventarioPdf";
            this.btnInventarioPdf.Size = new System.Drawing.Size(180, 35);
            this.btnInventarioPdf.TabIndex = 3;
            this.btnInventarioPdf.Text = "📄 Exportar a PDF";
            this.btnInventarioPdf.UseVisualStyleBackColor = false;
            this.btnInventarioPdf.Click += new System.EventHandler(this.btnInventarioPdf_Click);

            // ===== panelInventarioDiario =====
            this.panelInventarioDiario.BackColor = System.Drawing.Color.White;
            this.panelInventarioDiario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInventarioDiario.Controls.Add(this.btnInventarioDiarioPdf);
            this.panelInventarioDiario.Controls.Add(this.btnInventarioDiarioExcel);
            this.panelInventarioDiario.Controls.Add(this.btnInventarioDiarioVer);
            this.panelInventarioDiario.Controls.Add(this.dtpFechaInventarioDiario);
            this.panelInventarioDiario.Controls.Add(this.lblFechaInventarioDiario);
            this.panelInventarioDiario.Controls.Add(this.cmbAlmacenInventarioDiario);
            this.panelInventarioDiario.Controls.Add(this.lblAlmacenInventarioDiario);
            this.panelInventarioDiario.Controls.Add(this.lblInventarioDiarioTitulo);
            this.panelInventarioDiario.Location = new System.Drawing.Point(15, 555);
            this.panelInventarioDiario.Name = "panelInventarioDiario";
            this.panelInventarioDiario.Size = new System.Drawing.Size(850, 150);
            this.panelInventarioDiario.TabIndex = 4;

            // lblInventarioDiarioTitulo
            this.lblInventarioDiarioTitulo.AutoSize = true;
            this.lblInventarioDiarioTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblInventarioDiarioTitulo.ForeColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.lblInventarioDiarioTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblInventarioDiarioTitulo.Name = "lblInventarioDiarioTitulo";
            this.lblInventarioDiarioTitulo.Size = new System.Drawing.Size(400, 21);
            this.lblInventarioDiarioTitulo.Text = "📅 Inventario Diario (por fecha y almacén)";

            // lblAlmacenInventarioDiario
            this.lblAlmacenInventarioDiario.AutoSize = true;
            this.lblAlmacenInventarioDiario.Location = new System.Drawing.Point(15, 50);
            this.lblAlmacenInventarioDiario.Name = "lblAlmacenInventarioDiario";
            this.lblAlmacenInventarioDiario.Size = new System.Drawing.Size(90, 15);
            this.lblAlmacenInventarioDiario.Text = "Almacén:";

            // cmbAlmacenInventarioDiario
            this.cmbAlmacenInventarioDiario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlmacenInventarioDiario.Location = new System.Drawing.Point(110, 47);
            this.cmbAlmacenInventarioDiario.Name = "cmbAlmacenInventarioDiario";
            this.cmbAlmacenInventarioDiario.Size = new System.Drawing.Size(250, 23);
            this.cmbAlmacenInventarioDiario.TabIndex = 0;

            // lblFechaInventarioDiario
            this.lblFechaInventarioDiario.AutoSize = true;
            this.lblFechaInventarioDiario.Location = new System.Drawing.Point(380, 50);
            this.lblFechaInventarioDiario.Name = "lblFechaInventarioDiario";
            this.lblFechaInventarioDiario.Size = new System.Drawing.Size(40, 15);
            this.lblFechaInventarioDiario.Text = "Fecha:";

            // dtpFechaInventarioDiario
            this.dtpFechaInventarioDiario.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInventarioDiario.Location = new System.Drawing.Point(430, 47);
            this.dtpFechaInventarioDiario.Name = "dtpFechaInventarioDiario";
            this.dtpFechaInventarioDiario.Size = new System.Drawing.Size(130, 23);
            this.dtpFechaInventarioDiario.TabIndex = 1;

            // btnInventarioDiarioVer
            this.btnInventarioDiarioVer.BackColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.btnInventarioDiarioVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventarioDiarioVer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnInventarioDiarioVer.ForeColor = System.Drawing.Color.White;
            this.btnInventarioDiarioVer.Location = new System.Drawing.Point(15, 90);
            this.btnInventarioDiarioVer.Name = "btnInventarioDiarioVer";
            this.btnInventarioDiarioVer.Size = new System.Drawing.Size(180, 35);
            this.btnInventarioDiarioVer.TabIndex = 2;
            this.btnInventarioDiarioVer.Text = "👁️ Ver Inventario Diario";
            this.btnInventarioDiarioVer.UseVisualStyleBackColor = false;
            this.btnInventarioDiarioVer.Click += new System.EventHandler(this.btnInventarioDiarioVer_Click);

            // btnInventarioDiarioExcel
            this.btnInventarioDiarioExcel.BackColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.btnInventarioDiarioExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventarioDiarioExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnInventarioDiarioExcel.ForeColor = System.Drawing.Color.White;
            this.btnInventarioDiarioExcel.Location = new System.Drawing.Point(210, 90);
            this.btnInventarioDiarioExcel.Name = "btnInventarioDiarioExcel";
            this.btnInventarioDiarioExcel.Size = new System.Drawing.Size(180, 35);
            this.btnInventarioDiarioExcel.TabIndex = 3;
            this.btnInventarioDiarioExcel.Text = "📊 Exportar a Excel";
            this.btnInventarioDiarioExcel.UseVisualStyleBackColor = false;
            this.btnInventarioDiarioExcel.Click += new System.EventHandler(this.btnInventarioDiarioExcel_Click);

            // btnInventarioDiarioPdf
            this.btnInventarioDiarioPdf.BackColor = System.Drawing.Color.FromArgb(231, 29, 54);
            this.btnInventarioDiarioPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventarioDiarioPdf.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnInventarioDiarioPdf.ForeColor = System.Drawing.Color.White;
            this.btnInventarioDiarioPdf.Location = new System.Drawing.Point(405, 90);
            this.btnInventarioDiarioPdf.Name = "btnInventarioDiarioPdf";
            this.btnInventarioDiarioPdf.Size = new System.Drawing.Size(180, 35);
            this.btnInventarioDiarioPdf.TabIndex = 4;
            this.btnInventarioDiarioPdf.Text = "📄 Exportar a PDF";
            this.btnInventarioDiarioPdf.UseVisualStyleBackColor = false;
            this.btnInventarioDiarioPdf.Click += new System.EventHandler(this.btnInventarioDiarioPdf_Click);

            // ===== panelBotones =====
            this.panelBotones.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.panelBotones.Controls.Add(this.btnCerrar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 600);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(900, 60);
            this.panelBotones.TabIndex = 2;

            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(750, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(130, 38);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "✖ Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // ===== FrmReportes =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 660);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(850, 600);
            this.Name = "FrmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.FrmReportes_Load);

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBody.ResumeLayout(false);
            this.panelInventario.ResumeLayout(false);
            this.panelInventario.PerformLayout();
            this.panelInventarioDiario.ResumeLayout(false);
            this.panelInventarioDiario.PerformLayout();
            this.panelMovimientos.ResumeLayout(false);
            this.panelMovimientos.PerformLayout();
            this.panelStockBajo.ResumeLayout(false);
            this.panelStockBajo.PerformLayout();
            this.panelProductos.ResumeLayout(false);
            this.panelProductos.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Panel panelProductos;
        private System.Windows.Forms.Panel panelStockBajo;
        private System.Windows.Forms.Panel panelMovimientos;
        private System.Windows.Forms.Panel panelInventario;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEstado;

        // Productos
        private System.Windows.Forms.Label lblProductosTitulo;
        private System.Windows.Forms.Button btnProductosExcel;
        private System.Windows.Forms.Button btnProductosPdf;

        // Stock Bajo
        private System.Windows.Forms.Label lblStockBajoTitulo;
        private System.Windows.Forms.Button btnStockBajoExcel;
        private System.Windows.Forms.Button btnStockBajoPdf;  // ← NUEVO

        // Movimientos
        private System.Windows.Forms.Label lblMovimientosTitulo;
        private System.Windows.Forms.Label lblTipoMovimiento;
        private System.Windows.Forms.ComboBox cmbTipoMovimiento;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnMovimientosExcel;
        private System.Windows.Forms.Button btnMovimientosPdf;  // ← NUEVO

        // Inventario
        private System.Windows.Forms.Label lblInventarioTitulo;
        private System.Windows.Forms.Label lblAlmacenInventario;
        private System.Windows.Forms.ComboBox cmbAlmacenInventario;
        private System.Windows.Forms.Button btnInventarioVer;
        private System.Windows.Forms.Button btnInventarioExcel;
        private System.Windows.Forms.Button btnInventarioPdf;

        private System.Windows.Forms.Panel panelInventarioDiario;
        private System.Windows.Forms.Label lblInventarioDiarioTitulo;
        private System.Windows.Forms.Label lblAlmacenInventarioDiario;
        private System.Windows.Forms.ComboBox cmbAlmacenInventarioDiario;
        private System.Windows.Forms.Label lblFechaInventarioDiario;
        private System.Windows.Forms.DateTimePicker dtpFechaInventarioDiario;
        private System.Windows.Forms.Button btnInventarioDiarioVer;
        private System.Windows.Forms.Button btnInventarioDiarioExcel;
        private System.Windows.Forms.Button btnInventarioDiarioPdf;

        // Botones
        private System.Windows.Forms.Button btnCerrar;

        #endregion
    }
}