
namespace AutomotiveRepairShop;

public class Vehicle
{
    public Vehicle(string vin, int mileage, string damage) 
    {
        vin = vin;
        mileage = mileage;
        damage = damage;
    }

    public string Vin 
    {
        get { return this.vin; }
        set { this.vin = value; }
    }

    public int Mileage 
    {
        get { return this.mileage; }
        set { this.mileage = value;}
    }

    public string Damage 
    {
        get { return this.damage; }
        set { this.damage = value; }
    }

    public override string ToString() 
    {
        return $"Damage: {damage}, Vehicle: {vin} ({mileage} km)"
    }
}
