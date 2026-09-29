using System;
using System.Text;

public class Identifier
{
    public static string Clean(string identificador)
    {
       
        StringBuilder resultado = new StringBuilder();
        
        
        bool convertirASiguiente = false;

        
        foreach (char caracter in identificador)
        {
           
            if (caracter == ' ')
            {
                resultado.Append('_');
            }
            
            else if (Char.IsControl(caracter))
            {
                resultado.Append("CTRL");
            }
            
            else if (caracter == '-')
            {
               
                convertirASiguiente = true;
            }
            
            else if (!Char.IsLetter(caracter) && caracter != '_')
            {
                
                continue;
            }
           
            else if (caracter >= 'α' && caracter <= 'ω')
            {
                
                continue;
            }
            else
            {
                
                if (convertirASiguiente && Char.IsLetter(caracter))
                {
                    
                    resultado.Append(Char.ToUpper(caracter));
                    convertirASiguiente = false;
                }
                else
                {
                    
                    resultado.Append(caracter);
                }
            }
        }

        return resultado.ToString();
    }
}

class Program
{
    static void Main()
    {
        
        Console.WriteLine("=== Tarea 1: Espacios a guiones bajos ===");
        Console.WriteLine(Identifier.Clean("my   Id"));
        

        
        Console.WriteLine("\n=== Tarea 2: Caracteres de control ===");
        Console.WriteLine(Identifier.Clean("my\0Id"));
      

       
        Console.WriteLine("\n=== Tarea 3: Kebab-case a camelCase ===");
        Console.WriteLine(Identifier.Clean("à-ḃç"));
        

        
        Console.WriteLine("\n=== Tarea 4: Omitir caracteres no-letra ===");
        Console.WriteLine(Identifier.Clean("123"));
        

        
        Console.WriteLine("\n=== Tarea 5: Omitir letras griegas ===");
        Console.WriteLine(Identifier.Clean("MyΟβιεγτFinder"));
        

        
        Console.WriteLine("\n=== Pruebas combinadas ===");
        Console.WriteLine(Identifier.Clean("hello-world"));
      

        Console.WriteLine(Identifier.Clean("my var"));
       

        Console.WriteLine(Identifier.Clean(""));
       
    }
}