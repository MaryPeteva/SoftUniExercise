﻿namespace ZipAndExtract;

using System.IO;
using System.IO.Compression;

public class ZipAndExtract
{
    static void Main()
    {
        string inputFile = @"..\..\..\copyMe.png";
        string zipFile = @"..\..\..\archive.zip";
        string extractedFile = @"..\..\..\extracted.png";

        ZipFileToArchive(inputFile, zipFile);

        string fileName = Path.GetFileName(inputFile);
        ExtractFileFromArchive(zipFile, fileName, extractedFile);
    }

    public static void ZipFileToArchive(string inputFilePath, string zipFilePath)
    {
        using ZipArchive archive = ZipFile.Open(zipFilePath, ZipArchiveMode.Create);

        string fileName = Path.GetFileName(inputFilePath);

        archive.CreateEntryFromFile(inputFilePath, fileName);
    }

    public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
    {
        using ZipArchive archive = ZipFile.OpenRead(zipArchiveFilePath);

        ZipArchiveEntry fileForExctraction = archive.GetEntry(fileName);

        fileForExctraction.ExtractToFile(outputFilePath);
    }
}