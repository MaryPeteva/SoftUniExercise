using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double FoodWeightGainConst = 0.35;
        public Hen(string nameIn, double weightIn,  double wingSize) : base(nameIn, weightIn, wingSize, FoodWeightGainConst)
        {
            
            Foods.Add(new Meat(0));
            Foods.Add(new Seeds(0));
            Foods.Add(new Vegetable(0));
            Foods.Add(new Fruit(0));
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
