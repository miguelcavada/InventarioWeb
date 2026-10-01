
namespace InventarioWeb.WinForms.Forms
{
    partial class FrmMain
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnAlmacenes = new System.Windows.Forms.Button();
            this.btnMovimientos = new System.Windows.Forms.Button();
            this.btnConsignaciones = new System.Windows.Forms.Button();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.btnUnidades = new System.Windows.Forms.Button();
            this.btnGraficos = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // ===== panelMenu =====
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.panelMenu.Controls.Add(this.btnCategorias);
            this.panelMenu.Controls.Add(this.btnUnidades);
            this.panelMenu.Controls.Add(this.btnUsuarios);
            this.panelMenu.Controls.Add(this.btnReportes);
            this.panelMenu.Controls.Add(this.btnProveedores);
            this.panelMenu.Controls.Add(this.btnConsignaciones);
            this.panelMenu.Controls.Add(this.btnMovimientos);
            this.panelMenu.Controls.Add(this.btnAlmacenes);
            this.panelMenu.Controls.Add(this.btnProductos);
            this.panelMenu.Controls.Add(this.btnGraficos);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 600);
            this.panelMenu.TabIndex = 0;

            // ===== panelTop =====
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.panelTop.Controls.Add(this.btnSalir);
            this.panelTop.Controls.Add(this.lblUsuario);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(220, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(780, 60);
            this.panelTop.TabIndex = 1;

            // ===== lblTitulo =====
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(15, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(200, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Sistema de Inventario";

            // ===== lblUsuario =====
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(450, 22);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(100, 19);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario: Admin";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // ===== btnSalir =====
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(231, 29, 54);
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(680, 15);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(85, 32);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);

            // ===== panelContenido =====
            this.panelContenido.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(220, 60);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(780, 540);
            this.panelContenido.TabIndex = 2;

            // ===== btnProductos =====
            this.btnProductos.BackColor = System.Drawing.Color.Transparent;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.Location = new System.Drawing.Point(0, 20);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(220, 45);
            this.btnProductos.TabIndex = 0;
            this.btnProductos.Text = "  📦  Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);

            // ===== btnAlmacenes =====
            this.btnAlmacenes.BackColor = System.Drawing.Color.Transparent;
            this.btnAlmacenes.FlatAppearance.BorderSize = 0;
            this.btnAlmacenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlmacenes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAlmacenes.ForeColor = System.Drawing.Color.White;
            this.btnAlmacenes.Location = new System.Drawing.Point(0, 70);
            this.btnAlmacenes.Name = "btnAlmacenes";
            this.btnAlmacenes.Size = new System.Drawing.Size(220, 45);
            this.btnAlmacenes.TabIndex = 1;
            this.btnAlmacenes.Text = "  🏪  Almacenes";
            this.btnAlmacenes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlmacenes.UseVisualStyleBackColor = false;
            this.btnAlmacenes.Click += new System.EventHandler(this.btnAlmacenes_Click);

            // ===== btnMovimientos =====
            this.btnMovimientos.BackColor = System.Drawing.Color.Transparent;
            this.btnMovimientos.FlatAppearance.BorderSize = 0;
            this.btnMovimientos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMovimientos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMovimientos.ForeColor = System.Drawing.Color.White;
            this.btnMovimientos.Location = new System.Drawing.Point(0, 120);
            this.btnMovimientos.Name = "btnMovimientos";
            this.btnMovimientos.Size = new System.Drawing.Size(220, 45);
            this.btnMovimientos.TabIndex = 2;
            this.btnMovimientos.Text = "  ↔️  Movimientos";
            this.btnMovimientos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMovimientos.UseVisualStyleBackColor = false;
            this.btnMovimientos.Click += new System.EventHandler(this.btnMovimientos_Click);

            // ===== btnConsignaciones =====
            this.btnConsignaciones.BackColor = System.Drawing.Color.Transparent;
            this.btnConsignaciones.FlatAppearance.BorderSize = 0;
            this.btnConsignaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsignaciones.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnConsignaciones.ForeColor = System.Drawing.Color.White;
            this.btnConsignaciones.Location = new System.Drawing.Point(0, 170);
            this.btnConsignaciones.Name = "btnConsignaciones";
            this.btnConsignaciones.Size = new System.Drawing.Size(220, 45);
            this.btnConsignaciones.TabIndex = 3;
            this.btnConsignaciones.Text = "  🤝  Consignaciones";
            this.btnConsignaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsignaciones.UseVisualStyleBackColor = false;
            this.btnConsignaciones.Click += new System.EventHandler(this.btnConsignaciones_Click);

            // ===== btnCategorias =====
            this.btnCategorias.BackColor = System.Drawing.Color.Transparent;
            this.btnCategorias.FlatAppearance.BorderSize = 0;
            this.btnCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorias.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCategorias.ForeColor = System.Drawing.Color.White;
            this.btnCategorias.Location = new System.Drawing.Point(0, 220);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(220, 45);
            this.btnCategorias.TabIndex = 7;
            this.btnCategorias.Text = "  🏷️  Categorías";
            this.btnCategorias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorias.UseVisualStyleBackColor = false;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);

            // ===== btnUnidades =====
            this.btnUnidades.BackColor = System.Drawing.Color.Transparent;
            this.btnUnidades.FlatAppearance.BorderSize = 0;
            this.btnUnidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnidades.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnUnidades.ForeColor = System.Drawing.Color.White;
            this.btnUnidades.Location = new System.Drawing.Point(0, 270);
            this.btnUnidades.Name = "btnUnidades";
            this.btnUnidades.Size = new System.Drawing.Size(220, 45);
            this.btnUnidades.TabIndex = 8;
            this.btnUnidades.Text = "  📏  Unidades";
            this.btnUnidades.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnidades.UseVisualStyleBackColor = false;
            this.btnUnidades.Click += new System.EventHandler(this.btnUnidades_Click);

            // ===== btnProveedores =====
            this.btnProveedores.BackColor = System.Drawing.Color.Transparent;
            this.btnProveedores.FlatAppearance.BorderSize = 0;
            this.btnProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProveedores.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnProveedores.ForeColor = System.Drawing.Color.White;
            this.btnProveedores.Location = new System.Drawing.Point(0, 320);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(220, 45);
            this.btnProveedores.TabIndex = 4;
            this.btnProveedores.Text = "  🚚  Proveedores";
            this.btnProveedores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProveedores.UseVisualStyleBackColor = false;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);

            // ===== btnReportes =====
            this.btnReportes.BackColor = System.Drawing.Color.Transparent;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.Location = new System.Drawing.Point(0, 370);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(220, 45);
            this.btnReportes.TabIndex = 5;
            this.btnReportes.Text = "  📊  Reportes";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);

            // ===== btnUsuarios =====
            this.btnUsuarios.BackColor = System.Drawing.Color.Transparent;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.Location = new System.Drawing.Point(0, 420);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(220, 45);
            this.btnUsuarios.TabIndex = 6;
            this.btnUsuarios.Text = "  👥  Usuarios";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);

            this.btnGraficos.BackColor = System.Drawing.Color.Transparent;
            this.btnGraficos.FlatAppearance.BorderSize = 0;
            this.btnGraficos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGraficos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGraficos.ForeColor = System.Drawing.Color.White;
            this.btnGraficos.Location = new System.Drawing.Point(0, 470);
            this.btnGraficos.Name = "btnGraficos";
            this.btnGraficos.Size = new System.Drawing.Size(220, 45);
            this.btnGraficos.TabIndex = 10;
            this.btnGraficos.Text = "  📈  Gráficos";
            this.btnGraficos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGraficos.UseVisualStyleBackColor = false;
            this.btnGraficos.Click += new System.EventHandler(this.btnGraficos_Click);

            // ===== FrmMain =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Inventario - Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnAlmacenes;
        private System.Windows.Forms.Button btnMovimientos;
        private System.Windows.Forms.Button btnConsignaciones;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.Button btnUnidades;
        private System.Windows.Forms.Button btnGraficos;

        #endregion
    }
}