using PracticaForm.Modulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaForm.Dato
{
    public class Usuario
    {
        List<UsuarioNombre> lista = new List<UsuarioNombre>();
        public void Guardar(UsuarioNombre modelo)
        {
            lista.Add(modelo);
        }
        public List<UsuarioNombre> Consultar () { return lista; }
    }
}
