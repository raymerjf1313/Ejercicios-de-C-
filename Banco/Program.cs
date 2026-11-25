

// CLASE ESTÁTICA (págs. 61-62): se usa sin instanciar
static class Utilidades {
    public static string Dinero(double monto) => "RD$ " + monto.ToString("N2");
    public static bool MontoValido(double monto) => monto > 0;
}

// CLASE con atributos privados, getters/setters y constructores (págs. 13-38)
class Cliente {
    private string nombre;
    public string Nombre {
        get { return nombre; }
        set {
            if (string.IsNullOrWhiteSpace(value)) Console.WriteLine("  Nombre vacío, no se asigna");
            else nombre = value;                               // el setter valida
        }
    }
    public string Cedula { get; }

    public Cliente(string nombre, string cedula) {             // constructor con parámetros
        Nombre = nombre;
        Cedula = cedula;
    }

    public Cliente Copiar() => new Cliente(Nombre, Cedula);    // copia profunda (pág. 36)
}

// CLASE ABSTRACTA (pág. 42): no se puede instanciar, solo heredar
abstract class Cuenta {
    // Atributo static + constructor static (págs. 64-66): numera las cuentas
    private static int ultimoNumero;
    static Cuenta() {
        ultimoNumero = 1000;
        Console.WriteLine("[Constructor static: contador de cuentas iniciado]");
    }

    public string Numero { get; }
    public Cliente Titular { get; }                            // referencia al objeto Cliente
    public double Saldo { get; protected set; }                // protected: solo la clase y sus hijas modifican

    protected Cuenta(Cliente titular, double saldoInicial) {
        ultimoNumero++;
        Numero = "CT-" + ultimoNumero;
        Titular = titular;
        Saldo = saldoInicial;
    }

    // SOBRECARGA (págs. 27-30): mismo nombre, distintos parámetros
    public void Depositar(double monto) {
        if (!Utilidades.MontoValido(monto)) { Console.WriteLine("  Monto inválido"); return; }
        Saldo += monto;
    }
    public void Depositar(double monto, string concepto) {
        Depositar(monto);
        Console.WriteLine($"  Depósito de {Utilidades.Dinero(monto)} ({concepto})");
    }

    // VIRTUAL (pág. 53): las hijas pueden cambiar la regla de retiro
    public virtual bool Retirar(double monto) {
        if (!Utilidades.MontoValido(monto) || monto > Saldo) {
            Console.WriteLine($"  Retiro rechazado en {Numero}: fondos insuficientes");
            return false;
        }
        Saldo -= monto;
        return true;
    }

    // ABSTRACT: cada tipo de cuenta define qué pasa a fin de mes
    public abstract void AplicarFinDeMes();

    public virtual string Resumen() => $"{Numero} | {Titular.Nombre} | Saldo: {Utilidades.Dinero(Saldo)}";
}

// HERENCIA (pág. 39) y override
class CuentaAhorro : Cuenta {
    protected double tasaMensual = 0.01;                       // protected: las hijas pueden cambiarla

    public CuentaAhorro(Cliente titular, double saldoInicial) : base(titular, saldoInicial) { }

    public override void AplicarFinDeMes() {
        double interes = Saldo * tasaMensual;
        Saldo += interes;
        Console.WriteLine($"  {Numero}: interés de {Utilidades.Dinero(interes)}");
    }
}

class CuentaCorriente : Cuenta {
    private double limiteSobregiro;

    public CuentaCorriente(Cliente titular, double saldoInicial, double limiteSobregiro)
        : base(titular, saldoInicial) {
        this.limiteSobregiro = limiteSobregiro;
    }

    // OVERRIDE: esta cuenta permite retirar más del saldo hasta el límite
    public override bool Retirar(double monto) {
        if (!Utilidades.MontoValido(monto) || monto > Saldo + limiteSobregiro) {
            Console.WriteLine($"  Retiro rechazado en {Numero}: excede el límite de sobregiro");
            return false;
        }
        Saldo -= monto;
        return true;
    }

    public override void AplicarFinDeMes() {
        Saldo -= 50;                                           // comisión fija
        Console.WriteLine($"  {Numero}: comisión de {Utilidades.Dinero(50)}");
    }
}

// SEALED (pág. 59): nadie puede heredar de CuentaPremium
sealed class CuentaPremium : CuentaAhorro {
    public CuentaPremium(Cliente titular, double saldoInicial) : base(titular, saldoInicial) {
        tasaMensual = 0.02;                                    // usa el atributo protected de la madre
    }

    // BASE (pág. 57): reutiliza el resumen de la madre y le agrega algo
    public override string Resumen() => base.Resumen() + " | PREMIUM";
}

class Program {
    static void Main() {
        Console.WriteLine("=== Apertura de cuentas ===");
        Cliente raymer = new Cliente("Raymer", "001-0000000-1");

        // Dos cuentas con el MISMO objeto Cliente (shallow copy, pág. 24)
        Cuenta ahorro = new CuentaAhorro(raymer, 10000);
        Cuenta corriente = new CuentaCorriente(raymer, 2000, 1500);

        // Otro cliente creado con Copiar() (deep copy): es un objeto independiente
        Cliente copia = raymer.Copiar();
        copia.Nombre = "Ana";
        Cuenta premium = new CuentaPremium(copia, 50000);

        // POLIMORFISMO (pág. 53): una lista de Cuenta con objetos de distintos tipos
        List<Cuenta> cuentas = new() { ahorro, corriente, premium };
        foreach (Cuenta c in cuentas) Console.WriteLine(c.Resumen());

        Console.WriteLine("\n=== Operaciones ===");
        ahorro.Depositar(500, "salario");                      // sobrecarga con concepto
        corriente.Retirar(3000);                               // usa sobregiro (override)
        ahorro.Retirar(20000);                                 // rechazado (regla de la base)
        corriente.Retirar(2000);                               // excede el límite

        Console.WriteLine("\n=== Fin de mes ===");
        foreach (Cuenta c in cuentas) c.AplicarFinDeMes();     // cada una hace lo suyo

        Console.WriteLine("\n=== Referencia compartida ===");
        raymer.Nombre = "Raymer Pérez";                        // cambia el objeto compartido
        Console.WriteLine(ahorro.Resumen());
        Console.WriteLine(corriente.Resumen());                // ambas cuentas ven el cambio
        Console.WriteLine(premium.Resumen());                  // Ana no cambió: es una copia

        Console.WriteLine("\n=== Resumen final ===");
        double total = 0;
        foreach (Cuenta c in cuentas) total += c.Saldo;
        Console.WriteLine($"Total en el banco: {Utilidades.Dinero(total)}");
    }
}
