using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Druid : Hero
    {
        private const int PowerDr = 80;
        public Druid(string nameIn) : base(nameIn, PowerDr)
        {
            
        }

        public override string CastAbility() 
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
