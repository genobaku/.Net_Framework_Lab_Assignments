using System;

namespace Lab1_AccessModifiers
{
    public class GraduateStudent : Student
    {
        public GraduateStudent(string name, int age, string dept, double cgpa, string college, string address)
            : base(name, age, dept, cgpa, college, address)
        {
        }

        public void ShowData()
        {
            Console.WriteLine("--- Testing Access in GraduateStudent (Same Assembly, Derived) ---");

            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Department: " + Department);
            Console.WriteLine("CGPA: " + CGPA);
            Console.WriteLine("College: " + College);
            Console.WriteLine("Address: " + Address);

            Student baseStudentObj = new Student("Rohit Verma", 22, "Electronics", 8.90, "Technical Institute of Technology", "456 Hostel Block B");
            Console.WriteLine("baseStudentObj.Name: " + baseStudentObj.Name);
            Console.WriteLine("baseStudentObj.CGPA: " + baseStudentObj.CGPA);
            Console.WriteLine("baseStudentObj.College: " + baseStudentObj.College);
        }
    }
}
