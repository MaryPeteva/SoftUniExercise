using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private const double FoodWeightGainConst = 0.10;

        public Mouse(string nameIn, double weightIn, string livingRegionIn) : base(nameIn, weightIn, livingRegionIn, FoodWeightGainConst)
        {
            
            Foods.Add(new Vegetable(0));
            Foods.Add(new Fruit(0));
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

    }
}
