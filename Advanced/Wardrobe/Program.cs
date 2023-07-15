int n = int.Parse(Console.ReadLine());
Dictionary<string,Dictionary<string,int>> wardrobe = new Dictionary<string,Dictionary<string,int>>();
for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split(" -> ").ToArray();
    string colour = input[0];
    string[] tokens = input[1].Split(",");
    if (!wardrobe.ContainsKey(colour))
    {
        wardrobe.Add(colour, new Dictionary<string,int>());
    }

    for (int j = 0; j < tokens.Length; j++) 
    {
        if (!wardrobe[colour].ContainsKey(tokens[j]))
        {
            wardrobe[colour].Add(tokens[j], 1);
        }
        else 
        {
            wardrobe[colour][tokens[j]]++;
        }
    }

}
string[] toSearch = Console.ReadLine().Split().ToArray();

foreach (var color in wardrobe)
{
    string colorStr = color.Key;
    Console.WriteLine($"{colorStr} clothes:");

    foreach (var item in color.Value)
    {
        string itemStr = item.Key;
        int count = item.Value;
        if (colorStr == toSearch[0] && itemStr == toSearch[1])
        {
            Console.WriteLine($"* {itemStr} - {count} (found!)");
        }
        else 
        {
            Console.WriteLine($"* {itemStr} - {count}");
        }
        
    }
}