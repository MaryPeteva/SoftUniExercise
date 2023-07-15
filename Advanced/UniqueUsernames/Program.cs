int num = int.Parse(Console.ReadLine());
HashSet<string> userNames = new HashSet<string>();
for (int i = 0; i < num; i++) 
{
    userNames.Add(Console.ReadLine());
}

foreach (var name in userNames) 
{
    Console.WriteLine(name);
}