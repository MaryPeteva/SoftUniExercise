using FoodShortage.Models.Interfaces;
namespace FoodShortage.Models;
public class Citizen : IHuman, ICitizen, IBuyer
{
    private const int foodAddition = 10;
    private string name;
    private string birthdate;
    private string id;
    private int age;
    private int food;

    public Citizen(string nameIn, int ageIn, string idIn, string birthdateIn)
    {
        Name = nameIn;
        Age = ageIn;
        Id = idIn;
        Birthdate = birthdateIn;
        Food = 0;
    }
    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }
    public int Food { get => food; set => food = value; }
    public string Id { get => id; set => id = value; }
    public string Birthdate { get => birthdate; set => birthdate = value; }

    public void BuyFood()
    {
        Food += foodAddition;
    }
}
