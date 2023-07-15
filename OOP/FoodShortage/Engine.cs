using FoodShortage.Core.Interfaces;
using FoodShortage.IO.Interfaces;
using FoodShortage.Models;
using FoodShortage.Models.Interfaces;

namespace FoodShortage.Core;
public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }
    public void Run()
    {
        int ppl = int.Parse(reader.ReadLine());
        string input = string.Empty;
        List<IBuyer> humans = new List<IBuyer>();
        for (int i = 0; i < ppl; i++)
        {
            IBuyer current = null;
            string[] temp = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            if (temp.Length > 3) 
            {
                current = new Citizen(temp[0], int.Parse(temp[1]), temp[2], temp[3]);
            }
            else 
            {
                current = new Rebel(temp[0], int.Parse(temp[1]), temp[2]);
            }

            humans.Add(current);
        }
        while ((input = reader.ReadLine()) != "End") 
        {
            humans.FirstOrDefault(h=>h.Name == input)?.BuyFood();
        }

        writer.Write($"{humans.Sum(s => s.Food)}");
    }
}
