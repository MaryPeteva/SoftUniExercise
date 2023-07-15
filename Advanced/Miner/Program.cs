int size = int.Parse(Console.ReadLine());
Queue<string> commands = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray());
char[,] field = new char[size, size];
int collectedCoal = 0;
int coals = 0;
bool gameOver = false;
bool collectedAll = false;
string moveOut = string.Empty;

for (int i = 0; i < size; i++) 
{
    string input = Console.ReadLine();
    input = input.Replace(" ", "");
    char[] inputCh = input.ToCharArray();
    coals += input.Count(ch => ch == 'c');
    for (int j = 0; j < size; j++) 
    {
        field[i, j] = inputCh[j];
    }
} 

int[] indexes = FindStartIndex(field, size);
int startRow = indexes[0];
int startCol = indexes[1];

while (commands.Any() && (!gameOver || !collectedAll)) 
{
    switch (commands.Dequeue())
    {
        case "up":
            if (CheckIfInField(startRow - 1, startCol, field, size)) 
            {
                startRow -= 1; 
                moveOut = MakeMove(field, startRow, startCol, size);
            }
            break;
        case "down":
            if (CheckIfInField(startRow + 1, startCol, field, size))
            {
                startRow += 1;
                moveOut = MakeMove(field, startRow, startCol, size);
            }
            break;
        case "left":
            if (CheckIfInField(startRow, startCol - 1, field, size))
            {
                startCol -= 1;
                moveOut = MakeMove(field, startRow, startCol, size);
            }
            break;
        case "right":
            if (CheckIfInField(startRow, startCol + 1, field, size))
            {
                startCol += 1;
                moveOut = MakeMove(field, startRow, startCol, size);
            }
            break;
    }

    if (moveOut == "collected all")
    {
        collectedAll = true;
    }
    else if (moveOut == "game over") 
    {
        gameOver = true;
    }

}

if (gameOver)
{
    Console.WriteLine($"Game over! ({startRow}, {startCol})");
}
else if (collectedAll)
{
    Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
}
else
{
    Console.WriteLine($"{coals} coals left. ({startRow}, {startCol})");
}

string MakeMove(char[,] field, int row, int col, int size)
{
    string output = string.Empty;
    if (field[row,col] == 99)
    {
        field[row,col] = '*';
        coals--;
        if (coals == 0)
        {
            output = "collected all";
        }
        collectedCoal++;
    }

    if (field[row,col] == 101)
    {
        output = "game over";
    }
    return output;
}

static bool CheckIfInField(int row, int col, char[,] field, int size) 
{
    if (row >= 0 && row < size && col >= 0 && col < size) 
    {
        return true;
    }

    return false;
}
static int[] FindStartIndex(char[,] matrix, int size) 
{
    int[] indexes = new int[2];
    for (int i = 0; i < size; i++) 
    {
        for (int j = 0; j < size; j++)
        {
            if (matrix[i, j] == 115) 
            {
                indexes[0] = i;
                indexes[1] = j;
                break;
            }
        }
    }

    return indexes;
}