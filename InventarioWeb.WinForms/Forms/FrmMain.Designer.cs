namespace InventarioWeb.WinForms.Forms
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuInicio;
        private System.Windows.Forms.ToolStripMenuItem menuProductos;
        private System.Windows.Forms.ToolStripMenuItem menuProductosLista;
        private System.Windows.Forms.ToolStripMenuItem menuProductosNuevo;
        private System.Windows.Forms.ToolStripMenuItem menuProductosCategorias;
        private System.Windows.Forms.ToolStripMenuItem menuProductosUnidades;
        private System.Windows.Forms.ToolStripMenuItem menuAlmacenes;
        private System.Windows.Forms.ToolStripMenuItem menuAlmacenesLista;
        private System.Windows.Forms.ToolStripMenuItem menuAlmacenesNuevo;
        private System.Windows.Forms.ToolStripMenuItem menuMovimientos;
        private System.Windows.Forms.ToolStripMenuItem menuMovimientosHistorial;
        private System.Windows.Forms.ToolStripMenuItem menuMovimientosEntrada;
        private System.Windows.Forms.ToolStripMenuItem menuMovimientosSalida;
        private System.Windows.Forms.ToolStripMenuItem menuConsignaciones;
        private System.Windows.Forms.ToolStripMenuItem menuProveedores;
        private System.Windows.Forms.ToolStripMenuItem menuReportes;
        private System.Windows.Forms.ToolStripMenuItem menuGraficos;
        private System.Windows.Forms.ToolStripMenuItem menuAdministracion;
        private System.Windows.Forms.ToolStripMenuItem menuAdminUsuarios;
        private System.Windows.Forms.ToolStripMenuItem menuSesion;
        private System.Windows.Forms.ToolStripMenuItem menuSesionUsuario;
        private System.Windows.Forms.ToolStripMenuItem menuSesionSalir;
        private System.Windows.Forms.ToolStripSeparator menuSeparator1;
        private System.Windows.Forms.ToolStripSeparator menuSeparator2;
        private System.Windows.Forms.ToolStripSeparator menuSeparator3;
        private System.Windows.Forms.ToolStripSeparator menuSeparator4;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuInicio = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProductosLista = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProductosNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuProductosCategorias = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProductosUnidades = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAlmacenes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAlmacenesLista = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAlmacenesNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovimientos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovimientosHistorial = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuMovimientosEntrada = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovimientosSalida = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsignaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGraficos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdministracion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdminUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSesionUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSesionSalir = new System.Windows.Forms.ToolStripMenuItem();

            // menuStrip
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.menuInicio,
                this.menuProductos,
                this.menuAlmacenes,
                this.menuMovimientos,
                this.menuConsignaciones,
                this.menuProveedores,
                this.menuReportes,
                this.menuGraficos,
                this.menuAdministracion,
                this.menuSesion});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1200, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.menuStrip.ForeColor = System.Drawing.Color.White;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            // menuInicio
            this.menuInicio.Name = "menuInicio";
            this.menuInicio.Size = new System.Drawing.Size(80, 20);
            this.menuInicio.Text = "🏠 Inicio";
            this.menuInicio.Click += new System.EventHandler(this.MenuInicio_Click);

            // menuProductos
            this.menuProductos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.menuProductosLista,
                this.menuProductosNuevo,
                this.menuSeparator1,
                this.menuProductosCategorias,
                this.menuProductosUnidades});
            this.menuProductos.Name = "menuProductos";
            this.menuProductos.Size = new System.Drawing.Size(90, 20);
            this.menuProductos.Text = "📦 Productos";

            // menuProductosLista
            this.menuProductosLista.Name = "menuProductosLista";
            this.menuProductosLista.Size = new System.Drawing.Size(180, 22);
            this.menuProductosLista.Text = "Lista de Productos";
            this.menuProductosLista.Click += new System.EventHandler(this.MenuProductosLista_Click);

            // menuProductosNuevo
            this.menuProductosNuevo.Name = "menuProductosNuevo";
            this.menuProductosNuevo.Size = new System.Drawing.Size(180, 22);
            this.menuProductosNuevo.Text = "Nuevo Producto";
            this.menuProductosNuevo.Click += new System.EventHandler(this.MenuProductosNuevo_Click);

            // menuSeparator1
            this.menuSeparator1.Name = "menuSeparator1";
            this.menuSeparator1.Size = new System.Drawing.Size(177, 6);

            // menuProductosCategorias
            this.menuProductosCategorias.Name = "menuProductosCategorias";
            this.menuProductosCategorias.Size = new System.Drawing.Size(180, 22);
            this.menuProductosCategorias.Text = "Categorías";
            this.menuProductosCategorias.Click += new System.EventHandler(this.MenuProductosCategorias_Click);

            // menuProductosUnidades
            this.menuProductosUnidades.Name = "menuProductosUnidades";
            this.menuProductosUnidades.Size = new System.Drawing.Size(180, 22);
            this.menuProductosUnidades.Text = "Unidades de Medida";
            this.menuProductosUnidades.Click += new System.EventHandler(this.MenuProductosUnidades_Click);

            // menuAlmacenes
            this.menuAlmacenes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.menuAlmacenesLista,
                this.menuAlmacenesNuevo});
            this.menuAlmacenes.Name = "menuAlmacenes";
            this.menuAlmacenes.Size = new System.Drawing.Size(95, 20);
            this.menuAlmacenes.Text = "🏪 Almacenes";

            // menuAlmacenesLista
            this.menuAlmacenesLista.Name = "menuAlmacenesLista";
            this.menuAlmacenesLista.Size = new System.Drawing.Size(180, 22);
            this.menuAlmacenesLista.Text = "Lista de Almacenes";
            this.menuAlmacenesLista.Click += new System.EventHandler(this.MenuAlmacenesLista_Click);

            // menuAlmacenesNuevo
            this.menuAlmacenesNuevo.Name = "menuAlmacenesNuevo";
            this.menuAlmacenesNuevo.Size = new System.Drawing.Size(180, 22);
            this.menuAlmacenesNuevo.Text = "Nuevo Almacén";
            this.menuAlmacenesNuevo.Click += new System.EventHandler(this.MenuAlmacenesNuevo_Click);

            // menuMovimientos
            this.menuMovimientos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.menuMovimientosHistorial,
                this.menuSeparator2,
                this.menuMovimientosEntrada,
                this.menuMovimientosSalida});
            this.menuMovimientos.Name = "menuMovimientos";
            this.menuMovimientos.Size = new System.Drawing.Size(105, 20);
            this.menuMovimientos.Text = "↔️ Movimientos";

            // menuMovimientosHistorial
            this.menuMovimientosHistorial.Name = "menuMovimientosHistorial";
            this.menuMovimientosHistorial.Size = new System.Drawing.Size(180, 22);
            this.menuMovimientosHistorial.Text = "Historial";
            this.menuMovimientosHistorial.Click += new System.EventHandler(this.MenuMovimientosHistorial_Click);

            // menuSeparator2
            this.menuSeparator2.Name = "menuSeparator2";
            this.menuSeparator2.Size = new System.Drawing.Size(177, 6);

            // menuMovimientosEntrada
            this.menuMovimientosEntrada.Name = "menuMovimientosEntrada";
            this.menuMovimientosEntrada.Size = new System.Drawing.Size(180, 22);
            this.menuMovimientosEntrada.Text = "Nueva Entrada";
            this.menuMovimientosEntrada.Click += new System.EventHandler(this.MenuMovimientosEntrada_Click);

            // menuMovimientosSalida
            this.menuMovimientosSalida.Name = "menuMovimientosSalida";
            this.menuMovimientosSalida.Size = new System.Drawing.Size(180, 22);
            this.menuMovimientosSalida.Text = "Nueva Salida";
            this.menuMovimientosSalida.Click += new System.EventHandler(this.MenuMovimientosSalida_Click);

            // menuConsignaciones
            this.menuConsignaciones.Name = "menuConsignaciones";
            this.menuConsignaciones.Size = new System.Drawing.Size(115, 20);
            this.menuConsignaciones.Text = "🤝 Consignaciones";
            this.menuConsignaciones.Click += new System.EventHandler(this.MenuConsignaciones_Click);

            // menuProveedores
            this.menuProveedores.Name = "menuProveedores";
            this.menuProveedores.Size = new System.Drawing.Size(100, 20);
            this.menuProveedores.Text = "🚚 Proveedores";
            this.menuProveedores.Click += new System.EventHandler(this.MenuProveedores_Click);

            // menuSeparator3
            this.menuSeparator3.Name = "menuSeparator3";
            this.menuSeparator3.Size = new System.Drawing.Size(177, 6);

            // menuReportes
            this.menuReportes.Name = "menuReportes";
            this.menuReportes.Size = new System.Drawing.Size(85, 20);
            this.menuReportes.Text = "📊 Reportes";
            this.menuReportes.Click += new System.EventHandler(this.MenuReportes_Click);

            // menuGraficos
            this.menuGraficos.Name = "menuGraficos";
            this.menuGraficos.Size = new System.Drawing.Size(80, 20);
            this.menuGraficos.Text = "📈 Gráficos";
            this.menuGraficos.Click += new System.EventHandler(this.MenuGraficos_Click);

            // menuAdministracion
            this.menuAdministracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.menuAdminUsuarios});
            this.menuAdministracion.Name = "menuAdministracion";
            this.menuAdministracion.Size = new System.Drawing.Size(70, 20);
            this.menuAdministracion.Text = "⚙️ Admin";

            // menuAdminUsuarios
            this.menuAdminUsuarios.Name = "menuAdminUsuarios";
            this.menuAdminUsuarios.Size = new System.Drawing.Size(180, 22);
            this.menuAdminUsuarios.Text = "Usuarios";
            this.menuAdminUsuarios.Click += new System.EventHandler(this.MenuAdminUsuarios_Click);

            // menuSesion
            this.menuSesion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuSesion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.menuSesionUsuario,
                this.menuSeparator4,
                this.menuSesionSalir});
            this.menuSesion.Name = "menuSesion";
            this.menuSesion.Size = new System.Drawing.Size(120, 20);
            this.menuSesion.Text = "👤 Usuario";

            // menuSesionUsuario
            this.menuSesionUsuario.Enabled = false;
            this.menuSesionUsuario.Name = "menuSesionUsuario";
            this.menuSesionUsuario.Size = new System.Drawing.Size(180, 22);
            this.menuSesionUsuario.Text = "Usuario";

            // menuSeparator4
            this.menuSeparator4.Name = "menuSeparator4";
            this.menuSeparator4.Size = new System.Drawing.Size(177, 6);

            // menuSesionSalir
            this.menuSesionSalir.Name = "menuSesionSalir";
            this.menuSesionSalir.Size = new System.Drawing.Size(180, 22);
            this.menuSesionSalir.Text = "Cerrar Sesión";
            this.menuSesionSalir.Click += new System.EventHandler(this.MenuSesionSalir_Click);

            // FrmMain
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Inventario - Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
        }
    }
}