int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int exCount = 0;
while (exCount < 3)
{
    string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
    int index = 0;
    int len = nums.Length - 1;
    try
    {
        switch (input[0])
        {
            case "Replace":
                if (IsItInt(input[1]))
                {
                    index = int.Parse(input[1]);
                    if (IsItInRange(index, len))
                    {
                        if (IsItInt(input[2]))
                        {
                            nums[index] = int.Parse(input[2]);
                        }
                    }
                }
                break;
            case "Print":
                if (IsItInt(input[1]) && IsItInt(input[2]))
                {
                    index = int.Parse(input[1]);
                    int index2 = int.Parse(input[2]);
                    if (IsItInRange(index, len) && IsItInRange(index2, len))
                    {

                        int l2 = index2 - index + 1;
                        int[] outputArr = new int[l2];
                        Array.Copy(nums, index, outputArr, 0, l2);
                        Console.WriteLine(string.Join(", ", outputArr));
                    }
                }
                break;
            case "Show":
                if (IsItInt(input[1]))
                {
                    index = int.Parse(input[1]);
                    if (IsItInRange(index, len))
                    {
                        Console.WriteLine(nums[int.Parse(input[1])]);
                    }
                }
                break;
        }
    }
    catch (Exception ex)
    {
        exCount++;
        Console.WriteLine(ex.Message);
    }
}

Console.WriteLine(string.Join(", ", nums));

static bool IsItInRange(int n, int l)
{
    if (n >= 0 && n <= l)
    {
        return true;
    }
    else
    {
        throw new IndexOutOfRangeException("The index does not exist!");
    }
}
static bool IsItInt(string num)
{
    if (int.TryParse(num, out int n))
    {
        return true;
    }
    else
    {
        throw new FormatException("The variable is not in the correct format!");
    }
}