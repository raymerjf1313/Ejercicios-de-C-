using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaProductos
{
    public static class MetodosReportes
    {
        private static DataTable Llenar(SqlCommand comando)
        {
            using (SqlConnection conexion = comando.Connection)
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;
            }
        }

        // Cuadre del día: una fila por cajero con sus ventas de contado, crédito, ITBIS y total.
        public static DataTable CuadreDelDia(DateTime fecha)
        {
            SqlCommand comando = new SqlCommand(
                @"SELECT f.usuario AS Cajero,
                         ISNULL(u.nombres + ' ' + u.apellidos, f.usuario) AS Nombre,
                         ISNULL(f.turno, '-') AS Turno,
                         COUNT(*) AS Facturas,
                         SUM(CASE WHEN f.tipo = 'Contado' THEN f.total ELSE 0 END) AS Contado,
                         SUM(CASE WHEN f.tipo = 'Credito' THEN f.total ELSE 0 END) AS [Crédito],
                         SUM(f.total_bruto) AS Bruto,
                         SUM(f.total_itbis) AS ITBIS,
                         SUM(f.total) AS Total
                  FROM Facturas f
                  LEFT JOIN usuario u ON u.usuario = f.usuario
                  WHERE CAST(f.fecha AS DATE) = @fecha
                  GROUP BY f.usuario, u.nombres, u.apellidos, f.turno
                  ORDER BY f.usuario", Conexion.Obtener());
            comando.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha.Date;
            return Llenar(comando);
        }

        public static DataTable InventarioEnStock()
        {
            SqlCommand comando = new SqlCommand(
                @"SELECT CODIGO AS Código, NOMBRE AS Producto, MARCA AS Marca, PRECIO AS Precio,
                         STOCK AS Stock, PRECIO * STOCK AS [Valor inventario]
                  FROM Productos ORDER BY NOMBRE", Conexion.Obtener());
            return Llenar(comando);
        }

        // tipo: null = todas, "Contado" o "Credito".
        public static DataTable Facturas(DateTime desde, DateTime hasta, string tipo)
        {
            SqlCommand comando = new SqlCommand(
                @"SELECT RIGHT('00000' + CAST(f.id_factura AS VARCHAR(10)), 5) AS Factura,
                         CONVERT(VARCHAR(10), f.fecha, 103) AS Fecha,
                         CONVERT(VARCHAR(8), f.fecha, 108) AS Hora,
                         f.tipo AS Tipo, f.usuario AS Cajero, f.cliente AS Cliente,
                         f.total_bruto AS Bruto, f.total_itbis AS ITBIS, f.total AS Total
                  FROM Facturas f
                  WHERE f.fecha >= @desde AND f.fecha < DATEADD(DAY, 1, @hasta)
                    AND (@tipo IS NULL OR f.tipo = @tipo)
                  ORDER BY f.id_factura", Conexion.Obtener());
            comando.Parameters.Add("@desde", SqlDbType.Date).Value = desde.Date;
            comando.Parameters.Add("@hasta", SqlDbType.Date).Value = hasta.Date;
            comando.Parameters.Add("@tipo", SqlDbType.VarChar, 10).Value = (object)tipo ?? DBNull.Value;
            return Llenar(comando);
        }

        public static DataTable TopClientes(DateTime desde, DateTime hasta)
        {
            SqlCommand comando = new SqlCommand(
                @"SELECT TOP 5 c.nombre AS Cliente, ISNULL(c.documento, '') AS Documento,
                         COUNT(f.id_factura) AS Facturas, SUM(f.total) AS [Total ventas]
                  FROM Facturas f
                  INNER JOIN Clientes c ON c.id_cliente = f.id_cliente
                  WHERE f.fecha >= @desde AND f.fecha < DATEADD(DAY, 1, @hasta)
                  GROUP BY c.id_cliente, c.nombre, c.documento
                  ORDER BY SUM(f.total) DESC", Conexion.Obtener());
            comando.Parameters.Add("@desde", SqlDbType.Date).Value = desde.Date;
            comando.Parameters.Add("@hasta", SqlDbType.Date).Value = hasta.Date;
            return Llenar(comando);
        }
    }
}
