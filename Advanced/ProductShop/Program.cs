SortedDictionary<string,Dictionary<string,double>> shops = new SortedDictionary<string,Dictionary<string,double>>();
string input = string.Empty;
while ((input = Console.ReadLine()) != "Revision") 
{
    var tokens = input.Split(", ");
    string shop = tokens[0];
    string product = tokens[1];
    double price = double.Parse(tokens[2]);

    if (!shops.ContainsKey(shop)) 
    {
        shops.Add(shop, new Dictionary<string, double>());
    }
    shops[shop].Add(product,price);
}

foreach (var (shop,inventar) in shops) 
{
    Console.WriteLine($"{shop}->");
    foreach (var product in inventar) 
    {
        Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
    }
}