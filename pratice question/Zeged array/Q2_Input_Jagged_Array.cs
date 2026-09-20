using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter number of rows: ");
        int n = int.Parse(Console.ReadLine());

        int[][] arr = new int[n][];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter number of elements in row " + (i + 1) + ": ");
            int size = int.Parse(Console.ReadLine());
            arr[i] = new int[size];

            for (int j = 0; j < size; j++)
            {
                Console.Write("Enter value for row " + (i + 1) + " position " + (j + 1) + ": ");
                arr[i][j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("Jagged array is:");
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                Console.Write(arr[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}
