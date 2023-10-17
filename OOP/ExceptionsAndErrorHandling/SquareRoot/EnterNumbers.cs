using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterNumbers
{
    public class Program
    {
        static void Main() 
        {
            int start = 1;
            int end = 100;
            int[] nums = ReadNumbers(start, end);
            Console.WriteLine(string.Join(", ", nums));

        }

        public static int[] ReadNumbers(int start, int end) 
        {
            int[] nums = new int[10];
            int count = 0;
            while (count < 10) 
            {
                var temp = Console.ReadLine();
                try
                {
                    if (int.TryParse(temp, out int n))
                    {
                     
                        if (int.Parse(temp) <= start || int.Parse(temp) >= end)
                        {
                            throw new ArgumentException($"Your number is not in range {start} - {end}!");
                        }
                    }
                    else 
                    {
                        throw new ArgumentException("Invalid Number!");
                    }

                    nums[count] = int.Parse(temp);
                    start = nums[count];
                    count++;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return nums;
        }
    }
}
