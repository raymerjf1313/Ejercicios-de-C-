using System;

public class BalanzaPesaje
{
    private double peso;
    private double ajusteTara;

    public BalanzaPesaje(int precision)
    {
        Precision = precision;
        peso = 0;
        ajusteTara = 5.0;
    }

    public int Precision { get; }

    public double Weight
    {
        get { return peso; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "El peso no puede ser negativo.");
            }
            peso = value;
        }
    }

    public double TareAdjustment
    {
        get { return ajusteTara; }
        set { ajusteTara = value; }
    }

    public string DisplayWeight
    {
        get
        {
            double pesoAjustado = peso - ajusteTara;
            string formato = $"F{Precision}";
            return $"{pesoAjustado.ToString(formato)} kg";
        }
    }
}

class Program
{
    static void Main()
    {
        // Prueba 1: Precision (solo lectura)
        Console.WriteLine("=== Tarea 1: Precision ===");
        var bp = new BalanzaPesaje(precision: 3);
        Console.WriteLine($"Precisión: {bp.Precision}");
        // Esperado: 3

        
        Console.WriteLine("\n=== Tarea 2: Weight ===");
        bp.Weight = 60.5;
        Console.WriteLine($"Peso establecido: {bp.Weight}");
       

        bp.Weight = 75.125;
        Console.WriteLine($"Nuevo peso: {bp.Weight}");
     

       
        Console.WriteLine("\n=== Tarea 3: Validación Weight ===");
        try
        {
            bp.Weight = -10;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Excepción capturada: {ex.GetType().Name}");
            Console.WriteLine($"Mensaje: {ex.Message}");
            
        }

       
        Console.WriteLine("\n=== Tarea 4: TareAdjustment ===");
        bp = new BalanzaPesaje(precision: 3);
        bp.TareAdjustment = -10.6;
        Console.WriteLine($"Tare adjustment establecido: {bp.TareAdjustment}");
       

        bp.TareAdjustment = 2.5;
        Console.WriteLine($"Nuevo tare adjustment: {bp.TareAdjustment}");
       
        Console.WriteLine("\n=== Tarea 5: TareAdjustment por defecto ===");
        bp = new BalanzaPesaje(precision: 3);
        Console.WriteLine($"Tare adjustment por defecto: {bp.TareAdjustment}");
        

     
        Console.WriteLine("\n=== Tarea 6: DisplayWeight ===");
        bp = new BalanzaPesaje(precision: 3);
        bp.Weight = 60.567;
        bp.TareAdjustment = 10;
        Console.WriteLine($"Peso mostrado: {bp.DisplayWeight}");
        

        
        Console.WriteLine("\n=== Pruebas adicionales DisplayWeight ===");
        
        bp = new BalanzaPesaje(precision: 1);
        bp.Weight = 100.5;
        bp.TareAdjustment = 5;
        Console.WriteLine($"Precisión 1: {bp.DisplayWeight}");
       

        bp = new BalanzaPesaje(precision: 2);
        bp.Weight = 82.456;
        bp.TareAdjustment = 10.25;
        Console.WriteLine($"Precisión 2: {bp.DisplayWeight}");
      

       
        bp = new BalanzaPesaje(precision: 3);
        bp.Weight = 50;
        bp.TareAdjustment = -20;
        Console.WriteLine($"Tare adjustment negativo: {bp.DisplayWeight}");
       
     
        bp = new BalanzaPesaje(precision: 3);
        bp.Weight = 20;
        bp.TareAdjustment = 30;
        Console.WriteLine($"Display weight negativo permitido: {bp.DisplayWeight}");
        
    }
}