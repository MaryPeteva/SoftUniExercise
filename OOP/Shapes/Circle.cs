using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle:IDrawable
    {
        private double rad;
        public Circle(double rad)
        {
            this.rad = rad;
        }

        public void Draw()
        {
            DrawCircle();
        }

        private void DrawCircle() 
        {
            double rIn = this.rad - 0.4;
            double rOut = this.rad + 0.4;
            for (double i = this.rad; i >= -this.rad; --i)
            {
                for (double j = -this.rad; j < rOut; j+=0.5)
                {
                    double val = j * j + i * i;
                    if (val >= rIn * rIn && val <= rOut * rOut)
                    {
                        Console.Write("*");
                    }
                    else 
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
