
using WildFarm.Models.Foods;

namespace WildFarm.Models.Interfaces
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }
        List<Food> Foods { get; } 
        public void Eat(string food, int amount);
        public string ProduceSound();
    }
}
