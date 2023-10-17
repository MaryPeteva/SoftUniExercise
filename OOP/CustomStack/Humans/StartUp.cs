using System;
namespace Humans 
{
    public class StartUp 
    {
        static void Main() 
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            if (age >= 0) 
            {
                if (age < 15)
                {
                    Child pers = new Child(name, age);
                    Console.WriteLine(pers.ToString());
                }
                else if (age >= 15)
                {
                    Person pers = new Person(name, age);
                    Console.WriteLine(pers.ToString());
                }
            }
        }
    }
}