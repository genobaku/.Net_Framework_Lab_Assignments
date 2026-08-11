using System;

class Factorial
{
    static void Main()
    {
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
