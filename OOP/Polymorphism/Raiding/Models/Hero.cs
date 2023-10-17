using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public abstract class Hero : IHero
    {
        private string name;
        private int power;
        private const int powerIn = 0;

        public Hero(string nameIn, int powerIn)
        {
            Name = nameIn;
            this.Power = powerIn;
        }
        public string Name { get => this.name; private set => this.name = value; }

        public int Power { get => this.power; private set => this.power = value; }

        public virtual string CastAbility()
        {
            return "Casting...";
        }
    }
}
