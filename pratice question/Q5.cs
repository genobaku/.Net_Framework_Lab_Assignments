using System;

class Calculator
{
    static void Main()
    {
        int a, b, choice;

        Console.Write("Enter First Number: ");
        a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Second Number: ");
        b = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\n1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");

        Console.Write("Enter Choice: ");
        choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Sum = " + (a + b));
                break;
            case 2:
                Console.WriteLine("Difference = " + (a - b));
                break;
            case 3:
                Console.WriteLine("Product = " + (a * b));
                break;
            case 4:
                if (b != 0)
                    Console.WriteLine("Quotient = " + (a / b));
                else
                    Console.WriteLine("Division by zero not possible.");
                break;
            default:
                Console.WriteLine("Invalid Choice");
                break;
        }
    }
}
