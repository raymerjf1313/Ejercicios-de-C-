using System;

// Enum para los niveles de log
public enum NivelLog
{
    Desconocido = 0,
    Traza = 1,
    Depuracion = 2,
    Informacion = 4,
    Advertencia = 5,
    Error = 6,
    Fatal = 42
}

public class LineasLog
{
    public static NivelLog ParsearNivelLog(string linea)
    {
        int posicionInicio = linea.IndexOf("[") + 1;
        int posicionFin = linea.IndexOf("]");
        string codigoNivel = linea.Substring(posicionInicio, posicionFin - posicionInicio);

        return codigoNivel switch
        {
            "TRC" => NivelLog.Traza,
            "DBG" => NivelLog.Depuracion,
            "INF" => NivelLog.Informacion,
            "WRN" => NivelLog.Advertencia,
            "ERR" => NivelLog.Error,
            "FTL" => NivelLog.Fatal,
            _ => NivelLog.Desconocido
        };
    }

    public static string SalidaParaRegistroCorto(NivelLog nivel, string mensaje)
    {
        int codigoNumerado = (int)nivel;
        return $"{codigoNumerado}:{mensaje}";
    }
}

class Program
{
    static void Main()
    {
        // Prueba 1: Parsear niveles conocidos
        Console.WriteLine("=== Tarea 1 y 2: ParsearNivelLog ===");
        Console.WriteLine($"[TRC]: Traza inicial => {LineasLog.ParsearNivelLog("[TRC]: Traza inicial")}");
        Console.WriteLine($"[DBG]: Depurando => {LineasLog.ParsearNivelLog("[DBG]: Depurando")}");
        Console.WriteLine($"[INF]: Archivo eliminado => {LineasLog.ParsearNivelLog("[INF]: Archivo eliminado")}");
        Console.WriteLine($"[WRN]: Memoria baja => {LineasLog.ParsearNivelLog("[WRN]: Memoria baja")}");
        Console.WriteLine($"[ERR]: Stack overflow => {LineasLog.ParsearNivelLog("[ERR]: Stack overflow")}");
        Console.WriteLine($"[FTL]: Sistema caído => {LineasLog.ParsearNivelLog("[FTL]: Sistema caído")}");
        // Esperado: Traza, Depuracion, Informacion, Advertencia, Error, Fatal

        // Prueba 2: Parsear nivel desconocido
        Console.WriteLine("\n=== Nivel desconocido ===");
        Console.WriteLine($"[XYZ]: Mensaje raro => {LineasLog.ParsearNivelLog("[XYZ]: Mensaje raro")}");
        // Esperado: Desconocido

        // Prueba 3: Salida para registro corto
        Console.WriteLine("\n=== Tarea 3: SalidaParaRegistroCorto ===");
        Console.WriteLine($"Desconocido: {LineasLog.SalidaParaRegistroCorto(NivelLog.Desconocido, "Mensaje desconocido")}");
        Console.WriteLine($"Traza: {LineasLog.SalidaParaRegistroCorto(NivelLog.Traza, "Iniciando")}");
        Console.WriteLine($"Depuración: {LineasLog.SalidaParaRegistroCorto(NivelLog.Depuracion, "Punto de ruptura")}");
        Console.WriteLine($"Información: {LineasLog.SalidaParaRegistroCorto(NivelLog.Informacion, "Archivo eliminado")}");
        Console.WriteLine($"Advertencia: {LineasLog.SalidaParaRegistroCorto(NivelLog.Advertencia, "Memoria baja")}");
        Console.WriteLine($"Error: {LineasLog.SalidaParaRegistroCorto(NivelLog.Error, "Stack overflow")}");
        Console.WriteLine($"Fatal: {LineasLog.SalidaParaRegistroCorto(NivelLog.Fatal, "Sistema caído")}");
        // Esperado: 0:, 1:, 2:, 4:, 5:, 6:, 42:

        // Prueba 4: Flujo completo
        Console.WriteLine("\n=== Flujo completo ===");
        string linea = "[ERR]: Stack overflow";
        NivelLog nivel = LineasLog.ParsearNivelLog(linea);
        string registroCorto = LineasLog.SalidaParaRegistroCorto(nivel, "Stack overflow");
        Console.WriteLine($"Línea original: {linea}");
        Console.WriteLine($"Nivel parseado: {nivel}");
        Console.WriteLine($"Registro corto: {registroCorto}");
    }
}