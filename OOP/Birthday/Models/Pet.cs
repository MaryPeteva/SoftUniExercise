using BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations.Models
{
    public class Pet : IBirthdatable, IPet
    {
        private string name;
        private string birthdate;

        public Pet(string nameIn, string birthdateIn)
        {
            Name = nameIn;
            Birthdate = birthdateIn;
        }
        public string Name { get => name; set => name = value; }
        public string Birthdate { get => birthdate; set => birthdate = value; }
    }
}
