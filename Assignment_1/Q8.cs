using System;

namespace Assignment1;

public static class Q8
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("=== Q8: Prime Number ===");

        int n, count = 0;

        Console.Write("Enter a Number: ");
        n = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0)
                count++;
        }

        if (count == 2)
            Console.WriteLine("Prime Number");
        else
            Console.WriteLine("Not Prime Number");
    }
}
