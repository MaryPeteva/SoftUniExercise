using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string[] array1 = Console.ReadLine().Split();
        string[] array2 = Console.ReadLine().Split();

        string[] longestSequence = FindLongestSequence(array1, array2);
        Console.WriteLine($"[{string.Join(" ", longestSequence)}]");
    }

    static string[] FindLongestSequence(string[] array1, string[] array2)
    {
        int[,] dp = new int[array1.Length + 1, array2.Length + 1];

        for (int i = 1; i <= array1.Length; i++)
        {
            for (int j = 1; j <= array2.Length; j++)
            {
                if (array1[i - 1] == array2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        List<string> sequence = new List<string>();
        int x = array1.Length;
        int y = array2.Length;

        while (x > 0 && y > 0)
        {
            if (array1[x - 1] == array2[y - 1])
            {
                sequence.Insert(0, array1[x - 1]);
                x--;
                y--;
            }
            else if (dp[x - 1, y] > dp[x, y - 1])
            {
                x--;
            }
            else
            {
                y--;
            }
        }

        return sequence.ToArray();
    }
}
