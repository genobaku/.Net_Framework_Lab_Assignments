using System;

namespace Assignment5;

internal class Program
{
    private static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        C# Assignment 5 Menu");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Student Details");
            Console.WriteLine("2. Arithmetic Operations");
            Console.WriteLine("3. Number Check");
            Console.WriteLine("4. Calculator");
            Console.WriteLine("5. Array Operations");
            Console.WriteLine("6. Employee Class");
            Console.WriteLine("7. Inheritance Demo");
            Console.WriteLine("8. Method Overloading");
            Console.WriteLine("9. Exception Handling");
            Console.WriteLine("10. OOP / Polymorphism Demo");
            Console.WriteLine("0. Exit");
            Console.WriteLine("========================================");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Question1.Run();
                    break;
                case "2":
                    Question2.Run();
                    break;
                case "3":
                    Question3.Run();
                    break;
                case "4":
                    Question4.Run();
                    break;
                case "5":
                    Question5.Run();
                    break;
                case "6":
                    Question6.Run();
                    break;
                case "7":
                    Question7.Run();
                    break;
                case "8":
                    Question8.Run();
                    break;
                case "9":
                    Question9.Run();
                    break;
                case "10":
                    Question10.Run();
                    break;
                case "0":
                    Console.WriteLine("\nThank you for completing Assignment 5.");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
