using System;
using System.Windows.Forms;

namespace SistemaProductos
{
    public partial class FrmRegistroProductos : Form
    {
        public FrmRegistroProductos()
        {
            InitializeComponent();
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtMarca.Clear();
        }

        // Lee y valida los campos del formulario. Devuelve null si algo está mal.
        private Producto LeerFormulario(bool pedirCodigo)
        {
            Producto producto = new Producto();

            if (pedirCodigo)
            {
                if (!int.TryParse(txtCodigo.Text, out int codigo))
                {
                    MessageBox.Show("Ingresa un código válido.", "Aviso");
                    txtCodigo.Focus();
                    return null;
                }
                producto.Codigo = codigo;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                MessageBox.Show("Nombre y Marca son obligatorios.", "Aviso");
                return null;
            }
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio < 0)
            {
                MessageBox.Show("Precio inválido.", "Aviso");
                txtPrecio.Focus();
                return null;
            }
            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("Stock inválido.", "Aviso");
                txtStock.Focus();
                return null;
            }

            producto.Nombre = txtNombre.Text.Trim();
            producto.Precio = precio;
            producto.Stock = stock;
            producto.Marca = txtMarca.Text.Trim();
            return producto;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtNombre.Focus();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            // El código lo genera la base de datos (IDENTITY), por eso no se valida aquí.
            Producto producto = LeerFormulario(false);
            if (producto == null) return;

            try
            {
                int nuevoCodigo = MetodosProductos.Insertar(producto);
                MessageBox.Show("Producto registrado con código " + nuevoCodigo + ".", "Listo");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar: " + ex.Message, "Error");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Producto producto = LeerFormulario(true);
            if (producto == null) return;

            try
            {
                if (MetodosProductos.Actualizar(producto))
                    MessageBox.Show("Producto actualizado.", "Listo");
                else
                    MessageBox.Show("No existe un producto con ese código.", "Aviso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCodigo.Text, out int codigo))
            {
                MessageBox.Show("Ingresa el código del producto a eliminar.", "Aviso");
                txtCodigo.Focus();
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Eliminar el producto " + codigo + "?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) return;

            try
            {
                if (MetodosProductos.Eliminar(codigo))
                {
                    MessageBox.Show("Producto eliminado.", "Listo");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No existe un producto con ese código.", "Aviso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCodigo.Text, out int codigo))
            {
                MessageBox.Show("Escribe el código a buscar.", "Aviso");
                txtCodigo.Focus();
                return;
            }

            try
            {
                Producto producto = MetodosProductos.Buscar(codigo);
                if (producto == null)
                {
                    MessageBox.Show("No existe un producto con ese código.", "Aviso");
                    return;
                }
                txtNombre.Text = producto.Nombre;
                txtPrecio.Text = producto.Precio.ToString();
                txtStock.Text = producto.Stock.ToString();
                txtMarca.Text = producto.Marca;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message, "Error");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
