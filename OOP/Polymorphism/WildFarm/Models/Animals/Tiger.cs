using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double FoodWeightGainConst = 1.00;
        private List<Food> foods;
        public Tiger(string nameIn, double weightIn, string livingRegionIn, string breed) : base(nameIn, weightIn, livingRegionIn, breed, FoodWeightGainConst)
        {
            
            Foods.Add(new Meat(0));
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
