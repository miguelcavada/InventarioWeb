namespace InventarioWeb.WinForms.Forms
{
    partial class FrmCambioPrecio
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
            this.panelProducto = new System.Windows.Forms.Panel();
            this.lblMargenMayorista = new System.Windows.Forms.Label();
            this.lblMargenMinorista = new System.Windows.Forms.Label();
            this.lblMargenMayoristaTitulo = new System.Windows.Forms.Label();
            this.lblMargenMinoristaTitulo = new System.Windows.Forms.Label();
            this.lblMayoristaActual = new System.Windows.Forms.Label();
            this.lblMinoristaActual = new System.Windows.Forms.Label();
            this.lblCostoActual = new System.Windows.Forms.Label();
            this.lblMayoristaActualTitulo = new System.Windows.Forms.Label();
            this.lblMinoristaActualTitulo = new System.Windows.Forms.Label();
            this.lblCostoActualTitulo = new System.Windows.Forms.Label();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.panelBody = new System.Windows.Forms.Panel();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblCambios = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.lblNuevoMargenMayorista = new System.Windows.Forms.Label();
            this.lblNuevoMargenMinorista = new System.Windows.Forms.Label();
            this.lblNuevoMargenMayoristaTitulo = new System.Windows.Forms.Label();
            this.lblNuevoMargenMinoristaTitulo = new System.Windows.Forms.Label();
            this.numPrecioMayorista = new System.Windows.Forms.NumericUpDown();
            this.numPrecioMinorista = new System.Windows.Forms.NumericUpDown();
            this.numPrecioCosto = new System.Windows.Forms.NumericUpDown();
            this.lblPrecioMayorista = new System.Windows.Forms.Label();
            this.lblPrecioMinorista = new System.Windows.Forms.Label();
            this.lblPrecioCosto = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            this.panelTop.SuspendLayout();
            this.panelProducto.SuspendLayout();
            this.panelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioMayorista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioMinorista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioCosto)).BeginInit();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();

            // ===== panelTop =====
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(700, 60);
            this.panelTop.TabIndex = 0;

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(15, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(250, 25);
            this.lblTitulo.Text = "💰 Cambio de Precios";

            // ===== panelProducto =====
            this.panelProducto.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.panelProducto.Controls.Add(this.lblMargenMayorista);
            this.panelProducto.Controls.Add(this.lblMargenMinorista);
            this.panelProducto.Controls.Add(this.lblMargenMayoristaTitulo);
            this.panelProducto.Controls.Add(this.lblMargenMinoristaTitulo);
            this.panelProducto.Controls.Add(this.lblMayoristaActual);
            this.panelProducto.Controls.Add(this.lblMinoristaActual);
            this.panelProducto.Controls.Add(this.lblCostoActual);
            this.panelProducto.Controls.Add(this.lblMayoristaActualTitulo);
            this.panelProducto.Controls.Add(this.lblMinoristaActualTitulo);
            this.panelProducto.Controls.Add(this.lblCostoActualTitulo);
            this.panelProducto.Controls.Add(this.lblUnidad);
            this.panelProducto.Controls.Add(this.lblCategoria);
            this.panelProducto.Controls.Add(this.lblCodigo);
            this.panelProducto.Controls.Add(this.lblProducto);
            this.panelProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProducto.Location = new System.Drawing.Point(0, 60);
            this.panelProducto.Name = "panelProducto";
            this.panelProducto.Padding = new System.Windows.Forms.Padding(15);
            this.panelProducto.Size = new System.Drawing.Size(700, 180);
            this.panelProducto.TabIndex = 1;

            // lblProducto
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblProducto.Location = new System.Drawing.Point(15, 15);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(200, 21);
            this.lblProducto.Text = "📦 Producto";

            // lblCodigo
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCodigo.ForeColor = System.Drawing.Color.Gray;
            this.lblCodigo.Location = new System.Drawing.Point(15, 45);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(100, 15);
            this.lblCodigo.Text = "Código:";

            // lblCategoria
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategoria.ForeColor = System.Drawing.Color.Gray;
            this.lblCategoria.Location = new System.Drawing.Point(15, 65);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(100, 15);
            this.lblCategoria.Text = "Categoría:";

            // lblUnidad
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUnidad.ForeColor = System.Drawing.Color.Gray;
            this.lblUnidad.Location = new System.Drawing.Point(15, 85);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(100, 15);
            this.lblUnidad.Text = "Unidad:";

            // Precios actuales - separador
            this.lblCostoActualTitulo.AutoSize = true;
            this.lblCostoActualTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCostoActualTitulo.Location = new System.Drawing.Point(15, 120);
            this.lblCostoActualTitulo.Name = "lblCostoActualTitulo";
            this.lblCostoActualTitulo.Size = new System.Drawing.Size(90, 15);
            this.lblCostoActualTitulo.Text = "Costo Actual:";

            this.lblCostoActual.AutoSize = true;
            this.lblCostoActual.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCostoActual.Location = new System.Drawing.Point(130, 119);
            this.lblCostoActual.Name = "lblCostoActual";
            this.lblCostoActual.Size = new System.Drawing.Size(80, 19);
            this.lblCostoActual.Text = "$0.00";

            this.lblMinoristaActualTitulo.AutoSize = true;
            this.lblMinoristaActualTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMinoristaActualTitulo.Location = new System.Drawing.Point(280, 120);
            this.lblMinoristaActualTitulo.Name = "lblMinoristaActualTitulo";
            this.lblMinoristaActualTitulo.Size = new System.Drawing.Size(100, 15);
            this.lblMinoristaActualTitulo.Text = "Minorista Actual:";

            this.lblMinoristaActual.AutoSize = true;
            this.lblMinoristaActual.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMinoristaActual.Location = new System.Drawing.Point(400, 119);
            this.lblMinoristaActual.Name = "lblMinoristaActual";
            this.lblMinoristaActual.Size = new System.Drawing.Size(80, 19);
            this.lblMinoristaActual.Text = "$0.00";

            this.lblMayoristaActualTitulo.AutoSize = true;
            this.lblMayoristaActualTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMayoristaActualTitulo.Location = new System.Drawing.Point(500, 120);
            this.lblMayoristaActualTitulo.Name = "lblMayoristaActualTitulo";
            this.lblMayoristaActualTitulo.Size = new System.Drawing.Size(100, 15);
            this.lblMayoristaActualTitulo.Text = "Mayorista Actual:";

            this.lblMayoristaActual.AutoSize = true;
            this.lblMayoristaActual.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMayoristaActual.Location = new System.Drawing.Point(620, 119);
            this.lblMayoristaActual.Name = "lblMayoristaActual";
            this.lblMayoristaActual.Size = new System.Drawing.Size(80, 19);
            this.lblMayoristaActual.Text = "$0.00";

            // Márgenes actuales
            this.lblMargenMinoristaTitulo.AutoSize = true;
            this.lblMargenMinoristaTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMargenMinoristaTitulo.Location = new System.Drawing.Point(15, 145);
            this.lblMargenMinoristaTitulo.Name = "lblMargenMinoristaTitulo";
            this.lblMargenMinoristaTitulo.Size = new System.Drawing.Size(120, 15);
            this.lblMargenMinoristaTitulo.Text = "Margen Minorista:";

            this.lblMargenMinorista.AutoSize = true;
            this.lblMargenMinorista.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMargenMinorista.Location = new System.Drawing.Point(150, 144);
            this.lblMargenMinorista.Name = "lblMargenMinorista";
            this.lblMargenMinorista.Size = new System.Drawing.Size(40, 19);
            this.lblMargenMinorista.Text = "-";

            this.lblMargenMayoristaTitulo.AutoSize = true;
            this.lblMargenMayoristaTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMargenMayoristaTitulo.Location = new System.Drawing.Point(280, 145);
            this.lblMargenMayoristaTitulo.Name = "lblMargenMayoristaTitulo";
            this.lblMargenMayoristaTitulo.Size = new System.Drawing.Size(120, 15);
            this.lblMargenMayoristaTitulo.Text = "Margen Mayorista:";

            this.lblMargenMayorista.AutoSize = true;
            this.lblMargenMayorista.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMargenMayorista.Location = new System.Drawing.Point(415, 144);
            this.lblMargenMayorista.Name = "lblMargenMayorista";
            this.lblMargenMayorista.Size = new System.Drawing.Size(40, 19);
            this.lblMargenMayorista.Text = "-";

            // ===== panelBody =====
            this.panelBody.BackColor = System.Drawing.Color.White;
            this.panelBody.Controls.Add(this.lblMensaje);
            this.panelBody.Controls.Add(this.lblCambios);
            this.panelBody.Controls.Add(this.txtMotivo);
            this.panelBody.Controls.Add(this.lblMotivo);
            this.panelBody.Controls.Add(this.lblNuevoMargenMayorista);
            this.panelBody.Controls.Add(this.lblNuevoMargenMinorista);
            this.panelBody.Controls.Add(this.lblNuevoMargenMayoristaTitulo);
            this.panelBody.Controls.Add(this.lblNuevoMargenMinoristaTitulo);
            this.panelBody.Controls.Add(this.numPrecioMayorista);
            this.panelBody.Controls.Add(this.numPrecioMinorista);
            this.panelBody.Controls.Add(this.numPrecioCosto);
            this.panelBody.Controls.Add(this.lblPrecioMayorista);
            this.panelBody.Controls.Add(this.lblPrecioMinorista);
            this.panelBody.Controls.Add(this.lblPrecioCosto);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 240);
            this.panelBody.Name = "panelBody";
            this.panelBody.Padding = new System.Windows.Forms.Padding(15);
            this.panelBody.Size = new System.Drawing.Size(700, 280);
            this.panelBody.TabIndex = 2;

            int y = 15;

            // Sección nuevos precios
            var lblNuevos = new System.Windows.Forms.Label();
            lblNuevos.AutoSize = true;
            lblNuevos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblNuevos.ForeColor = System.Drawing.Color.FromArgb(67, 97, 238);
            lblNuevos.Location = new System.Drawing.Point(15, y);
            lblNuevos.Name = "lblNuevosPrecios";
            lblNuevos.Size = new System.Drawing.Size(180, 20);
            lblNuevos.Text = "💰 Nuevos Precios";
            this.panelBody.Controls.Add(lblNuevos);

            y += 35;

            // Precio Costo
            this.lblPrecioCosto.AutoSize = true;
            this.lblPrecioCosto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPrecioCosto.Location = new System.Drawing.Point(15, y + 3);
            this.lblPrecioCosto.Name = "lblPrecioCosto";
            this.lblPrecioCosto.Size = new System.Drawing.Size(90, 15);
            this.lblPrecioCosto.Text = "Precio Costo:";

            this.numPrecioCosto.DecimalPlaces = 2;
            this.numPrecioCosto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numPrecioCosto.Location = new System.Drawing.Point(150, y);
            this.numPrecioCosto.Maximum = 9999999;
            this.numPrecioCosto.Name = "numPrecioCosto";
            this.numPrecioCosto.Size = new System.Drawing.Size(150, 25);
            this.numPrecioCosto.TabIndex = 0;
            this.numPrecioCosto.ThousandsSeparator = true;
            this.numPrecioCosto.ValueChanged += new System.EventHandler(this.numPrecio_ValueChanged);

            y += 40;

            // Precio Minorista
            this.lblPrecioMinorista.AutoSize = true;
            this.lblPrecioMinorista.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPrecioMinorista.Location = new System.Drawing.Point(15, y + 3);
            this.lblPrecioMinorista.Name = "lblPrecioMinorista";
            this.lblPrecioMinorista.Size = new System.Drawing.Size(120, 15);
            this.lblPrecioMinorista.Text = "Precio Minorista: *";

            this.numPrecioMinorista.DecimalPlaces = 2;
            this.numPrecioMinorista.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numPrecioMinorista.Location = new System.Drawing.Point(150, y);
            this.numPrecioMinorista.Maximum = 9999999;
            this.numPrecioMinorista.Name = "numPrecioMinorista";
            this.numPrecioMinorista.Size = new System.Drawing.Size(150, 25);
            this.numPrecioMinorista.TabIndex = 1;
            this.numPrecioMinorista.ThousandsSeparator = true;
            this.numPrecioMinorista.ValueChanged += new System.EventHandler(this.numPrecio_ValueChanged);

            // Nuevo margen minorista
            this.lblNuevoMargenMinoristaTitulo.AutoSize = true;
            this.lblNuevoMargenMinoristaTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNuevoMargenMinoristaTitulo.Location = new System.Drawing.Point(320, y + 5);
            this.lblNuevoMargenMinoristaTitulo.Name = "lblNuevoMargenMinoristaTitulo";
            this.lblNuevoMargenMinoristaTitulo.Size = new System.Drawing.Size(50, 15);
            this.lblNuevoMargenMinoristaTitulo.Text = "Margen:";

            this.lblNuevoMargenMinorista.AutoSize = true;
            this.lblNuevoMargenMinorista.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNuevoMargenMinorista.Location = new System.Drawing.Point(380, y + 4);
            this.lblNuevoMargenMinorista.Name = "lblNuevoMargenMinorista";
            this.lblNuevoMargenMinorista.Size = new System.Drawing.Size(40, 19);
            this.lblNuevoMargenMinorista.Text = "-";

            y += 40;

            // Precio Mayorista
            this.lblPrecioMayorista.AutoSize = true;
            this.lblPrecioMayorista.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPrecioMayorista.Location = new System.Drawing.Point(15, y + 3);
            this.lblPrecioMayorista.Name = "lblPrecioMayorista";
            this.lblPrecioMayorista.Size = new System.Drawing.Size(120, 15);
            this.lblPrecioMayorista.Text = "Precio Mayorista:";

            this.numPrecioMayorista.DecimalPlaces = 2;
            this.numPrecioMayorista.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numPrecioMayorista.Location = new System.Drawing.Point(150, y);
            this.numPrecioMayorista.Maximum = 9999999;
            this.numPrecioMayorista.Name = "numPrecioMayorista";
            this.numPrecioMayorista.Size = new System.Drawing.Size(150, 25);
            this.numPrecioMayorista.TabIndex = 2;
            this.numPrecioMayorista.ThousandsSeparator = true;
            this.numPrecioMayorista.ValueChanged += new System.EventHandler(this.numPrecio_ValueChanged);

            // Nuevo margen mayorista
            this.lblNuevoMargenMayoristaTitulo.AutoSize = true;
            this.lblNuevoMargenMayoristaTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNuevoMargenMayoristaTitulo.Location = new System.Drawing.Point(320, y + 5);
            this.lblNuevoMargenMayoristaTitulo.Name = "lblNuevoMargenMayoristaTitulo";
            this.lblNuevoMargenMayoristaTitulo.Size = new System.Drawing.Size(50, 15);
            this.lblNuevoMargenMayoristaTitulo.Text = "Margen:";

            this.lblNuevoMargenMayorista.AutoSize = true;
            this.lblNuevoMargenMayorista.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNuevoMargenMayorista.Location = new System.Drawing.Point(380, y + 4);
            this.lblNuevoMargenMayorista.Name = "lblNuevoMargenMayorista";
            this.lblNuevoMargenMayorista.Size = new System.Drawing.Size(40, 19);
            this.lblNuevoMargenMayorista.Text = "-";

            y += 45;

            // Motivo
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMotivo.Location = new System.Drawing.Point(15, y + 3);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(120, 15);
            this.lblMotivo.Text = "Motivo del Cambio:";

            this.txtMotivo.Location = new System.Drawing.Point(150, y);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMotivo.Size = new System.Drawing.Size(500, 50);
            this.txtMotivo.TabIndex = 3;
            this.txtMotivo.PlaceholderText = "Ej: Ajuste por inflación, cambio de proveedor, promoción...";

            y += 60;

            // Indicador de cambios
            this.lblCambios.AutoSize = true;
            this.lblCambios.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCambios.Location = new System.Drawing.Point(15, y);
            this.lblCambios.Name = "lblCambios";
            this.lblCambios.Size = new System.Drawing.Size(0, 15);

            // Mensaje de error
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMensaje.Location = new System.Drawing.Point(15, y + 20);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 15);

            // ===== panelBotones =====
            this.panelBotones.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.panelBotones.Controls.Add(this.btnCancelar);
            this.panelBotones.Controls.Add(this.btnGuardar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 520);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(700, 60);
            this.panelBotones.TabIndex = 3;

            // btnGuardar
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(430, 12);
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
            this.btnCancelar.Location = new System.Drawing.Point(560, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(130, 38);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "✖ Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // ===== FrmCambioPrecio =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 580);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelProducto);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCambioPrecio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cambio de Precios";
            this.Load += new System.EventHandler(this.FrmCambioPrecio_Load);

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelProducto.ResumeLayout(false);
            this.panelProducto.PerformLayout();
            this.panelBody.ResumeLayout(false);
            this.panelBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioMayorista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioMinorista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioCosto)).EndInit();
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelProducto;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.Label lblCostoActualTitulo;
        private System.Windows.Forms.Label lblCostoActual;
        private System.Windows.Forms.Label lblMinoristaActualTitulo;
        private System.Windows.Forms.Label lblMinoristaActual;
        private System.Windows.Forms.Label lblMayoristaActualTitulo;
        private System.Windows.Forms.Label lblMayoristaActual;
        private System.Windows.Forms.Label lblMargenMinoristaTitulo;
        private System.Windows.Forms.Label lblMargenMinorista;
        private System.Windows.Forms.Label lblMargenMayoristaTitulo;
        private System.Windows.Forms.Label lblMargenMayorista;
        private System.Windows.Forms.Label lblPrecioCosto;
        private System.Windows.Forms.NumericUpDown numPrecioCosto;
        private System.Windows.Forms.Label lblPrecioMinorista;
        private System.Windows.Forms.NumericUpDown numPrecioMinorista;
        private System.Windows.Forms.Label lblPrecioMayorista;
        private System.Windows.Forms.NumericUpDown numPrecioMayorista;
        private System.Windows.Forms.Label lblNuevoMargenMinoristaTitulo;
        private System.Windows.Forms.Label lblNuevoMargenMinorista;
        private System.Windows.Forms.Label lblNuevoMargenMayoristaTitulo;
        private System.Windows.Forms.Label lblNuevoMargenMayorista;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label lblCambios;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        #endregion
    }
}