using System;

public enum MetodoViaje
{
    Caminando,
    Caballo
}

public class Personaje
{
    public string Clase { get; set; }
    public int Nivel { get; set; }
    public int PuntosVida { get; set; }
}

public class Destino
{
    public string Nombre { get; set; }
    public int Habitantes { get; set; }
}

public class MaestroJuego
{
    public static string Describir(Personaje personaje)
    {
        return $"You're a level {personaje.Nivel} {personaje.Clase} with {personaje.PuntosVida} hit points.";
    }

    public static string Describir(Destino destino)
    {
        return $"You've arrived at {destino.Nombre}, which has {destino.Habitantes} inhabitants.";
    }

    public static string Describir(MetodoViaje metodo)
    {
        return metodo switch
        {
            MetodoViaje.Caminando => "You're traveling to your destination by walking.",
            MetodoViaje.Caballo => "You're traveling to your destination on horseback.",
            _ => "Unknown travel method."
        };
    }

    public static string Describir(Personaje personaje, Destino destino, MetodoViaje metodo)
    {
        string personajeDesc = Describir(personaje);
        string metodoDesc = Describir(metodo);
        string destinoDesc = Describir(destino);
        
        return $"{personajeDesc} {metodoDesc} {destinoDesc}";
    }

    public static string Describir(Personaje personaje, Destino destino)
    {
        return Describir(personaje, destino, MetodoViaje.Caminando);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Tarea 1: Describir Personaje ===");
        var personaje = new Personaje();
        personaje.Clase = "Wizard";
        personaje.Nivel = 4;
        personaje.PuntosVida = 28;
        
        Console.WriteLine(MaestroJuego.Describir(personaje));

        Console.WriteLine("\n=== Tarea 2: Describir Destino ===");
        var destino = new Destino();
        destino.Nombre = "Muros";
        destino.Habitantes = 732;
        
        Console.WriteLine(MaestroJuego.Describir(destino));

        Console.WriteLine("\n=== Tarea 3: Describir Método de Viaje ===");
        Console.WriteLine(MaestroJuego.Describir(MetodoViaje.Caminando));
        Console.WriteLine(MaestroJuego.Describir(MetodoViaje.Caballo));

        Console.WriteLine("\n=== Tarea 4: Describir Viaje Completo (con parámetro) ===");
        Console.WriteLine(MaestroJuego.Describir(personaje, destino, MetodoViaje.Caballo));

        Console.WriteLine("\n=== Tarea 5: Describir Viaje (sin parámetro - por defecto caminando) ===");
        Console.WriteLine(MaestroJuego.Describir(personaje, destino));

        Console.WriteLine("\n=== Pruebas Adicionales ===");
        var guerrero = new Personaje();
        guerrero.Clase = "Warrior";
        guerrero.Nivel = 10;
        guerrero.PuntosVida = 50;

        var ciudad = new Destino();
        ciudad.Nombre = "Urvas";
        ciudad.Habitantes = 1500;

        Console.WriteLine(MaestroJuego.Describir(guerrero));
        Console.WriteLine(MaestroJuego.Describir(ciudad));
        Console.WriteLine(MaestroJuego.Describir(guerrero, ciudad, MetodoViaje.Caballo));
        Console.WriteLine(MaestroJuego.Describir(guerrero, ciudad));
    }
}
