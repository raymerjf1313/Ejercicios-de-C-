using System;

public interface IRemoteControlCar
{
    void Drive();
    int DistanceTravelled { get; }
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    private int bateria = 100;
    private const int velocidad = 10;
    private const int drenadoBateria = 1;
    private int metrajeRecorrido = 0;

    public int DistanceTravelled
    {
        get { return metrajeRecorrido; }
    }

    public int NumberOfVictories { get; set; } = 0;

    public void Drive()
    {
        if (bateria >= drenadoBateria)
        {
            metrajeRecorrido += velocidad;
            bateria -= drenadoBateria;
        }
    }

    public int CompareTo(ProductionRemoteControlCar other)
    {
        if (this.NumberOfVictories < other.NumberOfVictories)
            return -1;
        else if (this.NumberOfVictories > other.NumberOfVictories)
            return 1;
        else
            return 0;
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    private int bateria = 100;
    private const int velocidad = 20;
    private const int drenadoBateria = 2;
    private int metrajeRecorrido = 0;

    public int DistanceTravelled
    {
        get { return metrajeRecorrido; }
    }

    public void Drive()
    {
        if (bateria >= drenadoBateria)
        {
            metrajeRecorrido += velocidad;
            bateria -= drenadoBateria;
        }
    }
}

public class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static ProductionRemoteControlCar[] GetRankedCars(params ProductionRemoteControlCar[] autos)
    {
        System.Array.Sort(autos);
        return autos;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Tarea 1 y 2: Interfaz IRemoteControlCar ===");
        var produccion = new ProductionRemoteControlCar();
        var experimental = new ExperimentalRemoteControlCar();

        Console.WriteLine($"Producción antes: {produccion.DistanceTravelled} metros");
        Console.WriteLine($"Experimental antes: {experimental.DistanceTravelled} metros");

        TestTrack.Race(produccion);
        TestTrack.Race(experimental);

        Console.WriteLine($"Producción después: {produccion.DistanceTravelled} metros");
        Console.WriteLine($"Experimental después: {experimental.DistanceTravelled} metros");

        Console.WriteLine("\n=== Tarea 3: IComparable<T> - Múltiples carreras ===");
        var prod1 = new ProductionRemoteControlCar();
        var prod2 = new ProductionRemoteControlCar();
        var prod3 = new ProductionRemoteControlCar();

        for (int i = 0; i < 10; i++)
        {
            TestTrack.Race(prod1);
            if (i < 5)
                TestTrack.Race(prod2);
            if (i < 8)
                TestTrack.Race(prod3);
        }

        prod1.NumberOfVictories = 3;
        prod2.NumberOfVictories = 2;
        prod3.NumberOfVictories = 5;

        Console.WriteLine($"prod1 - Victorias: {prod1.NumberOfVictories}, Distancia: {prod1.DistanceTravelled}");
        Console.WriteLine($"prod2 - Victorias: {prod2.NumberOfVictories}, Distancia: {prod2.DistanceTravelled}");
        Console.WriteLine($"prod3 - Victorias: {prod3.NumberOfVictories}, Distancia: {prod3.DistanceTravelled}");

        Console.WriteLine("\n=== Tarea 3: Ranking (orden ascendente de victorias) ===");
        var ranking = TestTrack.GetRankedCars(prod1, prod2, prod3);

        for (int i = 0; i < ranking.Length; i++)
        {
            Console.WriteLine($"Posición {i + 1}: Victorias = {ranking[i].NumberOfVictories}");
        }

        Console.WriteLine("\n=== Prueba adicional: Comparación directa ===");
        var auto1 = new ProductionRemoteControlCar { NumberOfVictories = 10 };
        var auto2 = new ProductionRemoteControlCar { NumberOfVictories = 5 };
        var auto3 = new ProductionRemoteControlCar { NumberOfVictories = 10 };

        Console.WriteLine($"auto1.CompareTo(auto2) = {auto1.CompareTo(auto2)} (10 > 5)");
        Console.WriteLine($"auto2.CompareTo(auto1) = {auto2.CompareTo(auto1)} (5 < 10)");
        Console.WriteLine($"auto1.CompareTo(auto3) = {auto1.CompareTo(auto3)} (10 == 10)");

        Console.WriteLine("\n=== Validación de interfaz ===");
        IRemoteControlCar interfazProd = new ProductionRemoteControlCar();
        IRemoteControlCar interfazExp = new ExperimentalRemoteControlCar();

        interfazProd.Drive();
        interfazExp.Drive();

        Console.WriteLine($"Prod vía interfaz: {interfazProd.DistanceTravelled}");
        Console.WriteLine($"Exp vía interfaz: {interfazExp.DistanceTravelled}");
    }
}