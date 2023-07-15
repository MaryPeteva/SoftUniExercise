using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] inputIndex = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = inputIndex[0];
        int cols = inputIndex[1];
        char[,] lair = new char[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            string input = Console.ReadLine();
            for (int j = 0; j < cols; j++)
            {
                lair[i, j] = input[j];
            }
        }

        Queue<(int, int)> bunnies = FindBunnies(lair, rows, cols);

        string commands = Console.ReadLine();
        int playerIndxR = -1;
        int playerIndxC = -1;
        bool alive = true;
        bool escaped = false;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (lair[i, j] == 'P')
                {
                    playerIndxR = i;
                    playerIndxC = j;
                    break;
                }
            }
        }

        foreach (char ch in commands)
        {
            if (!alive || escaped)
                break;

            lair[playerIndxR, playerIndxC] = '.';
            switch (ch)
            {
                case 'U':
                    if (CheckIfInField(playerIndxR - 1, playerIndxC, rows, cols))
                    {
                        playerIndxR -= 1;
                        MakeMove(playerIndxR, playerIndxC, lair, ref alive);
                    }
                    else
                    {
                        escaped = true;
                    }
                    break;
                case 'D':
                    if (CheckIfInField(playerIndxR + 1, playerIndxC, rows, cols))
                    {
                        playerIndxR += 1;
                        MakeMove(playerIndxR, playerIndxC, lair, ref alive);
                    }
                    else
                    {
                        escaped = true;
                    }
                    break;
                case 'L':
                    if (CheckIfInField(playerIndxR, playerIndxC - 1, rows, cols))
                    {
                        playerIndxC -= 1;
                        MakeMove(playerIndxR, playerIndxC, lair, ref alive);
                    }
                    else
                    {
                        escaped = true;
                    }
                    break;
                case 'R':
                    if (CheckIfInField(playerIndxR, playerIndxC + 1, rows, cols))
                    {
                        playerIndxC += 1;
                        MakeMove(playerIndxR, playerIndxC, lair, ref alive);
                    }
                    else
                    {
                        escaped = true;
                    }
                    break;
            }

            if (escaped)
            {
                lair[playerIndxR, playerIndxC] = '.';
            }

            BunniesSpread(lair, rows, cols, bunnies);
            bunnies = FindBunnies(lair, rows, cols);
        }

        string message;
        if (alive || escaped)
        {
            message = $"won: {playerIndxR} {playerIndxC}";
        }
        else
        {
            message = $"dead: {playerIndxR} {playerIndxC}";
        }

        PrintLair(lair, rows, cols);
        Console.WriteLine(message);
    }

    public static void MakeMove(int row, int col, char[,] lair, ref bool alive)
    {
        if (lair[row, col] == 'B')
        {
            alive = false;
        }
        else
        {
            lair[row, col] = 'P';
        }
    }

    public static void BunniesSpread(char[,] lair, int rows, int cols, Queue<(int, int)> bunnies)
    {
        int[] dx = { -1, 0, 1, 0 };
        int[] dy = { 0, 1, 0, -1 };

        int count = bunnies.Count;
        for (int i = 0; i < count; i++)
        {
            var bunny = bunnies.Dequeue();
            for (int j = 0; j < 4; j++)
            {
                int newRow = bunny.Item1 + dx[j];
                int newCol = bunny.Item2 + dy[j];
                if (CheckIfInField(newRow, newCol, rows, cols) && lair[newRow, newCol] != 'B' && lair[newRow, newCol] != 'P')
                {
                    lair[newRow, newCol] = 'B';
                    bunnies.Enqueue((newRow, newCol));
                }
            }
        }
    }

    public static bool CheckIfInField(int row, int col, int rows, int cols)
    {
        return row >= 0 && row < rows && col >= 0 && col < cols;
    }

    public static Queue<(int, int)> FindBunnies(char[,] lair, int rows, int cols)
    {
        Queue<(int, int)> bunnies = new Queue<(int, int)>();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (lair[i, j] == 'B')
                {
                    bunnies.Enqueue((i, j));
                }
            }
        }

        return bunnies;
    }

    public static void PrintLair(char[,] lair, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(lair[i, j]);
            }
            Console.WriteLine();
        }
    }
}
