using System;

namespace Lab1_AccessModifiers
{
    public class Student
    {
        public string Name;
        private int Age;
        protected string Department;
        internal double CGPA;
        protected internal string College;
        private protected string Address;

        public Student(string name, int age, string dept, double cgpa, string college, string address)
        {
            Name = name;
            Age = age;
            Department = dept;
            CGPA = cgpa;
            College = college;
            Address = address;
        }

        public void Display()
        {
            Console.WriteLine("--- Student Details ---");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Department: " + Department);
            Console.WriteLine("CGPA: " + CGPA);
            Console.WriteLine("College: " + College);
            Console.WriteLine("Address: " + Address);
        }
    }
}
