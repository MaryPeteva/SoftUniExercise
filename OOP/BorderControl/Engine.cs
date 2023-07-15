using System;
using BorderControl.Core.Interfaces;
using BorderControl.IO.Interfaces;
using BorderControl.Models.Interfaces;
using BorderControl.Models;
namespace BorderControl.Core;
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
        string input = string.Empty;
        List<IIdentible> arrivals = new List<IIdentible>();
        while ((input = reader.ReadLine()) != "End") 
        {
            string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            IIdentible current = null;
            if (tokens.Length == 2)
            {
                current = new Robot(tokens[0], tokens[1]);
            }
            else if (tokens.Length == 3) 
            {
                current = new Human(tokens[0], int.Parse(tokens[1]), tokens[2]);
            }

            arrivals.Add(current);
        }

        string endingFakeId = reader.ReadLine();
        List<string> fakeId = new List<string>();
        foreach (var identity in arrivals) 
        {
            if (identity.Id.EndsWith(endingFakeId)) 
            {
                fakeId.Add(identity.Id);
            }
        }

        writer.WriteLine(string.Join("\n", fakeId));
    }
}
