using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Seat : ICar
    {
        private string model;
        private string color;

        public Seat(string inMod, string inCol)
        {
            Model = inMod; 
            Color = inCol;
        }

        public string Model { get => model; set => this.model = value; }
        public string Color { get => color; set => this.color = value; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{Color} Seat {Model}";
        }
    }
}
