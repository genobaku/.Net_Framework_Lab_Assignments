namespace Assignment5;

public static class Question3
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("=== Q3: Number Check ===");

        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number > 0)
        {
            Console.WriteLine($"{number} is positive.");
        }
        else if (number < 0)
        {
            Console.WriteLine($"{number} is negative.");
        }
        else
        {
            Console.WriteLine("The number is zero.");
        }

        if (number % 2 == 0)
        {
            Console.WriteLine($"{number} is even.");
        }
        else
        {
            Console.WriteLine($"{number} is odd.");
        }
    }
}
