double[] input = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
Dictionary<double,int> nums = new Dictionary<double,int>();
foreach (var num in input)
{
    if (!nums.ContainsKey(num))
    {
        nums.Add(num, 1);
    }
    else 
    {
        nums[num]++;
    }
}

foreach (var num in nums) 
{
    Console.WriteLine($"{num.Key} - {num.Value} times");
}
