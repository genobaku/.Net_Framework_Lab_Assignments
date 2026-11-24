namespace Assignment5;

public static class Question7
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("=== Q7: Inheritance Demo ===");

        Student student = new("Ayesha", 101, "BSc CS");
        student.DisplayStudentInfo();

        Teacher teacher = new("Mr. Khan", 55, "Computer Science");
        teacher.DisplayTeacherInfo();
    }
}

public class Person
{
    public string Name { get; set; }

    public Person(string name)
    {
        Name = name;
    }
}

public class Student : Person
{
    public int RollNumber { get; set; }
    public string Department { get; set; }

    public Student(string name, int rollNumber, string department)
        : base(name)
    {
        RollNumber = rollNumber;
        Department = department;
    }

    public void DisplayStudentInfo()
    {
        Console.WriteLine($"Student: {Name}, Roll No: {RollNumber}, Department: {Department}");
    }
}

public class Teacher : Person
{
    public int EmployeeId { get; set; }
    public string Subject { get; set; }

    public Teacher(string name, int employeeId, string subject)
        : base(name)
    {
        EmployeeId = employeeId;
        Subject = subject;
    }

    public void DisplayTeacherInfo()
    {
        Console.WriteLine($"Teacher: {Name}, ID: {EmployeeId}, Subject: {Subject}");
    }
}
