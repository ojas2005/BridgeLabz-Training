using System;
using System.IO;

namespace ExceptionHandlingProblems.Handlers
{
    //handles file reading with exception handling for file not found
    public class FileNotFoundHandler
    {
        //read file and handle file not found exception
        public static void Run()
        {
            Console.WriteLine("\n===== File Not Found Exception =====");
            string filePath = "data.txt";

            try
            {
                //attempt to read file
                string content = File.ReadAllText(filePath);
                Console.WriteLine("File contents:");
                Console.WriteLine(content);
            }
            catch (FileNotFoundException)
            {
                //handle file not found exception
                Console.WriteLine("File not found");
            }
            catch (IOException ex)
            {
                //handle other IO exceptions
                Console.WriteLine($"IO Error: {ex.Message}");
            }
        }
    }
}
