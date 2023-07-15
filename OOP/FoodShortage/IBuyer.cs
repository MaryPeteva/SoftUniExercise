namespace FoodShortage.Models.Interfaces;
public interface IBuyer :IHuman
{
    public int Food { get; }
    void BuyFood();
}