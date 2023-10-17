namespace Operations
{
    public class StartUp
    {
        static void Main()
        {
           MathOperations op = new MathOperations();
            Console.WriteLine(op.Add(2,3));
            Console.WriteLine(op.Add(2.2,3.3,5.5));
            Console.WriteLine(op.Add(2.2m,3.3m,4.4m));
        }
    }
}