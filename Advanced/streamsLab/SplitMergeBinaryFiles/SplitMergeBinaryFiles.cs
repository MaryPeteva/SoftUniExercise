namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";
            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }
        public static void SplitBinaryFile(string sourceFilePath, string
       partOneFilePath, string partTwoFilePath)
        {
            byte[] sourceFile = File.ReadAllBytes(sourceFilePath);
            int firstL = 0;
            int secondL = 0;
            if (sourceFile.Length % 2 == 0)
            {
                firstL = sourceFile.Length / 2;
                secondL = sourceFile.Length / 2;
            }
            else 
            {
                firstL = (sourceFile.Length / 2) + 1;
                secondL = (sourceFile.Length / 2) - 1;
            }
            byte[] firstPart = new byte[firstL];
            byte[] secondPart = new byte[secondL];

            Array.Copy(sourceFile, firstPart, firstL);
            Array.Copy(sourceFile, firstL, secondPart, 0, secondL);
            File.WriteAllBytes(partOneFilePath, firstPart);
            File.WriteAllBytes(partTwoFilePath, secondPart);
        }
        public static void MergeBinaryFiles(string partOneFilePath, string
       partTwoFilePath, string joinedFilePath)
        {
            byte[] firstP = File.ReadAllBytes(partOneFilePath);
            byte[] secondP = File.ReadAllBytes(partTwoFilePath);
            byte[] merged = firstP.Concat(secondP).ToArray();
            using (MemoryStream output = new MemoryStream()) 
            {
            
                foreach (byte b in merged)
                {
                    output.WriteByte(b);
                }

                File.WriteAllBytes(joinedFilePath, output.ToArray());
            }

        }
    }
}