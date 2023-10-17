using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double FoodWeightGainConst = 0.25;
        
        public Owl(string nameIn, double weightIn, double wingSize) : 
        base(nameIn, weightIn, wingSize, FoodWeightGainConst)
        {
            
            Foods.Add(new Meat(0));
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
