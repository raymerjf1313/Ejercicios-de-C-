namespace SistemaProductos
{
    partial class FrmMenu
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
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnCajeros = new System.Windows.Forms.Button();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Location = new System.Drawing.Point(0, 10);
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Size = new System.Drawing.Size(380, 32);
            this.lblTitulo.Text = "MENÚ PRINCIPAL";
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 32, 128);
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblBienvenida
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Location = new System.Drawing.Point(0, 48);
            this.lblBienvenida.AutoSize = false;
            this.lblBienvenida.Size = new System.Drawing.Size(380, 22);
            this.lblBienvenida.Text = "";
            this.lblBienvenida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);
            this.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnProductos
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Location = new System.Drawing.Point(40, 90);
            this.btnProductos.Size = new System.Drawing.Size(300, 50);
            this.btnProductos.Text = "Productos";
            this.btnProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnProductos.BackColor = System.Drawing.Color.FromArgb(155, 183, 213);
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.TabIndex = 0;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);

            // btnCajeros
            this.btnCajeros.Name = "btnCajeros";
            this.btnCajeros.Location = new System.Drawing.Point(40, 150);
            this.btnCajeros.Size = new System.Drawing.Size(300, 50);
            this.btnCajeros.Text = "Cajeros";
            this.btnCajeros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCajeros.BackColor = System.Drawing.Color.FromArgb(155, 183, 213);
            this.btnCajeros.UseVisualStyleBackColor = false;
            this.btnCajeros.TabIndex = 1;
            this.btnCajeros.Click += new System.EventHandler(this.btnCajeros_Click);

            // btnFacturar
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Location = new System.Drawing.Point(40, 210);
            this.btnFacturar.Size = new System.Drawing.Size(300, 50);
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnFacturar.BackColor = System.Drawing.Color.FromArgb(155, 183, 213);
            this.btnFacturar.UseVisualStyleBackColor = false;
            this.btnFacturar.TabIndex = 2;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);

            // btnReportes
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Location = new System.Drawing.Point(40, 270);
            this.btnReportes.Size = new System.Drawing.Size(300, 50);
            this.btnReportes.Text = "Reportes";
            this.btnReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnReportes.BackColor = System.Drawing.Color.FromArgb(155, 183, 213);
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.TabIndex = 3;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);

            // btnCerrarSesion
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Location = new System.Drawing.Point(40, 345);
            this.btnCerrarSesion.Size = new System.Drawing.Size(300, 45);
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.TabIndex = 4;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);

            // FrmMenu
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(232, 240, 250);
            this.ClientSize = new System.Drawing.Size(380, 420);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.btnProductos);
            this.Controls.Add(this.btnCajeros);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.btnReportes);
            this.Controls.Add(this.btnCerrarSesion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú principal";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnCajeros;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}
