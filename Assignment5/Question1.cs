namespace Assignment5;

public static class Question1
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("=== Q1: Student Details ===");

        Console.Write("Enter student name: ");
        string name = Console.ReadLine() ?? "Unknown";

        Console.Write("Enter roll number: ");
        int rollNumber = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter marks: ");
        double marks = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Student Details");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Roll Number: {rollNumber}");
        Console.WriteLine($"Marks: {marks}");
    }
}
