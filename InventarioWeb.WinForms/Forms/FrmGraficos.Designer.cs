namespace InventarioWeb.WinForms.Forms
{
    partial class FrmGraficos
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
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelKPIs = new System.Windows.Forms.Panel();
            this.lblTotalAlmacenes = new System.Windows.Forms.Label();
            this.lblTotalAlmacenesTitulo = new System.Windows.Forms.Label();
            this.lblSinStock = new System.Windows.Forms.Label();
            this.lblSinStockTitulo = new System.Windows.Forms.Label();
            this.lblStockBajo = new System.Windows.Forms.Label();
            this.lblStockBajoTitulo = new System.Windows.Forms.Label();
            this.lblStockNormal = new System.Windows.Forms.Label();
            this.lblStockNormalTitulo = new System.Windows.Forms.Label();
            this.lblTotalProductos = new System.Windows.Forms.Label();
            this.lblTotalProductosTitulo = new System.Windows.Forms.Label();
            this.panelGraficos = new System.Windows.Forms.Panel();
            this.panelGraficoAlmacenes = new System.Windows.Forms.Panel();
            this.panelGraficoEstado = new System.Windows.Forms.Panel();
            this.panelGraficoCategorias = new System.Windows.Forms.Panel();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();

            this.panelTop.SuspendLayout();
            this.panelKPIs.SuspendLayout();
            this.panelGraficos.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.panelTop.Controls.Add(this.btnRefrescar);
            this.panelTop.Controls.Add(this.lblEstado);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1100, 70);
            this.panelTop.TabIndex = 0;

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(250, 25);
            this.lblTitulo.Text = "📈 Análisis Estadístico";

            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.lblEstado.Location = new System.Drawing.Point(15, 45);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 15);

            this.btnRefrescar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(960, 20);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(120, 35);
            this.btnRefrescar.TabIndex = 0;
            this.btnRefrescar.Text = "🔄 Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);

            // panelKPIs
            this.panelKPIs.BackColor = System.Drawing.Color.White;
            this.panelKPIs.Controls.Add(this.lblTotalAlmacenes);
            this.panelKPIs.Controls.Add(this.lblTotalAlmacenesTitulo);
            this.panelKPIs.Controls.Add(this.lblSinStock);
            this.panelKPIs.Controls.Add(this.lblSinStockTitulo);
            this.panelKPIs.Controls.Add(this.lblStockBajo);
            this.panelKPIs.Controls.Add(this.lblStockBajoTitulo);
            this.panelKPIs.Controls.Add(this.lblStockNormal);
            this.panelKPIs.Controls.Add(this.lblStockNormalTitulo);
            this.panelKPIs.Controls.Add(this.lblTotalProductos);
            this.panelKPIs.Controls.Add(this.lblTotalProductosTitulo);
            this.panelKPIs.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKPIs.Location = new System.Drawing.Point(0, 70);
            this.panelKPIs.Name = "panelKPIs";
            this.panelKPIs.Size = new System.Drawing.Size(1100, 100);
            this.panelKPIs.TabIndex = 1;

            // KPI Total Productos
            this.lblTotalProductosTitulo.AutoSize = true;
            this.lblTotalProductosTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalProductosTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalProductosTitulo.Location = new System.Drawing.Point(30, 20);
            this.lblTotalProductosTitulo.Name = "lblTotalProductosTitulo";
            this.lblTotalProductosTitulo.Size = new System.Drawing.Size(100, 15);
            this.lblTotalProductosTitulo.Text = "Total Productos";

            this.lblTotalProductos.AutoSize = true;
            this.lblTotalProductos.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTotalProductos.ForeColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.lblTotalProductos.Location = new System.Drawing.Point(30, 40);
            this.lblTotalProductos.Name = "lblTotalProductos";
            this.lblTotalProductos.Size = new System.Drawing.Size(50, 41);
            this.lblTotalProductos.Text = "0";

            // KPI Stock Normal
            this.lblStockNormalTitulo.AutoSize = true;
            this.lblStockNormalTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStockNormalTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblStockNormalTitulo.Location = new System.Drawing.Point(230, 20);
            this.lblStockNormalTitulo.Name = "lblStockNormalTitulo";
            this.lblStockNormalTitulo.Size = new System.Drawing.Size(100, 15);
            this.lblStockNormalTitulo.Text = "Stock Normal";

            this.lblStockNormal.AutoSize = true;
            this.lblStockNormal.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblStockNormal.ForeColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.lblStockNormal.Location = new System.Drawing.Point(230, 40);
            this.lblStockNormal.Name = "lblStockNormal";
            this.lblStockNormal.Size = new System.Drawing.Size(50, 41);
            this.lblStockNormal.Text = "0";

            // KPI Stock Bajo
            this.lblStockBajoTitulo.AutoSize = true;
            this.lblStockBajoTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStockBajoTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblStockBajoTitulo.Location = new System.Drawing.Point(430, 20);
            this.lblStockBajoTitulo.Name = "lblStockBajoTitulo";
            this.lblStockBajoTitulo.Size = new System.Drawing.Size(100, 15);
            this.lblStockBajoTitulo.Text = "Stock Bajo";

            this.lblStockBajo.AutoSize = true;
            this.lblStockBajo.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblStockBajo.ForeColor = System.Drawing.Color.FromArgb(255, 159, 28);
            this.lblStockBajo.Location = new System.Drawing.Point(430, 40);
            this.lblStockBajo.Name = "lblStockBajo";
            this.lblStockBajo.Size = new System.Drawing.Size(50, 41);
            this.lblStockBajo.Text = "0";

            // KPI Sin Stock
            this.lblSinStockTitulo.AutoSize = true;
            this.lblSinStockTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSinStockTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblSinStockTitulo.Location = new System.Drawing.Point(630, 20);
            this.lblSinStockTitulo.Name = "lblSinStockTitulo";
            this.lblSinStockTitulo.Size = new System.Drawing.Size(100, 15);
            this.lblSinStockTitulo.Text = "Sin Stock";

            this.lblSinStock.AutoSize = true;
            this.lblSinStock.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblSinStock.ForeColor = System.Drawing.Color.FromArgb(231, 29, 54);
            this.lblSinStock.Location = new System.Drawing.Point(630, 40);
            this.lblSinStock.Name = "lblSinStock";
            this.lblSinStock.Size = new System.Drawing.Size(50, 41);
            this.lblSinStock.Text = "0";

            // KPI Total Almacenes
            this.lblTotalAlmacenesTitulo.AutoSize = true;
            this.lblTotalAlmacenesTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalAlmacenesTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalAlmacenesTitulo.Location = new System.Drawing.Point(830, 20);
            this.lblTotalAlmacenesTitulo.Name = "lblTotalAlmacenesTitulo";
            this.lblTotalAlmacenesTitulo.Size = new System.Drawing.Size(100, 15);
            this.lblTotalAlmacenesTitulo.Text = "Almacenes";

            this.lblTotalAlmacenes.AutoSize = true;
            this.lblTotalAlmacenes.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTotalAlmacenes.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblTotalAlmacenes.Location = new System.Drawing.Point(830, 40);
            this.lblTotalAlmacenes.Name = "lblTotalAlmacenes";
            this.lblTotalAlmacenes.Size = new System.Drawing.Size(50, 41);
            this.lblTotalAlmacenes.Text = "0";

            // panelGraficos
            this.panelGraficos.AutoScroll = true;
            this.panelGraficos.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.panelGraficos.Controls.Add(this.panelGraficoAlmacenes);
            this.panelGraficos.Controls.Add(this.panelGraficoEstado);
            this.panelGraficos.Controls.Add(this.panelGraficoCategorias);
            this.panelGraficos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGraficos.Location = new System.Drawing.Point(0, 170);
            this.panelGraficos.Name = "panelGraficos";
            this.panelGraficos.Padding = new System.Windows.Forms.Padding(15);
            this.panelGraficos.Size = new System.Drawing.Size(1100, 460);
            this.panelGraficos.TabIndex = 2;

            // panelGraficoCategorias
            this.panelGraficoCategorias.BackColor = System.Drawing.Color.White;
            this.panelGraficoCategorias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGraficoCategorias.Location = new System.Drawing.Point(15, 15);
            this.panelGraficoCategorias.Name = "panelGraficoCategorias";
            this.panelGraficoCategorias.Size = new System.Drawing.Size(530, 400);
            this.panelGraficoCategorias.TabIndex = 0;

            // panelGraficoEstado
            this.panelGraficoEstado.BackColor = System.Drawing.Color.White;
            this.panelGraficoEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGraficoEstado.Location = new System.Drawing.Point(555, 15);
            this.panelGraficoEstado.Name = "panelGraficoEstado";
            this.panelGraficoEstado.Size = new System.Drawing.Size(530, 400);
            this.panelGraficoEstado.TabIndex = 1;

            // panelGraficoAlmacenes
            this.panelGraficoAlmacenes.BackColor = System.Drawing.Color.White;
            this.panelGraficoAlmacenes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGraficoAlmacenes.Location = new System.Drawing.Point(15, 425);
            this.panelGraficoAlmacenes.Name = "panelGraficoAlmacenes";
            this.panelGraficoAlmacenes.Size = new System.Drawing.Size(1070, 400);
            this.panelGraficoAlmacenes.TabIndex = 2;

            // panelBotones
            this.panelBotones.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.panelBotones.Controls.Add(this.btnCerrar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 630);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(1100, 60);
            this.panelBotones.TabIndex = 3;

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

            // FrmGraficos
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 690);
            this.Controls.Add(this.panelGraficos);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelKPIs);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "FrmGraficos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Análisis Estadístico";
            this.Load += new System.EventHandler(this.FrmGraficos_Load);

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelKPIs.ResumeLayout(false);
            this.panelKPIs.PerformLayout();
            this.panelGraficos.ResumeLayout(false);
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelKPIs;
        private System.Windows.Forms.Panel panelGraficos;
        private System.Windows.Forms.Panel panelGraficoCategorias;
        private System.Windows.Forms.Panel panelGraficoEstado;
        private System.Windows.Forms.Panel panelGraficoAlmacenes;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Label lblTotalProductosTitulo;
        private System.Windows.Forms.Label lblTotalProductos;
        private System.Windows.Forms.Label lblStockNormalTitulo;
        private System.Windows.Forms.Label lblStockNormal;
        private System.Windows.Forms.Label lblStockBajoTitulo;
        private System.Windows.Forms.Label lblStockBajo;
        private System.Windows.Forms.Label lblSinStockTitulo;
        private System.Windows.Forms.Label lblSinStock;
        private System.Windows.Forms.Label lblTotalAlmacenesTitulo;
        private System.Windows.Forms.Label lblTotalAlmacenes;
        private System.Windows.Forms.Button btnCerrar;

        #endregion
    }
}