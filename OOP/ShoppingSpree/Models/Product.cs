using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree.Models
{
    public class Product
    {
        private string productName;
        private decimal productCost;
        public Product(string name, decimal cost)
        {
            ProductName = name;
            Cost = cost;
        }

        public string ProductName { get { return productName; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentNullException("Name cannot be empty.");
                }
                productName = value;
            }
        }
        public decimal Cost { get { return productCost; }
            private set 
            {
                if (value < 0) 
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                productCost = value;
            }
        }

        public override string ToString()
        {
            return ProductName;
        }
    }
}
