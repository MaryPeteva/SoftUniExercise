using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double FoodWeightGainConst = 0.40;

        public Dog(string nameIn, double weightIn, string livingRegionIn) : base(nameIn, weightIn, livingRegionIn, FoodWeightGainConst)
        {
            Foods.Add(new Meat(0));
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
