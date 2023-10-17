using System;
using System.Collections.Generic;
using System.Linq;
using Raiding.Core.Interfaces;
using Raiding.Factories.Interfaces;
using Raiding.IO.Interfaces;
using Raiding.Models.Interfaces;

namespace Raiding.Core;

public class Engine : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly IHeroFactory factory;
    private readonly ICollection<IHero> heroes;
 

    public Engine(IReader reader, IWriter writer, IHeroFactory factory)
    {
        this.reader = reader;
        this.writer = writer;
        this.factory = factory;
        heroes = new List<IHero>();
    }

    public void Run()
    {
        int numOfHeroes = int.Parse(reader.ReadLine());
        
        for (int i = 0; i < numOfHeroes; i++)
        {
            string name = reader.ReadLine();
            string type = reader.ReadLine();
            try 
            {
                heroes.Add(factory.Create(type, name));
            }
            catch(Exception ex)
            {
                writer.WriteLine(ex.Message);
            }
        }

        int nemesisHealth = int.Parse(reader.ReadLine());
        foreach (var hero in heroes)
        {
            writer.WriteLine(hero.CastAbility());
            if (nemesisHealth > 0) 
            {
                nemesisHealth -= hero.Power;
            }
        }

        if (nemesisHealth <= 0)
        {
            writer.WriteLine("Victory!");
        }
        else 
        {
            writer.WriteLine("Defeat...");
        }
    }

 }