using System;


public abstract class Character
{
    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        string tipo = this.GetType().Name;
        return $"Character is a {tipo}";
    }

    public abstract int DamagePoints(Character objetivo);
}


public class Warrior : Character
{
    public override int DamagePoints(Character objetivo)
    {
        if (objetivo.Vulnerable())
        {
            return 10;
        }
        else
        {
            return 6;
        }
    }
}


public class Wizard : Character
{
    private bool encantamientoPreprado;

    public Wizard()
    {
        encantamientoPreprado = false;
    }

    public void PrepareSpell()
    {
        encantamientoPreprado = true;
    }

    public override bool Vulnerable()
    {
        return !encantamientoPreprado;
    }

    public override int DamagePoints(Character objetivo)
    {
        if (encantamientoPreprado)
        {
            return 12;
        }
        else
        {
            return 3;
        }
    }
}

class Program
{
    static void Main()
    {
        
        Console.WriteLine("=== Tarea 1: ToString() ===");
        Character guerrero = new Warrior();
        Character mago = new Wizard();
        Console.WriteLine(guerrero.ToString());
        Console.WriteLine(mago.ToString());
        

       
        Console.WriteLine("\n=== Tarea 2: Vulnerable() ===");
        Console.WriteLine($"¿Guerrero vulnerable? {guerrero.Vulnerable()}");
       

      
        Console.WriteLine("\n=== Tarea 3: PrepareSpell() ===");
        var magoSinPreparacion = new Wizard();
        Console.WriteLine($"Mago sin preparación - ¿Vulnerable? {magoSinPreparacion.Vulnerable()}");
        magoSinPreparacion.PrepareSpell();
        Console.WriteLine($"Mago con hechizo preparado - ¿Vulnerable? {magoSinPreparacion.Vulnerable()}");

        
        Console.WriteLine("\n=== Tarea 4: Vulnerable() en Wizard ===");
        var magoNuevo = new Wizard();
        Console.WriteLine($"Mago nuevo (sin hechizo) ¿Vulnerable? {magoNuevo.Vulnerable()}");
        

       
        Console.WriteLine("\n=== Tarea 5: Wizard.DamagePoints() ===");
        var magoConHechizo = new Wizard();
        var magoSinHechizo = new Wizard();
        var guerreroObjetivo = new Warrior();

        magoConHechizo.PrepareSpell();
        Console.WriteLine($"Mago con hechizo vs Guerrero: {magoConHechizo.DamagePoints(guerreroObjetivo)} daño");
       
        Console.WriteLine($"Mago sin hechizo vs Guerrero: {magoSinHechizo.DamagePoints(guerreroObjetivo)} daño");
        

        
        Console.WriteLine("\n=== Tarea 6: Warrior.DamagePoints() ===");
        var guerreroAtaque = new Warrior();
        var magoVulnerable = new Wizard(); 
        var magoProtegido = new Wizard();
        magoProtegido.PrepareSpell();

        Console.WriteLine($"Guerrero vs Mago vulnerable (sin hechizo): {guerreroAtaque.DamagePoints(magoVulnerable)} daño");
        
        Console.WriteLine($"Guerrero vs Mago protegido (con hechizo): {guerreroAtaque.DamagePoints(magoProtegido)} daño");
        

        
        Console.WriteLine("\n=== Escenario completo ===");
        var w1 = new Warrior();
        var w2 = new Wizard();
        Console.WriteLine($"{w1.ToString()} ataca a {w2.ToString()}");
        Console.WriteLine($"Wizard vulnerable? {w2.Vulnerable()}");
        Console.WriteLine($"Daño infligido: {w1.DamagePoints(w2)}");

        w2.PrepareSpell();
        Console.WriteLine($"\nWizard prepara hechizo");
        Console.WriteLine($"Wizard vulnerable? {w2.Vulnerable()}");
        Console.WriteLine($"Daño infligido por guerrero: {w1.DamagePoints(w2)}");
        Console.WriteLine($"Daño infligido por mago: {w2.DamagePoints(w1)}");
    }
}
