using BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations.Models
{
    public class Citizen : IIdentible,IBirthdatable,ICitizen
    {
        private string name;
        private string birthdate;
        private string id;
        private int age;
        public Citizen(string nameIn, int ageIn, string idIn, string birthdateIn)
        {
            Name = nameIn;
            Age = ageIn;
            Id = idIn;
            Birthdate = birthdateIn;
        }
        public string Id { get => id; set => id = value; }
        public string Birthdate { get => birthdate; set => birthdate = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
    }
}
