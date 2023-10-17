using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    using Models;

    public class StartUp
    {
        static void Main()
        {
            var persons = new Dictionary<string, Person>();
            var products = new Dictionary<string, Product>();

            try
            {
                string[] ppl = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (var personData in ppl)
                {
                    string[] tokens = personData.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = tokens[0];
                    decimal money = decimal.Parse(tokens[1]);
                    persons[name] = new Person(name, money);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            try
            {
                string[] prodsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (var productData in prodsInput)
                {
                    string[] tokens = productData.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = tokens[0];
                    decimal cost = decimal.Parse(tokens[1]);
                    products[name] = new Product(name, cost);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string persName = tokens[0];
                string prodName = tokens[1];

                if (persons.TryGetValue(persName, out Person tempPers) && products.TryGetValue(prodName, out Product tempProd))
                {
                    try
                    {
                        Console.WriteLine(tempPers.AddProduct(tempProd));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, persons.Values));
        }
    }
}
