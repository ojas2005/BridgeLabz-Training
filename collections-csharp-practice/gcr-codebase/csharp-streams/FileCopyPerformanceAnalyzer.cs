using System;
using System.Diagnostics;
using System.IO;

namespace DataStreamProcessing
{
    /// <summary>
    /// Demonstrates performance comparison between direct stream operations and buffered stream operations
    /// for file copying operations.
    /// </summary>
    class FileCopyPerformanceAnalyzer
    {
        private const int BUFFER_SIZE = 4096; // 4 KB buffer size

        static void Main(string[] args)
        {
            Console.WriteLine("=== File Copy Performance Analyzer ===\n");
            
            Console.Write("Enter source file path: ");
            string sourceFile = Console.ReadLine();

            if (!File.Exists(sourceFile))
            {
                Console.WriteLine("Error: Source file does not exist.");
                return;
            }

            Console.Write("Enter destination path for direct copy: ");
            string destDirect = Console.ReadLine();

            Console.Write("Enter destination path for optimized copy: ");
            string destOptimized = Console.ReadLine();

            try
            {
                // Direct copy performance measurement
                Stopwatch directTimer = Stopwatch.StartNew();
                PerformDirectStreamCopy(sourceFile, destDirect);
                directTimer.Stop();
                Console.WriteLine($"\nDirect Stream Copy: {directTimer.ElapsedMilliseconds} ms");

                // Optimized buffered copy performance measurement
                Stopwatch optimizedTimer = Stopwatch.StartNew();
                PerformOptimizedStreamCopy(sourceFile, destOptimized);
                optimizedTimer.Stop();
                Console.WriteLine($"Optimized Stream Copy: {optimizedTimer.ElapsedMilliseconds} ms");

                // Calculate improvement
                double improvement = ((double)(directTimer.ElapsedMilliseconds - optimizedTimer.ElapsedMilliseconds) 
                    / directTimer.ElapsedMilliseconds) * 100;
                Console.WriteLine($"\nPerformance Improvement: {improvement:F2}%");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Copies file using direct FileStream operations
        /// </summary>
        private static void PerformDirectStreamCopy(string sourcePath, string destinationPath)
        {
            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            using (FileStream targetStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[BUFFER_SIZE];
                int bytesTransferred;

                while ((bytesTransferred = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    targetStream.Write(buffer, 0, bytesTransferred);
                }
            }
        }

        /// <summary>
        /// Copies file using optimized BufferedStream wrapper
        /// </summary>
        private static void PerformOptimizedStreamCopy(string sourcePath, string destinationPath)
        {
            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            using (BufferedStream bufferedSource = new BufferedStream(sourceStream, BUFFER_SIZE))
            using (FileStream targetStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
            using (BufferedStream bufferedTarget = new BufferedStream(targetStream, BUFFER_SIZE))
            {
                byte[] buffer = new byte[BUFFER_SIZE];
                int bytesTransferred;

                while ((bytesTransferred = bufferedSource.Read(buffer, 0, buffer.Length)) > 0)
                {
                    bufferedTarget.Write(buffer, 0, bytesTransferred);
                }
            }
        }
    }
}
