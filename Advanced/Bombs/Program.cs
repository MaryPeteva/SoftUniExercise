int rowCol = int.Parse(Console.ReadLine());
int[,] matrix = new int[rowCol, rowCol];
int alive = rowCol * rowCol;
int aliveSum = 0;
for (int i = 0; i < rowCol; i++) 
{
    int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
	for (int j = 0; j < rowCol; j++)
	{
		matrix[i, j] = input[j];
	}
}

int[] bombIndexes =  Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int bombCount = bombIndexes.Length / 2;
int bInd = 0;
for (int i = 0; i < bombCount; i++)
{
	int currI = bombIndexes[bInd];
	int currJ = bombIndexes[bInd + 1];
	int value = matrix[currI, currJ];

	if (matrix[currI, currJ] > 0) 
	{
        matrix = Boom(bombIndexes[bInd], bombIndexes[bInd + 1], matrix, rowCol, value);
    }
	matrix[currI, currJ] = 0;
	bInd += 2;
}

for (int i = 0; i < rowCol; i++)
{
	for (int j = 0; j < rowCol; j++)
	{
		if (matrix[i, j] <= 0)
		{
			alive--;
		}
		else 
		{
			aliveSum += matrix[i, j];
		}
	}
}

Console.WriteLine($"Alive cells: {alive}\nSum: {aliveSum}");
for (int i = 0; i < rowCol; i++)
{
	for (int j = 0; j < rowCol; j++)
	{
		Console.Write($"{matrix[i,j]} ");
	}
	Console.WriteLine();
}

static int[,] Boom(int i, int j, int[,] matrix, int rowCol, int value) 
{
	if (i + 1 < rowCol) 
	{
		if (matrix[i + 1, j] > 0) 
		{
			matrix[i + 1, j] -= value;
		}

		if (j + 1 < rowCol && matrix[i + 1, j + 1] > 0) 
		{
			matrix[i + 1, j + 1] -= value;
		}

		if (j - 1 >= 0 && matrix[i + 1, j - 1] >= 0) 
		{
			matrix[i + 1, j - 1] -= value;
		}
    }

	if (i - 1 >= 0) 
	{
		if (matrix[i - 1, j] > 0) 
		{
			matrix[i - 1, j] -= value;
		}

		if(j - 1 >= 0 && matrix[i - 1, j - 1] > 0) 
		{
			matrix[i - 1, j - 1] -= value;
		}

		if (j + 1 < rowCol && matrix[i - 1, j + 1] > 0) 
		{
			matrix[i - 1, j + 1] -= value;
		}

    }

	if (j + 1 < rowCol && matrix[i, j + 1] > 0) 
	{
		matrix[i, j + 1] -= value;
	}

	if (j - 1 >= 0 && matrix[i, j - 1] > 0) 
	{
		matrix[i, j - 1] -= value;
	}

	

	return matrix;
}