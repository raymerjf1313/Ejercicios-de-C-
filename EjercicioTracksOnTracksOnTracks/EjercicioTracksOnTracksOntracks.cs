using System;
using System.Collections.Generic;

public class Languages
{
    public static List<string> NewList()
    {
        return new List<string>();
    }

    public static List<string> GetExistingLanguages()
    {
        return new List<string> { "C#", "Clojure", "Elm" };
    }

    public static List<string> AddLanguage(List<string> lenguajes, string nuevoLenguaje)
    {
        lenguajes.Add(nuevoLenguaje);
        return lenguajes;
    }

    public static int CountLanguages(List<string> lenguajes)
    {
        return lenguajes.Count;
    }

    public static bool HasLanguage(List<string> lenguajes, string lenguajeBuscado)
    {
        return lenguajes.Contains(lenguajeBuscado);
    }

    public static List<string> ReverseList(List<string> lenguajes)
    {
        List<string> copia = new List<string>(lenguajes);
        copia.Reverse();
        return copia;
    }

    public static bool IsExciting(List<string> lenguajes)
    {
        if (lenguajes.Count == 0)
        {
            return false;
        }

        if (lenguajes[0] == "C#")
        {
            return true;
        }

        if (lenguajes.Count >= 2 && lenguajes.Count <= 3 && lenguajes[1] == "C#")
        {
            return true;
        }

        return false;
    }

    public static List<string> RemoveLanguage(List<string> lenguajes, string lenguajeARemover)
    {
        lenguajes.Remove(lenguajeARemover);
        return lenguajes;
    }

    public static bool IsUnique(List<string> lenguajes)
    {
        HashSet<string> sinDuplicados = new HashSet<string>(lenguajes);
        return sinDuplicados.Count == lenguajes.Count;
    }
}

class Program
{
    static void Main()
    {
        
        Console.WriteLine("=== Tarea 1: NewList ===");
        List<string> listaVacia = Languages.NewList();
        Console.WriteLine($"Lista vacía - Cantidad: {listaVacia.Count}");
        

        
        Console.WriteLine("\n=== Tarea 2: GetExistingLanguages ===");
        List<string> lenguajesActuales = Languages.GetExistingLanguages();
        Console.WriteLine($"Lenguajes: [{string.Join(", ", lenguajesActuales)}]");
       

       
        Console.WriteLine("\n=== Tarea 3: AddLanguage ===");
        List<string> lenguajes = Languages.GetExistingLanguages();
        lenguajes = Languages.AddLanguage(lenguajes, "VBA");
        Console.WriteLine($"Después de agregar VBA: [{string.Join(", ", lenguajes)}]");
        

        
        Console.WriteLine("\n=== Tarea 4: CountLanguages ===");
        lenguajes = Languages.GetExistingLanguages();
        Console.WriteLine($"Cantidad de lenguajes: {Languages.CountLanguages(lenguajes)}");
        

        
        Console.WriteLine("\n=== Tarea 5: HasLanguage ===");
        lenguajes = Languages.GetExistingLanguages();
        Console.WriteLine($"¿Tiene Elm? {Languages.HasLanguage(lenguajes, "Elm")}");
        Console.WriteLine($"¿Tiene Python? {Languages.HasLanguage(lenguajes, "Python")}");
        

       
        Console.WriteLine("\n=== Tarea 6: ReverseList ===");
        lenguajes = Languages.GetExistingLanguages();
        List<string> invertida = Languages.ReverseList(lenguajes);
        Console.WriteLine($"Original: [{string.Join(", ", lenguajes)}]");
        Console.WriteLine($"Invertida: [{string.Join(", ", invertida)}]");
        

        
        Console.WriteLine("\n=== Tarea 7: IsExciting ===");
        lenguajes = Languages.GetExistingLanguages();
        Console.WriteLine($"¿Es emocionante? {Languages.IsExciting(lenguajes)}");
        

        List<string> otrosLenguajes = new List<string> { "Rust", "C#" };
        Console.WriteLine($"¿[Rust, C#] es emocionante? {Languages.IsExciting(otrosLenguajes)}");
        

        List<string> noEmocionante = new List<string> { "Rust", "Python", "Java" };
        Console.WriteLine($"¿[Rust, Python, Java] es emocionante? {Languages.IsExciting(noEmocionante)}");
        

       
        Console.WriteLine("\n=== Tarea 8: RemoveLanguage ===");
        lenguajes = Languages.GetExistingLanguages();
        Console.WriteLine($"Antes: [{string.Join(", ", lenguajes)}]");
        lenguajes = Languages.RemoveLanguage(lenguajes, "Clojure");
        Console.WriteLine($"Después de remover Clojure: [{string.Join(", ", lenguajes)}]");
       

        
        Console.WriteLine("\n=== Tarea 9: IsUnique ===");
        List<string> sinDuplicados = Languages.GetExistingLanguages();
        Console.WriteLine($"¿[C#, Clojure, Elm] es única? {Languages.IsUnique(sinDuplicados)}");
        

        List<string> conDuplicados = new List<string> { "C#", "Python", "C#" };
        Console.WriteLine($"¿[C#, Python, C#] es única? {Languages.IsUnique(conDuplicados)}");
        
    }
}