
namespace ExtractSpecialBytes
{
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";
            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }
        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string
       bytesFilePath, string outputPath)
        {
            byte[] inputFile = File.ReadAllBytes(binaryFilePath);

            List<string> byteesToSearch = File.ReadAllLines(bytesFilePath).ToList();
            using (MemoryStream output = new MemoryStream()) 
            {
                foreach (var b in inputFile) 
                {
                    if (byteesToSearch.Contains(b.ToString())) 
                    {
                        output.WriteByte(b);
                    }
                }

                File.WriteAllBytes(outputPath, output.ToArray() );
            }
        }
    }
}