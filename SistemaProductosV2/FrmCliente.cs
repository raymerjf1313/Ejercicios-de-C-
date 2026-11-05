using System;
using System.Windows.Forms;

namespace SistemaProductos
{
    public partial class FrmCliente : Form
    {
        public int IdCreado { get; private set; }

        public FrmCliente()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del cliente es obligatorio.", "Aviso");
                txtNombre.Focus();
                return;
            }

            try
            {
                IdCreado = MetodosClientes.Insertar(txtNombre.Text.Trim(), txtDocumento.Text, txtTelefono.Text);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el cliente: " + ex.Message, "Error");
            }
        }
    }
}
