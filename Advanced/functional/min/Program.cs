HashSet<int> nums = Console.ReadLine().Split().Select(int.Parse).ToHashSet();
Func<HashSet<int>, int> min = nums =>
{
    int min = int.MaxValue;
    foreach (int n in nums) 
    {
        if (n < min) 
        {
            min = n;
        }
    }
    return min;
};

Console.WriteLine(min(nums));