namespace InventarioWeb.WinForms.Forms
{
    partial class FrmMovimientoDetalle
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
            this.panelInfo = new System.Windows.Forms.Panel();
            this.lblObservacionValor = new System.Windows.Forms.Label();
            this.lblObservacionTitulo = new System.Windows.Forms.Label();
            this.lblDestinoValor = new System.Windows.Forms.Label();
            this.lblDestinoTitulo = new System.Windows.Forms.Label();
            this.lblOrigenValor = new System.Windows.Forms.Label();
            this.lblOrigenTitulo = new System.Windows.Forms.Label();
            this.lblFechaValor = new System.Windows.Forms.Label();
            this.lblFechaTitulo = new System.Windows.Forms.Label();
            this.lblDocumentoValor = new System.Windows.Forms.Label();
            this.lblDocumentoTitulo = new System.Windows.Forms.Label();
            this.lblTipoValor = new System.Windows.Forms.Label();
            this.lblTipoTitulo = new System.Windows.Forms.Label();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTotal = new System.Windows.Forms.Panel();
            this.lblTotalValor = new System.Windows.Forms.Label();
            this.lblTotalTitulo = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnExportarPdf = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();

            this.panelTop.SuspendLayout();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.panelTotal.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();

            // ===== panelTop =====
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 60);
            this.panelTop.TabIndex = 0;

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(15, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(250, 25);
            this.lblTitulo.Text = "Detalle de Movimiento";

            // ===== panelInfo =====
            this.panelInfo.BackColor = System.Drawing.Color.White;
            this.panelInfo.Controls.Add(this.lblObservacionValor);
            this.panelInfo.Controls.Add(this.lblObservacionTitulo);
            this.panelInfo.Controls.Add(this.lblDestinoValor);
            this.panelInfo.Controls.Add(this.lblDestinoTitulo);
            this.panelInfo.Controls.Add(this.lblOrigenValor);
            this.panelInfo.Controls.Add(this.lblOrigenTitulo);
            this.panelInfo.Controls.Add(this.lblFechaValor);
            this.panelInfo.Controls.Add(this.lblFechaTitulo);
            this.panelInfo.Controls.Add(this.lblDocumentoValor);
            this.panelInfo.Controls.Add(this.lblDocumentoTitulo);
            this.panelInfo.Controls.Add(this.lblTipoValor);
            this.panelInfo.Controls.Add(this.lblTipoTitulo);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 60);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelInfo.Size = new System.Drawing.Size(800, 140);
            this.panelInfo.TabIndex = 1;

            int y = 15;
            int lblLeft = 20;
            int valLeft = 130;

            // Tipo
            this.lblTipoTitulo.AutoSize = true;
            this.lblTipoTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipoTitulo.Location = new System.Drawing.Point(lblLeft, y);
            this.lblTipoTitulo.Name = "lblTipoTitulo";
            this.lblTipoTitulo.Size = new System.Drawing.Size(35, 15);
            this.lblTipoTitulo.Text = "Tipo:";

            this.lblTipoValor.AutoSize = true;
            this.lblTipoValor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTipoValor.Location = new System.Drawing.Point(valLeft, y - 2);
            this.lblTipoValor.Name = "lblTipoValor";
            this.lblTipoValor.Size = new System.Drawing.Size(50, 19);
            this.lblTipoValor.Text = "-";

            // Documento
            this.lblDocumentoTitulo.AutoSize = true;
            this.lblDocumentoTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDocumentoTitulo.Location = new System.Drawing.Point(280, y);
            this.lblDocumentoTitulo.Name = "lblDocumentoTitulo";
            this.lblDocumentoTitulo.Size = new System.Drawing.Size(70, 15);
            this.lblDocumentoTitulo.Text = "Documento:";

            this.lblDocumentoValor.AutoSize = true;
            this.lblDocumentoValor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDocumentoValor.Location = new System.Drawing.Point(360, y - 2);
            this.lblDocumentoValor.Name = "lblDocumentoValor";
            this.lblDocumentoValor.Size = new System.Drawing.Size(50, 19);
            this.lblDocumentoValor.Text = "-";

            // Fecha
            this.lblFechaTitulo.AutoSize = true;
            this.lblFechaTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaTitulo.Location = new System.Drawing.Point(550, y);
            this.lblFechaTitulo.Name = "lblFechaTitulo";
            this.lblFechaTitulo.Size = new System.Drawing.Size(40, 15);
            this.lblFechaTitulo.Text = "Fecha:";

            this.lblFechaValor.AutoSize = true;
            this.lblFechaValor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFechaValor.Location = new System.Drawing.Point(600, y - 2);
            this.lblFechaValor.Name = "lblFechaValor";
            this.lblFechaValor.Size = new System.Drawing.Size(50, 19);
            this.lblFechaValor.Text = "-";

            y += 35;

            // Origen
            this.lblOrigenTitulo.AutoSize = true;
            this.lblOrigenTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOrigenTitulo.Location = new System.Drawing.Point(lblLeft, y);
            this.lblOrigenTitulo.Name = "lblOrigenTitulo";
            this.lblOrigenTitulo.Size = new System.Drawing.Size(90, 15);
            this.lblOrigenTitulo.Text = "Almacén Origen:";

            this.lblOrigenValor.AutoSize = true;
            this.lblOrigenValor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOrigenValor.Location = new System.Drawing.Point(valLeft, y - 2);
            this.lblOrigenValor.Name = "lblOrigenValor";
            this.lblOrigenValor.Size = new System.Drawing.Size(50, 19);
            this.lblOrigenValor.Text = "-";

            // Destino
            this.lblDestinoTitulo.AutoSize = true;
            this.lblDestinoTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDestinoTitulo.Location = new System.Drawing.Point(400, y);
            this.lblDestinoTitulo.Name = "lblDestinoTitulo";
            this.lblDestinoTitulo.Size = new System.Drawing.Size(100, 15);
            this.lblDestinoTitulo.Text = "Almacén Destino:";

            this.lblDestinoValor.AutoSize = true;
            this.lblDestinoValor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDestinoValor.Location = new System.Drawing.Point(510, y - 2);
            this.lblDestinoValor.Name = "lblDestinoValor";
            this.lblDestinoValor.Size = new System.Drawing.Size(50, 19);
            this.lblDestinoValor.Text = "-";

            y += 35;

            // Observación
            this.lblObservacionTitulo.AutoSize = true;
            this.lblObservacionTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblObservacionTitulo.Location = new System.Drawing.Point(lblLeft, y);
            this.lblObservacionTitulo.Name = "lblObservacionTitulo";
            this.lblObservacionTitulo.Size = new System.Drawing.Size(75, 15);
            this.lblObservacionTitulo.Text = "Observación:";

            this.lblObservacionValor.AutoSize = true;
            this.lblObservacionValor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblObservacionValor.Location = new System.Drawing.Point(valLeft, y - 2);
            this.lblObservacionValor.MaximumSize = new System.Drawing.Size(600, 0);
            this.lblObservacionValor.Name = "lblObservacionValor";
            this.lblObservacionValor.Size = new System.Drawing.Size(50, 19);
            this.lblObservacionValor.Text = "-";

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
                this.colCodigo, this.colProducto, this.colCantidad, this.colPrecio, this.colSubtotal});
            this.dgvDetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalles.Location = new System.Drawing.Point(0, 200);
            this.dgvDetalles.MultiSelect = false;
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.RowHeadersVisible = false;
            this.dgvDetalles.RowTemplate.Height = 30;
            this.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.Size = new System.Drawing.Size(800, 260);
            this.dgvDetalles.TabIndex = 2;

            // Columnas
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.FillWeight = 80;

            this.colProducto.Name = "colProducto";
            this.colProducto.HeaderText = "Producto";
            this.colProducto.FillWeight = 200;

            this.colCantidad.Name = "colCantidad";
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.FillWeight = 80;

            this.colPrecio.Name = "colPrecio";
            this.colPrecio.HeaderText = "Precio Unit.";
            this.colPrecio.FillWeight = 100;

            this.colSubtotal.Name = "colSubtotal";
            this.colSubtotal.HeaderText = "Subtotal";
            this.colSubtotal.FillWeight = 100;

            // ===== panelTotal =====
            this.panelTotal.BackColor = System.Drawing.Color.FromArgb(245, 245, 250);
            this.panelTotal.Controls.Add(this.lblTotalValor);
            this.panelTotal.Controls.Add(this.lblTotalTitulo);
            this.panelTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTotal.Location = new System.Drawing.Point(0, 460);
            this.panelTotal.Name = "panelTotal";
            this.panelTotal.Size = new System.Drawing.Size(800, 50);
            this.panelTotal.TabIndex = 3;

            this.lblTotalTitulo.AutoSize = true;
            this.lblTotalTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalTitulo.Location = new System.Drawing.Point(550, 15);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(60, 21);
            this.lblTotalTitulo.Text = "TOTAL:";

            this.lblTotalValor.AutoSize = true;
            this.lblTotalValor.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalValor.ForeColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.lblTotalValor.Location = new System.Drawing.Point(620, 12);
            this.lblTotalValor.Name = "lblTotalValor";
            this.lblTotalValor.Size = new System.Drawing.Size(50, 25);
            this.lblTotalValor.Text = "$0.00";

            // ===== panelBotones =====
            this.panelBotones.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.panelBotones.Controls.Add(this.btnExportarPdf);
            this.panelBotones.Controls.Add(this.btnCerrar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 510);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(800, 60);
            this.panelBotones.TabIndex = 4;

            // btnExportarPdf
            this.btnExportarPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarPdf.BackColor = System.Drawing.Color.FromArgb(231, 29, 54);
            this.btnExportarPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPdf.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportarPdf.ForeColor = System.Drawing.Color.White;
            this.btnExportarPdf.Location = new System.Drawing.Point(500, 12);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.Size = new System.Drawing.Size(150, 38);
            this.btnExportarPdf.TabIndex = 0;
            this.btnExportarPdf.Text = "📄 Exportar PDF";
            this.btnExportarPdf.UseVisualStyleBackColor = false;
            this.btnExportarPdf.Click += new System.EventHandler(this.btnExportarPdf_Click);

            // btnCerrar
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(660, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(130, 38);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "✖ Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // ===== FrmMovimientoDetalle =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 570);
            this.Controls.Add(this.dgvDetalles);
            this.Controls.Add(this.panelTotal);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "FrmMovimientoDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalle de Movimiento";
            this.Load += new System.EventHandler(this.FrmMovimientoDetalle_Load);

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.panelTotal.ResumeLayout(false);
            this.panelTotal.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Panel panelTotal;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTipoTitulo;
        private System.Windows.Forms.Label lblTipoValor;
        private System.Windows.Forms.Label lblDocumentoTitulo;
        private System.Windows.Forms.Label lblDocumentoValor;
        private System.Windows.Forms.Label lblFechaTitulo;
        private System.Windows.Forms.Label lblFechaValor;
        private System.Windows.Forms.Label lblOrigenTitulo;
        private System.Windows.Forms.Label lblOrigenValor;
        private System.Windows.Forms.Label lblDestinoTitulo;
        private System.Windows.Forms.Label lblDestinoValor;
        private System.Windows.Forms.Label lblObservacionTitulo;
        private System.Windows.Forms.Label lblObservacionValor;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.Label lblTotalTitulo;
        private System.Windows.Forms.Label lblTotalValor;
        private System.Windows.Forms.Button btnExportarPdf;
        private System.Windows.Forms.Button btnCerrar;

        #endregion
    }
}