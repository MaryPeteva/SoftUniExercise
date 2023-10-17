using System;
using System.Reflection.PortableExecutable;
using BorderControl.IO.Interfaces;
namespace BorderControl.IO;
public class Reader : IReader
{
    public string ReadLine() => Console.ReadLine();
    
}