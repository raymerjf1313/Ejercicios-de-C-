namespace SistemaProductos
{
    partial class FrmRegistroProductos
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
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.grpDatos.SuspendLayout();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Location = new System.Drawing.Point(0, 10);
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Size = new System.Drawing.Size(524, 32);
            this.lblTitulo.Text = "REGISTRO DE PRODUCTOS";
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 32, 128);
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // grpDatos
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Location = new System.Drawing.Point(12, 55);
            this.grpDatos.Size = new System.Drawing.Size(500, 300);
            this.grpDatos.Text = "Datos de Producto";
            this.grpDatos.ForeColor = System.Drawing.Color.FromArgb(0, 70, 170);

            // lblCodigo
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Location = new System.Drawing.Point(25, 30);
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Text = "Código";
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // txtCodigo
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Location = new System.Drawing.Point(95, 27);
            this.txtCodigo.Size = new System.Drawing.Size(150, 20);
            this.txtCodigo.TabIndex = 0;

            // lblNombre
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Location = new System.Drawing.Point(25, 70);
            this.lblNombre.AutoSize = true;
            this.lblNombre.Text = "Nombre";
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // txtNombre
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Location = new System.Drawing.Point(95, 67);
            this.txtNombre.Size = new System.Drawing.Size(150, 20);
            this.txtNombre.TabIndex = 1;

            // lblPrecio
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Location = new System.Drawing.Point(25, 111);
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Text = "Precio";
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrecio.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // txtPrecio
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Location = new System.Drawing.Point(95, 108);
            this.txtPrecio.Size = new System.Drawing.Size(150, 20);
            this.txtPrecio.TabIndex = 2;

            // lblStock
            this.lblStock.Name = "lblStock";
            this.lblStock.Location = new System.Drawing.Point(25, 152);
            this.lblStock.AutoSize = true;
            this.lblStock.Text = "Stock";
            this.lblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblStock.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // txtStock
            this.txtStock.Name = "txtStock";
            this.txtStock.Location = new System.Drawing.Point(95, 149);
            this.txtStock.Size = new System.Drawing.Size(150, 20);
            this.txtStock.TabIndex = 3;

            // lblMarca
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Location = new System.Drawing.Point(25, 193);
            this.lblMarca.AutoSize = true;
            this.lblMarca.Text = "Marca";
            this.lblMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblMarca.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // txtMarca
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Location = new System.Drawing.Point(95, 190);
            this.txtMarca.Size = new System.Drawing.Size(150, 20);
            this.txtMarca.TabIndex = 4;

            // btnNuevo
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Location = new System.Drawing.Point(310, 27);
            this.btnNuevo.Size = new System.Drawing.Size(150, 33);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(155, 183, 213);
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.TabIndex = 5;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            // btnActualizar
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Location = new System.Drawing.Point(310, 70);
            this.btnActualizar.Size = new System.Drawing.Size(150, 33);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(155, 183, 213);
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.TabIndex = 6;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            // btnInsertar
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Location = new System.Drawing.Point(310, 113);
            this.btnInsertar.Size = new System.Drawing.Size(150, 33);
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnInsertar.BackColor = System.Drawing.Color.FromArgb(155, 183, 213);
            this.btnInsertar.UseVisualStyleBackColor = false;
            this.btnInsertar.TabIndex = 7;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);

            // btnEliminar
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Location = new System.Drawing.Point(310, 156);
            this.btnEliminar.Size = new System.Drawing.Size(150, 33);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(155, 183, 213);
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // btnSalir
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Location = new System.Drawing.Point(310, 199);
            this.btnSalir.Size = new System.Drawing.Size(150, 33);
            this.btnSalir.Text = "SALIR";
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(155, 183, 213);
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);

            // btnBuscar
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Location = new System.Drawing.Point(75, 245);
            this.btnBuscar.Size = new System.Drawing.Size(125, 40);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(40, 60, 110);
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            this.grpDatos.Controls.Add(this.lblCodigo);
            this.grpDatos.Controls.Add(this.txtCodigo);
            this.grpDatos.Controls.Add(this.lblNombre);
            this.grpDatos.Controls.Add(this.txtNombre);
            this.grpDatos.Controls.Add(this.lblPrecio);
            this.grpDatos.Controls.Add(this.txtPrecio);
            this.grpDatos.Controls.Add(this.lblStock);
            this.grpDatos.Controls.Add(this.txtStock);
            this.grpDatos.Controls.Add(this.lblMarca);
            this.grpDatos.Controls.Add(this.txtMarca);
            this.grpDatos.Controls.Add(this.btnNuevo);
            this.grpDatos.Controls.Add(this.btnActualizar);
            this.grpDatos.Controls.Add(this.btnInsertar);
            this.grpDatos.Controls.Add(this.btnEliminar);
            this.grpDatos.Controls.Add(this.btnSalir);
            this.grpDatos.Controls.Add(this.btnBuscar);

            // FrmRegistroProductos
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(232, 240, 250);
            this.ClientSize = new System.Drawing.Size(524, 372);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.grpDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmRegistroProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Productos";
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnBuscar;
    }
}
