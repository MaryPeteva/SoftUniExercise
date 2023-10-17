

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double IncreasedConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapIn)
            : base(fuelQuantity, fuelConsumption, tankCapIn, IncreasedConsumption)
        {
        }
    }
}
