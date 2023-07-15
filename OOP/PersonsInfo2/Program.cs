namespace PersonInfo 
{
    public class StartUp 
    {
        static void Main() 
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string id = Console.ReadLine();
            string birthdate = Console.ReadLine();
            IBirthable pers = new Citizen(name, age,id, birthdate);
            IIdentifiable perss = new Citizen(name, age, id, birthdate);
            Console.WriteLine(perss.Id);
            Console.WriteLine(pers.Birthdate);
        }
    }
}