using System;

namespace Assignment1;

internal class Program
{
    private static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("        Assignment 1 Menu");
            Console.WriteLine("====================================");
            Console.WriteLine("1. Student Details");
            Console.WriteLine("2. Arithmetic Operations");
            Console.WriteLine("3. Positive/Negative/Zero");
            Console.WriteLine("4. Grade Calculator");
            Console.WriteLine("5. Calculator");
            Console.WriteLine("6. Even and Odd Numbers");
            Console.WriteLine("7. Factorial");
            Console.WriteLine("8. Prime Number");
            Console.WriteLine("9. Palindrome Number");
            Console.WriteLine("10. Menu Program");
            Console.WriteLine("0. Exit");
            Console.WriteLine("====================================");
            Console.Write("Choose an option: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Q1.Run();
                    break;
                case "2":
                    Q2.Run();
                    break;
                case "3":
                    Q3.Run();
                    break;
                case "4":
                    Q4.Run();
                    break;
                case "5":
                    Q5.Run();
                    break;
                case "6":
                    Q6.Run();
                    break;
                case "7":
                    Q7.Run();
                    break;
                case "8":
                    Q8.Run();
                    break;
                case "9":
                    Q9.Run();
                    break;
                case "10":
                    Q10.Run();
                    break;
                case "0":
                    Console.WriteLine("\nProgram ended.");
                    return;
                default:
                    Console.WriteLine("\nInvalid option.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
