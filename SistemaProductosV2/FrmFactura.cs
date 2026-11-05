using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaProductos
{
    public partial class FrmFactura : Form
    {
        private List<DetalleFactura> detalles = new List<DetalleFactura>();
        private Factura facturaGuardada = null;
        private string[] lineasImpresion;
        private int lineaActual;

        public FrmFactura()
        {
            InitializeComponent();
            ConfigurarTabla();

            UsuarioSistema u = Sesion.Actual;
            if (u != null)
                lblCajero.Text = "Cajero: " + u.NombreCompleto +
                    (string.IsNullOrEmpty(u.Turno) ? " (Administrador)" : " (Turno " + u.Turno + ")");

            NuevaFactura();
        }

        private void ConfigurarTabla()
        {
            dgvDetalle.Columns.Add("codigo", "ID");
            dgvDetalle.Columns.Add("producto", "Producto");
            dgvDetalle.Columns.Add("precio", "Precio");
            dgvDetalle.Columns.Add("cantidad", "Cantidad");
            dgvDetalle.Columns.Add("valor", "Valor");
            dgvDetalle.Columns.Add("itbis", "ITBIS");
            for (int i = 2; i <= 5; i++)
                dgvDetalle.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void CargarClientes()
        {
            try
            {
                cboCliente.DataSource = MetodosClientes.ListarParaCombo();
                cboCliente.DisplayMember = "nombre";
                cboCliente.ValueMember = "id_cliente";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error");
            }
        }

        private void CargarProductos()
        {
            try
            {
                cboProducto.DataSource = MetodosFacturas.ObtenerProductosConStock();
                cboProducto.DisplayMember = "NOMBRE";
                cboProducto.ValueMember = "CODIGO";
                ActualizarInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error");
            }
        }

        private int IdClienteSeleccionado()
        {
            DataRowView fila = cboCliente.SelectedItem as DataRowView;
            return fila == null ? 0 : Convert.ToInt32(fila["id_cliente"]);
        }

        private void ActualizarInfo()
        {
            DataRowView fila = cboProducto.SelectedItem as DataRowView;
            if (fila == null)
            {
                lblInfo.Text = "";
                return;
            }
            lblInfo.Text = "Precio (sin ITBIS): " + Convert.ToDecimal(fila["PRECIO"]).ToString("N2") +
                           "   |   Stock disponible: " + fila["STOCK"];
        }

        private void RefrescarTabla()
        {
            dgvDetalle.Rows.Clear();
            foreach (DetalleFactura d in detalles)
                dgvDetalle.Rows.Add(d.Codigo, d.Nombre, d.Precio.ToString("N2"), d.Cantidad,
                                    d.Valor.ToString("N2"), d.Itbis.ToString("N2"));

            decimal bruto = detalles.Sum(d => d.Valor);
            decimal itbis = detalles.Sum(d => d.Itbis);
            lblBruto.Text = "Total bruto: " + bruto.ToString("N2");
            lblItbis.Text = "Total ITBIS (" + (Factura.TasaItbis * 100).ToString("0") + "%): " + itbis.ToString("N2");
            lblTotal.Text = "TOTAL A PAGAR: " + (bruto + itbis).ToString("N2");
        }

        private void BloquearEdicion(bool facturaYaGuardada)
        {
            cboCliente.Enabled = !facturaYaGuardada;
            btnNuevoCliente.Enabled = !facturaYaGuardada;
            rbContado.Enabled = !facturaYaGuardada;
            rbCredito.Enabled = !facturaYaGuardada;
            grpProducto.Enabled = !facturaYaGuardada;
            btnQuitar.Enabled = !facturaYaGuardada;
            btnFacturar.Enabled = !facturaYaGuardada;
        }

        private void NuevaFactura()
        {
            detalles.Clear();
            facturaGuardada = null;
            numCantidad.Value = 1;
            rbContado.Checked = true;
            lblFecha.Text = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            CargarClientes();
            CargarProductos();
            RefrescarTabla();
            BloquearEdicion(false);
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarInfo();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            using (FrmCliente formulario = new FrmCliente())
            {
                if (formulario.ShowDialog() == DialogResult.OK)
                {
                    CargarClientes();
                    cboCliente.SelectedValue = formulario.IdCreado;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataRowView fila = cboProducto.SelectedItem as DataRowView;
            if (fila == null)
            {
                MessageBox.Show("No hay productos con stock disponible.", "Aviso");
                return;
            }

            int codigo = Convert.ToInt32(fila["CODIGO"]);
            string nombre = fila["NOMBRE"].ToString();
            decimal precio = Convert.ToDecimal(fila["PRECIO"]);
            int stock = Convert.ToInt32(fila["STOCK"]);
            int cantidad = (int)numCantidad.Value;

            DetalleFactura existente = detalles.FirstOrDefault(d => d.Codigo == codigo);
            int yaAgregado = existente == null ? 0 : existente.Cantidad;

            if (yaAgregado + cantidad > stock)
            {
                MessageBox.Show("Stock insuficiente. Disponible: " + stock + ", ya en la factura: " + yaAgregado + ".", "Aviso");
                return;
            }

            if (existente != null)
                existente.Cantidad += cantidad;
            else
                detalles.Add(new DetalleFactura { Codigo = codigo, Nombre = nombre, Precio = precio, Cantidad = cantidad });

            numCantidad.Value = 1;
            RefrescarTabla();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow == null) return;
            detalles.RemoveAt(dgvDetalle.CurrentRow.Index);
            RefrescarTabla();
        }

        // Cobra (contado) o registra la cuenta por cobrar (crédito), guarda la factura y ofrece imprimirla.
        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (detalles.Count == 0)
            {
                MessageBox.Show("Agrega al menos un producto a la factura.", "Aviso");
                return;
            }

            int idCliente = IdClienteSeleccionado();
            bool esCredito = rbCredito.Checked;
            if (esCredito && idCliente == 0)
            {
                MessageBox.Show("Selecciona un cliente para vender a crédito.", "Aviso");
                return;
            }

            DataRowView filaCliente = (DataRowView)cboCliente.SelectedItem;
            Factura factura = new Factura
            {
                Tipo = esCredito ? "Credito" : "Contado",
                IdCliente = idCliente == 0 ? (int?)null : idCliente,
                NombreCliente = filaCliente["nombre"].ToString(),
                UsuarioCajero = Sesion.Actual.Usuario,
                NombreCajero = Sesion.Actual.NombreCompleto,
                Turno = Sesion.Actual.Turno,
                Detalles = new List<DetalleFactura>(detalles)
            };
            factura.Calcular();

            if (esCredito)
            {
                DialogResult confirmar = MessageBox.Show(
                    "Venta a crédito para " + factura.NombreCliente + " por " + factura.Total.ToString("N2") +
                    ".\nSe registrará en cuentas por cobrar. ¿Continuar?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmar != DialogResult.Yes) return;
            }
            else
            {
                using (FrmPago pago = new FrmPago { TotalAPagar = factura.Total })
                {
                    if (pago.ShowDialog() != DialogResult.OK) return;
                    factura.MontoPagado = pago.MontoPagado;
                    factura.Devuelta = pago.Devuelta;
                }
            }

            try
            {
                MetodosFacturas.Guardar(factura);
                facturaGuardada = factura;
                BloquearEdicion(true);

                string resumen = "Factura No. " + factura.Numero + " guardada.\nTotal a pagar: " + factura.Total.ToString("N2");
                if (esCredito)
                    resumen += "\nRegistrada en cuentas por cobrar.";
                else
                    resumen += "\nMonto pagado: " + factura.MontoPagado.ToString("N2") +
                               "\nDevuelta: " + factura.Devuelta.ToString("N2");
                resumen += "\n\n¿Imprimir la factura ahora?";

                if (MessageBox.Show(resumen, "Listo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    Imprimir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la factura: " + ex.Message, "Error");
                CargarProductos(); // por si el stock cambió
            }
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            NuevaFactura();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmFactura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Imprimir();
                e.Handled = true;
            }
        }

        // F5: guarda la factura en .txt o .pdf según lo que elijas en el cuadro de diálogo.
        private void Imprimir()
        {
            if (facturaGuardada == null)
            {
                MessageBox.Show("Primero factura la venta para poder imprimirla.", "Aviso");
                return;
            }

            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Filter = "Archivo de texto (*.txt)|*.txt|Documento PDF (*.pdf)|*.pdf";
                dialogo.FileName = "Factura_" + facturaGuardada.Numero;
                if (dialogo.ShowDialog() != DialogResult.OK) return;

                string texto = facturaGuardada.GenerarTexto();
                try
                {
                    if (Path.GetExtension(dialogo.FileName).ToLower() == ".pdf")
                        GuardarPdf(texto, dialogo.FileName);
                    else
                        File.WriteAllText(dialogo.FileName, texto, Encoding.UTF8);

                    MessageBox.Show("Factura guardada en:\n" + dialogo.FileName, "Listo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el archivo: " + ex.Message, "Error");
                }
            }
        }

        // Genera el PDF con la impresora virtual "Microsoft Print to PDF" de Windows 10/11.
        private void GuardarPdf(string texto, string ruta)
        {
            lineasImpresion = texto.Replace("\r\n", "\n").Split('\n');
            lineaActual = 0;

            using (PrintDocument documento = new PrintDocument())
            {
                documento.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                if (!documento.PrinterSettings.IsValid)
                    throw new InvalidOperationException("Esta PC no tiene la impresora 'Microsoft Print to PDF'. Guarda la factura como .txt.");

                documento.PrinterSettings.PrintToFile = true;
                documento.PrinterSettings.PrintFileName = ruta;
                documento.PrintPage += ImprimirPagina;
                documento.Print();
            }
        }

        private void ImprimirPagina(object sender, PrintPageEventArgs e)
        {
            using (Font fuente = new Font("Courier New", 9))
            {
                float alto = fuente.GetHeight(e.Graphics);
                float y = e.MarginBounds.Top;

                while (lineaActual < lineasImpresion.Length && y + alto <= e.MarginBounds.Bottom)
                {
                    e.Graphics.DrawString(lineasImpresion[lineaActual], fuente, Brushes.Black, e.MarginBounds.Left, y);
                    y += alto;
                    lineaActual++;
                }
                e.HasMorePages = lineaActual < lineasImpresion.Length;
            }
        }
    }
}
