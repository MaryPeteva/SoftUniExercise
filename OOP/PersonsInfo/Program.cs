namespace PersonInfo 
{
    public class StartUp 
    {
        static void Main() 
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            IPerson pers = new Citizen(name, age);
            Console.WriteLine(pers.Name);
            Console.WriteLine(pers.Age);
        }
    }
}