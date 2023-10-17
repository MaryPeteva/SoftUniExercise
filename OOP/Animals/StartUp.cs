using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, Animals> animals = new Dictionary<string, Animals>();
            while ((input = Console.ReadLine()) != "Beast!") 
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (tokens.Length < 2) 
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                string name = tokens[0];
                string gender = tokens[2];
                int age = int.Parse(tokens[1]);
                if (age < 0) 
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                switch (input) 
                {
                    case "Dog":
                        Dog dog = new Dog(name, age, gender);
                        animals[input] = dog;
                        break;
                    case "Cat":
                        Cat cat = new Cat(name, age, gender);
                        animals[input] = cat;
                        break;
                    case "Frog":
                        Frog frog = new Frog(name, age, gender);
                        animals[input] = frog;
                        break;
                    case "Kitten":
                        Kittens kitty = new Kittens(name, age, gender);
                        animals[input] = kitty;
                        break;
                    case "Tomcat":
                        Tomcat tcat = new Tomcat(name, age, gender);
                        animals[input] = tcat;
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                    continue;
                }
            }

            foreach (var (type,animal) in animals) 
            {
                Console.WriteLine($"{type}\n{animal.ToString()}");
            }
        }
    }
}