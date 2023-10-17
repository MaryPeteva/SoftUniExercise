using System;

namespace CustomRandomList
{
    public class StartUp
    {

        static void Main()
        {
            RandomList l = new RandomList();
            l.Add("123");
            l.Add("abv");
            l.Add("dssa");
            string n = l.RandomString();
            Console.WriteLine(n);
        }
    }
}