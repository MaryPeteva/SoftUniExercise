using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] dimensions = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int row = dimensions[0];
        int col = dimensions[1];

        char[,] cupboard = new char[row, col];
        HashSet<(int, int)> cheesePositions = new HashSet<(int, int)>();

        int[] mouse = new int[2];

        for (int i = 1; i <= row; i++)
        {
            string inputRow = Console.ReadLine();
            char[] currRow = inputRow.ToCharArray();
            for (int j = 0; j < col; j++)
            {
                cupboard[i - 1, j] = currRow[j];
                if (currRow[j] == 'C')
                    cheesePositions.Add((i - 1, j));
                else if (currRow[j] == 'M')
                {
                    mouse[0] = i - 1;
                    mouse[1] = j;
                }
            }
        }

        bool catAttacks = false;
        bool happyMouse = false;
        bool trapped = false;
        string input = string.Empty;
        string[] moves = input.Split('\n').Skip(row + 2).TakeWhile(x => x != "danger").ToArray();

        foreach (string move in moves)
        {
            int newMouseR = mouse[0];
            int newMouseC = mouse[1];

            switch (move)
            {
                case "up":
                    newMouseR--;
                    break;
                case "down":
                    newMouseR++;
                    break;
                case "left":
                    newMouseC--;
                    break;
                case "right":
                    newMouseC++;
                    break;
            }

            if (newMouseR >= 0 && newMouseR < row && newMouseC >= 0 && newMouseC < col)
            {
                if (cupboard[newMouseR, newMouseC] == '@')
                {
                    catAttacks = true;
                    break;
                }
            }
        }
    }
}
