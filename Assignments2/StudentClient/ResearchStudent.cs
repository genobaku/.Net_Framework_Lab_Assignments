using System;
using StudentLibrary;

namespace StudentClient
{
    public class ResearchStudent : Student
    {
        public ResearchStudent(string name, int age, string dept, double cgpa, string college, string address)
            : base(name, age, dept, cgpa, college, address)
        {
        }

        public void ShowData()
        {
            Console.WriteLine("--- Testing Access in ResearchStudent (External Assembly, Derived) ---");

            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Department: " + Department);
            Console.WriteLine("College: " + College);

            Student baseStudentObj = new Student("Gaurav Sen", 23, "Robotics", 9.40, "National Engineering College", "789 Research Lab Road");
            Console.WriteLine("baseStudentObj.Name: " + baseStudentObj.Name);
        }
    }
}
