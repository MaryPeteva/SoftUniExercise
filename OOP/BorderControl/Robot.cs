using BorderControl.Models.Interfaces;
namespace BorderControl.Models;

public class Robot : IIdentible,IRobot
{
    private string id;
    private string model;

    public Robot(string modelIn, string idIn)
    {
        Id = idIn;
        model = modelIn;
    }
    public string Id { get => id; set => id = value; }
    public string Model { get => model; set => model = value; }
}
