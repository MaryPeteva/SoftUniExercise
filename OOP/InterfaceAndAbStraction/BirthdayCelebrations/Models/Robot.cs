using BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations.Models
{
    public class Robot : IIdentible, IRobot
    {
        private string model;
        private string id;
        public Robot(string modelIn, string idIn)
        {
            Id = idIn;
            Model = modelIn;

        }
        public string Model { get => model; set => model = value; }
        public string Id { get => id; set => id = value; }
    }
}
