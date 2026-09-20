using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string str = Console.ReadLine();
        if (str == null)
        {
            str = "";
        }

        Console.Write("Enter another string: ");
        string str2 = Console.ReadLine();
        if (str2 == null)
        {
            str2 = "";
        }

        Console.Write("Enter comma separated words: ");
        string wordsInput = Console.ReadLine();
        if (wordsInput == null)
        {
            wordsInput = "";
        }

        bool startCheck = str.StartsWith("Hello");
        bool endCheck = str.EndsWith("C#");
        int firstA = str.IndexOf('a');
        int len = str.Length < 5 ? str.Length : 5;
        string firstFive = str.Substring(0, len);
        string replaced = str.Replace("Java", "C#");
        string[] words = wordsInput.Split(',');
        bool equal = str == str2;
        bool emptyCheck = String.IsNullOrEmpty(str);

        Console.WriteLine($"Starts with Hello: {startCheck}");
        Console.WriteLine($"Ends with C#: {endCheck}");

        if (firstA == -1)
        {
            Console.WriteLine("First occurrence of 'a': not found");
        }
        else
        {
            Console.WriteLine($"First occurrence of 'a': {firstA}");
        }

        Console.WriteLine($"First 5 characters: {firstFive}");
        Console.WriteLine($"After replace: {replaced}");
        Console.WriteLine("Words:");

        for (int i = 0; i < words.Length; i++)
        {
            Console.WriteLine(words[i]);
        }

        Console.WriteLine($"Strings are equal: {equal}");
        Console.WriteLine($"String is null or empty: {emptyCheck}");
    }
}
