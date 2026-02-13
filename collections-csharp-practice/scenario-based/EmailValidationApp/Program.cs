using System;
using System.Threading;
class Program
    {
        static EmailValidationService validator = new EmailValidationService();
        static void ProcessUser(object? obj)
        {
            if (obj is not User user)
                return;

            try
            {
                validator.Validate(user.Email);
                FileManager.SaveValidEmail(user.Email);
                Console.WriteLine($"Valid: {user.Email}");
            }
            catch (InvalidEmailException ex)
            {
                FileManager.SaveInvalidEmail(user.Email);
                Console.WriteLine($"Invalid: {user.Email} | {ex.Message}");
            }
            Console.WriteLine("\n");
        }

        static void Main(string[] args)
        {  
            Console.WriteLine("");
            Console.WriteLine("EduConnect Email Registration Portal\n ");
            string[] emails =
            {"john.doe@gmail.com","megha_r92@outlook.in","admin@blitz.edu","john.doe@gmail","@gmail.com","raju#123@inbox.com","tiwariojas578@gmail.com","pushpaksinghal8272.com","prakhar@gmail.com"};
            foreach (var mail in emails)
            {
                User user = new User(mail);
                Thread thread = new Thread(ProcessUser);
                thread.Start(user);
            }
        }
    }
