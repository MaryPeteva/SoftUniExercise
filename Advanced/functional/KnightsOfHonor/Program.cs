Action<string, string[]> sir = (title, name) =>
{
    foreach (var n in name)
    {
        Console.WriteLine($"{title} {n}");
    }
};

string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
sir("Sir", names);