using System;

namespace CustomStack
{
    public class StartUp
    {

        static void Main()
        {
            StackOfStrings stStr = new StackOfStrings();
            Console.WriteLine(stStr.IsEmpty());
            stStr.AddRange(new string[] { "1", "11", "dsa", "dfer" });
            Console.WriteLine(stStr.IsEmpty());
        }
    }
}