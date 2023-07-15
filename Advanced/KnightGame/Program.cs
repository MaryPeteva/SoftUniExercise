int rowsCol = int.Parse(Console.ReadLine());
int toBeRemoved = 0;
if (rowsCol < 3)
{
    Console.WriteLine(toBeRemoved);
    return;
}
char[,] matrix = new char[rowsCol, rowsCol];
int knightCount = 0;

for (int i = 0; i < rowsCol; i++)
{
    char[] input = Console.ReadLine().ToCharArray();
    for (int j = 0; j < rowsCol; j++)
    {
        matrix[i, j] = input[j];
    }
}

int mostAttacks = 0;
int currentaTTACKS = 0;
int mostRow = 0;
int mostCol = 0;

while (true) 
{
    for (int i = 0; i < rowsCol; i++)
    {
        for (int j = 0; j < rowsCol; j++)
        {
            if (matrix[i, j] == 'K')
            {
                currentaTTACKS = CountAttacks(i, j, rowsCol, matrix);

                if (currentaTTACKS > mostAttacks)
                {
                    mostAttacks = currentaTTACKS;
                    mostRow = i;
                    mostCol = j;

                }
            }

        }

    }

    if (mostAttacks > 0)
    {
        matrix[mostRow, mostCol] = '0';
        toBeRemoved++;
    }
    else
    {
        break;
    }

    mostAttacks = 0;
    mostRow = 0;
    mostCol = 0;
    currentaTTACKS = 0;
}

Console.WriteLine(toBeRemoved);

static int CountAttacks(int i, int j, int rowsCol, char[,] matrix) 
{
    int attacks = 0;

    if (CheckDirection(i + 2, j + 1, rowsCol))
    {
        if (matrix[i + 2, j + 1] == 'K')
        {
            attacks++;
        }
    }

    if (CheckDirection(i + 1, j + 2, rowsCol))
    {
        if (matrix[i + 1, j + 2] == 'K')
        {
            attacks++;
        }
    }

    if (CheckDirection(i - 2, j - 1, rowsCol))
    {
        if (matrix[i - 2, j - 1] == 'K')
        {
            attacks++;
        }
    }

    if (CheckDirection(i - 1, j - 2, rowsCol))
    {
        if (matrix[i - 1, j - 2] == 'K')
        {
            attacks++;
        }
    }

    if (CheckDirection(i + 1, j - 2, rowsCol))
    {
        if (matrix[i + 1, j - 2] == 'K')
        {
            attacks++;
        }
    }

    if (CheckDirection(i - 1, j + 2, rowsCol))
    {
        if (matrix[i - 1, j + 2] == 'K')
        {
            attacks++;
        }
    }

    if (CheckDirection(i - 2, j + 1, rowsCol))
    {
        if (matrix[i - 2, j + 1] == 'K')
        {
            attacks++;
        }
    }

    if (CheckDirection(i + 2, j - 1, rowsCol))
    {
        if (matrix[i + 2, j - 1] == 'K')
        {
            attacks++;
        }
    }

    return attacks;
}
static bool CheckDirection(int row, int col, int rowCol) 
{
    if (row >= 0 && col >= 0 && row < rowCol && col < rowCol)
    {
        return true;
    }
    else 
    {
        return false;
    }
}