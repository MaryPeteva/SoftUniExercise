int row = int.Parse(Console.ReadLine());
char[,] matrix = new char[row, row];
for (int i = 0; i < row; i++) 
{
    string input = Console.ReadLine();

    for (int j = 0; j < row; j++)
    {
        matrix[i, j] = input[j];
    }
}

char searched = Console.ReadLine()[0];
bool found = false;
string toPrint = string.Empty;
for (int i = 0; i < row; i++) 
{
    for (int j = 0; j < row; j++)
    {
        if (matrix[i, j] == searched) 
        {
            found = true;
            toPrint = $"({i}, {j})";
            break;
        }

        if (found) 
        {
            break;
        }
    }
}

if (found)
{
    Console.WriteLine(toPrint);
}
else 
{
    Console.WriteLine($"{searched} does not occur in the matrix");
}