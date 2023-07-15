int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int[]sorted  = nums.OrderByDescending(x => x).ToArray();
if (nums.Length < 3)
{
    Console.WriteLine(string.Join(" ", sorted));
}
else 
{
    for (int i = 0; i < 3; i++) 
    {
        Console.Write($"{sorted[i]} ");
    }
}