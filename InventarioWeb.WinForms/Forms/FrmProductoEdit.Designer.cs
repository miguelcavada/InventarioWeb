namespace InventarioWeb.WinForms.Forms
{
    partial class FrmProductoEdit
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
            this.panelBody = new System.Windows.Forms.Panel();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblUnidadMedida = new System.Windows.Forms.Label();
            this.cmbUnidadMedida = new System.Windows.Forms.ComboBox();
            this.lblPrecioCosto = new System.Windows.Forms.Label();
            this.numPrecioCosto = new System.Windows.Forms.NumericUpDown();
            this.lblPrecioMinorista = new System.Windows.Forms.Label();
            this.numPrecioMinorista = new System.Windows.Forms.NumericUpDown();
            this.lblPrecioMayorista = new System.Windows.Forms.Label();
            this.numPrecioMayorista = new System.Windows.Forms.NumericUpDown();

            this.panelTop.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioMinorista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioMayorista)).BeginInit();
            this.SuspendLayout();

            // ===== panelTop =====
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(600, 60);
            this.panelTop.TabIndex = 0;

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(15, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(180, 25);
            this.lblTitulo.Text = "Nuevo Producto";

            // ===== panelBody =====
            this.panelBody.BackColor = System.Drawing.Color.White;
            this.panelBody.Controls.Add(this.numPrecioMayorista);
            this.panelBody.Controls.Add(this.lblPrecioMayorista);
            this.panelBody.Controls.Add(this.numPrecioMinorista);
            this.panelBody.Controls.Add(this.lblPrecioMinorista);
            this.panelBody.Controls.Add(this.numPrecioCosto);
            this.panelBody.Controls.Add(this.lblPrecioCosto);
            this.panelBody.Controls.Add(this.cmbUnidadMedida);
            this.panelBody.Controls.Add(this.lblUnidadMedida);
            this.panelBody.Controls.Add(this.cmbCategoria);
            this.panelBody.Controls.Add(this.lblCategoria);
            this.panelBody.Controls.Add(this.txtDescripcion);
            this.panelBody.Controls.Add(this.lblDescripcion);
            this.panelBody.Controls.Add(this.txtNombre);
            this.panelBody.Controls.Add(this.lblNombre);
            this.panelBody.Controls.Add(this.txtCodigo);
            this.panelBody.Controls.Add(this.lblCodigo);
            this.panelBody.Controls.Add(this.lblMensaje);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 60);
            this.panelBody.Name = "panelBody";
            this.panelBody.Padding = new System.Windows.Forms.Padding(20);
            this.panelBody.Size = new System.Drawing.Size(600, 500);
            this.panelBody.TabIndex = 1;

            int y = 20;
            int lblWidth = 140;
            int ctrlLeft = 170;
            int ctrlWidth = 380;

            // lblCodigo
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(20, y + 3);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(60, 15);
            this.lblCodigo.Text = "Código: *";

            // txtCodigo
            this.txtCodigo.Location = new System.Drawing.Point(ctrlLeft, y);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(ctrlWidth, 23);
            this.txtCodigo.TabIndex = 0;

            y += 40;

            // lblNombre
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, y + 3);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(60, 15);
            this.lblNombre.Text = "Nombre: *";

            // txtNombre
            this.txtNombre.Location = new System.Drawing.Point(ctrlLeft, y);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(ctrlWidth, 23);
            this.txtNombre.TabIndex = 1;

            y += 40;

            // lblDescripcion
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(20, y + 3);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(75, 15);
            this.lblDescripcion.Text = "Descripción:";

            // txtDescripcion
            this.txtDescripcion.Location = new System.Drawing.Point(ctrlLeft, y);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(ctrlWidth, 60);
            this.txtDescripcion.TabIndex = 2;

            y += 80;

            // lblCategoria
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(20, y + 3);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(70, 15);
            this.lblCategoria.Text = "Categoría: *";

            // cmbCategoria
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.Location = new System.Drawing.Point(ctrlLeft, y);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(ctrlWidth, 23);
            this.cmbCategoria.TabIndex = 3;

            y += 40;

            // lblUnidadMedida
            this.lblUnidadMedida.AutoSize = true;
            this.lblUnidadMedida.Location = new System.Drawing.Point(20, y + 3);
            this.lblUnidadMedida.Name = "lblUnidadMedida";
            this.lblUnidadMedida.Size = new System.Drawing.Size(110, 15);
            this.lblUnidadMedida.Text = "Unidad de Medida: *";

            // cmbUnidadMedida
            this.cmbUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidadMedida.Location = new System.Drawing.Point(ctrlLeft, y);
            this.cmbUnidadMedida.Name = "cmbUnidadMedida";
            this.cmbUnidadMedida.Size = new System.Drawing.Size(ctrlWidth, 23);
            this.cmbUnidadMedida.TabIndex = 4;

            y += 50;

            // lblPrecioCosto
            this.lblPrecioCosto.AutoSize = true;
            this.lblPrecioCosto.Location = new System.Drawing.Point(20, y + 3);
            this.lblPrecioCosto.Name = "lblPrecioCosto";
            this.lblPrecioCosto.Size = new System.Drawing.Size(100, 15);
            this.lblPrecioCosto.Text = "Precio de Costo:";

            // numPrecioCosto
            this.numPrecioCosto.DecimalPlaces = 2;
            this.numPrecioCosto.Location = new System.Drawing.Point(ctrlLeft, y);
            this.numPrecioCosto.Maximum = 9999999;
            this.numPrecioCosto.Name = "numPrecioCosto";
            this.numPrecioCosto.Size = new System.Drawing.Size(150, 23);
            this.numPrecioCosto.TabIndex = 5;
            this.numPrecioCosto.ThousandsSeparator = true;

            y += 40;

            // lblPrecioMinorista
            this.lblPrecioMinorista.AutoSize = true;
            this.lblPrecioMinorista.Location = new System.Drawing.Point(20, y + 3);
            this.lblPrecioMinorista.Name = "lblPrecioMinorista";
            this.lblPrecioMinorista.Size = new System.Drawing.Size(110, 15);
            this.lblPrecioMinorista.Text = "Precio Minorista: *";

            // numPrecioMinorista
            this.numPrecioMinorista.DecimalPlaces = 2;
            this.numPrecioMinorista.Location = new System.Drawing.Point(ctrlLeft, y);
            this.numPrecioMinorista.Maximum = 9999999;
            this.numPrecioMinorista.Name = "numPrecioMinorista";
            this.numPrecioMinorista.Size = new System.Drawing.Size(150, 23);
            this.numPrecioMinorista.TabIndex = 6;
            this.numPrecioMinorista.ThousandsSeparator = true;

            y += 40;

            // lblPrecioMayorista
            this.lblPrecioMayorista.AutoSize = true;
            this.lblPrecioMayorista.Location = new System.Drawing.Point(20, y + 3);
            this.lblPrecioMayorista.Name = "lblPrecioMayorista";
            this.lblPrecioMayorista.Size = new System.Drawing.Size(110, 15);
            this.lblPrecioMayorista.Text = "Precio Mayorista:";

            // numPrecioMayorista
            this.numPrecioMayorista.DecimalPlaces = 2;
            this.numPrecioMayorista.Location = new System.Drawing.Point(ctrlLeft, y);
            this.numPrecioMayorista.Maximum = 9999999;
            this.numPrecioMayorista.Name = "numPrecioMayorista";
            this.numPrecioMayorista.Size = new System.Drawing.Size(150, 23);
            this.numPrecioMayorista.TabIndex = 7;
            this.numPrecioMayorista.ThousandsSeparator = true;

            y += 50;

            // lblMensaje
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(20, y);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 15);

            // ===== panelBotones =====
            this.panelBotones.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.panelBotones.Controls.Add(this.btnCancelar);
            this.panelBotones.Controls.Add(this.btnGuardar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 560);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(600, 60);
            this.panelBotones.TabIndex = 2;

            // btnGuardar
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(320, 12);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 38);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "💾 Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // btnCancelar
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(460, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(130, 38);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "✖ Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // ===== FrmProductoEdit =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 620);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProductoEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Producto";
            this.Load += new System.EventHandler(this.FrmProductoEdit_Load);

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBody.ResumeLayout(false);
            this.panelBody.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioMinorista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioMayorista)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblUnidadMedida;
        private System.Windows.Forms.ComboBox cmbUnidadMedida;
        private System.Windows.Forms.Label lblPrecioCosto;
        private System.Windows.Forms.NumericUpDown numPrecioCosto;
        private System.Windows.Forms.Label lblPrecioMinorista;
        private System.Windows.Forms.NumericUpDown numPrecioMinorista;
        private System.Windows.Forms.Label lblPrecioMayorista;
        private System.Windows.Forms.NumericUpDown numPrecioMayorista;

        #endregion
    }
}