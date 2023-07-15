namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            var toSearchReader = new StreamReader(wordsFilePath);
            Dictionary<string, int> wordsToSearch = new Dictionary<string, int>();
            using (toSearchReader)
            {
                while (!toSearchReader.EndOfStream)
                {
                    string[] currentLine = toSearchReader.ReadLine().Split().ToArray();
                    for (int i = 0; i < currentLine.Length; i++)
                    {
                        if (!wordsToSearch.ContainsKey(currentLine[i]))
                        {
                            wordsToSearch[currentLine[i]] = 0;
                        }
                    }
                }
            }

            var reader = new StreamReader(textFilePath);

            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    char[] toReplace = { '-', ',', '.', '!', '?', ' ' };
                    string[] line = reader.ReadLine().Split(toReplace, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (wordsToSearch.ContainsKey(line[i].ToLower()))
                        {
                            wordsToSearch[line[i].ToLower()]++;
                        }
                    }
                }
            }

            var q = wordsToSearch.OrderByDescending(x => x.Value).AsEnumerable().ToDictionary(x => x.Key, x => x.Value);

            var writer = new StreamWriter(outputFilePath);
            using (writer)
            {
                foreach (var (word, n) in q)
                {
                    writer.WriteLine($"{word} - {n}");
                }
            }
        }
    }
}
