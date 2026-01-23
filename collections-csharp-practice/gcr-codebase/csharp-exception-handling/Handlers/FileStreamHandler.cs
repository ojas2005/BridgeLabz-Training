using System;
using System.IO;

namespace ExceptionHandlingProblems.Handlers
{
    //handles file reading using using statement for automatic resource cleanup
    public class FileStreamHandler
    {
        //read first line from file using using statement
        public static void Run()
        {
            Console.WriteLine("\n===== Using Statement for File Handling =====");
            string filePath = "info.txt";

            try
            {
                //using statement ensures StreamReader is disposed automatically
                using (StreamReader reader = new StreamReader(filePath))
                {
                    //read first line from file
                    string firstLine = reader.ReadLine();

                    if (firstLine != null)
                    {
                        Console.WriteLine($"First line: {firstLine}");
                    }
                    else
                    {
                        Console.WriteLine("File is empty");
                    }
                }
                //StreamReader is automatically closed and disposed here
            }
            catch (FileNotFoundException)
            {
                //handle file not found exception
                Console.WriteLine("Error reading file");
            }
            catch (IOException ex)
            {
                //handle IO exceptions
                Console.WriteLine($"IO Error: {ex.Message}");
            }
        }
    }
}
