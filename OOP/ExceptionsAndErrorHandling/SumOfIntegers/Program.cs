using System;

public class Program
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        long sum = 0;
        foreach (string line in input)
        {
            try
            {
                if (!long.TryParse(line, out long n))
                {
                    throw new FormatException($"The element '{line}' is in wrong format!");
                }

                if (n > int.MaxValue || n < int.MinValue)
                {
                    throw new OverflowException($"The element '{line}' is out of range!");
                }

                sum += n;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }
            finally
            {
                Console.WriteLine($"Element '{line}' processed - current sum: {sum}");
            }
        }

        Console.WriteLine($"The total sum of all integers is: {sum}");
    }
}
