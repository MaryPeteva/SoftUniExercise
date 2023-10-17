using System;
using System.Threading.Channels;
using BorderControl.IO.Interfaces;
namespace BorderControl.IO;

public class Writer : IWriter
{
    public void WriteLine(string line)=> Console.WriteLine(line);
   
}
