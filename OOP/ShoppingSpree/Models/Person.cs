using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;
        public Person(string name, decimal money)
        {
            PersonName = name; 
            Money = money;
            products = new List<Product>();
        }

        public string PersonName { get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Money { get {  return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");    
                }
                money = value;
            }
        }

        public string AddProduct(Product prod) 
        {
            return CheckPriceMoney(prod);
            
        }

        private string CheckPriceMoney(Product prod)
        {
            if (money - prod.Cost < 0) 
            {
                throw new ArgumentException($"{PersonName} can't afford {prod.ProductName}");
            }
            money -= prod.Cost;
            products.Add(prod);
            return $"{PersonName} bought {prod.ProductName}";
        }

        public override string ToString()
        {
            if (products.Count > 0)
            {
                return $"{PersonName} - {string.Join(", ", products.Select(p => p.ToString()))}";
            }
            else
            {
                return $"{PersonName} - Nothing bought";
            }
        }
    }
}
