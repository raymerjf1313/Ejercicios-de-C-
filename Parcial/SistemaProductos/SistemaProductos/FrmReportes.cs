using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaProductos
{
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();
            cboReporte.Items.AddRange(new object[]
            {
                "Cuadre del día (por cajero)",
                "Inventario en stock",
                "Facturas de crédito o contado",
                "5 clientes con más ventas"
            });
            cboTipo.Items.AddRange(new object[] { "Todas", "Contado", "Crédito" });
            cboTipo.SelectedIndex = 0;
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
            cboReporte.SelectedIndex = 0;
        }

        // Muestra solo los filtros que usa cada reporte.
        private void cboReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            int r = cboReporte.SelectedIndex;
            bool usaFechas = r != 1;
            bool usaRango = r == 2 || r == 3;

            lblDesde.Visible = dtpDesde.Visible = usaFechas;
            lblDesde.Text = r == 0 ? "Fecha" : "Desde";
            lblHasta.Visible = dtpHasta.Visible = usaRango;
            lblTipo.Visible = cboTipo.Visible = r == 2;

            dgvReporte.DataSource = null;
            lblResumen.Text = "";
        }

        private static decimal Suma(DataTable tabla, string columna)
        {
            decimal total = 0;
            foreach (DataRow fila in tabla.Rows)
                if (fila[columna] != DBNull.Value) total += Convert.ToDecimal(fila[columna]);
            return total;
        }

        private void FormatearColumnas()
        {
            foreach (DataGridViewColumn columna in dgvReporte.Columns)
            {
                if (columna.ValueType == typeof(decimal))
                {
                    columna.DefaultCellStyle.Format = "N2";
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (columna.ValueType == typeof(int))
                {
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            int r = cboReporte.SelectedIndex;
            if ((r == 2 || r == 3) && dtpHasta.Value.Date < dtpDesde.Value.Date)
            {
                MessageBox.Show("La fecha 'Hasta' no puede ser menor que 'Desde'.", "Aviso");
                return;
            }

            try
            {
                DataTable tabla;
                string resumen;

                switch (r)
                {
                    case 0:
                        tabla = MetodosReportes.CuadreDelDia(dtpDesde.Value);
                        resumen = "Facturas: " + Suma(tabla, "Facturas").ToString("0") +
                                  "  |  Contado: " + Suma(tabla, "Contado").ToString("N2") +
                                  "  |  Crédito: " + Suma(tabla, "Crédito").ToString("N2") +
                                  "  |  ITBIS: " + Suma(tabla, "ITBIS").ToString("N2") +
                                  "  |  TOTAL: " + Suma(tabla, "Total").ToString("N2");
                        break;
                    case 1:
                        tabla = MetodosReportes.InventarioEnStock();
                        resumen = "Unidades en stock: " + Suma(tabla, "Stock").ToString("0") +
                                  "  |  Valor del inventario: " + Suma(tabla, "Valor inventario").ToString("N2");
                        break;
                    case 2:
                        string tipo = cboTipo.SelectedIndex == 1 ? "Contado" : (cboTipo.SelectedIndex == 2 ? "Credito" : null);
                        tabla = MetodosReportes.Facturas(dtpDesde.Value, dtpHasta.Value, tipo);
                        resumen = "Facturas: " + tabla.Rows.Count +
                                  "  |  ITBIS: " + Suma(tabla, "ITBIS").ToString("N2") +
                                  "  |  TOTAL: " + Suma(tabla, "Total").ToString("N2");
                        break;
                    default:
                        tabla = MetodosReportes.TopClientes(dtpDesde.Value, dtpHasta.Value);
                        resumen = "Total de los 5 clientes: " + Suma(tabla, "Total ventas").ToString("N2");
                        break;
                }

                dgvReporte.DataSource = tabla;
                FormatearColumnas();
                lblResumen.Text = tabla.Rows.Count == 0 ? "Sin resultados para este reporte." : resumen;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
