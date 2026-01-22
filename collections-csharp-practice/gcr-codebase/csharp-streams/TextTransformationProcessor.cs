using System;
using System.IO;
using System.Text;

namespace DataStreamProcessing
{
    /// <summary>
    /// Processes text files with transformation filters (e.g., case conversion).
    /// Uses StreamReader/StreamWriter with BufferedStream for efficient text processing.
    /// </summary>
    class TextTransformationProcessor
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Text File Transformation Processor ===\n");

            Console.Write("Enter source text file path: ");
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
                TransformTextFile(sourceFile, outputFile, line => line.ToLower());
                Console.WriteLine("File transformation completed successfully.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File I/O Error: {ex.Message}");
            }
        }

        private static void TransformTextFile(string inputPath, string outputPath, 
            Func<string, string> transformation)
        {
            using (FileStream sourceStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (BufferedStream bufferedSource = new BufferedStream(sourceStream))
            using (StreamReader reader = new StreamReader(bufferedSource, Encoding.UTF8))
            using (FileStream targetStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            using (BufferedStream bufferedTarget = new BufferedStream(targetStream))
            using (StreamWriter writer = new StreamWriter(bufferedTarget, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(transformation(line));
                }
            }
        }
    }
}
