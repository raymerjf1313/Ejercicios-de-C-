namespace SistemaProductos
{
    partial class FrmPago
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
            this.lblT = new System.Windows.Forms.Label();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.lblM = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblD = new System.Windows.Forms.Label();
            this.lblDevuelta = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Location = new System.Drawing.Point(0, 10);
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Size = new System.Drawing.Size(360, 32);
            this.lblTitulo.Text = "COBRO";
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 32, 128);
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblT
            this.lblT.Name = "lblT";
            this.lblT.Location = new System.Drawing.Point(20, 62);
            this.lblT.AutoSize = true;
            this.lblT.Text = "Total a pagar";
            this.lblT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblT.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // lblTotalPagar
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Location = new System.Drawing.Point(170, 56);
            this.lblTotalPagar.AutoSize = false;
            this.lblTotalPagar.Size = new System.Drawing.Size(170, 28);
            this.lblTotalPagar.Text = "0.00";
            this.lblTotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalPagar.ForeColor = System.Drawing.Color.FromArgb(0, 32, 128);
            this.lblTotalPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // lblM
            this.lblM.Name = "lblM";
            this.lblM.Location = new System.Drawing.Point(20, 112);
            this.lblM.AutoSize = true;
            this.lblM.Text = "Monto pagado";
            this.lblM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblM.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // txtMonto
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Location = new System.Drawing.Point(170, 108);
            this.txtMonto.Size = new System.Drawing.Size(170, 23);
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            this.txtMonto.TabIndex = 0;
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonto.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);

            // lblD
            this.lblD.Name = "lblD";
            this.lblD.Location = new System.Drawing.Point(20, 162);
            this.lblD.AutoSize = true;
            this.lblD.Text = "Devuelta";
            this.lblD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblD.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // lblDevuelta
            this.lblDevuelta.Name = "lblDevuelta";
            this.lblDevuelta.Location = new System.Drawing.Point(170, 156);
            this.lblDevuelta.AutoSize = false;
            this.lblDevuelta.Size = new System.Drawing.Size(170, 28);
            this.lblDevuelta.Text = "0.00";
            this.lblDevuelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblDevuelta.ForeColor = System.Drawing.Color.FromArgb(0, 100, 0);
            this.lblDevuelta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // btnAceptar
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Location = new System.Drawing.Point(40, 208);
            this.btnAceptar.Size = new System.Drawing.Size(130, 36);
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(155, 183, 213);
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);

            // btnCancelar
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Location = new System.Drawing.Point(190, 208);
            this.btnCancelar.Size = new System.Drawing.Size(130, 36);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            // FrmPago
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(232, 240, 250);
            this.ClientSize = new System.Drawing.Size(360, 260);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblT);
            this.Controls.Add(this.lblTotalPagar);
            this.Controls.Add(this.lblM);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.lblD);
            this.Controls.Add(this.lblDevuelta);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cobro";
            this.AcceptButton = this.btnAceptar;
            this.CancelButton = this.btnCancelar;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblT;
        private System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.Label lblM;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label lblD;
        private System.Windows.Forms.Label lblDevuelta;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
