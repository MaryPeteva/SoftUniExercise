namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";
            MergeTextFiles(firstInputFilePath, secondInputFilePath,
           outputFilePath);
        }
        public static void MergeTextFiles(string firstInputFilePath, string
       secondInputFilePath, string outputFilePath)
        {
            string[] firstFile = File.ReadAllLines(firstInputFilePath);
            string[] secondFile = File.ReadAllLines(secondInputFilePath);
            int lines = firstFile.Length + secondFile.Length;
            var writer = new StreamWriter(outputFilePath);
            using (writer) 
            {
                for (int i = 0; i < lines; i++)
                {
                    if (i < firstFile.Length)
                    {
                        writer.WriteLine(firstFile[i]);
                    }

                    if (i < secondFile.Length)
                    {
                        writer.WriteLine(secondFile[i]);
                    }
                }
            }
        }
    }
}