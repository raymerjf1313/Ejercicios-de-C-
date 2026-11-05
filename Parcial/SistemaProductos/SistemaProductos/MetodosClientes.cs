using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaProductos
{
    public static class MetodosClientes
    {
        // El id 0 es "Consumidor final" (no existe en la tabla, se guarda como NULL en la factura).
        public static DataTable ListarParaCombo()
        {
            using (SqlConnection conexion = Conexion.Obtener())
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(
                    @"SELECT * FROM (
                          SELECT 0 AS id_cliente, 'Consumidor final' AS nombre
                          UNION ALL
                          SELECT id_cliente, nombre FROM Clientes
                      ) t
                      ORDER BY CASE WHEN id_cliente = 0 THEN 0 ELSE 1 END, nombre", conexion);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;
            }
        }

        public static int Insertar(string nombre, string documento, string telefono)
        {
            using (SqlConnection conexion = Conexion.Obtener())
            {
                SqlCommand comando = new SqlCommand(
                    @"INSERT INTO Clientes (nombre, documento, telefono)
                      OUTPUT INSERTED.id_cliente
                      VALUES (@nombre, @documento, @telefono)", conexion);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@documento", string.IsNullOrWhiteSpace(documento) ? (object)DBNull.Value : documento.Trim());
                comando.Parameters.AddWithValue("@telefono", string.IsNullOrWhiteSpace(telefono) ? (object)DBNull.Value : telefono.Trim());
                conexion.Open();
                return (int)comando.ExecuteScalar();
            }
        }
    }
}
