using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class DomesticAssistant : Robot
    {
        private const int BatteryCap = 20000;
        private const int ConvertionCapacityIndex = 2000;
        public DomesticAssistant(string model) : base(model, BatteryCap, ConvertionCapacityIndex)
        {
        }
    }
}
