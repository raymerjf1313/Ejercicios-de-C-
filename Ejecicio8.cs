public static class LogAnalysis
{
    public static string SubstringAfter(this string texto, string delimitador)
    {
        int indice = texto.IndexOf(delimitador);
        if (indice == -1)
            return texto;
        
        return texto.Substring(indice + delimitador.Length);
    }

    public static string SubstringBetween(this string texto, string delimitadorInicio, string delimitadorFin)
    {
        int indiceInicio = texto.IndexOf(delimitadorInicio);
        int indiceFin = texto.IndexOf(delimitadorFin, indiceInicio + delimitadorInicio.Length);
        
        if (indiceInicio == -1 || indiceFin == -1)
            return "";
        
        return texto.Substring(indiceInicio + delimitadorInicio.Length, indiceFin - indiceInicio - delimitadorInicio.Length);
    }

    public static string Message(this string texto)
    {
        return texto.SubstringAfter(": ");
    }

    public static string LogLevel(this string texto)
    {
        return texto.SubstringBetween("[", "]");
    }

    public static void Main()
    {
        var registro = "[ERROR]: Missing ; on line 20.";
        Console.WriteLine(registro.LogLevel());    // => "ERROR"
        Console.WriteLine(registro.Message());     // => "Missing ; on line 20."
    }
}