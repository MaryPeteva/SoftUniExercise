using Vehicles.Core.Interfaces;
using Vehicles.Core;
using Vehicles.IO.Interfaces;
using Vehicles.IO;
using Vehicles.Factories.Interfaces;
using Vehicles.Factories;

namespace Vehicles 
{
    public class StartUp 
    {
        static void Main() 
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IVehFactory vehicleFactory = new VehFactory();

            IEngine engine = new Engine(reader, writer, vehicleFactory);

            engine.Run();
        }
    }
}