using DefiningClasses;
using System;
public class StartUp
{
    static void Main(string[] args) 
    {
    
        Person peter = new();
        peter.Name = "Peter";
        peter.Age = 20;
        Person george = new();
        george.Name = "George";
        george.Age = 18;
        Person jose = new();
        jose.Name = "Jose";
        jose.Age = 43;
    }
}