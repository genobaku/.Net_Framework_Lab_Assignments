namespace Assignment5;

public static class Question10
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("=== Q10: OOP / Polymorphism Demo ===");

        Shape[] shapes =
        {
            new Circle(5),
            new Rectangle(4, 6),
            new Triangle(3, 8)
        };

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetType().Name} area: {shape.CalculateArea():F2}");
        }

        Console.WriteLine();
        BankAccount account = new("Student Savings");
        account.Deposit(5000);
        account.Withdraw(1500);
        Console.WriteLine(account.GetBalance());
    }
}

public abstract class Shape
{
    public abstract double CalculateArea();
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

public class Triangle : Shape
{
    public double Base { get; set; }
    public double Height { get; set; }

    public Triangle(double baseValue, double height)
    {
        Base = baseValue;
        Height = height;
    }

    public override double CalculateArea()
    {
        return 0.5 * Base * Height;
    }
}

public class BankAccount
{
    public string AccountName { get; set; }
    private double Balance { get; set; }

    public BankAccount(string accountName)
    {
        AccountName = accountName;
        Balance = 0;
    }

    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Deposit amount must be greater than zero.");
            return;
        }

        Balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdraw amount must be greater than zero.");
            return;
        }

        if (amount > Balance)
        {
            Console.WriteLine("Insufficient balance.");
            return;
        }

        Balance -= amount;
    }

    public string GetBalance()
    {
        return $"{AccountName} current balance: {Balance:C}";
    }
}
