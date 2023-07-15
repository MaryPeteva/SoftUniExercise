using AutomotiveRepairShop;
public class RepairShop
{
    public int Capacity { get; private set; }
public List<Vehicle> Vehicles { get; private set; }

public RepairShop(int capacity)
{
    Capacity = capacity;
    Vehicles = new List<Vehicle>();
}

public void AddVehicle(Vehicle vehicle)
{
    if (Vehicles.Count < Capacity)
    {
        Vehicles.Add(vehicle);
    }
}

public bool RemoveVehicle(string vin)
{
    Vehicle vehicle = Vehicles.FirstOrDefault(v => v.VIN == vin);
    if (vehicle != null)
    {
        Vehicles.Remove(vehicle);
        return true;
    }
    return false;
}

public int GetCount()
{
    return Vehicles.Count;
}

public Vehicle GetLowestMileage()
{
    return Vehicles.OrderBy(v => v.Mileage).FirstOrDefault();
}

public string Report()
{
    string report = "Vehicles in the preparatory:\n";
    report += string.Join(Environment.NewLine, Vehicles.Select(v => v.ToString()));
    return report;
}
}