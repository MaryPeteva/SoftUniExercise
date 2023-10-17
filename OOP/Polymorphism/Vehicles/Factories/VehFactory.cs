using Vehicles.Factories.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Factories
{
    public class VehFactory : IVehFactory
    {
        public IVehicle Create(string type, double fuelQuantity, double fuelConsumption, double tankCap)
        {
            switch (type)
            {
                case "Car":
                    return new Car(fuelQuantity, fuelConsumption, tankCap);
                case "Truck":
                    return new Truck(fuelQuantity, fuelConsumption, tankCap);
                case "Bus":
                    return new Bus(fuelQuantity, fuelConsumption, tankCap);
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }
        }

    }
}
