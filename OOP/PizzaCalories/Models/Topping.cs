using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Models
{
    public class Topping
    {
        private const int calPerGram = 2;
        private Dictionary<string, double> toppingTypes = new Dictionary<string, double>() { { "meat", 1.2 }, { "veggies", 0.8 }, { "cheese", 1.1 }, { "sauce", 0.9 } };
        private string typeTopping;
        private double gramsTopping;
        private double modCals;

        public Topping(string inType, double inGrams)
        {
            Type = inType;
            Gram = inGrams;
            modCals = toppingTypes[Type.ToLower()];
        }

        public string Type
            { get { return typeTopping; }
            private set 
            {
                if (!toppingTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                typeTopping = value.ToLower();
            }
        }

        public double Gram 
        {
            get { return gramsTopping; }
            private set 
            {
                if (value < 1 || value > 50) 
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }
                gramsTopping = value;
            }
        }

        public double ToppingCals() 
        {
            return calPerGram * modCals * gramsTopping;
        }
    }
}
