using BirthdayCelebrations.core.Interfaces;
using BirthdayCelebrations.IO.Interfaces;
using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations.core
{
    public class Engine:IEngine
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
            List<IBirthdatable> brDatables = new List<IBirthdatable>();
            while ((input = reader.ReadLine()) != "End") 
            {
                IBirthdatable current = null;
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                switch (tokens[0]) 
                {
                    case "Citizen":
                        current = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
                        break;
                    case "Pet":
                        current = new Pet(tokens[1], tokens[2]);
                        break;
                }
                if (current != null) 
                {
                
                    brDatables.Add(current);
                }
            }

            string year = reader.ReadLine();
            List<string> years = new List<string>();
            foreach (var brD in brDatables) 
            {
                if (brD.Birthdate.EndsWith(year)) 
                {
                    years.Add(brD.Birthdate);
                }
            }

            if (years.Any())
            {
                writer.WriteLine(string.Join("\n", years));
            }
            else 
            {
                writer.WriteLine(" ");
            }
        }
    }
}
