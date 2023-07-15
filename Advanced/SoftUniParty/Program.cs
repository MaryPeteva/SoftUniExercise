List<string> guests = new List<string>();
string input = string.Empty;
while ((input = Console.ReadLine()) != "PARTY") 
{
    guests.Add(input);
}

while ((input = Console.ReadLine()) != "END") 
{
    guests.Remove(input);
}

Console.WriteLine($"{guests.Count}\n{string.Join("\n", guests)}");