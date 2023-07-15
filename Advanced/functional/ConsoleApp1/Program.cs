double[] nums = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).Select(n => n * 1.2).ToArray();
foreach(var num in nums)
{
    Console.WriteLine($"{num:f2}");
}