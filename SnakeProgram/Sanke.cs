using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;

        
        int ancho = 30;
        int alto = 15;

       
        List<int> serpienteX = new List<int>();
        List<int> serpienteY = new List<int>();
        serpienteX.Add(ancho / 2);
        serpienteY.Add(alto / 2);

        
        int direccionX = 1;
        int direccionY = 0;

        
        Random aleatorio = new Random();
        int comidaX = aleatorio.Next(1, ancho - 1);
        int comidaY = aleatorio.Next(1, alto - 1);

        int puntos = 0;
        bool juegoTerminado = false;

        Console.Clear();

        while (!juegoTerminado)
        {
            
            if (Console.KeyAvailable)
            {
                ConsoleKey tecla = Console.ReadKey(true).Key;

                if (tecla == ConsoleKey.UpArrow && direccionY != 1)
                {
                    direccionX = 0;
                    direccionY = -1;
                }
                else if (tecla == ConsoleKey.DownArrow && direccionY != -1)
                {
                    direccionX = 0;
                    direccionY = 1;
                }
                else if (tecla == ConsoleKey.LeftArrow && direccionX != 1)
                {
                    direccionX = -1;
                    direccionY = 0;
                }
                else if (tecla == ConsoleKey.RightArrow && direccionX != -1)
                {
                    direccionX = 1;
                    direccionY = 0;
                }
            }

           
            int nuevaX = serpienteX[0] + direccionX;
            int nuevaY = serpienteY[0] + direccionY;

            
            bool choque = false;

            if (nuevaX <= 0 || nuevaX >= ancho - 1 || nuevaY <= 0 || nuevaY >= alto - 1)
            {
                choque = true;
            }

          
            for (int i = 0; i < serpienteX.Count; i++)
            {
                if (serpienteX[i] == nuevaX && serpienteY[i] == nuevaY)
                {
                    choque = true;
                }
            }

            if (choque)
            {
                juegoTerminado = true;
            }
            else
            {
                
                serpienteX.Insert(0, nuevaX);
                serpienteY.Insert(0, nuevaY);

                if (nuevaX == comidaX && nuevaY == comidaY)
                {
                    
                    puntos++;

                  
                    bool lugarLibre = false;

                    while (!lugarLibre)
                    {
                        comidaX = aleatorio.Next(1, ancho - 1);
                        comidaY = aleatorio.Next(1, alto - 1);
                        lugarLibre = true;

                        for (int i = 0; i < serpienteX.Count; i++)
                        {
                            if (serpienteX[i] == comidaX && serpienteY[i] == comidaY)
                            {
                                lugarLibre = false;
                            }
                        }
                    }
                }
                else
                {
                   
                    serpienteX.RemoveAt(serpienteX.Count - 1);
                    serpienteY.RemoveAt(serpienteY.Count - 1);
                }
            }

         
            Console.SetCursorPosition(0, 0);
            string pantalla = "";

            for (int y = 0; y < alto; y++)
            {
                for (int x = 0; x < ancho; x++)
                {
                    string celda = " ";

                    if (x == 0 || x == ancho - 1 || y == 0 || y == alto - 1)
                    {
                        celda = "#";
                    }
                    else if (x == comidaX && y == comidaY)
                    {
                        celda = "*";
                    }
                    else
                    {
                        for (int i = 0; i < serpienteX.Count; i++)
                        {
                            if (serpienteX[i] == x && serpienteY[i] == y)
                            {
                                if (i == 0)
                                {
                                    celda = "O";
                                }
                                else
                                {
                                    celda = "o";
                                }
                            }
                        }
                    }

                    pantalla = pantalla + celda;
                }

                pantalla = pantalla + Environment.NewLine;
            }

            Console.Write(pantalla);
            Console.WriteLine("Puntos: " + puntos);

            
            Thread.Sleep(150);
        }

        Console.WriteLine();
        Console.WriteLine("¡Juego terminado! Puntos finales: " + puntos);
        Console.ReadKey();
    }
}
