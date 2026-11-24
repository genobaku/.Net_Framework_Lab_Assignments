namespace Assignment5;

public static class Question6
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("=== Q6: Employee Class ===");

        Console.Write("Enter employee name: ");
        string name = Console.ReadLine() ?? "Unknown";

        Console.Write("Enter employee ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter salary: ");
        double salary = Convert.ToDouble(Console.ReadLine());

        Employee employee = new(name, id, salary);
        employee.DisplayInfo();
    }
}

public class Employee
{
    public string Name { get; set; }
    public int Id { get; set; }
    public double Salary { get; set; }

    public Employee(string name, int id, double salary)
    {
        Name = name;
        Id = id;
        Salary = salary;
    }

    public void DisplayInfo()
    {
        Console.WriteLine();
        Console.WriteLine("Employee Information");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Salary: {Salary:C}");
    }
}
