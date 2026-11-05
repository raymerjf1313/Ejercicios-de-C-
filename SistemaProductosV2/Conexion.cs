using System.Data.SqlClient;

namespace SistemaProductos
{
    public static class Conexion
    {
        // Si tu instancia se llama distinto, cambia .\SQLEXPRESS (ej: DESKTOP-XXXX\SQLEXPRESS)
        private const string cadenaConexion =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=ALMACEN;Integrated Security=True";

        public static SqlConnection Obtener()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
