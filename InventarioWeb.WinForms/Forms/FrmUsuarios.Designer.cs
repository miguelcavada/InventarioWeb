namespace InventarioWeb.WinForms.Forms
{
    partial class FrmUsuarios
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnActivarDesactivar = new System.Windows.Forms.Button();
            this.btnCambiarPassword = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelKPIs = new System.Windows.Forms.Panel();
            this.lblAdminsValor = new System.Windows.Forms.Label();
            this.lblAdminsTitulo = new System.Windows.Forms.Label();
            this.lblInactivosValor = new System.Windows.Forms.Label();
            this.lblInactivosTitulo = new System.Windows.Forms.Label();
            this.lblActivosValor = new System.Windows.Forms.Label();
            this.lblActivosTitulo = new System.Windows.Forms.Label();
            this.lblTotalUsuariosValor = new System.Windows.Forms.Label();
            this.lblTotalUsuariosTitulo = new System.Windows.Forms.Label();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUltimoAcceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();

            // Labels para KPIs (referenciados en código)
            this.lblTotalUsuarios = new System.Windows.Forms.Label();
            this.lblActivos = new System.Windows.Forms.Label();
            this.lblInactivos = new System.Windows.Forms.Label();
            this.lblAdmins = new System.Windows.Forms.Label();

            this.panelTop.SuspendLayout();
            this.panelKPIs.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.panelTop.Controls.Add(this.btnCerrar);
            this.panelTop.Controls.Add(this.btnActivarDesactivar);
            this.panelTop.Controls.Add(this.btnCambiarPassword);
            this.panelTop.Controls.Add(this.btnEditar);
            this.panelTop.Controls.Add(this.btnNuevo);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1100, 100);
            this.panelTop.TabIndex = 0;

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(15, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(200, 25);
            this.lblTitulo.Text = "Gestión de Usuarios";

            // btnNuevo
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(420, 55);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(110, 28);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "➕ Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            // btnEditar
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(255, 159, 28);
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(540, 55);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(110, 28);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "✏️ Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            // btnCambiarPassword
            this.btnCambiarPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCambiarPassword.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.btnCambiarPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarPassword.ForeColor = System.Drawing.Color.White;
            this.btnCambiarPassword.Location = new System.Drawing.Point(660, 55);
            this.btnCambiarPassword.Name = "btnCambiarPassword";
            this.btnCambiarPassword.Size = new System.Drawing.Size(140, 28);
            this.btnCambiarPassword.TabIndex = 3;
            this.btnCambiarPassword.Text = "🔑 Cambiar Contraseña";
            this.btnCambiarPassword.UseVisualStyleBackColor = false;
            this.btnCambiarPassword.Click += new System.EventHandler(this.btnCambiarPassword_Click);

            // btnActivarDesactivar
            this.btnActivarDesactivar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActivarDesactivar.BackColor = System.Drawing.Color.FromArgb(231, 29, 54);
            this.btnActivarDesactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivarDesactivar.ForeColor = System.Drawing.Color.White;
            this.btnActivarDesactivar.Location = new System.Drawing.Point(810, 55);
            this.btnActivarDesactivar.Name = "btnActivarDesactivar";
            this.btnActivarDesactivar.Size = new System.Drawing.Size(140, 28);
            this.btnActivarDesactivar.TabIndex = 4;
            this.btnActivarDesactivar.Text = "🔒 Activar/Desactivar";
            this.btnActivarDesactivar.UseVisualStyleBackColor = false;
            this.btnActivarDesactivar.Click += new System.EventHandler(this.btnActivarDesactivar_Click);

            // btnCerrar
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(960, 55);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 28);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "✖ Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // panelKPIs
            this.panelKPIs.BackColor = System.Drawing.Color.FromArgb(240, 240, 245);
            this.panelKPIs.Controls.Add(this.lblAdminsValor);
            this.panelKPIs.Controls.Add(this.lblAdminsTitulo);
            this.panelKPIs.Controls.Add(this.lblInactivosValor);
            this.panelKPIs.Controls.Add(this.lblInactivosTitulo);
            this.panelKPIs.Controls.Add(this.lblActivosValor);
            this.panelKPIs.Controls.Add(this.lblActivosTitulo);
            this.panelKPIs.Controls.Add(this.lblTotalUsuariosValor);
            this.panelKPIs.Controls.Add(this.lblTotalUsuariosTitulo);
            this.panelKPIs.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKPIs.Location = new System.Drawing.Point(0, 100);
            this.panelKPIs.Name = "panelKPIs";
            this.panelKPIs.Size = new System.Drawing.Size(1100, 80);
            this.panelKPIs.TabIndex = 1;

            // KPIs (mismo patrón que FrmAlmacenInventario)
            this.lblTotalUsuariosTitulo.AutoSize = true;
            this.lblTotalUsuariosTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalUsuariosTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalUsuariosTitulo.Location = new System.Drawing.Point(30, 15);
            this.lblTotalUsuariosTitulo.Text = "Total Usuarios";

            this.lblTotalUsuariosValor.AutoSize = true;
            this.lblTotalUsuariosValor.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalUsuariosValor.ForeColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.lblTotalUsuariosValor.Location = new System.Drawing.Point(30, 35);
            this.lblTotalUsuariosValor.Text = "0";

            this.lblActivosTitulo.AutoSize = true;
            this.lblActivosTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblActivosTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblActivosTitulo.Location = new System.Drawing.Point(230, 15);
            this.lblActivosTitulo.Text = "Activos";

            this.lblActivosValor.AutoSize = true;
            this.lblActivosValor.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblActivosValor.ForeColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.lblActivosValor.Location = new System.Drawing.Point(230, 35);
            this.lblActivosValor.Text = "0";

            this.lblInactivosTitulo.AutoSize = true;
            this.lblInactivosTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInactivosTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblInactivosTitulo.Location = new System.Drawing.Point(430, 15);
            this.lblInactivosTitulo.Text = "Inactivos";

            this.lblInactivosValor.AutoSize = true;
            this.lblInactivosValor.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblInactivosValor.ForeColor = System.Drawing.Color.FromArgb(255, 159, 28);
            this.lblInactivosValor.Location = new System.Drawing.Point(430, 35);
            this.lblInactivosValor.Text = "0";

            this.lblAdminsTitulo.AutoSize = true;
            this.lblAdminsTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAdminsTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblAdminsTitulo.Location = new System.Drawing.Point(630, 15);
            this.lblAdminsTitulo.Text = "Administradores";

            this.lblAdminsValor.AutoSize = true;
            this.lblAdminsValor.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblAdminsValor.ForeColor = System.Drawing.Color.FromArgb(231, 29, 54);
            this.lblAdminsValor.Location = new System.Drawing.Point(630, 35);
            this.lblAdminsValor.Text = "0";

            // dgvUsuarios
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvUsuarios.ColumnHeadersHeight = 35;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colId, this.colNombre, this.colEmail, this.colRol,
                this.colTelefono, this.colEstado, this.colUltimoAcceso, this.colFechaRegistro});
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.Location = new System.Drawing.Point(0, 180);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.RowTemplate.Height = 30;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(1100, 390);
            this.dgvUsuarios.TabIndex = 2;
            this.dgvUsuarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellDoubleClick);

            // Columnas
            this.colId.Name = "colId";
            this.colId.HeaderText = "ID";
            this.colId.Visible = false;

            this.colNombre.Name = "colNombre";
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.FillWeight = 150;

            this.colEmail.Name = "colEmail";
            this.colEmail.HeaderText = "Email";
            this.colEmail.FillWeight = 180;

            this.colRol.Name = "colRol";
            this.colRol.HeaderText = "Rol";
            this.colRol.FillWeight = 80;

            this.colTelefono.Name = "colTelefono";
            this.colTelefono.HeaderText = "Teléfono";
            this.colTelefono.FillWeight = 100;

            this.colEstado.Name = "colEstado";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.FillWeight = 70;

            this.colUltimoAcceso.Name = "colUltimoAcceso";
            this.colUltimoAcceso.HeaderText = "Último Acceso";
            this.colUltimoAcceso.FillWeight = 120;

            this.colFechaRegistro.Name = "colFechaRegistro";
            this.colFechaRegistro.HeaderText = "Fecha Registro";
            this.colFechaRegistro.FillWeight = 100;

            // panelBottom
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.panelBottom.Controls.Add(this.lblTotal);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 570);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1100, 30);
            this.panelBottom.TabIndex = 3;

            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(15, 7);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(150, 15);
            this.lblTotal.Text = "Mostrando 0 usuario(s)";

            // FrmUsuarios
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelKPIs);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "FrmUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.FrmUsuarios_Load);

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelKPIs.ResumeLayout(false);
            this.panelKPIs.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelKPIs;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnCambiarPassword;
        private System.Windows.Forms.Button btnActivarDesactivar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUltimoAcceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaRegistro;

        // KPIs
        private System.Windows.Forms.Label lblTotalUsuariosTitulo;
        private System.Windows.Forms.Label lblTotalUsuariosValor;
        private System.Windows.Forms.Label lblActivosTitulo;
        private System.Windows.Forms.Label lblActivosValor;
        private System.Windows.Forms.Label lblInactivosTitulo;
        private System.Windows.Forms.Label lblInactivosValor;
        private System.Windows.Forms.Label lblAdminsTitulo;
        private System.Windows.Forms.Label lblAdminsValor;

        // Labels referenciados en código
        private System.Windows.Forms.Label lblTotalUsuarios;
        private System.Windows.Forms.Label lblActivos;
        private System.Windows.Forms.Label lblInactivos;
        private System.Windows.Forms.Label lblAdmins;

        #endregion
    }
}