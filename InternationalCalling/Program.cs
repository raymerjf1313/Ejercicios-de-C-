using System;
using System.Collections.Generic;
using System.Linq;

public class CodigosMarcado
{
    public static Dictionary<int, string> ObtenerDiccionarioVacio()
    {
        return new Dictionary<int, string>();
    }

    public static Dictionary<int, string> ObtenerDiccionarioExistente()
    {
        return new Dictionary<int, string>
        {
            { 1, "United States of America" },
            { 55, "Brazil" },
            { 91, "India" }
        };
    }

    public static Dictionary<int, string> AgregarPaisADiccionarioVacio(int codigo, string pais)
    {
        var diccionario = ObtenerDiccionarioVacio();
        diccionario.Add(codigo, pais);
        return diccionario;
    }

    public static Dictionary<int, string> AgregarPaisADiccionarioExistente(Dictionary<int, string> diccionario, int codigo, string pais)
    {
        diccionario.Add(codigo, pais);
        return diccionario;
    }

    public static string ObtenerNombrePaisDeDiccionario(Dictionary<int, string> diccionario, int codigo)
    {
        if (diccionario.ContainsKey(codigo))
        {
            return diccionario[codigo];
        }
        return string.Empty;
    }

    public static bool VerificarCodigoExiste(Dictionary<int, string> diccionario, int codigo)
    {
        return diccionario.ContainsKey(codigo);
    }

    public static Dictionary<int, string> ActualizarDiccionario(Dictionary<int, string> diccionario, int codigo, string paisNuevo)
    {
        if (diccionario.ContainsKey(codigo))
        {
            diccionario[codigo] = paisNuevo;
        }
        return diccionario;
    }

    public static Dictionary<int, string> EliminarPaisDeDiccionario(Dictionary<int, string> diccionario, int codigo)
    {
        diccionario.Remove(codigo);
        return diccionario;
    }

    public static string EncontrarNombrePaismasLargo(Dictionary<int, string> diccionario)
    {
        return diccionario.Values.OrderByDescending(pais => pais.Length).First();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Tarea 1: Diccionario Vacío ===");
        var vacio = CodigosMarcado.ObtenerDiccionarioVacio();
        Console.WriteLine($"Cantidad de elementos: {vacio.Count}");

        Console.WriteLine("\n=== Tarea 2: Diccionario Existente ===");
        var existente = CodigosMarcado.ObtenerDiccionarioExistente();
        Console.WriteLine($"Código 1: {existente[1]}");
        Console.WriteLine($"Código 55: {existente[55]}");
        Console.WriteLine($"Código 91: {existente[91]}");

        Console.WriteLine("\n=== Tarea 3: Agregar a Diccionario Vacío ===");
        var conPais = CodigosMarcado.AgregarPaisADiccionarioVacio(44, "United Kingdom");
        Console.WriteLine($"Código 44: {conPais[44]}");
        Console.WriteLine($"Cantidad: {conPais.Count}");

        Console.WriteLine("\n=== Tarea 4: Agregar a Diccionario Existente ===");
        var extendido = CodigosMarcado.ObtenerDiccionarioExistente();
        CodigosMarcado.AgregarPaisADiccionarioExistente(extendido, 44, "United Kingdom");
        Console.WriteLine($"Cantidad total: {extendido.Count}");
        foreach (var par in extendido.OrderBy(p => p.Key))
        {
            Console.WriteLine($"  {par.Key} => {par.Value}");
        }

        Console.WriteLine("\n=== Tarea 5: Obtener Nombre País ===");
        var dic = CodigosMarcado.ObtenerDiccionarioExistente();
        Console.WriteLine($"Código 55: {CodigosMarcado.ObtenerNombrePaisDeDiccionario(dic, 55)}");
        Console.WriteLine($"Código 999: '{CodigosMarcado.ObtenerNombrePaisDeDiccionario(dic, 999)}'");

        Console.WriteLine("\n=== Tarea 6: Verificar Código Existe ===");
        Console.WriteLine($"¿Existe código 55? {CodigosMarcado.VerificarCodigoExiste(dic, 55)}");
        Console.WriteLine($"¿Existe código 999? {CodigosMarcado.VerificarCodigoExiste(dic, 999)}");

        Console.WriteLine("\n=== Tarea 7: Actualizar Diccionario ===");
        var paraActualizar = CodigosMarcado.ObtenerDiccionarioExistente();
        CodigosMarcado.ActualizarDiccionario(paraActualizar, 1, "Les États-Unis");
        Console.WriteLine($"Código 1 actualizado: {paraActualizar[1]}");
        
        CodigosMarcado.ActualizarDiccionario(paraActualizar, 999, "Newlands");
        Console.WriteLine($"Intento de actualizar 999 (no existe): {paraActualizar.Count} elementos");

        Console.WriteLine("\n=== Tarea 8: Eliminar País ===");
        var paraEliminar = CodigosMarcado.ObtenerDiccionarioExistente();
        Console.WriteLine($"Antes: {paraEliminar.Count} elementos");
        CodigosMarcado.EliminarPaisDeDiccionario(paraEliminar, 91);
        Console.WriteLine($"Después: {paraEliminar.Count} elementos");
        foreach (var par in paraEliminar.OrderBy(p => p.Key))
        {
            Console.WriteLine($"  {par.Key} => {par.Value}");
        }

        Console.WriteLine("\n=== Tarea 9: País con Nombre Más Largo ===");
        var paraBuscar = CodigosMarcado.ObtenerDiccionarioExistente();
        Console.WriteLine($"País más largo: {CodigosMarcado.EncontrarNombrePaismasLargo(paraBuscar)}");
    }
}