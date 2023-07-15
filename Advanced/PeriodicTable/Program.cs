HashSet<string> table = new HashSet<string>();
int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
    for (int j = 0; j < input.Length; j++) 
    {
        table.Add(input[j]);
    }
}
table = table.OrderBy(x => x).ToHashSet();
Console.WriteLine(string.Join(" ", table));