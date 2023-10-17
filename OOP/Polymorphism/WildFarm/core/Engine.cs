
using WildFarm.Core.Interfaces;
using WildFarm.Factories;
using WildFarm.IO.Interfaces;
using WildFarm.Models.Interfaces;

namespace WildFarms.Core;

public class Engine : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;
 

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        string input = string.Empty;
        List<IAnimal> animals = new List<IAnimal>();
        while ((input = reader.ReadLine()) != "End") 
        {
            try 
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                IAnimal currentAnimal = Factory.CreateAnimal(tokens);
                animals.Add(currentAnimal);
                writer.WriteLine(currentAnimal.ProduceSound());
                string[] tokens2 = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Factory.FeedAnimal(currentAnimal, tokens2[0], int.Parse(tokens2[1]));
            }
            catch (Exception ex)
            {
                writer.WriteLine(ex.Message);
            }
        }

        foreach (var animal in animals)
        {
            writer.WriteLine(animal.ToString());
        }
    }

 }