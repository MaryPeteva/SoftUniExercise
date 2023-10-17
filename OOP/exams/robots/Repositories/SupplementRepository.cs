using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        List<ISupplement> supplements;
        public SupplementRepository() 
        {
            this.supplements = new List<ISupplement>();
        }
        public void AddNew(ISupplement model)=> this.supplements.Add(model);

        public ISupplement FindByStandard(int interfaceStandard) => this.supplements.FirstOrDefault(s => s.InterfaceStandard == interfaceStandard);
        

        public IReadOnlyCollection<ISupplement> Models() => this.supplements.AsReadOnly();


        public bool RemoveByName(string typeName) => this.supplements.Remove(this.supplements.FirstOrDefault(s => s.GetType().Name == typeName));

    }
}
