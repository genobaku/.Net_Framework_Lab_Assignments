namespace Assignment5;

public static class Question4
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("=== Q4: Calculator ===");

        Console.Write("Enter first number: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter second number: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Choose operation (+, -, *, /): ");
        char op = Convert.ToChar(Console.ReadLine() ?? "+");

        double result = 0;

        switch (op)
        {
            case '+':
                result = a + b;
                break;
            case '-':
                result = a - b;
                break;
            case '*':
                result = a * b;
                break;
            case '/':
                if (b == 0)
                {
                    Console.WriteLine("Division by zero is invalid.");
                    return;
                }
                result = a / b;
                break;
            default:
                Console.WriteLine("Invalid operator selected.");
                return;
        }

        Console.WriteLine($"Result: {result}");
    }
}
