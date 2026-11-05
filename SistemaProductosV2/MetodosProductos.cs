using System.Data.SqlClient;

namespace SistemaProductos
{
    public class Producto
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Marca { get; set; }
    }

    public static class MetodosProductos
    {
        public static int Insertar(Producto producto)
        {
            using (SqlConnection conexion = Conexion.Obtener())
            {
                string consulta = @"INSERT INTO Productos (NOMBRE, PRECIO, STOCK, MARCA)
                                    OUTPUT INSERTED.CODIGO
                                    VALUES (@nombre, @precio, @stock, @marca)";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@nombre", producto.Nombre);
                comando.Parameters.AddWithValue("@precio", producto.Precio);
                comando.Parameters.AddWithValue("@stock", producto.Stock);
                comando.Parameters.AddWithValue("@marca", producto.Marca);
                conexion.Open();
                return (int)comando.ExecuteScalar();
            }
        }

        public static bool Actualizar(Producto producto)
        {
            using (SqlConnection conexion = Conexion.Obtener())
            {
                string consulta = @"UPDATE Productos
                                    SET NOMBRE = @nombre, PRECIO = @precio, STOCK = @stock, MARCA = @marca
                                    WHERE CODIGO = @codigo";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@codigo", producto.Codigo);
                comando.Parameters.AddWithValue("@nombre", producto.Nombre);
                comando.Parameters.AddWithValue("@precio", producto.Precio);
                comando.Parameters.AddWithValue("@stock", producto.Stock);
                comando.Parameters.AddWithValue("@marca", producto.Marca);
                conexion.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public static bool Eliminar(int codigo)
        {
            using (SqlConnection conexion = Conexion.Obtener())
            {
                SqlCommand comando = new SqlCommand("DELETE FROM Productos WHERE CODIGO = @codigo", conexion);
                comando.Parameters.AddWithValue("@codigo", codigo);
                conexion.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public static Producto Buscar(int codigo)
        {
            using (SqlConnection conexion = Conexion.Obtener())
            {
                SqlCommand comando = new SqlCommand(
                    "SELECT CODIGO, NOMBRE, PRECIO, STOCK, MARCA FROM Productos WHERE CODIGO = @codigo", conexion);
                comando.Parameters.AddWithValue("@codigo", codigo);
                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    if (!lector.Read()) return null;
                    return new Producto
                    {
                        Codigo = lector.GetInt32(0),
                        Nombre = lector.GetString(1),
                        Precio = lector.GetDecimal(2),
                        Stock = lector.GetInt32(3),
                        Marca = lector.GetString(4)
                    };
                }
            }
        }
    }
}
