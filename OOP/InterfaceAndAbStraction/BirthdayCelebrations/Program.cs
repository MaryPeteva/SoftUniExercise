using BirthdayCelebrations.core;
using BirthdayCelebrations.core.Interfaces;
using BirthdayCelebrations.IO;

IEngine engine = new Engine(new Reader(), new Writer());
engine.Run();