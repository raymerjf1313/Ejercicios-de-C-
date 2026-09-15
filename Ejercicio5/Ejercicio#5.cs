public class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        if (speed == 0)
        {
            return 0.0;
        }
        else if (speed >= 1 && speed <= 4)
        {
            return 1.0; 
        }
        else if (speed >= 5 && speed <= 8)
        {
            return 0.9; 
        }
        else if (speed == 9)
        {
            return 0.8; 
        }
        else if (speed == 10)
        {
            return 0.77; 
        }
        
        return 0.0;
    }

    public static double ProductionRatePerHour(int speed)
    {
        double carsPerHour = speed * 221;
        double successRate = SuccessRate(speed);
        
        return carsPerHour * successRate;
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        double produccionPorHora = ProductionRatePerHour(speed);
        
        int autosPorMinuto = (int)produccionPorHora / 60;
        
        return autosPorMinuto;
    }
}

class Program
{
    static void Main()
    {
        // Pruebas
        Console.WriteLine(AssemblyLine.SuccessRate(0));
        Console.WriteLine(AssemblyLine.SuccessRate(5));
        Console.WriteLine(AssemblyLine.SuccessRate(10));
        
        Console.WriteLine(AssemblyLine.ProductionRatePerHour(6));
        Console.WriteLine(AssemblyLine.ProductionRatePerHour(10));
        
        Console.WriteLine(AssemblyLine.WorkingItemsPerMinute(6));
        Console.WriteLine(AssemblyLine.WorkingItemsPerMinute(10));
    }
}