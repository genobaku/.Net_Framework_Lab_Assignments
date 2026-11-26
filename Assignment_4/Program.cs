using System;

namespace Assignment4;

public delegate int SumDelegate(int a, int b);
public delegate void LogDelegate(string message);
public delegate double CalculatorDelegate(double a, double b);
public delegate void NotificationDelegate(string message);
public delegate double SalaryComponentDelegate(double basicSalary);
public delegate void TaskDelegate(string taskName);

public class Program
{
    public static void Main()
    {
        while (true)
        {
            SafeClear();
            Console.WriteLine("==================================================");
            Console.WriteLine("              ASSIGNMENT 4: DELEGATES             ");
            Console.WriteLine("==================================================");
            Console.WriteLine("1. Question 1 (Theory - See Theory_Questions.md)");
            Console.WriteLine("2. Question 2: Sum of Two Integers");
            Console.WriteLine("3. Question 3: Unicast and Multicast Execution");
            Console.WriteLine("4. Question 4: Calculator Operations");
            Console.WriteLine("5. Question 5: Multicast Notification System");
            Console.WriteLine("6. Question 6: Employee Salary Calculation");
            Console.WriteLine("7. Question 7: Method Names and Invocation");
            Console.WriteLine("8. Question 8: Action Delegate Execution");
            Console.WriteLine("9. Question 9: Func Delegate Execution");
            Console.WriteLine("10. Question 10: Predicate Delegate Execution");
            Console.WriteLine("11. Run All Programs");
            Console.WriteLine("0. Exit");
            Console.WriteLine("==================================================");
            Console.Write("Select an option: ");

            string? choice = Console.ReadLine();
            if (choice == null)
            {
                break;
            }

            SafeClear();

            switch (choice.Trim())
            {
                case "1":
                    Console.WriteLine("Question 1 is a theory question.");
                    Console.WriteLine("Complete explanation, purpose, and syntax are documented in Theory_Questions.md");
                    break;
                case "2":
                    RunQuestion2();
                    break;
                case "3":
                    RunQuestion3();
                    break;
                case "4":
                    RunQuestion4();
                    break;
                case "5":
                    RunQuestion5();
                    break;
                case "6":
                    RunQuestion6();
                    break;
                case "7":
                    RunQuestion7();
                    break;
                case "8":
                    RunQuestion8();
                    break;
                case "9":
                    RunQuestion9();
                    break;
                case "10":
                    RunQuestion10();
                    break;
                case "11":
                    RunAllPrograms();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please enter a number between 0 and 11.");
                    break;
            }

            Pause();
        }
    }

    private static void SafeClear()
    {
        try
        {
            if (!Console.IsOutputRedirected)
            {
                Console.Clear();
            }
        }
        catch
        {
        }
    }

    private static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    private static void RunAllPrograms()
    {
        RunQuestion2();
        Console.WriteLine("\n--------------------------------------------------\n");
        RunQuestion3();
        Console.WriteLine("\n--------------------------------------------------\n");
        RunQuestion4();
        Console.WriteLine("\n--------------------------------------------------\n");
        RunQuestion5();
        Console.WriteLine("\n--------------------------------------------------\n");
        RunQuestion6();
        Console.WriteLine("\n--------------------------------------------------\n");
        RunQuestion7();
        Console.WriteLine("\n--------------------------------------------------\n");
        RunQuestion8();
        Console.WriteLine("\n--------------------------------------------------\n");
        RunQuestion9();
        Console.WriteLine("\n--------------------------------------------------\n");
        RunQuestion10();
    }

    private static void RunQuestion2()
    {
        Console.WriteLine("=== Question 2: Sum of Two Integers ===");
        SumDelegate del = Add;
        int a = 25;
        int b = 35;
        int sum = del(a, b);
        Console.WriteLine($"First Number: {a}");
        Console.WriteLine($"Second Number: {b}");
        Console.WriteLine($"Sum: {sum}");
    }

    private static int Add(int a, int b) => a + b;

    private static void RunQuestion3()
    {
        Console.WriteLine("=== Question 3: Unicast and Multicast Delegates ===");
        LogDelegate unicast = PrintConsole;
        Console.WriteLine("Unicast Invocation:");
        unicast("Executing unicast target.");

        Console.WriteLine();
        LogDelegate multicast = PrintConsole;
        multicast += PrintFile;
        Console.WriteLine("Multicast Invocation:");
        multicast("Executing multicast targets.");
    }

    private static void PrintConsole(string message) => Console.WriteLine("[Console] " + message);
    private static void PrintFile(string message) => Console.WriteLine("[File] " + message);

    private static void RunQuestion4()
    {
        Console.WriteLine("=== Question 4: Calculator Operations ===");
        CalculatorDelegate calc;
        double a = 12.0;
        double b = 4.0;

        Console.WriteLine($"Inputs: a = {a}, b = {b}");

        calc = AddValues;
        Console.WriteLine($"Addition: {calc(a, b)}");

        calc = SubtractValues;
        Console.WriteLine($"Subtraction: {calc(a, b)}");

        calc = MultiplyValues;
        Console.WriteLine($"Multiplication: {calc(a, b)}");

        calc = DivideValues;
        Console.WriteLine($"Division: {calc(a, b)}");
    }

    private static double AddValues(double a, double b) => a + b;
    private static double SubtractValues(double a, double b) => a - b;
    private static double MultiplyValues(double a, double b) => a * b;
    private static double DivideValues(double a, double b) => b != 0 ? a / b : 0;

    private static void RunQuestion5()
    {
        Console.WriteLine("=== Question 5: Notification Services ===");
        NotificationDelegate notify = SendEmail;
        notify += SendSms;
        notify += SendWhatsApp;

        string alert = "Order #84920 shipped successfully.";
        notify(alert);
    }

    private static void SendEmail(string message) => Console.WriteLine("[Email] " + message);
    private static void SendSms(string message) => Console.WriteLine("[SMS] " + message);
    private static void SendWhatsApp(string message) => Console.WriteLine("[WhatsApp] " + message);

    private static void RunQuestion6()
    {
        Console.WriteLine("=== Question 6: Employee Salary Calculation ===");
        double basicSalary = 60000.0;
        Console.WriteLine($"Basic Salary: {basicSalary:C}");
        Console.WriteLine();

        SalaryComponentDelegate salaryChain = GetBasic;
        salaryChain += GetHra;
        salaryChain += GetDa;
        salaryChain += GetBonus;

        double total = 0;
        foreach (Delegate del in salaryChain.GetInvocationList())
        {
            SalaryComponentDelegate comp = (SalaryComponentDelegate)del;
            double value = comp(basicSalary);
            total += value;
            Console.WriteLine($"{del.Method.Name}: {value:C}");
        }

        Console.WriteLine();
        Console.WriteLine($"Total Salary: {total:C}");
    }

    private static double GetBasic(double basic) => basic;
    private static double GetHra(double basic) => basic * 0.20;
    private static double GetDa(double basic) => basic * 0.10;
    private static double GetBonus(double basic) => basic * 0.15;

    private static void RunQuestion7()
    {
        Console.WriteLine("=== Question 7: Method Names and Individual Invocation ===");
        TaskDelegate tasks = InitializeStep;
        tasks += ProcessStep;
        tasks += FinalizeStep;

        Delegate[] list = tasks.GetInvocationList();
        Console.WriteLine($"Total Methods: {list.Length}");
        Console.WriteLine();

        foreach (Delegate del in list)
        {
            Console.WriteLine($"Method Name: {del.Method.Name}");
            TaskDelegate target = (TaskDelegate)del;
            target("BatchTask_01");
        }
    }

    private static void InitializeStep(string task) => Console.WriteLine("Initialized: " + task);
    private static void ProcessStep(string task) => Console.WriteLine("Processed: " + task);
    private static void FinalizeStep(string task) => Console.WriteLine("Finalized: " + task);

    private static void RunQuestion8()
    {
        Console.WriteLine("=== Question 8: Built-in Action Delegate ===");
        Action<string> action = LogGreeting;
        Console.WriteLine("Unicast Action:");
        action("Student");

        Console.WriteLine();
        action += LogFarewell;
        Console.WriteLine("Multicast Action:");
        action("Student");
    }

    private static void LogGreeting(string name) => Console.WriteLine("Hello, " + name);
    private static void LogFarewell(string name) => Console.WriteLine("Goodbye, " + name);

    private static void RunQuestion9()
    {
        Console.WriteLine("=== Question 9: Built-in Func Delegate ===");
        Func<int, int> singleFunc = Square;
        Console.WriteLine($"Single Func (Square of 7): {singleFunc(7)}");
        Console.WriteLine();

        Func<int, int> multiFunc = Square;
        multiFunc += Cube;
        multiFunc += DoubleValue;

        int input = 4;
        Console.WriteLine($"Multicast Func with input {input}:");
        foreach (Delegate del in multiFunc.GetInvocationList())
        {
            Func<int, int> target = (Func<int, int>)del;
            int result = target(input);
            Console.WriteLine($"{del.Method.Name}({input}) = {result}");
        }
    }

    private static int Square(int x) => x * x;
    private static int Cube(int x) => x * x * x;
    private static int DoubleValue(int x) => x * 2;

    private static void RunQuestion10()
    {
        Console.WriteLine("=== Question 10: Built-in Predicate Delegate ===");
        Predicate<int> predicateChain = IsEven;
        predicateChain += IsPositive;
        predicateChain += IsGreaterThan100;

        int testNumber = 150;
        Console.WriteLine($"Evaluating number: {testNumber}");

        foreach (Delegate del in predicateChain.GetInvocationList())
        {
            Predicate<int> target = (Predicate<int>)del;
            bool passes = target(testNumber);
            Console.WriteLine($"{del.Method.Name}({testNumber}): {passes}");
        }
    }

    private static bool IsEven(int n) => n % 2 == 0;
    private static bool IsPositive(int n) => n > 0;
    private static bool IsGreaterThan100(int n) => n > 100;
}
