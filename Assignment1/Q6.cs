using System;

namespace Assignment1;

public static class Q6
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("=== Q6: Even and Odd Numbers ===");

        int n;

        Console.Write("Enter N: ");
        n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Even Numbers:");
        for (int i = 1; i <= n; i++)
        {
            if (i % 2 == 0)
                Console.Write(i + " ");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Odd Numbers:");
        for (int i = 1; i <= n; i++)
        {
            if (i % 2 != 0)
                Console.Write(i + " ");
        }
    }
}
