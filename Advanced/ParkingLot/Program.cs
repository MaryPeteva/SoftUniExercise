HashSet<string> parking = new HashSet<string>();
string input = string.Empty;
while ((input = Console.ReadLine()) != "END") 
{
    string[] tokens = input.Split(", ");
    string command = tokens[0];
    string carNum = tokens[1];
    if (command == "IN")
    {
        parking.Add(carNum);
    }
    else 
    {
        parking.Remove(carNum);
    }
}

if (parking.Any())
{
    foreach (var car in parking)
    {
        Console.WriteLine(car);
    }
}
else 
{
    Console.WriteLine("Parking Lot is Empty");
}