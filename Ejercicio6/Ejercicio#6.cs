public static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        if (balance < 0)
            return 3.213f;
        else if (balance < 1000)
            return 0.5f;
        else if (balance < 5000)
            return 1.621f;
        else
            return 2.475f;
    }

    public static decimal Interest(decimal balance)
    {
        return balance * (decimal)InterestRate(balance) / 100;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years = 0;
        while (balance < targetBalance)
        {
            balance = AnnualBalanceUpdate(balance);
            years++;
        }
        return years;
    }
}

class Program
{
    static void Main()
    {
        // Pruebas
        Console.WriteLine(SavingsAccount.InterestRate(-100));
        Console.WriteLine(SavingsAccount.InterestRate(500));
        Console.WriteLine(SavingsAccount.InterestRate(2000));
        Console.WriteLine(SavingsAccount.InterestRate(6000));
        
        Console.WriteLine(SavingsAccount.Interest(100));
        Console.WriteLine(SavingsAccount.Interest(1000));
        
        Console.WriteLine(SavingsAccount.AnnualBalanceUpdate(100));
        Console.WriteLine(SavingsAccount.AnnualBalanceUpdate(1000));
        
        Console.WriteLine(SavingsAccount.YearsBeforeDesiredBalance(100, 200));
        Console.WriteLine(SavingsAccount.YearsBeforeDesiredBalance(1000, 5000));
    }
}