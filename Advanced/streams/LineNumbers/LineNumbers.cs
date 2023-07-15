using System.IO;
using System.Linq;
using System.Text;

namespace LineNumbers;

public class LineNumbers
{
    static void Main()
    {
        string inputFilePath = @"..\..\..\text.txt";
        string outputFilePath = @"..\..\..\output.txt";

        ProcessLines(inputFilePath, outputFilePath);
    }

    public static void ProcessLines(string inputFilePath, string outputFilePath)
    {
        StringBuilder source = new();

        string[] lines = File.ReadAllLines(inputFilePath);

        for (int i = 0; i < lines.Length; i++)
        {
            int lettersCount = lines[i].Count(char.IsLetter);
            int symbolsCount = lines[i].Count(char.IsPunctuation);

            source.AppendLine($"Line {i + 1}: {lines[i]} ({lettersCount})({symbolsCount})");
        }

        File.WriteAllText(outputFilePath, source.ToString());
    }
}