using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        List<IRobot> robots;
        public RobotRepository() 
        {
            robots = new List<IRobot>();
        }
        public void AddNew(IRobot model) => this.robots.Add(model);

        public IRobot FindByStandard(int interfaceStandard) => this.robots.FirstOrDefault(r => r.InterfaceStandards.Any(i=>i == interfaceStandard));

        public IReadOnlyCollection<IRobot> Models() => this.robots.AsReadOnly();


        public bool RemoveByName(string typeName) => this.robots.Remove(this.robots.FirstOrDefault(r => r.GetType().Name == typeName));
    }
}
