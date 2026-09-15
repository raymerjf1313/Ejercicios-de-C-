public class LogLine
{
    public static string Message(string linea)
    {
        int posicionInicio = linea.IndexOf(": ") + 2;
        return linea.Substring(posicionInicio).Trim();
    }

    public static string LogLevel(string linea)
    {
        int posicionInicio = linea.IndexOf("[") + 1;
        int posicionFin = linea.IndexOf("]");
        return linea.Substring(posicionInicio, posicionFin - posicionInicio).ToLower();
    }

    public static string Reformat(string linea)
    {
        return $"{Message(linea)} ({LogLevel(linea)})";
    }
}

class Program
{
    static void Main()
    {
        // Pruebas
        Console.WriteLine(LogLine.Message("[ERROR]: Invalid operation"));
        Console.WriteLine(LogLine.Message("[WARNING]:  Disk almost full\r\n"));
        
        Console.WriteLine(LogLine.LogLevel("[ERROR]: Invalid operation"));
        Console.WriteLine(LogLine.LogLevel("[WARNING]: Something"));
        
        Console.WriteLine(LogLine.Reformat("[INFO]: Operation completed"));
        Console.WriteLine(LogLine.Reformat("[ERROR]: Invalid operation"));
    }
}