using System.IO;
using System.Threading;

public static class FileManager
{
    private static readonly object locker = new object(); //will be used to avoid race condition.
    public static void SaveValidEmail(string email)
    {
        lock(locker) //to avoid race condition,one thread at a time
        {
            File.AppendAllText("valid_emails.txt",email+Environment.NewLine); //email name and then \n in valid_email file
        }
    }
    public static void SaveInvalidEmail(string email)
    {
        lock(locker)
        {
            File.AppendAllText("invalid_emails.txt", email + Environment.NewLine);
        }
    }
}

