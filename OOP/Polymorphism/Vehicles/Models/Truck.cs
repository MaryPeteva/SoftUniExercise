using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double IncreasedConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapIn) 
            : base(fuelQuantity, fuelConsumption, tankCapIn, IncreasedConsumption)
        {
        }

        public override void Refuel(double amount)
        {
            if (FuelQuantity + amount > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }
            base.Refuel(amount * 0.95);            
        }
    }
}
