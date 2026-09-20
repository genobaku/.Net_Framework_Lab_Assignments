using System;

class EvenOdd
{
    static void Main()
    {
        int n;

        Console.Write("Enter N: ");
        n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nEven Numbers:");
        for (int i = 1; i <= n; i++)
        {
            if (i % 2 == 0)
                Console.Write(i + " ");
        }

        Console.WriteLine("\n\nOdd Numbers:");
        for (int i = 1; i <= n; i++)
        {
            if (i % 2 != 0)
                Console.Write(i + " ");
        }
    }
}
