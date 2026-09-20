using System;

namespace Assignment1;

public static class Q1
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("=== Q1: Student Details ===");

        string name;
        int rollNumber;
        float marks;

        Console.Write("Enter Student Name: ");
        name = Console.ReadLine() ?? "Unknown";

        Console.Write("Enter Roll Number: ");
        rollNumber = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Marks: ");
        marks = Convert.ToSingle(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("----- Student Details -----");
        Console.WriteLine("Name : " + name);
        Console.WriteLine("Roll Number : " + rollNumber);
        Console.WriteLine("Marks : " + marks);
    }
}
