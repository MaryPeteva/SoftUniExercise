namespace Stealer;
public class StartUp
{
    static void Main() 
    {
        Spy spy = new Spy();
        string res = spy.CollectGettersAndSetters("Stealer.Hacker");
        Console.WriteLine(res);
    }
}