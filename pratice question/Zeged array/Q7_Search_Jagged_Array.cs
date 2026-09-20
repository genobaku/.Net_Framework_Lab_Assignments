using System;

class Program
{
    static void Main()
    {
        int[][] arr =
        {
            new int[] { 5, 8, 9 },
            new int[] { 2, 7, 4 },
            new int[] { 11, 13, 15, 17 }
        };

        Console.Write("Enter element to search: ");
        int target = int.Parse(Console.ReadLine());

        bool found = false;

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                if (arr[i][j] == target)
                {
                    Console.WriteLine("Element found at row " + (i + 1) + " and column " + (j + 1));
                    found = true;
                    break;
                }
            }

            if (found)
            {
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Element not found");
        }
    }
}
