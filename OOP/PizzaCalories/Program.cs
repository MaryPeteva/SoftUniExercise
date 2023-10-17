using PizzaCalories.Models;
namespace PizzaCalories 
{
    public class StartUp 
    {
        static void Main() 
        {
            string[] inputPizza = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] inputDought = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string input = string.Empty;
            try
            {
                Dough dough = new Dough(inputDought[1], inputDought[2], int.Parse(inputDought[3]));
                Pizza pizza = new Pizza(inputPizza[1], dough);
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] inputToppings = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    Topping tempT = new Topping(inputToppings[1], double.Parse(inputToppings[2]));
                    pizza.AddTopping(tempT);
                }

                Console.WriteLine(pizza.ToString());
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}