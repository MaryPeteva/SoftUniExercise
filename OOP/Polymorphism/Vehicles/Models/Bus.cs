using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {

        private const double IncreasedFuelConsumptionWithPeople = 1.4;

        public bool IsAirConditionerOn { get; set; }

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, 0)
        {
            IsAirConditionerOn = true;
        }

        public override string Drive(double distance)
        {
            double consumption = IsAirConditionerOn ? FuelConsumption + IncreasedFuelConsumptionWithPeople : FuelConsumption;

            if (FuelQuantity - distance * consumption < 0)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= distance * consumption;

            return $"{this.GetType().Name} travelled {distance} km";
        }

    }
}

