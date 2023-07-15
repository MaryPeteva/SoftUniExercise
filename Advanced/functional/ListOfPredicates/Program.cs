int n = int.Parse(Console.ReadLine());
List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
List<int> divisibles = FindNumbersDivisibleBySequence(n, nums);
Console.WriteLine(string.Join(" ", divisibles));
static bool IsDivisibleBySequence(int num, List<int> nums)
{
    foreach (int divisor in nums)
    {
        if (num % divisor != 0)
        {
            return false;
        }
    }
    return true;
}

static List<int> FindNumbersDivisibleBySequence(int n, List<int> nums)
{
    List<int> numbers = new List<int>();
    for (int i = 1; i <= n; i++)
    {
        if (IsDivisibleBySequence(i, nums))
        {
            numbers.Add(i);
        }
    }
    return numbers;
}