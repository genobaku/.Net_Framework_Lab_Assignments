using System;

class Program
{
    static void Main()
    {
        int[][] arr =
        {
            new int[] { 3, 5, 7 },
            new int[] { 4, 6, 8, 10 },
            new int[] { 2, 9 }
        };

        for (int i = 0; i < arr.Length; i++)
        {
            int rowSum = 0;

            for (int j = 0; j < arr[i].Length; j++)
            {
                rowSum = rowSum + arr[i][j];
            }

            Console.WriteLine("Row " + (i + 1) + " has " + arr[i].Length + " elements and sum = " + rowSum);
        }
    }
}
