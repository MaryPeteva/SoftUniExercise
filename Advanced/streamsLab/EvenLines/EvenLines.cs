namespace EvenLines
{
    using System;
    using System.Text.RegularExpressions;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            Console.WriteLine(ProcessLines(inputFilePath));
        }
        public static string ProcessLines(string inputFilePath)
        {
            var source = new StreamReader(inputFilePath);
            int lines = 1;
            string ret = string.Empty;
            using (source) 
            {
                while (!source.EndOfStream) 
                {
                    string currentLine = source.ReadLine();
                    currentLine = currentLine.Replace('-', '@').Replace('.', '@').Replace(',', '@').Replace('!', '@').Replace('?', '@');
                    if (lines % 2 != 0)
                    {
                        string[] rev = currentLine.Split().ToArray();
                        Array.Reverse(rev);
                        currentLine = string.Join(" ", rev);
                        ret += currentLine + "\n";
                    }
                    lines++;
                }
            }

            return ret.ToString();

        }
    }
}