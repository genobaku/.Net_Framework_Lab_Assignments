using System;

namespace Assignment3;

internal class Program
{
    private static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("        Assignment 3 Menu");
            Console.WriteLine("====================================");
            Console.WriteLine("1. Student Details");
            Console.WriteLine("2. Sum of Numbers");
            Console.WriteLine("3. Even or Odd");
            Console.WriteLine("4. Largest of Three Numbers");
            Console.WriteLine("5. Factorial");
            Console.WriteLine("0. Exit");
            Console.WriteLine("====================================");
            Console.Write("Choose an option: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StudentDetails();
                    break;
                case "2":
                    SumOfNumbers();
                    break;
                case "3":
                    EvenOrOdd();
                    break;
                case "4":
                    LargestOfThree();
                    break;
                case "5":
                    Factorial();
                    break;
                case "0":
                    Console.WriteLine("\nProgram ended.");
                    return;
                default:
                    Console.WriteLine("\nInvalid option. Try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    private static void StudentDetails()
    {
        Console.Clear();
        Console.WriteLine("=== Student Details ===");

        Console.Write("Enter name: ");
        string name = Console.ReadLine() ?? "Unknown";

        Console.Write("Enter roll number: ");
        int rollNumber = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter marks: ");
        double marks = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Student Information");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Roll Number: {rollNumber}");
        Console.WriteLine($"Marks: {marks}");
    }

    private static void SumOfNumbers()
    {
        Console.Clear();
        Console.WriteLine("=== Sum of Numbers ===");

        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int sum = 0;
        for (int i = 1; i <= n; i++)
        {
            sum += i;
        }

        Console.WriteLine($"Sum of numbers from 1 to {n} is: {sum}");
    }

    private static void EvenOrOdd()
    {
        Console.Clear();
        Console.WriteLine("=== Even or Odd ===");

        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number % 2 == 0)
        {
            Console.WriteLine($"{number} is Even.");
        }
        else
        {
            Console.WriteLine($"{number} is Odd.");
        }
    }

    private static void LargestOfThree()
    {
        Console.Clear();
        Console.WriteLine("=== Largest of Three Numbers ===");

        Console.Write("Enter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter third number: ");
        int c = Convert.ToInt32(Console.ReadLine());

        int largest = a;
        if (b > largest)
        {
            largest = b;
        }
        if (c > largest)
        {
            largest = c;
        }

        Console.WriteLine($"The largest number is: {largest}");
    }

    private static void Factorial()
    {
        Console.Clear();
        Console.WriteLine("=== Factorial ===");

        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        long factorial = 1;
        for (int i = 1; i <= number; i++)
        {
            factorial *= i;
        }

        Console.WriteLine($"Factorial of {number} is: {factorial}");
    }
}
