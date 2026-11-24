using System;

namespace Assignment1;

public static class Q7
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("=== Q7: Factorial ===");

        int n;
        long fact = 1;

        Console.Write("Enter a Number: ");
        n = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            fact = fact * i;
        }

        Console.WriteLine("Factorial = " + fact);
    }
}
