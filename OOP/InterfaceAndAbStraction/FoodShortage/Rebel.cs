using FoodShortage.Models.Interfaces;
namespace FoodShortage.Models;
public class Rebel:IHuman,IRebel,IBuyer
{
    private const int foodAddition = 5;
    private string name;
    private int age;
    private int food;
    private string group;

    public Rebel(string nameIn, int ageIn, string groupIn)
    {
        Name = nameIn;
        Age = ageIn;
        Group = groupIn;
        Food = 0;
    }
    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }
    public int Food { get => food; set => food = value; }
    public string Group { get => group; set => group = value; }

    public void BuyFood()
    {
        Food += foodAddition;
    }
}