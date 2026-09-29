using System;

public class CalculadoraSimple
{
    public static string Calcular(int numero1, int numero2, string operacion)
    {
        if (operacion == null)
        {
            throw new ArgumentNullException(nameof(operacion), "La operación no puede ser null.");
        }

        if (operacion == "")
        {
            throw new ArgumentException("La operación no puede estar vacía.", nameof(operacion));
        }

        try
        {
            int resultado = operacion switch
            {
                "+" => numero1 + numero2,
                "*" => numero1 * numero2,
                "/" => numero1 / numero2,
                _ => throw new ArgumentOutOfRangeException(nameof(operacion), $"Operación '{operacion}' no soportada.")
            };

            return $"{numero1} {operacion} {numero2} = {resultado}";
        }
        catch (DivideByZeroException)
        {
            return "División por cero no permitida.";
        }
    }
}

class Program
{
    static void Main()
    {
        // Prueba 1: Operación válida - Suma
        Console.WriteLine("=== Tarea 1: Operaciones válidas ===");
        Console.WriteLine(CalculadoraSimple.Calcular(16, 51, "+"));
        // Esperado: "16 + 51 = 67"

        Console.WriteLine(CalculadoraSimple.Calcular(32, 6, "*"));
        // Esperado: "32 * 6 = 192"

        Console.WriteLine(CalculadoraSimple.Calcular(512, 4, "/"));
        // Esperado: "512 / 4 = 128"

        // Prueba 2: Operación null
        Console.WriteLine("\n=== Tarea 2a: Operación null ===");
        try
        {
            CalculadoraSimple.Calcular(58, 6, null);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Excepción capturada: {ex.GetType().Name} - {ex.Message}");
            // Esperado: ArgumentNullException
        }

        // Prueba 3: Operación vacía
        Console.WriteLine("\n=== Tarea 2b: Operación vacía ===");
        try
        {
            CalculadoraSimple.Calcular(8, 2, "");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Excepción capturada: {ex.GetType().Name} - {ex.Message}");
            // Esperado: ArgumentException
        }

        // Prueba 4: Operación no válida
        Console.WriteLine("\n=== Tarea 2c: Operación no soportada ===");
        try
        {
            CalculadoraSimple.Calcular(100, 10, "-");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Excepción capturada: {ex.GetType().Name} - {ex.Message}");
            // Esperado: ArgumentOutOfRangeException
        }

        // Prueba 5: División por cero
        Console.WriteLine("\n=== Tarea 3: División por cero ===");
        Console.WriteLine(CalculadoraSimple.Calcular(512, 0, "/"));
        // Esperado: "División por cero no permitida."

        // Pruebas adicionales
        Console.WriteLine("\n=== Pruebas adicionales ===");
        Console.WriteLine(CalculadoraSimple.Calcular(10, 5, "+"));
        Console.WriteLine(CalculadoraSimple.Calcular(7, 3, "*"));
        Console.WriteLine(CalculadoraSimple.Calcular(100, 2, "/"));

        // División por cero con números negativos
        Console.WriteLine("\n=== División por cero (números negativos) ===");
        Console.WriteLine(CalculadoraSimple.Calcular(-10, 0, "/"));
    }
}