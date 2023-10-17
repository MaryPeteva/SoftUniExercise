using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Models
{
    public class Pizza
    {
        private string pizzaName;
        private Dough douugh;
        private List<Topping> toppings;
   
        public Pizza(string name, Dough dough)
        {
            PizzaName = name;
            douugh = dough;
            toppings = new List<Topping>();
        }

        public string PizzaName
        {
            get { return pizzaName; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                pizzaName = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);

        }

        public double TotalCals
        {
            get
            {
                double topCals = 0;
                foreach (var top in toppings)
                {
                    topCals += top.ToppingCals();
                }
                return douugh.DoughCals + topCals;
            }
        }

        public override string ToString()
        {
            return $"{PizzaName} - {TotalCals:f2} Calories.";
        }
    }
}
