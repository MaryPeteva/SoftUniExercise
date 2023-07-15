using System;

class Program
{
    static void Main()
    {
        int[] dimensions = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int row = dimensions[0];
        int col = dimensions[1];
        char[,] cupboard = new char[row, col];
        int cheese = 0;

        for (int i = 0; i < row; i++)
        {
            string inputRows = Console.ReadLine();
            char[] currRow = inputRows.ToCharArray();
            cheese += currRow.Count(ch => ch == 'C');
            for (int j = 0; j < col; j++)
            {
                cupboard[i, j] = currRow[j];
            }
        }

        int[] mouse = FindStartIndex(cupboard, row, col);
        string input = string.Empty;
        bool catAttacks = false;
        bool happyMouse = false;
        bool trapped = false;

        while ((input = Console.ReadLine()) != "danger")
        {
            int tempMouseR = mouse[0];
            int tempMouseC = mouse[1];

            switch (input)
            {
                case "up":
                    tempMouseR--;
                    break;
                case "down":
                    tempMouseR++;
                    break;
                case "left":
                    tempMouseC--;
                    break;
                case "right":
                    tempMouseC++;
                    break;
            }

            if (CheckIfInField(tempMouseR, tempMouseC, cupboard, row, col))
            {
                if (!IsWall(tempMouseR, tempMouseC, cupboard))
                {
                    if (!IsTrapped(cupboard, tempMouseR, tempMouseC))
                    {
                        if (cupboard[tempMouseR, tempMouseC] == 'C')
                        {
                            cupboard[tempMouseR, tempMouseC] = 'M';
                            cupboard[mouse[0], mouse[1]] = '*';
                            mouse[0] = tempMouseR;
                            mouse[1] = tempMouseC;
                            cupboard[mouse[0], mouse[1]] = 'M';
                            cheese--;
                            if (cheese <= 0)
                            {
                                happyMouse = true;
                                break;
                            }
                        }

                        cupboard[mouse[0], mouse[1]] = '*';
                        mouse[0] = tempMouseR;
                        mouse[1] = tempMouseC;
                        cupboard[mouse[0], mouse[1]] = 'M';
                    }
                    else
                    {
                        trapped = true;
                        cupboard[mouse[0], mouse[1]] = '*';
                        cupboard[tempMouseR, tempMouseC] = 'M';
                        break;
                    }
                }
            }
            else
            {
                catAttacks = true;
                break;
            }
        }

        if (input == "danger")
        {
            Console.WriteLine("Mouse will come back later!");
        }
        if (happyMouse)
        {
            Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
        }

        if (catAttacks)
        {
            Console.WriteLine("No more cheese for tonight!");
        }

        if (trapped)
        {
            Console.WriteLine("Mouse is trapped!");
        }

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Console.Write(cupboard[i, j]);
            }
            Console.WriteLine();
        }
    }

    static bool IsWall(int row, int col, char[,] field)
    {
        return field[row, col] == '@';
    }

    static bool CheckIfInField(int row, int col, char[,] field, int rows, int cols)
    {
        return row >= 0 && row < rows && col >= 0 && col < cols;
    }

    static bool IsTrapped(char[,] cupboard, int row, int col)
    {
        return cupboard[row, col] == 'T';
    }

    static int[] FindStartIndex(char[,] matrix, int row, int col)
    {
        int[] indexes = new int[2];

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (matrix[i, j] == 'M')
                {
                    indexes[0] = i;
                    indexes[1] = j;
                    return indexes;
                }
            }
        }

        return indexes;
    }
}
