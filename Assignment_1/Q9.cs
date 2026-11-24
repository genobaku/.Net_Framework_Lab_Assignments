using System;

namespace Assignment1;

public static class Q9
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("=== Q9: Palindrome Number ===");

        int num, rem, rev = 0, temp;

        Console.Write("Enter a Number: ");
        num = Convert.ToInt32(Console.ReadLine());
        temp = num;

        while (num > 0)
        {
            rem = num % 10;
            rev = rev * 10 + rem;
            num = num / 10;
        }

        if (temp == rev)
            Console.WriteLine("Palindrome Number");
        else
            Console.WriteLine("Not a Palindrome Number");
    }
}
