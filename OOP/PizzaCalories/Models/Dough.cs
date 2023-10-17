using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private const int calPerGram = 2;
        private Dictionary<string, double> flourTypesCals = new Dictionary<string, double> { { "white", 1.5 }, { "wholegrain", 1.0 } };
        private Dictionary<string,double> techCals = new Dictionary<string, double> { { "crispy", 0.9 }, { "chewy", 1.1 }, { "homemade", 1.0 } };
        private string flour;
        private string technique;
        private int grams;
        private double typeMod;
        private double techMod;
        

        public Dough(string inFlour, string inTech, int inGrams)
        {
            Flour = inFlour;
            Tech = inTech;
            Grams = inGrams;
            typeMod = flourTypesCals[Flour.ToLower()];
            techMod = techCals[Tech.ToLower()];
        }

        public string Flour {
            get { return flour; }
            private set 
            {
                if (!flourTypesCals.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flour = value.ToLower();
            }
        }

        public string Tech 
        {
            get { return technique; }
            private set 
            {
                if(!techCals.ContainsKey(value.ToLower()))    
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                technique = value.ToLower();
            }
        }

        public int Grams 
        {
            get { return grams; }
            private set 
            {
                if (value < 1 || value > 200) 
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                grams = value;
            }
        }

        public double DoughCals
        {
            get { return calPerGram * typeMod * techMod * grams; }
        }

    }
}
