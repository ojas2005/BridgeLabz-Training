using System;
using System.IO;

namespace DataStreamProcessing
{
    /// <summary>
    /// Captures user profile information from console input and persists to file.
    /// Demonstrates StreamWriter usage with standard input stream.
    /// </summary>
    class UserProfileWriter
    {
        private const string DEFAULT_OUTPUT_FILE = "user_profile.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("=== User Profile Writer ===\n");

            try
            {
                string outputPath = GetOutputPath();
                UserProfile profile = GatherUserProfile();
                SaveProfile(outputPath, profile);

                Console.WriteLine($"\nProfile saved successfully to: {outputPath}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File I/O Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static string GetOutputPath()
        {
            Console.Write($"Enter output file path (default: {DEFAULT_OUTPUT_FILE}): ");
            string input = Console.ReadLine();
            return string.IsNullOrWhiteSpace(input) ? DEFAULT_OUTPUT_FILE : input;
        }

        private static UserProfile GatherUserProfile()
        {
            using (StreamReader inputReader = new StreamReader(Console.OpenStandardInput()))
            {
                Console.Write("Enter your full name: ");
                string name = inputReader.ReadLine();

                Console.Write("Enter your age: ");
                string age = inputReader.ReadLine();

                Console.Write("Enter your favorite programming language: ");
                string language = inputReader.ReadLine();

                return new UserProfile
                {
                    Name = name,
                    Age = age,
                    FavoriteLanguage = language
                };
            }
        }

        private static void SaveProfile(string filePath, UserProfile profile)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("=== User Profile ===");
                writer.WriteLine($"Name: {profile.Name}");
                writer.WriteLine($"Age: {profile.Age}");
                writer.WriteLine($"Favorite Language: {profile.FavoriteLanguage}");
                writer.WriteLine($"Recorded on: {DateTime.Now:F}");
            }
        }
    }

    /// <summary>
    /// Data model for user profile information
    /// </summary>
    class UserProfile
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string FavoriteLanguage { get; set; }
    }
}
