using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models.Animals
{
    public abstract class Bird : Animal
    {
        private double wingSize;
        public Bird(string nameIn, double weightIn, double wingSize, double foodWeightGainConst) : base(nameIn, weightIn, foodWeightGainConst)
        {

            this.WingSize = wingSize;
        }

        public double WingSize { get => this.wingSize; private set => this.wingSize = value; }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
