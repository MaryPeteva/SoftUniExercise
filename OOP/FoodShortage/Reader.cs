using FoodShortage.IO.Interfaces;
namespace FoodShortage.IO;
public class Reader : IReader
{
    public string ReadLine() => Console.ReadLine();
   
}