using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaProductos
{
    public static class MetodosUsuarios
    {
        private static object ONulo(string texto)
        {
            return string.IsNullOrWhiteSpace(texto) ? (object)DBNull.Value : texto.Trim();
        }

        // Devuelve el usuario si los datos coinciden, o null si no.
        public static UsuarioSistema ValidarLogin(string usuario, string clave)
        {
            using (SqlConnection conexion = Conexion.Obtener())
            {
                string consulta = @"SELECT id_usuario, nombres, apellidos, usuario, estado, turno
                                    FROM usuario
                                    WHERE usuario = @usuario AND [contraseña] = @clave";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@clave", clave);
                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    if (!lector.Read()) return null;
                    return new UsuarioSistema
                    {
                        Id = lector.GetInt32(0),
                        Nombres = lector.GetString(1),
                        Apellidos = lector.GetString(2),
                        Usuario = lector.GetString(3),
                        Estado = lector.GetString(4),
                        Turno = lector.IsDBNull(5) ? null : lector.GetString(5)
                    };
                }
            }
        }

        public static DataTable ListarCajeros()
        {
            using (SqlConnection conexion = Conexion.Obtener())
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(
                    @"SELECT id_usuario, ci_usuario AS Cedula, nombres AS Nombres, apellidos AS Apellidos,
                             telefono AS Telefono, email AS Email, usuario AS Usuario,
                             [contraseña] AS Clave, turno AS Turno
                      FROM usuario WHERE estado = 'Cajero' ORDER BY turno, nombres", conexion);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;
            }
        }

        public static void InsertarCajero(UsuarioSistema u)
        {
            using (SqlConnection conexion = Conexion.Obtener())
            {
                SqlCommand comando = new SqlCommand(
                    @"INSERT INTO usuario (ci_usuario, nombres, apellidos, telefono, email, usuario, [contraseña], estado, fecha_ingreso, turno)
                      VALUES (@cedula, @nombres, @apellidos, @telefono, @email, @usuario, @clave, 'Cajero', CAST(GETDATE() AS DATE), @turno)", conexion);
                comando.Parameters.AddWithValue("@cedula", u.Cedula);
                comando.Parameters.AddWithValue("@nombres", u.Nombres);
                comando.Parameters.AddWithValue("@apellidos", u.Apellidos);
                comando.Parameters.AddWithValue("@telefono", ONulo(u.Telefono));
                comando.Parameters.AddWithValue("@email", ONulo(u.Email));
                comando.Parameters.AddWithValue("@usuario", u.Usuario);
                comando.Parameters.AddWithValue("@clave", u.Clave);
                comando.Parameters.AddWithValue("@turno", u.Turno);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public static bool ActualizarCajero(UsuarioSistema u)
        {
            using (SqlConnection conexion = Conexion.Obtener())
            {
                SqlCommand comando = new SqlCommand(
                    @"UPDATE usuario
                      SET ci_usuario = @cedula, nombres = @nombres, apellidos = @apellidos, telefono = @telefono,
                          email = @email, usuario = @usuario, [contraseña] = @clave, turno = @turno
                      WHERE id_usuario = @id AND estado = 'Cajero'", conexion);
                comando.Parameters.AddWithValue("@id", u.Id);
                comando.Parameters.AddWithValue("@cedula", u.Cedula);
                comando.Parameters.AddWithValue("@nombres", u.Nombres);
                comando.Parameters.AddWithValue("@apellidos", u.Apellidos);
                comando.Parameters.AddWithValue("@telefono", ONulo(u.Telefono));
                comando.Parameters.AddWithValue("@email", ONulo(u.Email));
                comando.Parameters.AddWithValue("@usuario", u.Usuario);
                comando.Parameters.AddWithValue("@clave", u.Clave);
                comando.Parameters.AddWithValue("@turno", u.Turno);
                conexion.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public static bool EliminarCajero(int id)
        {
            using (SqlConnection conexion = Conexion.Obtener())
            {
                SqlCommand comando = new SqlCommand(
                    "DELETE FROM usuario WHERE id_usuario = @id AND estado = 'Cajero'", conexion);
                comando.Parameters.AddWithValue("@id", id);
                conexion.Open();
                return comando.ExecuteNonQuery() > 0;
            }
        }
    }
}
