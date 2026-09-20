namespace Assignment5;

public static class Question5
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("=== Q5: Array Operations ===");

        Console.Write("How many numbers do you want to enter? ");
        int size = Convert.ToInt32(Console.ReadLine());
        int[] numbers = new int[size];

        int sum = 0;
        int largest = int.MinValue;
        int smallest = int.MaxValue;

        for (int i = 0; i < size; i++)
        {
            Console.Write($"Enter number {i + 1}: ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
            sum += numbers[i];

            if (numbers[i] > largest)
                largest = numbers[i];

            if (numbers[i] < smallest)
                smallest = numbers[i];
        }

        Console.WriteLine();
        Console.WriteLine("Entered numbers:");
        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }

        Console.WriteLine();
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {(double)sum / size}");
        Console.WriteLine($"Largest: {largest}");
        Console.WriteLine($"Smallest: {smallest}");
    }
}
