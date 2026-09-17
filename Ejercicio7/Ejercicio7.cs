public class RemoteControlCar
{
    private int _distanciaMetros = 0;
    private int _porcentajeBateria = 100;

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_distanciaMetros} meters";
    }

    public string BatteryDisplay()
    {
        if (_porcentajeBateria == 0)
            return "Battery empty";
        
        return $"Battery at {_porcentajeBateria}%";
    }

    public void Drive()
    {
        if (_porcentajeBateria > 0)
        {
            _distanciaMetros += 20;
            _porcentajeBateria -= 1;
        }
    }

    public static void Main()
    {
        var coche = RemoteControlCar.Buy();
        Console.WriteLine(coche.DistanceDisplay());
        Console.WriteLine(coche.BatteryDisplay());
    }
}