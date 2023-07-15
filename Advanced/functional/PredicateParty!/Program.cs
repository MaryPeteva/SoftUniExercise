List<string> guests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
string input = string.Empty;
while ((input = Console.ReadLine()) != "Party!")
{
    string[] commands = input.Split().ToArray();
    string command = commands[0];
    string criteriaOne = commands[1];
    string criteriaTwo = commands[2];
    guests = Manipulate(guests, criteriaOne, criteriaTwo, command);
}

if (guests.Any())
{
    Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
}
else 
{
    Console.WriteLine("Nobody is going to the party!");
}

static List<string> Manipulate(List<string> names, string criteriaOne, string criteriaTwo, string action)
{
    switch (criteriaOne) 
    {
        case "StartsWith":
            for (int i = 0; i < names.Count; i++)
            {
                if (StartsWith(names[i], criteriaTwo)) 
                {
                    if (action == "Double")
                    {
                        names.Add(names[i]);
                    }
                    else if (action == "Remove") 
                    {
                        names.Remove(names[i]);
                    }
                }
            }
            break;
        case "EndsWith":
            for (int i = 0; i < names.Count; i++)
            {
                if (EndsWith(names[i], criteriaTwo))
                {
                    if (action == "Double")
                    {
                        names.Add(names[i]);
                    }
                    else if (action == "Remove")
                    {
                        names.Remove(names[i]);
                    }
                }
            }
            break;
        case "Length":
            for (int i = 0; i < names.Count; i++)
            {
                if (LenghtName(names[i], int.Parse(criteriaTwo)))
                {
                    if (action == "Double")
                    {
                        names.Add(names[i]);
                    }
                    else if (action == "Remove")
                    {
                        names.Remove(names[i]);
                    }
                }
            }
            break;
    }
    return names;
}

static bool StartsWith(string name, string criteria)
{
    return name.StartsWith(criteria);
}

static bool EndsWith(string name, string criteria)
{
    return name.EndsWith(criteria);
}

static bool LenghtName(string name, int criteria)
{
    return name.Count() == criteria;
}