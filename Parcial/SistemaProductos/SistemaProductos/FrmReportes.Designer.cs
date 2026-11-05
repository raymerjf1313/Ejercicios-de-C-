namespace SistemaProductos
{
    partial class FrmReportes
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
            this.lblReporte = new System.Windows.Forms.Label();
            this.cboReporte = new System.Windows.Forms.ComboBox();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.lblResumen = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Location = new System.Drawing.Point(0, 10);
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Size = new System.Drawing.Size(880, 32);
            this.lblTitulo.Text = "REPORTES";
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 32, 128);
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblReporte
            this.lblReporte.Name = "lblReporte";
            this.lblReporte.Location = new System.Drawing.Point(20, 58);
            this.lblReporte.AutoSize = true;
            this.lblReporte.Text = "Reporte";
            this.lblReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblReporte.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // cboReporte
            this.cboReporte.Name = "cboReporte";
            this.cboReporte.Location = new System.Drawing.Point(85, 55);
            this.cboReporte.Size = new System.Drawing.Size(290, 21);
            this.cboReporte.TabIndex = 0;
            this.cboReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReporte.SelectedIndexChanged += new System.EventHandler(this.cboReporte_SelectedIndexChanged);

            // lblDesde
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Location = new System.Drawing.Point(20, 97);
            this.lblDesde.AutoSize = true;
            this.lblDesde.Text = "Fecha";
            this.lblDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // dtpDesde
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Location = new System.Drawing.Point(85, 93);
            this.dtpDesde.Size = new System.Drawing.Size(110, 20);
            this.dtpDesde.TabIndex = 1;
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // lblHasta
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Location = new System.Drawing.Point(215, 97);
            this.lblHasta.AutoSize = true;
            this.lblHasta.Text = "Hasta";
            this.lblHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblHasta.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // dtpHasta
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Location = new System.Drawing.Point(260, 93);
            this.dtpHasta.Size = new System.Drawing.Size(110, 20);
            this.dtpHasta.TabIndex = 2;
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // lblTipo
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Location = new System.Drawing.Point(390, 97);
            this.lblTipo.AutoSize = true;
            this.lblTipo.Text = "Tipo";
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // cboTipo
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Location = new System.Drawing.Point(430, 93);
            this.cboTipo.Size = new System.Drawing.Size(110, 21);
            this.cboTipo.TabIndex = 3;
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // btnGenerar
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Location = new System.Drawing.Point(570, 88);
            this.btnGenerar.Size = new System.Drawing.Size(150, 30);
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(155, 183, 213);
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.TabIndex = 4;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);

            // dgvReporte
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.Location = new System.Drawing.Point(20, 130);
            this.dgvReporte.Size = new System.Drawing.Size(840, 390);
            this.dgvReporte.TabIndex = 5;
            this.dgvReporte.ReadOnly = true;
            this.dgvReporte.AllowUserToAddRows = false;
            this.dgvReporte.AllowUserToDeleteRows = false;
            this.dgvReporte.MultiSelect = false;
            this.dgvReporte.RowHeadersVisible = false;
            this.dgvReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporte.BackgroundColor = System.Drawing.Color.White;

            // lblResumen
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Location = new System.Drawing.Point(20, 530);
            this.lblResumen.AutoSize = false;
            this.lblResumen.Size = new System.Drawing.Size(700, 22);
            this.lblResumen.Text = "";
            this.lblResumen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblResumen.ForeColor = System.Drawing.Color.FromArgb(0, 32, 128);
            this.lblResumen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // btnCerrar
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Location = new System.Drawing.Point(740, 540);
            this.btnCerrar.Size = new System.Drawing.Size(120, 32);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // FrmReportes
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(232, 240, 250);
            this.ClientSize = new System.Drawing.Size(880, 585);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblReporte);
            this.Controls.Add(this.cboReporte);
            this.Controls.Add(this.lblDesde);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.dgvReporte);
            this.Controls.Add(this.lblResumen);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblReporte;
        private System.Windows.Forms.ComboBox cboReporte;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.Button btnCerrar;
    }
}
