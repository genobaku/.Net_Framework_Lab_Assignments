namespace Assignment5;

public static class Question9
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("=== Q9: Exception Handling ===");

        try
        {
            Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            ValidateAge(age);
            Console.WriteLine($"Your age is valid: {age}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid numeric age.");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Exception handling completed.");
        }
    }

    public static void ValidateAge(int age)
    {
        if (age < 0 || age > 120)
        {
            throw new ArgumentOutOfRangeException(nameof(age), "Age must be between 0 and 120.");
        }
    }
}
