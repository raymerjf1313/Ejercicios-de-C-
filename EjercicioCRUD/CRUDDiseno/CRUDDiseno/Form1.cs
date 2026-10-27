using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CRUDDiseno
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")] private static extern bool ReleaseCapture();
        [DllImport("user32.dll")] private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        public Form1()
        {
            InitializeComponent();
        }
        CDatos datos = new CDatos();
        Persona persona = new Persona();
        private int id;
        private void CargarGrid()
        {
            var Lst = datos.Read();
            dgvEjemplo.DataSource = Lst;

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            CargarGrid();
            
        }
        private void CargarDatos() 
        {
        
            persona.Id = id;
            persona.Nombre = txtNombre.Text;
            persona.Apellido = txtApellido.Text;
            persona.Correo = txtCorreo.Text;
        
        }
        private void Limpiar()
        {
            id = 0;
            txtNombre.Focus();
            txtNombre.Text = string.Empty;
            txtApellido.Text = String.Empty;
            txtCorreo.Text = string.Empty;
            CargarGrid();

        }

        // Permite arrastrar la ventana desde la barra de título
        private void pnlTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xF012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();

        // Eventos vacíos, listos para que programes tu CRUD
        private void btnNuevo_Click(object sender, EventArgs e)
        {
         
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CargarDatos();
            datos.Create(persona);
            Limpiar();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                CargarDatos();
                datos.Update(persona);
                Limpiar();
            }
            else
            {

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                CargarDatos();
                datos.Delete(id);
                Limpiar();
            }
            else
            {

            }
        }

        private void Buscar_TextChanged(object sender, EventArgs e)
        {
        }

        private void dgvEjemplo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvEjemplo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvEjemplo_DoubleClick(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dgvEjemplo.CurrentRow.Cells["Id"].Value.ToString());
            txtNombre.Text = dgvEjemplo.CurrentRow.Cells["Nombre"].Value.ToString();
            txtApellido.Text = dgvEjemplo.CurrentRow.Cells["Apellido"].Value.ToString();
            txtCorreo.Text = dgvEjemplo.CurrentRow.Cells["Correo"].Value.ToString();
        }
    }
}
