using System;
using System.Windows.Forms;

namespace SistemaProductos
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();

            UsuarioSistema u = Sesion.Actual;
            if (u == null) return;

            lblBienvenida.Text = u.NombreCompleto + " - " +
                (u.EsAdministrador ? "Administrador" : "Cajero, turno " + u.Turno);

            // El cajero solo puede facturar; el administrador accede a todo.
            btnProductos.Enabled = u.EsAdministrador;
            btnCajeros.Enabled = u.EsAdministrador;
            btnReportes.Enabled = u.EsAdministrador;
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            using (FrmRegistroProductos formulario = new FrmRegistroProductos())
                formulario.ShowDialog();
        }

        private void btnCajeros_Click(object sender, EventArgs e)
        {
            using (FrmUsuarios formulario = new FrmUsuarios())
                formulario.ShowDialog();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            using (FrmFactura formulario = new FrmFactura())
                formulario.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            using (FrmReportes formulario = new FrmReportes())
                formulario.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
