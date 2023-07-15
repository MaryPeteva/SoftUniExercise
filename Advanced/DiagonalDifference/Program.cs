int rowCol = int.Parse(Console.ReadLine());
int[,] matrix = new int[rowCol, rowCol];
for (int i = 0; i < rowCol; i++) 
{
    int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
	for (int j = 0; j < rowCol; j++)
	{
		matrix[i,j] = input[j];
	}
}

int primerySum =  0;
int secondarySum = 0;
for (int i = 0; i < rowCol; i++) 
{
	for (int j = 0; j < rowCol; j++) 
	{
		if (i == j) 
		{
			primerySum += matrix[i, j];
		}

		if ((i + j) == (rowCol - 1))
		{
			secondarySum += matrix[i, j];
		}

    }
}

Console.WriteLine(Math.Abs(primerySum - secondarySum));

