namespace SistemaProductos
{
    partial class FrmUsuarios
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpCajero = new System.Windows.Forms.GroupBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.lblNombres = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.lblTurno = new System.Windows.Forms.Label();
            this.cboTurno = new System.Windows.Forms.ComboBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgvCajeros = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajeros)).BeginInit();
            this.grpCajero.SuspendLayout();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Location = new System.Drawing.Point(0, 10);
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Size = new System.Drawing.Size(760, 32);
            this.lblTitulo.Text = "ADMINISTRACIÓN DE CAJEROS";
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 32, 128);
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // grpCajero
            this.grpCajero.Name = "grpCajero";
            this.grpCajero.Location = new System.Drawing.Point(15, 50);
            this.grpCajero.Size = new System.Drawing.Size(730, 165);
            this.grpCajero.Text = "Datos del cajero";
            this.grpCajero.ForeColor = System.Drawing.Color.FromArgb(0, 70, 170);

            // lblCedula
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Location = new System.Drawing.Point(15, 31);
            this.lblCedula.AutoSize = true;
            this.lblCedula.Text = "Cédula";
            this.lblCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCedula.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // txtCedula
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Location = new System.Drawing.Point(95, 28);
            this.txtCedula.Size = new System.Drawing.Size(200, 20);
            this.txtCedula.TabIndex = 0;

            // lblNombres
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Location = new System.Drawing.Point(15, 65);
            this.lblNombres.AutoSize = true;
            this.lblNombres.Text = "Nombres";
            this.lblNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombres.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // txtNombres
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Location = new System.Drawing.Point(95, 62);
            this.txtNombres.Size = new System.Drawing.Size(200, 20);
            this.txtNombres.TabIndex = 1;

            // lblApellidos
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Location = new System.Drawing.Point(15, 99);
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Text = "Apellidos";
            this.lblApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblApellidos.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // txtApellidos
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Location = new System.Drawing.Point(95, 96);
            this.txtApellidos.Size = new System.Drawing.Size(200, 20);
            this.txtApellidos.TabIndex = 2;

            // lblTelefono
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Location = new System.Drawing.Point(15, 133);
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Text = "Teléfono";
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // txtTelefono
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Location = new System.Drawing.Point(95, 130);
            this.txtTelefono.Size = new System.Drawing.Size(200, 20);
            this.txtTelefono.TabIndex = 3;

            // lblEmail
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Location = new System.Drawing.Point(330, 31);
            this.lblEmail.AutoSize = true;
            this.lblEmail.Text = "Email";
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // txtEmail
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Location = new System.Drawing.Point(410, 28);
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 4;

            // lblUsuario
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Location = new System.Drawing.Point(330, 65);
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // txtUsuario
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Location = new System.Drawing.Point(410, 62);
            this.txtUsuario.Size = new System.Drawing.Size(200, 20);
            this.txtUsuario.TabIndex = 5;

            // lblClave
            this.lblClave.Name = "lblClave";
            this.lblClave.Location = new System.Drawing.Point(330, 99);
            this.lblClave.AutoSize = true;
            this.lblClave.Text = "Contraseña";
            this.lblClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblClave.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // txtClave
            this.txtClave.Name = "txtClave";
            this.txtClave.Location = new System.Drawing.Point(410, 96);
            this.txtClave.Size = new System.Drawing.Size(200, 20);
            this.txtClave.TabIndex = 6;

            // lblTurno
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Location = new System.Drawing.Point(330, 133);
            this.lblTurno.AutoSize = true;
            this.lblTurno.Text = "Turno";
            this.lblTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTurno.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // cboTurno
            this.cboTurno.Name = "cboTurno";
            this.cboTurno.Location = new System.Drawing.Point(410, 130);
            this.cboTurno.Size = new System.Drawing.Size(200, 21);
            this.cboTurno.TabIndex = 7;
            this.cboTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // btnNuevo
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Location = new System.Drawing.Point(15, 225);
            this.btnNuevo.Size = new System.Drawing.Size(120, 34);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(155, 183, 213);
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.TabIndex = 8;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            // btnInsertar
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Location = new System.Drawing.Point(145, 225);
            this.btnInsertar.Size = new System.Drawing.Size(120, 34);
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnInsertar.BackColor = System.Drawing.Color.FromArgb(155, 183, 213);
            this.btnInsertar.UseVisualStyleBackColor = false;
            this.btnInsertar.TabIndex = 9;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);

            // btnActualizar
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Location = new System.Drawing.Point(275, 225);
            this.btnActualizar.Size = new System.Drawing.Size(120, 34);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(155, 183, 213);
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.TabIndex = 10;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            // btnEliminar
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Location = new System.Drawing.Point(405, 225);
            this.btnEliminar.Size = new System.Drawing.Size(120, 34);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(155, 183, 213);
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // btnCerrar
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Location = new System.Drawing.Point(625, 225);
            this.btnCerrar.Size = new System.Drawing.Size(120, 34);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.TabIndex = 12;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // dgvCajeros
            this.dgvCajeros.Name = "dgvCajeros";
            this.dgvCajeros.Location = new System.Drawing.Point(15, 270);
            this.dgvCajeros.Size = new System.Drawing.Size(730, 270);
            this.dgvCajeros.TabIndex = 13;
            this.dgvCajeros.ReadOnly = true;
            this.dgvCajeros.AllowUserToAddRows = false;
            this.dgvCajeros.AllowUserToDeleteRows = false;
            this.dgvCajeros.MultiSelect = false;
            this.dgvCajeros.RowHeadersVisible = false;
            this.dgvCajeros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCajeros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCajeros.BackgroundColor = System.Drawing.Color.White;
            this.dgvCajeros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCajeros_CellClick);

            this.grpCajero.Controls.Add(this.lblCedula);
            this.grpCajero.Controls.Add(this.txtCedula);
            this.grpCajero.Controls.Add(this.lblNombres);
            this.grpCajero.Controls.Add(this.txtNombres);
            this.grpCajero.Controls.Add(this.lblApellidos);
            this.grpCajero.Controls.Add(this.txtApellidos);
            this.grpCajero.Controls.Add(this.lblTelefono);
            this.grpCajero.Controls.Add(this.txtTelefono);
            this.grpCajero.Controls.Add(this.lblEmail);
            this.grpCajero.Controls.Add(this.txtEmail);
            this.grpCajero.Controls.Add(this.lblUsuario);
            this.grpCajero.Controls.Add(this.txtUsuario);
            this.grpCajero.Controls.Add(this.lblClave);
            this.grpCajero.Controls.Add(this.txtClave);
            this.grpCajero.Controls.Add(this.lblTurno);
            this.grpCajero.Controls.Add(this.cboTurno);

            // FrmUsuarios
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(232, 240, 250);
            this.ClientSize = new System.Drawing.Size(760, 555);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.grpCajero);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvCajeros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración de cajeros";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajeros)).EndInit();
            this.grpCajero.ResumeLayout(false);
            this.grpCajero.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpCajero;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.ComboBox cboTurno;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvCajeros;
    }
}
