
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private string name;
        private double weight;
        private int foodEaten;
        private double foodWeightGainConst;
        private List<Food> foods;

        protected Animal(string nameIn, double weightIn, double foodWeightGainConst)
        {
            name = nameIn;
            weight = weightIn;
            this.foodWeightGainConst = foodWeightGainConst;
            foods = new List<Food>();
        }

        public string Name { get => this.name; private set => this.name = value; }
        public double Weight { get => this.weight; private set => this.weight = value; }
        public int FoodEaten { get => this.foodEaten; private set => this.foodEaten = value; }
        public List<Food> Foods { get => foods; }

        public void Eat(string foodIn, int amount)
        {
            Food foodS = Foods.FirstOrDefault(food => food.GetType().Name == foodIn);

            if (foodS == null)
            {
                throw new ArgumentException($"{GetType().Name} does not eat {foodIn}!");
            }

            Weight += amount * foodWeightGainConst;
            FoodEaten += amount;
        }

        public virtual string ProduceSound()
        {
            return string.Empty;
        }
    }
}
