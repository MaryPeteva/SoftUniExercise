int[] inputNum = Console.ReadLine().Split().Select(int.Parse).ToArray();
int n = inputNum[0] + inputNum[1];
HashSet<int> first = new HashSet<int>();
HashSet<int> second = new HashSet<int>();
int input = 0;
for (int i = 0; i < n; i++) 
{
    input = int.Parse(Console.ReadLine());
    if (i < inputNum[0])
    {
        first.Add(input);
    }
    else 
    {
        second.Add(input);
    }
}

List<int> commonEl = new List<int>();
foreach (var element in first) 
{
    if (second.Contains(element)) 
    {
        commonEl.Add(element);
    }
}

Console.WriteLine(string.Join(" ", commonEl));