int num = 1;
int rows = int.Parse(Console.ReadLine());
int[][] jaggedMatrix = new int[rows][];
for (int i = 0; i < rows; i++) 
{
    int[] newRow = new int[i];
    for (int j = 0; j < rows; j++) 
    {
        newRow[j] = num * (i - j) / (j + 1);
    }
    jaggedMatrix[i] = newRow;
}

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < jaggedMatrix[i].Length; j++)
    {
        Console.Write($"{jaggedMatrix[i][j]} ");
    }
    Console.WriteLine();
}