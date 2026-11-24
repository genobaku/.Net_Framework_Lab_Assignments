using System;

namespace Lab1_AccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Lab Assignment 2 - Same Assembly Tests ===");

            Console.WriteLine("\n[Lab 1] Accessing inside Student class:");
            Student s1 = new Student("Anurag Sharma", 21, "Computer Science", 9.24, "Technical Institute of Technology", "123 Academic Way, Sector 4");
            s1.Display();

            Console.WriteLine("\n[Lab 2] Testing access from TestStudent class:");
            TestStudent.RunTests();

            Console.WriteLine("\n[Lab 3] Testing access from GraduateStudent (Derived Class):");
            GraduateStudent g1 = new GraduateStudent("Anurag Sharma", 21, "Computer Science", 9.24, "Technical Institute of Technology", "123 Academic Way, Sector 4");
            g1.ShowData();

            Console.WriteLine("\nPress any key to exit...");
            if (!Console.IsInputRedirected)
            {
                Console.ReadKey();
            }
        }
    }
}
