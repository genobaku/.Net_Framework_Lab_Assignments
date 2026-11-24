using System;

class Program
{
    static void Main()
    {
        int[][] arr =
        {
            new int[] { 12, 8, 30 },
            new int[] { 21, 45, 7 },
            new int[] { 19, 2, 14, 28 }
        };

        int max = arr[0][0];
        int min = arr[0][0];

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                if (arr[i][j] > max)
                {
                    max = arr[i][j];
                }

                if (arr[i][j] < min)
                {
                    min = arr[i][j];
                }
            }
        }

        Console.WriteLine("Largest element = " + max);
        Console.WriteLine("Smallest element = " + min);
    }
}
