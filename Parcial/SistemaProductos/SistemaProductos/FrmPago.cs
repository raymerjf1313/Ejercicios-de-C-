using System;
using System.Windows.Forms;

namespace SistemaProductos
{
    public partial class FrmPago : Form
    {
        private decimal totalAPagar;

        public decimal MontoPagado { get; private set; }
        public decimal Devuelta { get; private set; }

        // Se asigna al abrir el formulario: new FrmPago { TotalAPagar = total }
        public decimal TotalAPagar
        {
            get { return totalAPagar; }
            set
            {
                totalAPagar = value;
                lblTotalPagar.Text = value.ToString("N2");
                lblDevuelta.Text = "0.00";
            }
        }

        public FrmPago()
        {
            InitializeComponent();
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            decimal monto;
            if (decimal.TryParse(txtMonto.Text, out monto) && monto >= totalAPagar)
                lblDevuelta.Text = (monto - totalAPagar).ToString("N2");
            else
                lblDevuelta.Text = "0.00";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            decimal monto;
            if (!decimal.TryParse(txtMonto.Text, out monto))
            {
                MessageBox.Show("Ingresa el monto pagado.", "Aviso");
                txtMonto.Focus();
                return;
            }
            if (monto < totalAPagar)
            {
                MessageBox.Show("El monto pagado no cubre el total a pagar.", "Aviso");
                txtMonto.Focus();
                return;
            }

            MontoPagado = monto;
            Devuelta = monto - totalAPagar;
            DialogResult = DialogResult.OK;
        }
    }
}
