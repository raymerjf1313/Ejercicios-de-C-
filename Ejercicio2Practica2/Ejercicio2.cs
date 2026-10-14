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

            Console.Write("Apellido: ");
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

        Console.ReadKey();
    }
}