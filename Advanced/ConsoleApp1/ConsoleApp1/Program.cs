using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        string text = string.Empty;
        Stack<string> tempText = new Stack<string>();
        int numOfOperations = int.Parse(Console.ReadLine());

        for (int i = 0; i < numOfOperations; i++)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            string command = input[0];
            switch (command)
            {
                case "1":
                    string argument = input[1];
                    tempText.Push(text);
                    text += argument;
                    break;
                case "2":
                    argument = input[1];
                    tempText.Push(text);
                    text = text.Remove(text.Length - int.Parse(argument));
                    break;
                case "3":
                    argument = input[1];
                    Console.WriteLine(text[int.Parse(argument) - 1]);
                    break;
                case "4":
                    text = tempText.Pop();
                    break;
            }

        }
    }
}