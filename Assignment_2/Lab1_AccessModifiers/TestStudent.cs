using System;

namespace Lab1_AccessModifiers
{
    public class TestStudent
    {
        public static void RunTests()
        {
            Student student = new Student("Anurag Sharma", 21, "Computer Science", 9.24, "Technical Institute of Technology", "123 Academic Way, Sector 4");

            Console.WriteLine("--- Testing Access in TestStudent (Same Assembly, Non-Derived) ---");

            Console.WriteLine("Name: " + student.Name);

            Console.WriteLine("CGPA: " + student.CGPA);

            Console.WriteLine("College: " + student.College);
        }
    }
}
