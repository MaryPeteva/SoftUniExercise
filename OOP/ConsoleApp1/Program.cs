using RobotService.Models.Contracts;
using RobotService.Models;
namespace RobotService;
public class StartUp 
{
    static void Main() 
    {
        IRobot r = new Robot("K - 2SO",2000,1000);
        r.InstallSupplement();
        Console.WriteLine(r.ToString());
    }
}