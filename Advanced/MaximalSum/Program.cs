int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
int row = input[0];
int col = input[1];
int[,] matrix = new int[row, col];
for (int i = 0; i < row; i++)
{
    int[] input1 = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

    for (int j = 0; j < col; j++)
    {
        matrix[i, j] = input1[j];
    }
}

int sum = 0;
int tempSum = 0;
int[,] subMatrix = new int[3, 3];

for (int i = 0; i < row; i++)
{
    for (int j = 0; j < col; j++)
    {
        if (i + 2 < row && j + 2 < col)
        {
            tempSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
            int tempI = i;
            int tempJ = j;
            if (tempSum > sum)
            {
                sum = tempSum;
                for (int k = 0; k < 3; k++)
                {
                    for (int l = 0; l < 3; l++)
                    {
                        subMatrix[k, l] = matrix[tempI, tempJ];
                        tempJ++;
                    }
                    tempI++;
                    tempJ = j;
                }
            }
        }

    }

}


Console.WriteLine($"Sum = {sum}");
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write($"{subMatrix[i, j]} ");
    }
    Console.WriteLine();
}
;