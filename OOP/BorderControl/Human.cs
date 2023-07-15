using BorderControl.Models.Interfaces;

namespace BorderControl.Models;

public class Human : IIdentible, IHuman
{
    private string name;
    private int age;
    private string id;
    public Human(string nameIn, int ageIn, string idIn)
    {
        Name = nameIn;
        Age = ageIn;
        Id = idIn;

    }
    public string Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }
}
