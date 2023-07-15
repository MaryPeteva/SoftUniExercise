namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";
            GetFolderSize(folderPath, outputPath);
        }
        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            double memorySum = 0;
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] files = dir.GetFiles("*", SearchOption.AllDirectories);
            foreach (FileInfo file in files) 
            {
                memorySum += file.Length;
            }

            memorySum = memorySum / 1024;
            string toWrite = $"{memorySum.ToString()} KB";
            File.WriteAllText(outputFilePath, toWrite);
        }
    }
}