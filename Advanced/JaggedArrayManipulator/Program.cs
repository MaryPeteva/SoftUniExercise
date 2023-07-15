int rows = int.Parse(Console.ReadLine());
int[][] jaggedMatrix =  new int[rows][];

for (int i = 0; i < rows; i++) 
{
    jaggedMatrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
}

for (int i = 0; i < rows; i++) 
{
    if (i + 1 < rows) 
    {
        if (jaggedMatrix[i].Length == jaggedMatrix[i + 1].Length)
        {
            for (int j = 0; j < jaggedMatrix[i].Length; j++)
            {
                jaggedMatrix[i][j] *= 2;
                jaggedMatrix[i + 1][j] *= 2;
            }
        }
        else
        {
            for (int j = 0; j < jaggedMatrix[i].Length; j++)
            {
                jaggedMatrix[i][j] /= 2;
            }

            for (int k = 0; k < jaggedMatrix[i + 1].Length; k++)
            {
                jaggedMatrix[i + 1][k] /= 2;
            }
        }
    }
}

string input = string.Empty;
while ((input = Console.ReadLine()) != "End") 
{
    string[] arrInput = input.Split().ToArray();
    string command = arrInput[0];
    int row = int.Parse(arrInput[1]);
    int col = int.Parse(arrInput[2]);
    int value = int.Parse(arrInput[3]);

    if ((row <= rows && row >= 0) && (col < jaggedMatrix[row].Length && col >= 0)) 
    {
        switch (command)
        {
            case "Add":
                jaggedMatrix[row][col] += value;
                break;
            case "Subtract":
                jaggedMatrix[row][col] -= value;
                break;

        }
    }
}

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < jaggedMatrix[i].Length; j++)
    {
        Console.Write($"{jaggedMatrix[i][j]} ");
    }
    Console.WriteLine();
}