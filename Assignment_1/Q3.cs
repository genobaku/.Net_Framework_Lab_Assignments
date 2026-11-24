using System;

namespace Assignment1;

public static class Q3
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("=== Q3: Positive / Negative / Zero ===");

        int number;

        Console.Write("Enter a number: ");
        number = Convert.ToInt32(Console.ReadLine());

        if (number > 0)
        {
            Console.WriteLine("The number is Positive.");
        }
        else if (number < 0)
        {
            Console.WriteLine("The number is Negative.");
        }
        else
        {
            Console.WriteLine("The number is Zero.");
        }
    }
}
