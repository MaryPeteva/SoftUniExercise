namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";
            RewriteFileWithLineNumbers(inputPath, outputPath);
        }
        public static void RewriteFileWithLineNumbers(string inputFilePath, string
       outputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            var writer = new StreamWriter(outputFilePath);
            int lineNum = 1;
            using (reader) 
            {
                using (writer) 
                {
                    while (!reader.EndOfStream) 
                    {
                        string line = reader.ReadLine();
                        writer.WriteLine($"{lineNum}. {line}");
                        lineNum++;
                    }
                }
            }
        }
    }
}