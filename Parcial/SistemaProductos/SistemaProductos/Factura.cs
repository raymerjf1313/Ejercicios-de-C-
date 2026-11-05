using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaProductos
{
    public class DetalleFactura
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        // Valor de la línea (precio x cantidad), sin ITBIS.
        public decimal Valor { get { return Precio * Cantidad; } }
        public decimal Itbis { get { return Math.Round(Valor * Factura.TasaItbis, 2); } }
    }

    public class Factura
    {
        // ITBIS en República Dominicana: 18 %. Los precios de Productos se toman SIN ITBIS.
        public const decimal TasaItbis = 0.18m;

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }            // "Contado" o "Credito"
        public string UsuarioCajero { get; set; }
        public string NombreCajero { get; set; }
        public string Turno { get; set; }
        public int? IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public decimal TotalBruto { get; set; }
        public decimal TotalItbis { get; set; }
        public decimal Total { get; set; }          // total a pagar
        public decimal MontoPagado { get; set; }
        public decimal Devuelta { get; set; }
        public List<DetalleFactura> Detalles { get; set; }

        public string Numero { get { return Id.ToString("D5"); } }
        public bool EsCredito { get { return Tipo == "Credito"; } }

        public void Calcular()
        {
            TotalBruto = Detalles.Sum(d => d.Valor);
            TotalItbis = Detalles.Sum(d => d.Itbis);
            Total = TotalBruto + TotalItbis;
        }

        private const int Ancho = 57;

        private static string Fila(string id, string nombre, string cantidad, string precio, string valor, string itbis)
        {
            if (nombre.Length > 16) nombre = nombre.Substring(0, 16);
            return id.PadRight(5) + nombre.PadRight(17) + cantidad.PadLeft(5) +
                   precio.PadLeft(10) + valor.PadLeft(11) + itbis.PadLeft(9);
        }

        private static string Centrar(string texto)
        {
            int espacios = Math.Max(0, (Ancho - texto.Length) / 2);
            return new string(' ', espacios) + texto;
        }

        private static string Linea(string etiqueta, string valor)
        {
            return etiqueta.PadRight(Ancho - 16) + valor.PadLeft(16);
        }

        // Texto de 57 columnas, para usar tanto en el .txt como en el PDF.
        public string GenerarTexto()
        {
            string igual = new string('=', Ancho);
            string raya = new string('-', Ancho);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(igual);
            sb.AppendLine(Centrar("FACTURA DE VENTA"));
            sb.AppendLine(igual);
            sb.AppendLine("Factura No. : " + Numero);
            sb.AppendLine("Fecha       : " + Fecha.ToString("dd/MM/yyyy"));
            sb.AppendLine("Hora        : " + Fecha.ToString("HH:mm:ss"));
            sb.AppendLine("Tipo        : " + (EsCredito ? "CRÉDITO" : "CONTADO"));
            sb.AppendLine("Cajero      : " + NombreCajero + (string.IsNullOrEmpty(Turno) ? "" : " (Turno " + Turno + ")"));
            sb.AppendLine("Cliente     : " + NombreCliente);
            sb.AppendLine(raya);
            sb.AppendLine(Fila("ID", "PRODUCTO", "CANT", "PRECIO", "VALOR", "ITBIS"));
            sb.AppendLine(raya);
            foreach (DetalleFactura d in Detalles)
                sb.AppendLine(Fila(d.Codigo.ToString(), d.Nombre, d.Cantidad.ToString(),
                                   d.Precio.ToString("N2"), d.Valor.ToString("N2"), d.Itbis.ToString("N2")));
            sb.AppendLine(raya);
            sb.AppendLine(Linea("Total bruto", TotalBruto.ToString("N2")));
            sb.AppendLine(Linea("Total ITBIS (" + (TasaItbis * 100).ToString("0") + "%)", TotalItbis.ToString("N2")));
            sb.AppendLine(Linea("TOTAL A PAGAR", Total.ToString("N2")));
            if (EsCredito)
            {
                sb.AppendLine(raya);
                sb.AppendLine("Venta a crédito: pendiente en cuentas por cobrar.");
            }
            else
            {
                sb.AppendLine(Linea("Monto pagado", MontoPagado.ToString("N2")));
                sb.AppendLine(Linea("Devuelta", Devuelta.ToString("N2")));
            }
            sb.AppendLine(igual);
            sb.AppendLine(Centrar("Gracias por su compra"));
            return sb.ToString();
        }
    }
}
