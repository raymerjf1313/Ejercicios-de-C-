public class BirdCount
{
    
    private int[] conteosPorDia;

    
    public BirdCount(int[] conteosPorDia)
    {
        this.conteosPorDia = conteosPorDia;
    }

    public static int[] LastWeek()
    {
        return new int[] { 0, 2, 5, 3, 7, 8, 4 };
    }

   
    public int Today()
    {
        
        return conteosPorDia[conteosPorDia.Length - 1];
    }

   
    public void IncrementTodaysCount()
    {
      
        int ultimaPosicion = conteosPorDia.Length - 1;
        conteosPorDia[ultimaPosicion]++;
    }

   
    public bool HasDayWithoutBirds()
    {
    
        foreach (int conteo in conteosPorDia)
        {
            
            if (conteo == 0)
            {
                return true;
            }
        }
        
        return false;
    }

    
    public int CountForFirstDays(int dias)
    {
        int total = 0;

        
        for (int i = 0; i < dias; i++)
        {
            total += conteosPorDia[i];
        }

        return total;
    }

   
    public int BusyDays()
    {
        int diasOcupados = 0;

       
        foreach (int conteo in conteosPorDia)
        {
         
            if (conteo >= 5)
            {
                diasOcupados++;
            }
        }

        return diasOcupados;
    }
}

class Program
{
    static void Main()
    {
        
        int[] conteosDeSemana = { 2, 5, 0, 7, 4, 1 };
        var contadorPajaros = new BirdCount(conteosDeSemana);

        
        Console.WriteLine("=== Tarea 1: LastWeek ===");
        int[] semanaAnterior = BirdCount.LastWeek();
        Console.WriteLine($"Semana anterior: [{string.Join(", ", semanaAnterior)}]");

        
        Console.WriteLine("\n=== Tarea 2: Today ===");
        Console.WriteLine($"Conteo de hoy: {contadorPajaros.Today()}");

        
        Console.WriteLine("\n=== Tarea 3: IncrementTodaysCount ===");
        contadorPajaros.IncrementTodaysCount();
        Console.WriteLine($"Conteo después de incrementar: {contadorPajaros.Today()}");

       
        Console.WriteLine("\n=== Tarea 4: HasDayWithoutBirds ===");
        Console.WriteLine($"¿Hay un día sin pájaros? {contadorPajaros.HasDayWithoutBirds()}");

      
        Console.WriteLine("\n=== Tarea 5: CountForFirstDays ===");
        Console.WriteLine($"Pájaros en los primeros 4 días: {contadorPajaros.CountForFirstDays(4)}");

       
        Console.WriteLine("\n=== Tarea 6: BusyDays ===");
        Console.WriteLine($"Días ocupados: {contadorPajaros.BusyDays()}");
    }
}