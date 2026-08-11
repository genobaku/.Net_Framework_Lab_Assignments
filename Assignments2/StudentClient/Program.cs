using System;
using StudentLibrary;

namespace StudentClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Lab Assignment 2 - External Assembly Client Tests ===");

            Console.WriteLine("\n[Lab 4] Testing access from a non-derived class in external assembly:");
            RunLab4Tests();

            Console.WriteLine("\n[Lab 5] Testing access from a derived class in external assembly:");
            ResearchStudent rs = new ResearchStudent("Anurag Sharma", 21, "Computer Science", 9.24, "Technical Institute of Technology", "123 Academic Way, Sector 4");
            rs.ShowData();

            Console.WriteLine("\nPress any key to exit...");
            if (!Console.IsInputRedirected)
            {
                Console.ReadKey();
            }
        }

        private static void RunLab4Tests()
        {
            Student student = new Student("Anurag Sharma", 21, "Computer Science", 9.24, "Technical Institute of Technology", "123 Academic Way, Sector 4");

            Console.WriteLine("--- Testing Access in StudentClient Program (External Assembly, Non-Derived) ---");

            Console.WriteLine("Name: " + student.Name);
        }
    }
}
