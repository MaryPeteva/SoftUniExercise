using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfo
{
    public class Citizen : IPerson
    {
        private string name;
        private int age;
        public Citizen(string nameIn, int ageIn)
        {
            Name = nameIn;
            Age = ageIn;
        }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
    }
}
