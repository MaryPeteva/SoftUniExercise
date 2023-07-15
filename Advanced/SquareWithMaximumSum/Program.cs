int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
int row = input[0];
int col = input[1];
int[,] matrix = new int[row, col];
for (int i = 0; i < row; i++)
{
    int[] input1 = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

    for (int j = 0; j < col; j++) 
    {
        matrix[i, j] = input1[j];
    }
}

int sum = 0;
int tempSum = 0;
int[,] subMatrix = new int[2, 2];

for (int i = 0; i < row; i++) 
{
    for (int j = 0; j < col; j++)
    {
        if (i + 1 < row && j + 1 < col) 
        {
            tempSum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
            int tempI = i;
            int tempJ = j;
            if (tempSum > sum)
            {
                sum = tempSum;
                for (int k = 0; k < 2; k++)
                {
                    for (int l = 0; l < 2; l++)
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

for (int i = 0; i < 2; i++)
{
    for (int j = 0; j < 2; j++)
    {
        Console.Write($"{subMatrix[i, j]} ");
    }
    Console.WriteLine();
}
Console.WriteLine(sum);