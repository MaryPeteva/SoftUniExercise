using FoodShortage.Core;
using FoodShortage.Core.Interfaces;
using FoodShortage.IO;

IEngine engine = new Engine(new Reader(), new Writer());
engine.Run();