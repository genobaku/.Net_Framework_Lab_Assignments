using System;

class Program
{
    static void Main()
    {
        int[][] arr =
        {
            new int[] { 10, 20, 30 },
            new int[] { 5, 15 },
            new int[] { 7, 9, 11, 13 }
        };

        int sum = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                sum = sum + arr[i][j];
            }
        }

        Console.WriteLine("Sum of all elements = " + sum);
    }
}
