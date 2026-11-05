using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaProductos
{
    public partial class FrmUsuarios : Form
    {
        private int idSeleccionado = 0;

        public FrmUsuarios()
        {
            InitializeComponent();
            cboTurno.Items.AddRange(new object[] { "Mañana", "Tarde", "Noche" });
            CargarTabla();
        }

        private void CargarTabla()
        {
            try
            {
                dgvCajeros.DataSource = MetodosUsuarios.ListarCajeros();
                dgvCajeros.Columns["id_usuario"].Visible = false;
                dgvCajeros.Columns["Clave"].Visible = false;
                dgvCajeros.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cajeros: " + ex.Message, "Error");
            }
        }

        private void LimpiarCampos()
        {
            idSeleccionado = 0;
            txtCedula.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtUsuario.Clear();
            txtClave.Clear();
            cboTurno.SelectedIndex = -1;
            dgvCajeros.ClearSelection();
            txtCedula.Focus();
        }

        private UsuarioSistema LeerFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text) || string.IsNullOrWhiteSpace(txtNombres.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text) || string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Cédula, nombres, apellidos, usuario y contraseña son obligatorios.", "Aviso");
                return null;
            }
            if (cboTurno.SelectedIndex < 0)
            {
                MessageBox.Show("Selecciona el turno del cajero.", "Aviso");
                return null;
            }

            return new UsuarioSistema
            {
                Id = idSeleccionado,
                Cedula = txtCedula.Text.Trim(),
                Nombres = txtNombres.Text.Trim(),
                Apellidos = txtApellidos.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Usuario = txtUsuario.Text.Trim(),
                Clave = txtClave.Text,
                Turno = cboTurno.SelectedItem.ToString()
            };
        }

        private static bool EsUsuarioDuplicado(SqlException ex)
        {
            return ex.Number == 2627 || ex.Number == 2601;
        }

        private void dgvCajeros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataRowView fila = dgvCajeros.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (fila == null) return;

            idSeleccionado = Convert.ToInt32(fila["id_usuario"]);
            txtCedula.Text = fila["Cedula"].ToString();
            txtNombres.Text = fila["Nombres"].ToString();
            txtApellidos.Text = fila["Apellidos"].ToString();
            txtTelefono.Text = fila["Telefono"].ToString();
            txtEmail.Text = fila["Email"].ToString();
            txtUsuario.Text = fila["Usuario"].ToString();
            txtClave.Text = fila["Clave"].ToString();
            cboTurno.SelectedItem = fila["Turno"].ToString();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            UsuarioSistema cajero = LeerFormulario();
            if (cajero == null) return;

            try
            {
                MetodosUsuarios.InsertarCajero(cajero);
                MessageBox.Show("Cajero creado.", "Listo");
                CargarTabla();
                LimpiarCampos();
            }
            catch (SqlException ex)
            {
                if (EsUsuarioDuplicado(ex))
                    MessageBox.Show("Ya existe un usuario con ese nombre de usuario.", "Aviso");
                else
                    MessageBox.Show("Error al crear el cajero: " + ex.Message, "Error");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un cajero de la tabla.", "Aviso");
                return;
            }
            UsuarioSistema cajero = LeerFormulario();
            if (cajero == null) return;

            try
            {
                if (MetodosUsuarios.ActualizarCajero(cajero))
                {
                    MessageBox.Show("Cajero actualizado.", "Listo");
                    CargarTabla();
                    LimpiarCampos();
                }
            }
            catch (SqlException ex)
            {
                if (EsUsuarioDuplicado(ex))
                    MessageBox.Show("Ya existe un usuario con ese nombre de usuario.", "Aviso");
                else
                    MessageBox.Show("Error al actualizar: " + ex.Message, "Error");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un cajero de la tabla.", "Aviso");
                return;
            }
            DialogResult respuesta = MessageBox.Show("¿Eliminar al cajero " + txtNombres.Text + " " + txtApellidos.Text + "?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) return;

            try
            {
                MetodosUsuarios.EliminarCajero(idSeleccionado);
                CargarTabla();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
