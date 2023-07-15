//Write a program that reads a string matrix from the console and performs certain operations with its elements. User
//input is provided in a similar way as in the problems above – first, you read the dimensions and then the data.
//Your program should then receive commands in the format: "swap row1 col1 row2 col2" where row1, col1,
//row2, col2 are coordinates in the matrix. For a command to be valid, it should start with the "swap" keyword along
//with four valid coordinates (no more, no less). You should swap the values at the given coordinates (cell [row1,
//col1] with cell[row2, col2]) and print the matrix at each step (thus you'll be able to check if the operation was
//performed correctly). 
//If the command is not valid (doesn't contain the keyword "swap", has fewer or more coordinates entered or the
//given coordinates do not exist), print "Invalid input!" and move on to the next command. Your program should
//finish when the string "END" is entered.
int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
int row = dimentions[0];
int col = dimentions[1];
string[,] matrix = new string[row, col];
for (int i = 0; i < row; i++) 
{
	string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
    for (int j = 0; j < col; j++)
	{
		matrix[i,j] = input[j];
	}
}

string inputCom = string.Empty;
while ((inputCom = Console.ReadLine()) != "END") 
{
	string[] arrInput = inputCom.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
	string command = arrInput[0];

	if (arrInput.Length < 5 || command != "swap" || arrInput.Length > 5) 
	{
		Console.WriteLine("Invalid input!");
		continue;
	}
    int firstIndex = int.Parse(arrInput[1]);
    int secondIndex = int.Parse(arrInput[2]);
    int thirdIndex = int.Parse(arrInput[3]);
    int fourthIndex = int.Parse(arrInput[4]);
    string temp = string.Empty;
	if ((firstIndex < 0 || firstIndex >= row) || (secondIndex < 0 || secondIndex >= col) || (thirdIndex < 0 || thirdIndex >= row) || (fourthIndex < 0 || fourthIndex >= col)) 
	{
        Console.WriteLine("Invalid input!");
        continue;
    }
	temp = matrix[firstIndex, secondIndex];
	matrix[firstIndex, secondIndex] = matrix[thirdIndex, fourthIndex];
	matrix[thirdIndex, fourthIndex] = temp;

    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}
