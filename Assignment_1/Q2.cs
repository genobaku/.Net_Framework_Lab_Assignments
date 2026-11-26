    using System;

    namespace Assignment1;

    public static class Q2
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("=== Q2: Arithmetic Operations ===");

            int num1, num2;

            Console.Write("Enter First Number: ");
            num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Second Number: ");
            num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("----- Arithmetic Operations -----");
            Console.WriteLine("Sum = " + (num1 + num2));
            Console.WriteLine("Difference = " + (num1 - num2));
            Console.WriteLine("Product = " + (num1 * num2));

            if (num2 != 0)
            {
                Console.WriteLine("Quotient = " + (num1 / num2));
                Console.WriteLine("Remainder = " + (num1 % num2));
            }
            else
            {
                Console.WriteLine("Quotient = Cannot divide by zero.");
                Console.WriteLine("Remainder = Cannot divide by zero.");
            }
        }
    }
