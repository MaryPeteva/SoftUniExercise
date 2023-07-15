SortedDictionary<char, int> text =  new SortedDictionary<char, int>();
string input = Console.ReadLine();
foreach (var ch in input) 
{
    if (!text.ContainsKey(ch))
    {
        text.Add(ch, 1);
    }
    else 
    {
        text[ch]++;
    }
}

foreach (var (ch, n) in text) 
{
    Console.WriteLine($"{ch}: {n} time/s");
}