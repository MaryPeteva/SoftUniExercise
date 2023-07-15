namespace FoodShortage.Models.Interfaces;

public interface ICitizen 
{
    public int Age { get; set; }
    string Id { get; set; }
    string Birthdate { get; set; }
}