using WildFarm.Core.Interfaces;
using WildFarm.IO.Interfaces;
using WildFarm.IO;
using WildFarms.Core;

namespace WildFarm
{
    public class StartUp 
    {
        static void Main() 
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            
            IEngine engine = new Engine(reader, writer);

            engine.Run();
        }
    }
}