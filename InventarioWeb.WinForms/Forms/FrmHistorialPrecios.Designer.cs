namespace InventarioWeb.WinForms.Forms
{
    partial class FrmHistorialPrecios
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
            this.lblPrecioActual = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelKPIs = new System.Windows.Forms.Panel();
            this.lblUltimoCambio = new System.Windows.Forms.Label();
            this.lblUltimoCambioTitulo = new System.Windows.Forms.Label();
            this.lblDisminuciones = new System.Windows.Forms.Label();
            this.lblDisminucionesTitulo = new System.Windows.Forms.Label();
            this.lblAumentos = new System.Windows.Forms.Label();
            this.lblAumentosTitulo = new System.Windows.Forms.Label();
            this.lblTotalCambios = new System.Windows.Forms.Label();
            this.lblTotalCambiosTitulo = new System.Windows.Forms.Label();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostoAnterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostoNuevo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVentaAnterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVentaNuevo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVariacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();

            this.panelTop.SuspendLayout();
            this.panelKPIs.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();

            // ===== panelTop =====
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.panelTop.Controls.Add(this.lblPrecioActual);
            this.panelTop.Controls.Add(this.lblCategoria);
            this.panelTop.Controls.Add(this.lblCodigo);
            this.panelTop.Controls.Add(this.lblProducto);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1100, 90);
            this.panelTop.TabIndex = 0;

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(15, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(300, 25);
            this.lblTitulo.Text = "📊 Historial de Cambios de Precios";

            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblProducto.ForeColor = System.Drawing.Color.White;
            this.lblProducto.Location = new System.Drawing.Point(15, 40);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(150, 20);
            this.lblProducto.Text = "📦 Producto";

            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.lblCodigo.Location = new System.Drawing.Point(15, 65);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(100, 15);
            this.lblCodigo.Text = "Código:";

            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.lblCategoria.Location = new System.Drawing.Point(250, 65);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(100, 15);
            this.lblCategoria.Text = "Categoría:";

            this.lblPrecioActual.AutoSize = true;
            this.lblPrecioActual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrecioActual.ForeColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.lblPrecioActual.Location = new System.Drawing.Point(500, 65);
            this.lblPrecioActual.Name = "lblPrecioActual";
            this.lblPrecioActual.Size = new System.Drawing.Size(150, 15);
            this.lblPrecioActual.Text = "Precio actual: $0.00";

            // ===== panelKPIs =====
            this.panelKPIs.BackColor = System.Drawing.Color.FromArgb(240, 240, 245);
            this.panelKPIs.Controls.Add(this.lblUltimoCambio);
            this.panelKPIs.Controls.Add(this.lblUltimoCambioTitulo);
            this.panelKPIs.Controls.Add(this.lblDisminuciones);
            this.panelKPIs.Controls.Add(this.lblDisminucionesTitulo);
            this.panelKPIs.Controls.Add(this.lblAumentos);
            this.panelKPIs.Controls.Add(this.lblAumentosTitulo);
            this.panelKPIs.Controls.Add(this.lblTotalCambios);
            this.panelKPIs.Controls.Add(this.lblTotalCambiosTitulo);
            this.panelKPIs.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKPIs.Location = new System.Drawing.Point(0, 90);
            this.panelKPIs.Name = "panelKPIs";
            this.panelKPIs.Size = new System.Drawing.Size(1100, 70);
            this.panelKPIs.TabIndex = 1;

            // KPI Total Cambios
            this.lblTotalCambiosTitulo.AutoSize = true;
            this.lblTotalCambiosTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalCambiosTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalCambiosTitulo.Location = new System.Drawing.Point(30, 10);
            this.lblTotalCambiosTitulo.Name = "lblTotalCambiosTitulo";
            this.lblTotalCambiosTitulo.Size = new System.Drawing.Size(100, 15);
            this.lblTotalCambiosTitulo.Text = "Total Cambios";

            this.lblTotalCambios.AutoSize = true;
            this.lblTotalCambios.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalCambios.ForeColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.lblTotalCambios.Location = new System.Drawing.Point(30, 28);
            this.lblTotalCambios.Name = "lblTotalCambios";
            this.lblTotalCambios.Size = new System.Drawing.Size(40, 30);
            this.lblTotalCambios.Text = "0";

            // KPI Aumentos
            this.lblAumentosTitulo.AutoSize = true;
            this.lblAumentosTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAumentosTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblAumentosTitulo.Location = new System.Drawing.Point(230, 10);
            this.lblAumentosTitulo.Name = "lblAumentosTitulo";
            this.lblAumentosTitulo.Size = new System.Drawing.Size(70, 15);
            this.lblAumentosTitulo.Text = "Aumentos";

            this.lblAumentos.AutoSize = true;
            this.lblAumentos.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblAumentos.ForeColor = System.Drawing.Color.FromArgb(231, 29, 54);
            this.lblAumentos.Location = new System.Drawing.Point(230, 28);
            this.lblAumentos.Name = "lblAumentos";
            this.lblAumentos.Size = new System.Drawing.Size(40, 30);
            this.lblAumentos.Text = "0";

            // KPI Disminuciones
            this.lblDisminucionesTitulo.AutoSize = true;
            this.lblDisminucionesTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDisminucionesTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblDisminucionesTitulo.Location = new System.Drawing.Point(430, 10);
            this.lblDisminucionesTitulo.Name = "lblDisminucionesTitulo";
            this.lblDisminucionesTitulo.Size = new System.Drawing.Size(90, 15);
            this.lblDisminucionesTitulo.Text = "Disminuciones";

            this.lblDisminuciones.AutoSize = true;
            this.lblDisminuciones.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDisminuciones.ForeColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.lblDisminuciones.Location = new System.Drawing.Point(430, 28);
            this.lblDisminuciones.Name = "lblDisminuciones";
            this.lblDisminuciones.Size = new System.Drawing.Size(40, 30);
            this.lblDisminuciones.Text = "0";

            // KPI Último Cambio
            this.lblUltimoCambioTitulo.AutoSize = true;
            this.lblUltimoCambioTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUltimoCambioTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblUltimoCambioTitulo.Location = new System.Drawing.Point(630, 10);
            this.lblUltimoCambioTitulo.Name = "lblUltimoCambioTitulo";
            this.lblUltimoCambioTitulo.Size = new System.Drawing.Size(90, 15);
            this.lblUltimoCambioTitulo.Text = "Último Cambio";

            this.lblUltimoCambio.AutoSize = true;
            this.lblUltimoCambio.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblUltimoCambio.ForeColor = System.Drawing.Color.FromArgb(255, 159, 28);
            this.lblUltimoCambio.Location = new System.Drawing.Point(630, 32);
            this.lblUltimoCambio.Name = "lblUltimoCambio";
            this.lblUltimoCambio.Size = new System.Drawing.Size(100, 20);
            this.lblUltimoCambio.Text = "Sin cambios";

            // ===== panelFiltros =====
            this.panelFiltros.BackColor = System.Drawing.Color.White;
            this.panelFiltros.Controls.Add(this.btnLimpiar);
            this.panelFiltros.Controls.Add(this.btnFiltrar);
            this.panelFiltros.Controls.Add(this.dtpHasta);
            this.panelFiltros.Controls.Add(this.lblHasta);
            this.panelFiltros.Controls.Add(this.dtpDesde);
            this.panelFiltros.Controls.Add(this.lblDesde);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 160);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelFiltros.Size = new System.Drawing.Size(1100, 60);
            this.panelFiltros.TabIndex = 2;

            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(15, 20);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(42, 15);
            this.lblDesde.Text = "Desde:";

            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(65, 17);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(130, 23);
            this.dtpDesde.TabIndex = 0;

            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(215, 20);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(40, 15);
            this.lblHasta.Text = "Hasta:";

            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(265, 17);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(130, 23);
            this.dtpHasta.TabIndex = 1;

            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(420, 15);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(100, 28);
            this.btnFiltrar.TabIndex = 2;
            this.btnFiltrar.Text = "🔍 Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(530, 15);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 28);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "🔄 Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            // ===== dgvHistorial =====
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorial.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.dgvHistorial.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHistorial.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvHistorial.ColumnHeadersHeight = 35;
            this.dgvHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colFecha, this.colCostoAnterior, this.colCostoNuevo,
                this.colVentaAnterior, this.colVentaNuevo, this.colVariacion,
                this.colMotivo, this.colUsuario});
            this.dgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorial.Location = new System.Drawing.Point(0, 220);
            this.dgvHistorial.MultiSelect = false;
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.RowTemplate.Height = 30;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(1100, 360);
            this.dgvHistorial.TabIndex = 3;

            // Columnas
            this.colFecha.Name = "colFecha";
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.FillWeight = 100;

            this.colCostoAnterior.Name = "colCostoAnterior";
            this.colCostoAnterior.HeaderText = "Costo Ant.";
            this.colCostoAnterior.FillWeight = 90;

            this.colCostoNuevo.Name = "colCostoNuevo";
            this.colCostoNuevo.HeaderText = "Costo Nuevo";
            this.colCostoNuevo.FillWeight = 90;

            this.colVentaAnterior.Name = "colVentaAnterior";
            this.colVentaAnterior.HeaderText = "Venta Ant.";
            this.colVentaAnterior.FillWeight = 90;

            this.colVentaNuevo.Name = "colVentaNuevo";
            this.colVentaNuevo.HeaderText = "Venta Nuevo";
            this.colVentaNuevo.FillWeight = 90;

            this.colVariacion.Name = "colVariacion";
            this.colVariacion.HeaderText = "Variación";
            this.colVariacion.FillWeight = 80;

            this.colMotivo.Name = "colMotivo";
            this.colMotivo.HeaderText = "Motivo";
            this.colMotivo.FillWeight = 200;

            this.colUsuario.Name = "colUsuario";
            this.colUsuario.HeaderText = "Usuario";
            this.colUsuario.FillWeight = 120;

            // ===== panelBotones =====
            this.panelBotones.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.panelBotones.Controls.Add(this.btnCerrar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 580);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(1100, 60);
            this.panelBotones.TabIndex = 4;

            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(950, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(130, 38);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "✖ Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // ===== FrmHistorialPrecios =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 640);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelKPIs);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "FrmHistorialPrecios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Historial de Precios";
            this.Load += new System.EventHandler(this.FrmHistorialPrecios_Load);

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelKPIs.ResumeLayout(false);
            this.panelKPIs.PerformLayout();
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelKPIs;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblPrecioActual;
        private System.Windows.Forms.Label lblTotalCambiosTitulo;
        private System.Windows.Forms.Label lblTotalCambios;
        private System.Windows.Forms.Label lblAumentosTitulo;
        private System.Windows.Forms.Label lblAumentos;
        private System.Windows.Forms.Label lblDisminucionesTitulo;
        private System.Windows.Forms.Label lblDisminuciones;
        private System.Windows.Forms.Label lblUltimoCambioTitulo;
        private System.Windows.Forms.Label lblUltimoCambio;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoAnterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaAnterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVariacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.Button btnCerrar;

        #endregion
    }
}