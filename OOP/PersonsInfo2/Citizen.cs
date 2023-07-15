using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfo
{
    public class Citizen : IPerson,IIdentifiable, IBirthable
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;
        public Citizen(string nameIn, int ageIn, string idIn, string birthdateIn)
        {
            Name = nameIn;
            Age = ageIn;
            Id = idIn;
            Birthdate = birthdateIn;
        }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Id { get => id; set => id = value; }
        public string Birthdate { get => birthdate; set => birthdate = value; }
    }
}
