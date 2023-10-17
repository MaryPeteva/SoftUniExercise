using System;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models;

public abstract class Vehicle : IVehicle
{
    private double increasedConsumption;
    private double fuelQuantity;
    private double fuelConsumption;
    private double tankCapacity;

    protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapIn, double increasedConsumption)
    {
        TankCapacity = tankCapIn;
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
        this.increasedConsumption = increasedConsumption;
    }

    public double FuelQuantity
    {
        get => this.fuelQuantity;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            this.fuelQuantity = value;
        }
    }

    public double FuelConsumption { get => this.fuelConsumption; private set => this.fuelConsumption = value; }

    public double TankCapacity { get => this.tankCapacity; private set => this.tankCapacity = value; }

    public virtual string Drive(double distance)
    {
        double consumption = FuelConsumption + increasedConsumption;

        if (FuelQuantity < distance * consumption)
        {
            throw new ArgumentException($"{this.GetType().Name} needs refueling");
        }

        FuelQuantity -= distance * consumption;

        return $"{this.GetType().Name} travelled {distance} km";
    }

    public virtual void Refuel(double amount) 
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        if (FuelQuantity + amount > TankCapacity) 
        {
            throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
        }
        FuelQuantity += amount;
    }

    public override string ToString()
        => $"{this.GetType().Name}: {FuelQuantity:F2}";
}