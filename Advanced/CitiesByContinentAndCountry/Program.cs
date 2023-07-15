using System.Reflection.Metadata.Ecma335;

Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();
int count = int.Parse(Console.ReadLine());
for (int i = 0; i < count; i++) 
{
    var tokens = Console.ReadLine().Split();
    string continent = tokens[0];
    string country = tokens[1];
    string city = tokens[2];
    
    if (!continents.ContainsKey(continent))
    {
        continents[continent] = new Dictionary<string, List<string>>();
    }
    if (!continents[continent].ContainsKey(country)) 
    {
        continents[continent][country] = new List<string>();
    }
    continents[continent][country].Add(city);
}

foreach (var continent in continents)
{
    Console.WriteLine($"{continent.Key}:");
    foreach (var (country,city) in continent.Value)
    {
        Console.WriteLine($"{country} -> {string.Join(", ",city)}");
    }
}