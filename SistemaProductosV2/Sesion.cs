namespace SistemaProductos
{
    public class UsuarioSistema
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Estado { get; set; }   // Administrador o Cajero
        public string Turno { get; set; }    // Mañana, Tarde, Noche (solo cajeros)

        public string NombreCompleto { get { return Nombres + " " + Apellidos; } }
        public bool EsAdministrador { get { return Estado == "Administrador"; } }
    }

    // Guarda quién inició sesión para usarlo en todos los formularios.
    public static class Sesion
    {
        public static UsuarioSistema Actual { get; set; }
    }
}
