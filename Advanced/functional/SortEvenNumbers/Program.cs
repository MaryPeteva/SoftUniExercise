double[] nums = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).Select(n => n * 1.2).ToArray();
//string[] output = nums.Select(n => n.ToString()).Select(n => $"{n:f2}").ToArray();
Console.WriteLine(string.Join("\n", nums));