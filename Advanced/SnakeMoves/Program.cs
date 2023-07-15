int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
int row = dimentions[0];
int col = dimentions[1];
char[,] matrix = new char[row, col];
string snake = Console.ReadLine();
Queue<char> snakeQ = new Queue<char>(snake.ToCharArray());

for (int i = 0; i < row; i++) 
{
	if (i % 2 == 0)
	{
		for (int j = 0; j < col; j++)
		{
			matrix[i, j] = snakeQ.Dequeue();
		}
	}
	else 
	{
        for (int j = col-1; j >= 0; j--)
        {
            matrix[i, j] = snakeQ.Dequeue();
        }
    }

	foreach (var ch in snake) 
	{
		snakeQ.Enqueue(ch);
	}
}

for (int i = 0; i < row; i++)
{
	for (int j = 0; j < col; j++)
	{
		Console.Write(matrix[i,j]);
	}
	Console.WriteLine();
}