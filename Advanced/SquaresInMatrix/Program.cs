int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
int row = input[0];
int col = input[1];
string[,] matrix = new string[row, col];
int count = 0;
for (int i = 0; i < row; i++) 
{
    string[] inp = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
    for (int j = 0; j < col; j++) 
    {
        matrix[i,j] = inp[j];
    }
}

for (int i = 0; i < row; i++)
{
    for (int j = 0; j < col; j++)
    {
        if (i + 1 < row && j + 1 < col) 
        {
            if (matrix[i, j] == matrix[i, j + 1] && matrix[i, j] == matrix[i + 1, j] && matrix[i, j] == matrix[i + 1, j + 1])
            {
                count++;
            }
        }
    }
}

Console.WriteLine(count);