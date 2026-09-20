using System;

class Program
{
    static void Main()
    {
        int[][] marks = new int[3][];

        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter number of subjects for student " + (i + 1) + ": ");
            int n = int.Parse(Console.ReadLine());
            marks[i] = new int[n];

            for (int j = 0; j < n; j++)
            {
                Console.Write("Enter marks for subject " + (j + 1) + " of student " + (i + 1) + ": ");
                marks[i][j] = int.Parse(Console.ReadLine());
            }
        }

        for (int i = 0; i < 3; i++)
        {
            int total = 0;

            for (int j = 0; j < marks[i].Length; j++)
            {
                total = total + marks[i][j];
            }

            double percentage = (total * 100.0) / (marks[i].Length * 100);

            Console.WriteLine("Student " + (i + 1) + " total marks = " + total);
            Console.WriteLine("Student " + (i + 1) + " percentage = " + percentage + "%");
        }
    }
}
