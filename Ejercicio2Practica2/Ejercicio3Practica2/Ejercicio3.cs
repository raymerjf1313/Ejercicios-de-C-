using System;
using System.Collections.Generic;

class Estudiante
{
    public string Nombre;
    public string Apellido;
    public int Nota1;
    public int Nota2;
    public int Nota3;
    public int Nota4;
    public double Promedio;
    public string Literal;
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<Estudiante> estudiantes = new List<Estudiante>();
        string respuesta = "S";

        while (respuesta == "S")
        {
            Estudiante e = new Estudiante();

            Console.Write("Nombre: ");
            e.Nombre = Console.ReadLine();

            Console.Write("Primer apellido: ");
            e.Apellido = Console.ReadLine();

            Console.Write("Nota 1: ");
            e.Nota1 = int.Parse(Console.ReadLine());

            Console.Write("Nota 2: ");
            e.Nota2 = int.Parse(Console.ReadLine());

            Console.Write("Nota 3: ");
            e.Nota3 = int.Parse(Console.ReadLine());

            Console.Write("Nota 4: ");
            e.Nota4 = int.Parse(Console.ReadLine());

            e.Promedio = (e.Nota1 + e.Nota2 + e.Nota3 + e.Nota4) / 4.0;

            if (e.Promedio >= 90)
            {
                e.Literal = "A";
            }
            else if (e.Promedio >= 80)
            {
                e.Literal = "B";
            }
            else if (e.Promedio >= 70)
            {
                e.Literal = "C";
            }
            else
            {
                e.Literal = "F";
            }

            estudiantes.Add(e);

            Console.Write("¿Desea ingresar otro estudiante? (S/N): ");
            respuesta = Console.ReadLine().ToUpper();
            Console.WriteLine();
        }

        // Ordenar por apellido (metodo burbuja)
        for (int i = 0; i < estudiantes.Count - 1; i++)
        {
            for (int j = 0; j < estudiantes.Count - 1 - i; j++)
            {
                if (string.Compare(estudiantes[j].Apellido, estudiantes[j + 1].Apellido, true) > 0)
                {
                    Estudiante temporal = estudiantes[j];
                    estudiantes[j] = estudiantes[j + 1];
                    estudiantes[j + 1] = temporal;
                }
            }
        }

        Console.WriteLine("Colegio Dios es bueno.");
        Console.WriteLine("Calificaciones del cuatrimestre");
        Console.WriteLine("==========================================================================");
        Console.WriteLine("Nombre      Apellido    Nota1  Nota2  Nota3  Nota4  Promedio  Literal");
        Console.WriteLine("==========================================================================");

        foreach (Estudiante e in estudiantes)
        {
            Console.WriteLine(
                e.Nombre.PadRight(12) +
                e.Apellido.PadRight(12) +
                e.Nota1.ToString().PadRight(7) +
                e.Nota2.ToString().PadRight(7) +
                e.Nota3.ToString().PadRight(7) +
                e.Nota4.ToString().PadRight(7) +
                e.Promedio.ToString("0.0").PadRight(10) +
                e.Literal);
        }

        int totalA = 0;
        int totalB = 0;
        int totalC = 0;
        int totalReprobados = 0;

        foreach (Estudiante e in estudiantes)
        {
            if (e.Literal == "A") totalA++;
            else if (e.Literal == "B") totalB++;
            else if (e.Literal == "C") totalC++;
            else totalReprobados++;
        }

        Console.WriteLine("==========================================================================");
        Console.WriteLine("Estudiantes en A: " + totalA);
        Console.WriteLine("Estudiantes en B: " + totalB);
        Console.WriteLine("Estudiantes en C: " + totalC);
        Console.WriteLine("Estudiantes Reprobados: " + totalReprobados);

        Console.ReadKey();
    }
}
