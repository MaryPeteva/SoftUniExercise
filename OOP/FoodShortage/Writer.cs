using FoodShortage.IO.Interfaces;
namespace FoodShortage.IO;
public class Writer : IWriter
{
    public void Write(string line)=> Console.WriteLine(line);
}