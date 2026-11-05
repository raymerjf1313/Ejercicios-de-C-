namespace SistemaProductos
{
    partial class FrmFactura
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
            this.lblCajero = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.btnNuevoCliente = new System.Windows.Forms.Button();
            this.rbContado = new System.Windows.Forms.RadioButton();
            this.rbCredito = new System.Windows.Forms.RadioButton();
            this.grpProducto = new System.Windows.Forms.GroupBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.cboProducto = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.lblBruto = new System.Windows.Forms.Label();
            this.lblItbis = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnNueva = new System.Windows.Forms.Button();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.grpProducto.SuspendLayout();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Location = new System.Drawing.Point(0, 10);
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Size = new System.Drawing.Size(760, 32);
            this.lblTitulo.Text = "FACTURA DE VENTA";
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 32, 128);
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblCajero
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Location = new System.Drawing.Point(20, 52);
            this.lblCajero.AutoSize = true;
            this.lblCajero.Text = "Cajero:";
            this.lblCajero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCajero.ForeColor = System.Drawing.Color.FromArgb(0, 32, 128);

            // lblFecha
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Location = new System.Drawing.Point(500, 52);
            this.lblFecha.AutoSize = true;
            this.lblFecha.Text = "Fecha:";
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(0, 32, 128);

            // lblCliente
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Location = new System.Drawing.Point(20, 90);
            this.lblCliente.AutoSize = true;
            this.lblCliente.Text = "Cliente";
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // cboCliente
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Location = new System.Drawing.Point(80, 87);
            this.cboCliente.Size = new System.Drawing.Size(290, 21);
            this.cboCliente.TabIndex = 0;
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // btnNuevoCliente
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Location = new System.Drawing.Point(380, 84);
            this.btnNuevoCliente.Size = new System.Drawing.Size(110, 26);
            this.btnNuevoCliente.Text = "Nuevo cliente";
            this.btnNuevoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevoCliente.BackColor = System.Drawing.Color.FromArgb(155, 183, 213);
            this.btnNuevoCliente.UseVisualStyleBackColor = false;
            this.btnNuevoCliente.TabIndex = 1;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);

            // rbContado
            this.rbContado.Name = "rbContado";
            this.rbContado.Location = new System.Drawing.Point(520, 88);
            this.rbContado.AutoSize = true;
            this.rbContado.Text = "Contado";
            this.rbContado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.rbContado.TabIndex = 2;
            this.rbContado.Checked = true;

            // rbCredito
            this.rbCredito.Name = "rbCredito";
            this.rbCredito.Location = new System.Drawing.Point(620, 88);
            this.rbCredito.AutoSize = true;
            this.rbCredito.Text = "Crédito";
            this.rbCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.rbCredito.TabIndex = 3;

            // grpProducto
            this.grpProducto.Name = "grpProducto";
            this.grpProducto.Location = new System.Drawing.Point(20, 118);
            this.grpProducto.Size = new System.Drawing.Size(720, 82);
            this.grpProducto.Text = "Agregar producto";
            this.grpProducto.ForeColor = System.Drawing.Color.FromArgb(0, 70, 170);

            // lblProducto
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Location = new System.Drawing.Point(15, 30);
            this.lblProducto.AutoSize = true;
            this.lblProducto.Text = "Producto";
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblProducto.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // cboProducto
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Location = new System.Drawing.Point(75, 27);
            this.cboProducto.Size = new System.Drawing.Size(300, 21);
            this.cboProducto.TabIndex = 4;
            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.SelectedIndexChanged += new System.EventHandler(this.cboProducto_SelectedIndexChanged);

            // lblCantidad
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Location = new System.Drawing.Point(390, 30);
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Text = "Cantidad";
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // numCantidad
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Location = new System.Drawing.Point(450, 27);
            this.numCantidad.Size = new System.Drawing.Size(65, 20);
            this.numCantidad.TabIndex = 5;
            this.numCantidad.Minimum = 1;
            this.numCantidad.Maximum = 9999;
            this.numCantidad.Value = 1;

            // btnAgregar
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Location = new System.Drawing.Point(535, 22);
            this.btnAgregar.Size = new System.Drawing.Size(160, 30);
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(155, 183, 213);
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            // lblInfo
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Location = new System.Drawing.Point(75, 57);
            this.lblInfo.AutoSize = true;
            this.lblInfo.Text = "";
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(105, 105, 105);

            // dgvDetalle
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Location = new System.Drawing.Point(20, 210);
            this.dgvDetalle.Size = new System.Drawing.Size(720, 195);
            this.dgvDetalle.TabIndex = 7;
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;

            // btnQuitar
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Location = new System.Drawing.Point(20, 415);
            this.btnQuitar.Size = new System.Drawing.Size(160, 30);
            this.btnQuitar.Text = "Quitar seleccionado";
            this.btnQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuitar.BackColor = System.Drawing.Color.FromArgb(155, 183, 213);
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.TabIndex = 8;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);

            // lblBruto
            this.lblBruto.Name = "lblBruto";
            this.lblBruto.Location = new System.Drawing.Point(400, 410);
            this.lblBruto.AutoSize = false;
            this.lblBruto.Size = new System.Drawing.Size(340, 22);
            this.lblBruto.Text = "Total bruto: 0.00";
            this.lblBruto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblBruto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // lblItbis
            this.lblItbis.Name = "lblItbis";
            this.lblItbis.Location = new System.Drawing.Point(400, 432);
            this.lblItbis.AutoSize = false;
            this.lblItbis.Size = new System.Drawing.Size(340, 22);
            this.lblItbis.Text = "Total ITBIS (18%): 0.00";
            this.lblItbis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblItbis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // lblTotal
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Location = new System.Drawing.Point(400, 454);
            this.lblTotal.AutoSize = false;
            this.lblTotal.Size = new System.Drawing.Size(340, 30);
            this.lblTotal.Text = "TOTAL A PAGAR: 0.00";
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(0, 32, 128);
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // btnNueva
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Location = new System.Drawing.Point(20, 505);
            this.btnNueva.Size = new System.Drawing.Size(150, 40);
            this.btnNueva.Text = "Nueva factura";
            this.btnNueva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnNueva.BackColor = System.Drawing.Color.FromArgb(155, 183, 213);
            this.btnNueva.UseVisualStyleBackColor = false;
            this.btnNueva.TabIndex = 9;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);

            // btnFacturar
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Location = new System.Drawing.Point(180, 505);
            this.btnFacturar.Size = new System.Drawing.Size(190, 40);
            this.btnFacturar.Text = "Facturar / Cobrar";
            this.btnFacturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnFacturar.BackColor = System.Drawing.Color.FromArgb(155, 183, 213);
            this.btnFacturar.UseVisualStyleBackColor = false;
            this.btnFacturar.TabIndex = 10;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);

            // btnImprimir
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Location = new System.Drawing.Point(380, 505);
            this.btnImprimir.Size = new System.Drawing.Size(190, 40);
            this.btnImprimir.Text = "Imprimir (F5)";
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(155, 183, 213);
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.TabIndex = 11;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);

            // btnCerrar
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Location = new System.Drawing.Point(580, 505);
            this.btnCerrar.Size = new System.Drawing.Size(160, 40);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.TabIndex = 12;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            this.grpProducto.Controls.Add(this.lblProducto);
            this.grpProducto.Controls.Add(this.cboProducto);
            this.grpProducto.Controls.Add(this.lblCantidad);
            this.grpProducto.Controls.Add(this.numCantidad);
            this.grpProducto.Controls.Add(this.btnAgregar);
            this.grpProducto.Controls.Add(this.lblInfo);

            // FrmFactura
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(232, 240, 250);
            this.ClientSize = new System.Drawing.Size(760, 560);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblCajero);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.btnNuevoCliente);
            this.Controls.Add(this.rbContado);
            this.Controls.Add(this.rbCredito);
            this.Controls.Add(this.grpProducto);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.lblBruto);
            this.Controls.Add(this.lblItbis);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnNueva);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturación";
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmFactura_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.grpProducto.ResumeLayout(false);
            this.grpProducto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCajero;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Button btnNuevoCliente;
        private System.Windows.Forms.RadioButton rbContado;
        private System.Windows.Forms.RadioButton rbCredito;
        private System.Windows.Forms.GroupBox grpProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ComboBox cboProducto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Label lblBruto;
        private System.Windows.Forms.Label lblItbis;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCerrar;
    }
}
