using System;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataStreamProcessing
{
    /// <summary>
    /// Demonstrates inter-process communication using anonymous pipes.
    /// Allows bidirectional message passing between threads with stream-based I/O.
    /// </summary>
    class InterProcessPipeComm
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Inter-Process Pipe Communication ===\n");

            try
            {
                using (AnonymousPipeServerStream serverPipe = 
                       new AnonymousPipeServerStream(PipeDirection.Out))
                using (AnonymousPipeClientStream clientPipe = 
                       new AnonymousPipeClientStream(PipeDirection.In, serverPipe.ClientSafePipeHandle))
                {
                    Console.WriteLine("Pipe established. Starting communication...\n");

                    Thread senderThread = new Thread(() => SendMessages(serverPipe));
                    Thread receiverThread = new Thread(() => ReceiveMessages(clientPipe));

                    senderThread.Start();
                    receiverThread.Start();

                    senderThread.Join();
                    receiverThread.Join();

                    Console.WriteLine("\nCommunication completed.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Pipe Communication Error: {ex.Message}");
            }
        }

        private static void SendMessages(Stream pipe)
        {
            using (StreamWriter sender = new StreamWriter(pipe, Encoding.UTF8) { AutoFlush = true })
            {
                for (int i = 1; i <= 5; i++)
                {
                    sender.WriteLine($"Message {i}");
                    Thread.Sleep(500); // Simulate processing delay
                }
            }
        }

        private static void ReceiveMessages(Stream pipe)
        {
            using (StreamReader receiver = new StreamReader(pipe, Encoding.UTF8))
            {
                string message;
                while ((message = receiver.ReadLine()) != null)
                {
                    Console.WriteLine($"[Received] {message}");
                }
            }
        }
    }
}
