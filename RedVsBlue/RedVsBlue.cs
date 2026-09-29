using System;
using System.Reflection;
using Red = RedRemoteControlCarTeam;
using Blue = BlueRemoteControlCarTeam;

namespace RedRemoteControlCarTeam
{
    public class Motor
    {
        private int revoluciones = 0;

        public int Revoluciones
        {
            get { return revoluciones; }
            set { revoluciones = value; }
        }
    }

    public class Telemetria
    {
        private string estadoActual = "";

        public string EstadoActual
        {
            get { return estadoActual; }
            set { estadoActual = value; }
        }
    }

    public class RemoteControlCar
    {
        private Motor motor;
        private Telemetria telemetria;

        public RemoteControlCar()
        {
            motor = new Motor();
            telemetria = new Telemetria();
        }

        public Motor Motor
        {
            get { return motor; }
        }

        public Telemetria Telemetria
        {
            get { return telemetria; }
        }
    }
}

namespace BlueRemoteControlCarTeam
{
    public class Motor
    {
        private int revoluciones = 0;

        public int Revoluciones
        {
            get { return revoluciones; }
            set { revoluciones = value; }
        }
    }

    public class Telemetria
    {
        private string estadoActual = "";

        public string EstadoActual
        {
            get { return estadoActual; }
            set { estadoActual = value; }
        }
    }

    public class RemoteControlCar
    {
        private Motor motor;
        private Telemetria telemetria;

        public RemoteControlCar()
        {
            motor = new Motor();
            telemetria = new Telemetria();
        }

        public Motor Motor
        {
            get { return motor; }
        }

        public Telemetria Telemetria
        {
            get { return telemetria; }
        }
    }
}

namespace Combined
{
    public class CarBuilder
    {
        public static RedRemoteControlCarTeam.RemoteControlCar BuildRed()
        {
            return new RedRemoteControlCarTeam.RemoteControlCar();
        }

        public static BlueRemoteControlCarTeam.RemoteControlCar BuildBlue()
        {
            return new BlueRemoteControlCarTeam.RemoteControlCar();
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Acceso directo ===");
        var autoRojo = Combined.CarBuilder.BuildRed();
        var autoAzul = Combined.CarBuilder.BuildBlue();

        autoRojo.Motor.Revoluciones = 5000;
        autoAzul.Motor.Revoluciones = 6000;

        Console.WriteLine($"Rojo: {autoRojo.Motor.Revoluciones} RPM");
        Console.WriteLine($"Azul: {autoAzul.Motor.Revoluciones} RPM");

        Console.WriteLine("\n=== Usando Reflexión (Reflection) ===");
        
        var tipoCarBuilder = Type.GetType("Combined.CarBuilder");
        Console.WriteLine($"Tipo encontrado: {tipoCarBuilder}");

        var metodoRojo = tipoCarBuilder?.GetMethod("BuildRed");
        Console.WriteLine($"Método BuildRed: {metodoRojo?.Name}");
        Console.WriteLine($"Retorna: {metodoRojo?.ReturnType.FullName}");

        var metodoAzul = tipoCarBuilder?.GetMethod("BuildBlue");
        Console.WriteLine($"Método BuildBlue: {metodoAzul?.Name}");
        Console.WriteLine($"Retorna: {metodoAzul?.ReturnType.FullName}");

        Console.WriteLine("\n=== Invocando métodos con Reflexión ===");
        var autoRojoReflection = metodoRojo?.Invoke(null, null);
        var autoAzulReflection = metodoAzul?.Invoke(null, null);

        Console.WriteLine($"Auto Rojo creado: {autoRojoReflection != null}");
        Console.WriteLine($"Auto Azul creado: {autoAzulReflection != null}");

        Console.WriteLine("\n=== Tipo de objeto con Reflexión ===");
        Console.WriteLine($"Tipo Rojo: {autoRojoReflection?.GetType().FullName}");
        Console.WriteLine($"Tipo Azul: {autoAzulReflection?.GetType().FullName}");

        Console.WriteLine("\n=== Listando métodos de CarBuilder ===");
        var metodos = tipoCarBuilder?.GetMethods(BindingFlags.Public | BindingFlags.Static);
        foreach (var metodo in metodos ?? new MethodInfo[0])
        {
            if (metodo.DeclaringType == tipoCarBuilder)
            {
                Console.WriteLine($"Método: {metodo.Name}, Retorna: {metodo.ReturnType.Name}");
            }
        }
    }
}