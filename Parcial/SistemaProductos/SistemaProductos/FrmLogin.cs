using System;
using System.Windows.Forms;

namespace SistemaProductos
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrEmpty(txtContrasena.Text))
            {
                MessageBox.Show("Ingresa usuario y contraseña.", "Aviso");
                return;
            }

            try
            {
                UsuarioSistema usuario = MetodosUsuarios.ValidarLogin(txtUsuario.Text.Trim(), txtContrasena.Text);

                if (usuario == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso denegado",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContrasena.Clear();
                    txtContrasena.Focus();
                    return;
                }

                Sesion.Actual = usuario;
                Hide();
                using (FrmMenu menu = new FrmMenu())
                {
                    menu.ShowDialog();
                }

                // Al cerrar sesión se vuelve al login.
                Sesion.Actual = null;
                txtUsuario.Clear();
                txtContrasena.Clear();
                Show();
                txtUsuario.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Error");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
