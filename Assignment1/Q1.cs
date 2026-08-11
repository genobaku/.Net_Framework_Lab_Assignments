using System;

class StudentDetails
{
    static void Main()
    {
        string name;
        int rollNumber;
        float marks;

        Console.Write("Enter Student Name: ");
        name = Console.ReadLine();

        Console.Write("Enter Roll Number: ");
        rollNumber = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Marks: ");
        marks = Convert.ToSingle(Console.ReadLine());

        Console.WriteLine("\n----- Student Details -----");
        Console.WriteLine("Name : " + name);
        Console.WriteLine("Roll Number : " + rollNumber);
        Console.WriteLine("Marks : " + marks);
    }
}
