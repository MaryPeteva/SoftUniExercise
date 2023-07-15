Dictionary<int,int> nums = new Dictionary<int,int>();
int n = int.Parse(Console.ReadLine());
int input = 0;
for (int i = 0; i < n; i++) 
{
    input = int.Parse(Console.ReadLine());
    if (!nums.ContainsKey(input))
    {
        nums.Add(input, 1);
    }
    else 
    {
        nums[input]++;
    }
}

foreach(var(num, numV) in nums) 
{
    if(numV % 2 == 0) 
    {
        Console.WriteLine(num);
        break;
    }
}