

namespace WildFarm.Models.Animals
{
    public abstract class Mammal : Animal
    {
        private string livingRegion;
        public Mammal(string nameIn, double weightIn, string livingRegionIn, double foodWeightGainConst) : base(nameIn, weightIn, foodWeightGainConst)
        {
            this.LivingRegion = livingRegionIn;
        }

        public string LivingRegion { get => this.livingRegion; private set => this.livingRegion = value; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
