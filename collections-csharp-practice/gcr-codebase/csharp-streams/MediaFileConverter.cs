using System;
using System.IO;

namespace DataStreamProcessing
{
    /// <summary>
    /// Converts media files (images, documents) to byte arrays and reconstructs them.
    /// Useful for storage, transmission, or in-memory processing of binary files.
    /// </summary>
    class MediaFileConverter
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Media File to Byte Array Converter ===\n");

            Console.Write("Enter source media file path: ");
            string sourceFile = Console.ReadLine();

            if (!File.Exists(sourceFile))
            {
                Console.WriteLine("Error: Source file does not exist.");
                return;
            }

            Console.Write("Enter output file path: ");
            string outputFile = Console.ReadLine();

            try
            {
                // Read file into byte array
                byte[] fileContent = File.ReadAllBytes(sourceFile);
                Console.WriteLine($"\nFile loaded: {fileContent.Length} bytes");

                // Reconstruct from byte array using memory stream
                using (MemoryStream memoryBuffer = new MemoryStream(fileContent))
                {
                    byte[] recoveredContent = memoryBuffer.ToArray();
                    File.WriteAllBytes(outputFile, recoveredContent);
                }

                Console.WriteLine("File successfully converted and restored.");

                // Verification
                bool contentMatches = VerifyFileIntegrity(sourceFile, outputFile);
                Console.WriteLine(contentMatches 
                    ? "Verification: Files are identical ✓" 
                    : "Verification: Files differ ✗");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File I/O Error: {ex.Message}");
            }
        }

        private static bool VerifyFileIntegrity(string originalPath, string recoveredPath)
        {
            byte[] original = File.ReadAllBytes(originalPath);
            byte[] recovered = File.ReadAllBytes(recoveredPath);
            
            if (original.Length != recovered.Length)
                return false;

            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] != recovered[i])
                    return false;
            }

            return true;
        }
    }
}
