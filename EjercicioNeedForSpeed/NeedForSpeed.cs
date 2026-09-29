using System;

public class RemoteControlCar
{
    private int velocidad;
    private int drenadoBateria;
    private int metrajeRecorrido;
    private int bateria;

    public RemoteControlCar(int velocidad, int drenadoBateria)
    {
        this.velocidad = velocidad;
        this.drenadoBateria = drenadoBateria;
        this.metrajeRecorrido = 0;
        this.bateria = 100;
    }

    public void Drive()
    {
        if (bateria >= drenadoBateria)
        {
            metrajeRecorrido += velocidad;
            bateria -= drenadoBateria;
        }
    }

    public int DistanceDriven()
    {
        return metrajeRecorrido;
    }

    public bool BatteryDrained()
    {
        return bateria < drenadoBateria;
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

public class RaceTrack
{
    private int distancia;

    public RaceTrack(int distancia)
    {
        this.distancia = distancia;
    }

    public bool TryFinishTrack(RemoteControlCar coche)
    {
        while (!coche.BatteryDrained())
        {
            coche.Drive();
        }

        return coche.DistanceDriven() >= distancia;
    }
}

class Program
{
    static void Main()
    {
        
        Console.WriteLine("=== Tarea 1: Constructor RemoteControlCar ===");
        int velocidad = 5;
        int drenadoBateria = 2;
        var coche = new RemoteControlCar(velocidad, drenadoBateria);
        Console.WriteLine($"Coche creado con velocidad={velocidad}, drenado={drenadoBateria}");

        
        Console.WriteLine("\n=== Tarea 2: Constructor RaceTrack ===");
        int distancia = 800;
        var pista = new RaceTrack(distancia);
        Console.WriteLine($"Pista creada con distancia={distancia} metros");

        
        Console.WriteLine("\n=== Tarea 3: Drive() y DistanceDriven() ===");
        coche = new RemoteControlCar(5, 2);
        Console.WriteLine($"Distancia inicial: {coche.DistanceDriven()} metros");
        coche.Drive();
        Console.WriteLine($"Después de Drive(): {coche.DistanceDriven()} metros");
        coche.Drive();
        Console.WriteLine($"Después de otro Drive(): {coche.DistanceDriven()} metros");

        
        Console.WriteLine("\n=== Tarea 4: BatteryDrained() ===");
        coche = new RemoteControlCar(5, 2);
        Console.WriteLine($"¿Batería agotada al inicio? {coche.BatteryDrained()}");
        for (int i = 0; i < 50; i++)
        {
            coche.Drive();
        }
        Console.WriteLine($"¿Batería agotada después de 50 Drive()? {coche.BatteryDrained()}");
        Console.WriteLine($"Distancia recorrida: {coche.DistanceDriven()} metros");
        
        
        coche = new RemoteControlCar(100, 68);
        Console.WriteLine($"\nCoche velocidad=100, drenado=68");
        Console.WriteLine($"¿Batería agotada al inicio? {coche.BatteryDrained()}");
        coche.Drive();
        Console.WriteLine($"Después de un Drive(): distancia={coche.DistanceDriven()}, ¿drenada? {coche.BatteryDrained()}");

       
        Console.WriteLine("\n=== Tarea 5: Nitro() ===");
        var nitro = RemoteControlCar.Nitro();
        Console.WriteLine($"Nitro creado");
        nitro.Drive();
        Console.WriteLine($"Distancia después de un Drive(): {nitro.DistanceDriven()} metros");
       

        
        Console.WriteLine("\n=== Tarea 6: TryFinishTrack() ===");
        
        
        coche = new RemoteControlCar(5, 2);
        pista = new RaceTrack(100);
        bool resultado = pista.TryFinishTrack(coche);
        Console.WriteLine($"Coche (5m, 2% drenado) en pista de 100m: {resultado}");
        Console.WriteLine($"Distancia recorrida: {coche.DistanceDriven()} metros");

       
        coche = new RemoteControlCar(5, 2);
        pista = new RaceTrack(500);
        resultado = pista.TryFinishTrack(coche);
        Console.WriteLine($"\nCoche (5m, 2% drenado) en pista de 500m: {resultado}");
        Console.WriteLine($"Distancia recorrida: {coche.DistanceDriven()} metros");

        
        nitro = RemoteControlCar.Nitro();
        pista = new RaceTrack(1000);
        resultado = pista.TryFinishTrack(nitro);
        Console.WriteLine($"\nNitro en pista de 1000m: {resultado}");
        Console.WriteLine($"Distancia recorrida: {nitro.DistanceDriven()} metros");
    }
}