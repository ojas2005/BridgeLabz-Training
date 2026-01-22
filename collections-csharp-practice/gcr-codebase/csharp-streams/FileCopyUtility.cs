using System;
using System.IO;

namespace DataStreamProcessing
{
    /// <summary>
    /// Basic file copying utility using FileStream byte-by-byte transfer.
    /// Demonstrates fundamental file I/O operations with proper error handling.
    /// </summary>
    class FileCopyUtility
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== File Copy Utility ===\n");

            Console.Write("Enter source file path: ");
            string sourceFile = Console.ReadLine();

            Console.Write("Enter destination file path: ");
            string destinationFile = Console.ReadLine();

            try
            {
                if (!File.Exists(sourceFile))
                {
                    Console.WriteLine("Error: Source file does not exist.");
                    return;
                }

                CopyFile(sourceFile, destinationFile);
                Console.WriteLine("File copied successfully.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File I/O Error: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access Error: {ex.Message}");
            }
        }

        private static void CopyFile(string sourcePath, string destinationPath)
        {
            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            using (FileStream targetStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
            {
                int currentByte;
                while ((currentByte = sourceStream.ReadByte()) != -1)
                {
                    targetStream.WriteByte((byte)currentByte);
                }
            }
        }
    }
}
