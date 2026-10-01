namespace InventarioWeb.WinForms.Forms
{
    partial class FrmConsignacionDetalle
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
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.lblObservacionTitulo = new System.Windows.Forms.Label();
            this.lblTotalVendido = new System.Windows.Forms.Label();
            this.lblTotalVendidoTitulo = new System.Windows.Forms.Label();
            this.panelKPIs = new System.Windows.Forms.Panel();
            this.lblPendientesValor = new System.Windows.Forms.Label();
            this.lblPendientesTitulo = new System.Windows.Forms.Label();
            this.lblDevueltosValor = new System.Windows.Forms.Label();
            this.lblDevueltosTitulo = new System.Windows.Forms.Label();
            this.lblVendidosValor = new System.Windows.Forms.Label();
            this.lblVendidosTitulo = new System.Windows.Forms.Label();
            this.lblEntregadosValor = new System.Windows.Forms.Label();
            this.lblEntregadosTitulo = new System.Windows.Forms.Label();
            this.panelAcciones = new System.Windows.Forms.Panel();
            this.btnRegistrarDevolucion = new System.Windows.Forms.Button();
            this.btnRegistrarVenta = new System.Windows.Forms.Button();
            this.lblAccionesTitulo = new System.Windows.Forms.Label();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.colDetalleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntregados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVendidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDevueltos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();

            this.panelTop.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelKPIs.SuspendLayout();
            this.panelAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();

            // ===== panelTop =====
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.panelTop.Controls.Add(this.lblEstado);
            this.panelTop.Controls.Add(this.lblAlmacen);
            this.panelTop.Controls.Add(this.lblFecha);
            this.panelTop.Controls.Add(this.lblVendedor);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1100, 80);
            this.panelTop.TabIndex = 0;

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(15, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(250, 25);
            this.lblTitulo.Text = "📋 Detalle de Consignación";

            // lblVendedor
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblVendedor.ForeColor = System.Drawing.Color.White;
            this.lblVendedor.Location = new System.Drawing.Point(15, 45);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(120, 19);
            this.lblVendedor.Text = "👤 Vendedor";

            // lblFecha
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(260, 45);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(100, 19);
            this.lblFecha.Text = "📅 Fecha";

            // lblAlmacen
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAlmacen.ForeColor = System.Drawing.Color.White;
            this.lblAlmacen.Location = new System.Drawing.Point(450, 45);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(120, 19);
            this.lblAlmacen.Text = "🏪 Almacén";

            // lblEstado (badge)
            this.lblEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.White;
            this.lblEstado.Location = new System.Drawing.Point(900, 10);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(100, 21);
            this.lblEstado.Text = "PENDIENTE";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // ===== panelInfo =====
            this.panelInfo.BackColor = System.Drawing.Color.White;
            this.panelInfo.Controls.Add(this.lblObservacion);
            this.panelInfo.Controls.Add(this.lblObservacionTitulo);
            this.panelInfo.Controls.Add(this.lblTotalVendido);
            this.panelInfo.Controls.Add(this.lblTotalVendidoTitulo);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 80);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelInfo.Size = new System.Drawing.Size(1100, 60);
            this.panelInfo.TabIndex = 1;

            // lblObservacionTitulo
            this.lblObservacionTitulo.AutoSize = true;
            this.lblObservacionTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblObservacionTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblObservacionTitulo.Name = "lblObservacionTitulo";
            this.lblObservacionTitulo.Size = new System.Drawing.Size(80, 15);
            this.lblObservacionTitulo.Text = "Observación:";

            // lblObservacion
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblObservacion.Location = new System.Drawing.Point(110, 18);
            this.lblObservacion.MaximumSize = new System.Drawing.Size(600, 0);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(50, 19);
            this.lblObservacion.Text = "-";

            // lblTotalVendidoTitulo
            this.lblTotalVendidoTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalVendidoTitulo.AutoSize = true;
            this.lblTotalVendidoTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalVendidoTitulo.Location = new System.Drawing.Point(800, 20);
            this.lblTotalVendidoTitulo.Name = "lblTotalVendidoTitulo";
            this.lblTotalVendidoTitulo.Size = new System.Drawing.Size(100, 15);
            this.lblTotalVendidoTitulo.Text = "Total Vendido:";

            // lblTotalVendido
            this.lblTotalVendido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalVendido.AutoSize = true;
            this.lblTotalVendido.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalVendido.ForeColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.lblTotalVendido.Location = new System.Drawing.Point(910, 14);
            this.lblTotalVendido.Name = "lblTotalVendido";
            this.lblTotalVendido.Size = new System.Drawing.Size(70, 25);
            this.lblTotalVendido.Text = "$0.00";

            // ===== panelKPIs =====
            this.panelKPIs.BackColor = System.Drawing.Color.FromArgb(240, 240, 245);
            this.panelKPIs.Controls.Add(this.lblPendientesValor);
            this.panelKPIs.Controls.Add(this.lblPendientesTitulo);
            this.panelKPIs.Controls.Add(this.lblDevueltosValor);
            this.panelKPIs.Controls.Add(this.lblDevueltosTitulo);
            this.panelKPIs.Controls.Add(this.lblVendidosValor);
            this.panelKPIs.Controls.Add(this.lblVendidosTitulo);
            this.panelKPIs.Controls.Add(this.lblEntregadosValor);
            this.panelKPIs.Controls.Add(this.lblEntregadosTitulo);
            this.panelKPIs.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKPIs.Location = new System.Drawing.Point(0, 140);
            this.panelKPIs.Name = "panelKPIs";
            this.panelKPIs.Size = new System.Drawing.Size(1100, 80);
            this.panelKPIs.TabIndex = 2;

            // KPI Entregados
            this.lblEntregadosTitulo.AutoSize = true;
            this.lblEntregadosTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEntregadosTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblEntregadosTitulo.Location = new System.Drawing.Point(30, 15);
            this.lblEntregadosTitulo.Name = "lblEntregadosTitulo";
            this.lblEntregadosTitulo.Size = new System.Drawing.Size(80, 15);
            this.lblEntregadosTitulo.Text = "Entregados";

            this.lblEntregadosValor.AutoSize = true;
            this.lblEntregadosValor.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblEntregadosValor.ForeColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.lblEntregadosValor.Location = new System.Drawing.Point(30, 35);
            this.lblEntregadosValor.Name = "lblEntregadosValor";
            this.lblEntregadosValor.Size = new System.Drawing.Size(40, 32);
            this.lblEntregadosValor.Text = "0";

            // KPI Vendidos
            this.lblVendidosTitulo.AutoSize = true;
            this.lblVendidosTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVendidosTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblVendidosTitulo.Location = new System.Drawing.Point(230, 15);
            this.lblVendidosTitulo.Name = "lblVendidosTitulo";
            this.lblVendidosTitulo.Size = new System.Drawing.Size(60, 15);
            this.lblVendidosTitulo.Text = "Vendidos";

            this.lblVendidosValor.AutoSize = true;
            this.lblVendidosValor.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblVendidosValor.ForeColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.lblVendidosValor.Location = new System.Drawing.Point(230, 35);
            this.lblVendidosValor.Name = "lblVendidosValor";
            this.lblVendidosValor.Size = new System.Drawing.Size(40, 32);
            this.lblVendidosValor.Text = "0";

            // KPI Devueltos
            this.lblDevueltosTitulo.AutoSize = true;
            this.lblDevueltosTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDevueltosTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblDevueltosTitulo.Location = new System.Drawing.Point(430, 15);
            this.lblDevueltosTitulo.Name = "lblDevueltosTitulo";
            this.lblDevueltosTitulo.Size = new System.Drawing.Size(65, 15);
            this.lblDevueltosTitulo.Text = "Devueltos";

            this.lblDevueltosValor.AutoSize = true;
            this.lblDevueltosValor.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblDevueltosValor.ForeColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.lblDevueltosValor.Location = new System.Drawing.Point(430, 35);
            this.lblDevueltosValor.Name = "lblDevueltosValor";
            this.lblDevueltosValor.Size = new System.Drawing.Size(40, 32);
            this.lblDevueltosValor.Text = "0";

            // KPI Pendientes
            this.lblPendientesTitulo.AutoSize = true;
            this.lblPendientesTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPendientesTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblPendientesTitulo.Location = new System.Drawing.Point(630, 15);
            this.lblPendientesTitulo.Name = "lblPendientesTitulo";
            this.lblPendientesTitulo.Size = new System.Drawing.Size(70, 15);
            this.lblPendientesTitulo.Text = "Pendientes";

            this.lblPendientesValor.AutoSize = true;
            this.lblPendientesValor.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblPendientesValor.ForeColor = System.Drawing.Color.FromArgb(255, 159, 28);
            this.lblPendientesValor.Location = new System.Drawing.Point(630, 35);
            this.lblPendientesValor.Name = "lblPendientesValor";
            this.lblPendientesValor.Size = new System.Drawing.Size(40, 32);
            this.lblPendientesValor.Text = "0";

            // ===== panelAcciones =====
            this.panelAcciones.BackColor = System.Drawing.Color.FromArgb(250, 250, 255);
            this.panelAcciones.Controls.Add(this.btnRegistrarDevolucion);
            this.panelAcciones.Controls.Add(this.btnRegistrarVenta);
            this.panelAcciones.Controls.Add(this.lblAccionesTitulo);
            this.panelAcciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAcciones.Location = new System.Drawing.Point(0, 220);
            this.panelAcciones.Name = "panelAcciones";
            this.panelAcciones.Size = new System.Drawing.Size(1100, 60);
            this.panelAcciones.TabIndex = 3;

            // lblAccionesTitulo
            this.lblAccionesTitulo.AutoSize = true;
            this.lblAccionesTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAccionesTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblAccionesTitulo.Name = "lblAccionesTitulo";
            this.lblAccionesTitulo.Size = new System.Drawing.Size(200, 19);
            this.lblAccionesTitulo.Text = "Acciones (seleccione un producto):";

            // btnRegistrarVenta
            this.btnRegistrarVenta.BackColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.btnRegistrarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarVenta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarVenta.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarVenta.Location = new System.Drawing.Point(420, 15);
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.Size = new System.Drawing.Size(160, 32);
            this.btnRegistrarVenta.TabIndex = 0;
            this.btnRegistrarVenta.Text = "💵 Registrar Venta";
            this.btnRegistrarVenta.UseVisualStyleBackColor = false;
            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);

            // btnRegistrarDevolucion
            this.btnRegistrarDevolucion.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.btnRegistrarDevolucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarDevolucion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarDevolucion.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarDevolucion.Location = new System.Drawing.Point(590, 15);
            this.btnRegistrarDevolucion.Name = "btnRegistrarDevolucion";
            this.btnRegistrarDevolucion.Size = new System.Drawing.Size(180, 32);
            this.btnRegistrarDevolucion.TabIndex = 1;
            this.btnRegistrarDevolucion.Text = "↩️ Registrar Devolución";
            this.btnRegistrarDevolucion.UseVisualStyleBackColor = false;
            this.btnRegistrarDevolucion.Click += new System.EventHandler(this.btnRegistrarDevolucion_Click);

            // ===== dgvDetalles =====
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalles.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalles.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.dgvDetalles.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDetalles.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvDetalles.ColumnHeadersHeight = 35;
            this.dgvDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colDetalleId, this.colCodigo, this.colProducto,
                this.colEntregados, this.colVendidos, this.colDevueltos,
                this.colPendiente, this.colPrecio, this.colSubtotal});
            this.dgvDetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalles.Location = new System.Drawing.Point(0, 280);
            this.dgvDetalles.MultiSelect = false;
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.RowHeadersVisible = false;
            this.dgvDetalles.RowTemplate.Height = 30;
            this.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.Size = new System.Drawing.Size(1100, 280);
            this.dgvDetalles.TabIndex = 4;

            // Columnas
            this.colDetalleId.Name = "colDetalleId";
            this.colDetalleId.HeaderText = "DetalleId";
            this.colDetalleId.Visible = false;

            this.colCodigo.Name = "colCodigo";
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.FillWeight = 80;

            this.colProducto.Name = "colProducto";
            this.colProducto.HeaderText = "Producto";
            this.colProducto.FillWeight = 200;

            this.colEntregados.Name = "colEntregados";
            this.colEntregados.HeaderText = "Entregados";
            this.colEntregados.FillWeight = 80;

            this.colVendidos.Name = "colVendidos";
            this.colVendidos.HeaderText = "Vendidos";
            this.colVendidos.FillWeight = 80;

            this.colDevueltos.Name = "colDevueltos";
            this.colDevueltos.HeaderText = "Devueltos";
            this.colDevueltos.FillWeight = 80;

            this.colPendiente.Name = "colPendiente";
            this.colPendiente.HeaderText = "Pendiente";
            this.colPendiente.FillWeight = 80;

            this.colPrecio.Name = "colPrecio";
            this.colPrecio.HeaderText = "Precio Unit.";
            this.colPrecio.FillWeight = 100;

            this.colSubtotal.Name = "colSubtotal";
            this.colSubtotal.HeaderText = "Total Vendido";
            this.colSubtotal.FillWeight = 100;

            // ===== panelBotones =====
            this.panelBotones.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.panelBotones.Controls.Add(this.btnCerrar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 560);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(1100, 60);
            this.panelBotones.TabIndex = 5;

            // btnCerrar
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

            // ===== FrmConsignacionDetalle =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 620);
            this.Controls.Add(this.dgvDetalles);
            this.Controls.Add(this.panelAcciones);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelKPIs);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "FrmConsignacionDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalle de Consignación";
            this.Load += new System.EventHandler(this.FrmConsignacionDetalle_Load);

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelKPIs.ResumeLayout(false);
            this.panelKPIs.PerformLayout();
            this.panelAcciones.ResumeLayout(false);
            this.panelAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Panel panelKPIs;
        private System.Windows.Forms.Panel panelAcciones;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblObservacionTitulo;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.Label lblTotalVendidoTitulo;
        private System.Windows.Forms.Label lblTotalVendido;
        private System.Windows.Forms.Label lblEntregadosTitulo;
        private System.Windows.Forms.Label lblEntregadosValor;
        private System.Windows.Forms.Label lblVendidosTitulo;
        private System.Windows.Forms.Label lblVendidosValor;
        private System.Windows.Forms.Label lblDevueltosTitulo;
        private System.Windows.Forms.Label lblDevueltosValor;
        private System.Windows.Forms.Label lblPendientesTitulo;
        private System.Windows.Forms.Label lblPendientesValor;
        private System.Windows.Forms.Label lblAccionesTitulo;
        private System.Windows.Forms.Button btnRegistrarVenta;
        private System.Windows.Forms.Button btnRegistrarDevolucion;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetalleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntregados;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVendidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDevueltos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPendiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.Button btnCerrar;

        #endregion
    }
}