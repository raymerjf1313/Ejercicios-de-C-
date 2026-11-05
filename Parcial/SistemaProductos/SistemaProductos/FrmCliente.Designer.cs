namespace SistemaProductos
{
    partial class FrmCliente
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Location = new System.Drawing.Point(0, 10);
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Size = new System.Drawing.Size(380, 32);
            this.lblTitulo.Text = "NUEVO CLIENTE";
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 32, 128);
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblNombre
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Location = new System.Drawing.Point(20, 58);
            this.lblNombre.AutoSize = true;
            this.lblNombre.Text = "Nombre";
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // txtNombre
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Location = new System.Drawing.Point(120, 55);
            this.txtNombre.Size = new System.Drawing.Size(230, 20);
            this.txtNombre.TabIndex = 0;

            // lblDocumento
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Location = new System.Drawing.Point(20, 98);
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Text = "Cédula / RNC";
            this.lblDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblDocumento.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // txtDocumento
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Location = new System.Drawing.Point(120, 95);
            this.txtDocumento.Size = new System.Drawing.Size(230, 20);
            this.txtDocumento.TabIndex = 1;

            // lblTelefono
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Location = new System.Drawing.Point(20, 138);
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Text = "Teléfono";
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // txtTelefono
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Location = new System.Drawing.Point(120, 135);
            this.txtTelefono.Size = new System.Drawing.Size(230, 20);
            this.txtTelefono.TabIndex = 2;

            // btnGuardar
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Location = new System.Drawing.Point(60, 178);
            this.btnGuardar.Size = new System.Drawing.Size(120, 34);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(155, 183, 213);
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // btnCancelar
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Location = new System.Drawing.Point(200, 178);
            this.btnCancelar.Size = new System.Drawing.Size(120, 34);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            // FrmCliente
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(232, 240, 250);
            this.ClientSize = new System.Drawing.Size(380, 230);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblDocumento);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo cliente";
            this.AcceptButton = this.btnGuardar;
            this.CancelButton = this.btnCancelar;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
