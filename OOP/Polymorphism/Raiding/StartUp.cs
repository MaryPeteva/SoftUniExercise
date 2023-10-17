using Raiding.Core.Interfaces;
using Raiding.Core;
using Raiding.IO.Interfaces;
using Raiding.IO;
using Raiding.Factories.Interfaces;
using Raiding.Factories;

namespace Raiding
{
    public class StartUp
    {
        static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IHeroFactory factory = new HeroFactory();
            IEngine engine = new Engine(reader, writer, factory);

            engine.Run();
        }
    }
}