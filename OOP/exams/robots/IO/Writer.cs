namespace RobotService.IO
{
    using RobotService.IO.Contracts;
    using System;
    public class Writer : IWriter
    {
        public void Write(string message) 
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(message);
            Console.ResetColor();
        }

        public void WriteLine(string message) 
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
