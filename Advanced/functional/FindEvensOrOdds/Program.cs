using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int maxLength = int.Parse(Console.ReadLine());
        List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        List<string> filteredNames = FilterNames(names, maxLength);
       Console.WriteLine(string.Join("\n", filteredNames));
    }

    static List<string> FilterNames(List<string> names, int maxLength)
    {
        List<string> filteredNames = new List<string>();

        foreach (string name in names)
        {
            if (name.Length <= maxLength)
            {
                filteredNames.Add(name);
            }
        }

        return filteredNames;
    }
}
