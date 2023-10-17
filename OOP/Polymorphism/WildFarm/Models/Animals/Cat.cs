using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double FoodWeightGainConst = 0.30;

        public Cat(string nameIn, double weightIn, string livingRegionIn, string breed) : base(nameIn, weightIn, livingRegionIn, breed, FoodWeightGainConst)
        {
            
            Foods.Add(new Vegetable(0));
            Foods.Add(new Meat(0));
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }

}
