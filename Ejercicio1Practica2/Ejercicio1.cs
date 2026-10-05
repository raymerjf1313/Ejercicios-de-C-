using System;

class Program
{
    static void Main()
    {
        Console.Write("Ingrese el primer valor: ");
        double valor1 = double.Parse(Console.ReadLine());

        Console.Write("Ingrese el segundo valor: ");
        double valor2 = double.Parse(Console.ReadLine());

        Console.WriteLine("Suma: " + (valor1 + valor2));
        Console.WriteLine("Resta: " + (valor1 - valor2));
        Console.WriteLine("Multiplicacion: " + (valor1 * valor2));

        if (valor2 == 0)
        {
            Console.WriteLine("Division: no se puede dividir entre cero");
        }
        else
        {
            Console.WriteLine("Division: " + (valor1 / valor2));
        }

        if (valor1 >= 0)
        {
            Console.WriteLine("Raiz cuadrada del primer valor: " + Math.Sqrt(valor1));
        }
        else
        {
            Console.WriteLine("Raiz cuadrada del primer valor: no existe para negativos");
        }

        if (valor2 >= 0)
        {
            Console.WriteLine("Raiz cuadrada del segundo valor: " + Math.Sqrt(valor2));
        }
        else
        {
            Console.WriteLine("Raiz cuadrada del segundo valor: no existe para negativos");
        }

        Console.ReadKey();
    }
}
