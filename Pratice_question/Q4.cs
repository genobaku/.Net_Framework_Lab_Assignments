using System;

class Grade
{
    static void Main()
    {
        int marks;

        Console.Write("Enter Marks (0-100): ");
        marks = Convert.ToInt32(Console.ReadLine());

        if (marks >= 91 && marks <= 100)
            Console.WriteLine("Grade: O");
        else if (marks >= 81)
            Console.WriteLine("Grade: A+");
        else if (marks >= 71)
            Console.WriteLine("Grade: A");
        else if (marks >= 61)
            Console.WriteLine("Grade: B+");
        else if (marks >= 51)
            Console.WriteLine("Grade: B");
        else
            Console.WriteLine("Grade: Fail");
    }
}
