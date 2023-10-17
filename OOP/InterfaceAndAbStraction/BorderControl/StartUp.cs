using BorderControl.Core;
using BorderControl.Core.Interfaces;
using BorderControl.IO;

IEngine engine = new Engine(new Reader(), new Writer());
engine.Run();