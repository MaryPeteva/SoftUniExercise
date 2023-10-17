using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        private string model;
        private string color;
        private int batterie;

        public Tesla(string inMod, string inCol, int batteries)
        {
            Model = inMod;
            Color = inCol;
            Battery = batteries;
        }
        public string Model { get => model; set => this.model = value; }
        public string Color { get => color; set => this.color = value; }
        public int Battery { get => batterie; set => this.batterie = value; }

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
            return $"{Color} Tesla {Model} with {Battery} Batteries";
        }
    }
}
