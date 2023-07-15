using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomotiveRepairShop;

public class RepairShop
{
    private int capacity;
    private List<Vehicle> vahicles;

    public RepairShop(int cap) 
    {
        capacity = cap;
        vahicles = new List<Vehicle>();
    }
    public int Capacity 
    {
        get { return this.capacity; }
        set { this.capacity = value; }
    }

    public List<Vehicle> Vehicles 
    {
        get { return this.vahicles; }
        set { this.vahicles = value;}
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
        Vehicle vehicle = Vehicles.FirstOrDefault(v => v.Vin == vin);

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
        return $"Vehicles in the preparatory:\n{string.Join("\n", Vehicles)}";
    }
}
