using System;

class Program
{
    static void Main()
    {
        int[][] arr =
        {
            new int[] { 5, 6, 7 },
            new int[] { 10, 20 },
            new int[] { 1, 2, 3, 4 }
        };

        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("Row " + (i + 1) + ": ");

            for (int j = 0; j < arr[i].Length; j++)
            {
                Console.Write(arr[i][j] + " ");
            }

            Console.WriteLine();
        }
    }
}
