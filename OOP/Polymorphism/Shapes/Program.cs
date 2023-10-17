namespace Shapes 
{
    public class StartUp 
    {
        static void Main() 
        {
            Circle c = new Circle(4);
            Console.WriteLine(c.CalculatePerimeter());
            Console.WriteLine(c.CalculateArea());
            Console.WriteLine(c.Draw());
            Rectangle r = new Rectangle(5,5);
            Console.WriteLine(r.CalculateArea());
            Console.WriteLine(r.CalculatePerimeter());
            Console.WriteLine(r.Draw());
        }
    }
}