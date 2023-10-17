using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models.Animals
{
    public abstract class Feline : Mammal
    {
        private string breed;
        public Feline(string nameIn, double weightIn, string livingRegionIn, string breed, double foodWeightGainConst) : base(nameIn, weightIn, livingRegionIn, foodWeightGainConst)
        {
            Breed = breed;
        }

        public string Breed { get => this.breed; private set => this.breed = value; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
