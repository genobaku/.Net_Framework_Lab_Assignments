namespace Assignment5;

public static class Question2
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("=== Q2: Arithmetic Operations ===");

        Console.Write("Enter first number: ");
        double first = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter second number: ");
        double second = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine($"Sum: {first + second}");
        Console.WriteLine($"Difference: {first - second}");
        Console.WriteLine($"Product: {first * second}");

        if (second != 0)
        {
            Console.WriteLine($"Quotient: {first / second}");
            Console.WriteLine($"Remainder: {first % second}");
        }
        else
        {
            Console.WriteLine("Division by zero is not allowed.");
        }
    }
}
