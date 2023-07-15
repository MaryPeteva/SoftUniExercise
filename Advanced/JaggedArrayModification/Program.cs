//Create a program that reads a matrix from the console. On the first line, you will get matrix rows. On the next rows
//lines, you will get elements for each column separated with space. You will be receiving commands in the following
//format:
// Add {row} { col} { value} – Increase the number at the given coordinates with the value.
// Subtract {row} { col} { value} – Decrease the number at the given coordinates by the value.
//Coordinates might be invalid. In this case, you should print "Invalid coordinates". When you receive "END"
//you should print the matrix and stop the program

int rows = int.Parse(Console.ReadLine());
int[][] jaggedMatrix = new int[rows][];
for (int i = 0; i < rows; i++) 
{
    jaggedMatrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
}

string input = string.Empty;
while ((input = Console.ReadLine()) != "END") 
{
    string[] arrInput = input.Split().ToArray();
    string command = arrInput[0];
    int row = int.Parse(arrInput[1]);
    int col = int.Parse(arrInput[2]);
    int value = int.Parse(arrInput[3]);

    if (row >= 0 && row < jaggedMatrix.Length && col >= 0 && col < jaggedMatrix[row].Length)
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
    else 
    {
        Console.WriteLine("Invalid coordinates");
    }

}

for (int i = 0; i < rows; i++)
{
    Console.WriteLine(string.Join(" ", jaggedMatrix[i]));
}
