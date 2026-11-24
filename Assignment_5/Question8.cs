namespace Assignment5;

public static class Question8
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("=== Q8: Method Overloading ===");

        PrintValue(10);
        PrintValue(15.5);
        PrintValue("Hello from Assignment 5");
    }

    public static void PrintValue(int number)
    {
        Console.WriteLine($"Integer value: {number}");
    }

    public static void PrintValue(double number)
    {
        Console.WriteLine($"Double value: {number}");
    }

    public static void PrintValue(string text)
    {
        Console.WriteLine($"String value: {text}");
    }
}
