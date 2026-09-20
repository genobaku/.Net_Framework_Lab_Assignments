using System;

namespace Assignment4;

internal class Program
{
    private static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("       Random Assignment 4 Menu");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Student Registration");
            Console.WriteLine("2. Simple Calculator");
            Console.WriteLine("3. Array Analysis");
            Console.WriteLine("4. Employee Details");
            Console.WriteLine("5. Number Guessing Game");
            Console.WriteLine("6. OOP Shape Demo");
            Console.WriteLine("0. Exit");
            Console.WriteLine("========================================");
            Console.Write("Choose an option: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StudentRegistration();
                    break;
                case "2":
                    Calculator();
                    break;
                case "3":
                    ArrayAnalysis();
                    break;
                case "4":
                    EmployeeDetails();
                    break;
                case "5":
                    NumberGuessingGame();
                    break;
                case "6":
                    ShapeDemo();
                    break;
                case "0":
                    Console.WriteLine("\nAssignment 4 closed.");
                    return;
                default:
                    Console.WriteLine("\nInvalid option. Try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    private static void StudentRegistration()
    {
        Console.Clear();
        Console.WriteLine("=== Student Registration ===");

        Console.Write("Enter student name: ");
        string name = Console.ReadLine() ?? "Unknown";

        Console.Write("Enter roll number: ");
        int rollNo = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter course: ");
        string course = Console.ReadLine() ?? "N/A";

        Console.WriteLine();
        Console.WriteLine("Registration Successful");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Roll Number: {rollNo}");
        Console.WriteLine($"Course: {course}");
    }

    private static void Calculator()
    {
        Console.Clear();
        Console.WriteLine("=== Calculator ===");

        Console.Write("Enter first number: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter second number: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Choose operator (+, -, *, /): ");
        char op = Convert.ToChar(Console.ReadLine() ?? "+");

        double result = 0;

        switch (op)
        {
            case '+':
                result = a + b;
                break;
            case '-':
                result = a - b;
                break;
            case '*':
                result = a * b;
                break;
            case '/':
                if (b == 0)
                {
                    Console.WriteLine("Division by zero is not allowed.");
                    return;
                }
                result = a / b;
                break;
            default:
                Console.WriteLine("Invalid operator.");
                return;
        }

        Console.WriteLine($"Result: {result}");
    }

    private static void ArrayAnalysis()
    {
        Console.Clear();
        Console.WriteLine("=== Array Analysis ===");

        Console.Write("How many values? ");
        int size = Convert.ToInt32(Console.ReadLine());

        int[] values = new int[size];
        int sum = 0;
        int max = int.MinValue;
        int min = int.MaxValue;

        for (int i = 0; i < size; i++)
        {
            Console.Write($"Enter value {i + 1}: ");
            values[i] = Convert.ToInt32(Console.ReadLine());
            sum += values[i];

            if (values[i] > max)
                max = values[i];

            if (values[i] < min)
                min = values[i];
        }

        Console.WriteLine();
        Console.WriteLine("Values entered: " + string.Join(", ", values));
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {(double)sum / size:F2}");
        Console.WriteLine($"Maximum: {max}");
        Console.WriteLine($"Minimum: {min}");
    }

    private static void EmployeeDetails()
    {
        Console.Clear();
        Console.WriteLine("=== Employee Details ===");

        Employee employee = new Employee();

        Console.Write("Enter employee name: ");
        employee.Name = Console.ReadLine() ?? "Unknown";

        Console.Write("Enter employee ID: ");
        employee.Id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter salary: ");
        employee.Salary = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Employee Information");
        Console.WriteLine($"Name: {employee.Name}");
        Console.WriteLine($"ID: {employee.Id}");
        Console.WriteLine($"Salary: {employee.Salary:C}");
    }

    private static void NumberGuessingGame()
    {
        Console.Clear();
        Console.WriteLine("=== Number Guessing Game ===");

        Random random = new Random();
        int target = random.Next(1, 101);
        int attempts = 0;

        while (true)
        {
            Console.Write("Guess a number between 1 and 100: ");
            int guess = Convert.ToInt32(Console.ReadLine());
            attempts++;

            if (guess < target)
            {
                Console.WriteLine("Too low. Try again.");
            }
            else if (guess > target)
            {
                Console.WriteLine("Too high. Try again.");
            }
            else
            {
                Console.WriteLine($"Correct! You guessed it in {attempts} attempts.");
                break;
            }
        }
    }

    private static void ShapeDemo()
    {
        Console.Clear();
        Console.WriteLine("=== Shape Demo ===");

        Shape[] shapes =
        {
            new Circle(5),
            new Rectangle(4, 6),
            new Triangle(3, 8)
        };

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetType().Name}: Area = {shape.CalculateArea():F2}");
        }
    }
}

public class Employee
{
    public string Name { get; set; } = "";
    public int Id { get; set; }
    public double Salary { get; set; }
}

public abstract class Shape
{
    public abstract double CalculateArea();
}

public class Circle : Shape
{
    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Radius { get; set; }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

public class Rectangle : Shape
{
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double Width { get; set; }
    public double Height { get; set; }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

public class Triangle : Shape
{
    public Triangle(double baseValue, double height)
    {
        Base = baseValue;
        Height = height;
    }

    public double Base { get; set; }
    public double Height { get; set; }

    public override double CalculateArea()
    {
        return 0.5 * Base * Height;
    }
}
