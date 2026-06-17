using System;
using System.Threading;

namespace AddressBookApp.Utilities
{
    public class ThreadSafeLogger
    {
        private static readonly Lazy<ThreadSafeLogger> _instance = 
            new Lazy<ThreadSafeLogger>(() => new ThreadSafeLogger());

        private readonly ReaderWriterLockSlim _lockSlim;

        public static ThreadSafeLogger Instance => _instance.Value;

        private ThreadSafeLogger()
        {
            _lockSlim = new ReaderWriterLockSlim();
        }

        public void Log(string message)
        {
            _lockSlim.EnterWriteLock();
            try
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] [Thread {Thread.CurrentThread.ManagedThreadId}] {message}");
            }
            finally
            {
                _lockSlim.ExitWriteLock();
            }
        }

        public void LogError(string message, Exception ex = null)
        {
            _lockSlim.EnterWriteLock();
            try
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] [Thread {Thread.CurrentThread.ManagedThreadId}] ERROR: {message}");
                if (ex != null)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
            finally
            {
                _lockSlim.ExitWriteLock();
            }
        }
    }
}
