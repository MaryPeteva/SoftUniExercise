using System;
using System.Linq;
using System.Reflection;

int rowsCol = int.Parse(Console.ReadLine());
int[,] matrix = new int[rowsCol, rowsCol];
for (int i = 0; i < rowsCol; i++) 
{
   int[] input  = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
    int j = 0;
    foreach (var index in input) 
    {
        matrix[i, j] = index;
        j++;
    }
}
int sum = 0;
for (int i = 0; i < rowsCol; i++) 
{
    for (int j = 0; j < rowsCol; j++)
    {
        if (i == j) 
        {
            sum += matrix[i, j];
        }
    }   
}

Console.WriteLine(sum);