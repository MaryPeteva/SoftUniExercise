using RobotService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Supplement : ISupplement
    {
        private int interfaceStandard;
        private int batteryUsage;
        protected Supplement(int interfaceStandard, int batteryUsage)
        {
            this.interfaceStandard = interfaceStandard;

            this.batteryUsage = batteryUsage;

        }
        public int InterfaceStandard { get => this.interfaceStandard;
            private set 
            {
                this.interfaceStandard = value;
            }
        }

        public int BatteryUsage { get => this.batteryUsage;
            private set 
            {
                this.batteryUsage = value;
            }
        }
    }
}
