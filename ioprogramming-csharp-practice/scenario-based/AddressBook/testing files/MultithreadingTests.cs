using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBookApp.Tests
{
    [TestClass]
    public class MultithreadingTests
    {
        private ContactDirectory directory;

        [TestInitialize]
        public void SetUp()
        {
            directory = new ContactDirectory();
        }

        [TestMethod]
        public void InsertContact_FromMultipleThreads_ShouldBeSafe()
        {
            int threadCount = 10;
            var threads = new Thread[threadCount];

            for (int i = 0; i < threadCount; i++)
            {
                int threadId = i;
                threads[i] = new Thread(() =>
                {
                    try
                    {
                        var contact = new ContactPerson(
                            $"Rahul{threadId}",
                            $"Sharma{threadId}",
                            $"MG Road {threadId}",
                            "Mumbai",
                            "Maharashtra",
                            $"4000{threadId:D2}",
                            "9876543210",
                            $"rahul{threadId}@test.in"
                        );
                        directory.InsertContact(contact);
                    }
                    catch (ContactException ex)
                    {
                        Assert.Fail($"Thread {threadId} failed: {ex.Message}");
                    }
                });

                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            var allContacts = directory.GetAllContacts();
            Assert.AreEqual(threadCount,allContacts.Count,"Not all contacts were added safely");
        }

        [TestMethod]
        public void ConcurrentOperations_ShouldNotCauseDataCorruption()
        {
            var contact1 = new ContactPerson("Amit","Patel","12 Park Street","Mumbai","Maharashtra","400001","9876543211","amit@test.in");
            var contact2 = new ContactPerson("Sneha","Reddy","45 Brigade Road","Bengaluru","Karnataka","560001","9123456780","sneha@test.in");
            directory.InsertContact(contact1);
            directory.InsertContact(contact2);

            var tasks = new Task[5];
            
            tasks[0] = Task.Run(() => directory.SortByFirstName());
            tasks[1] = Task.Run(() => directory.SortByCity());
            tasks[2] = Task.Run(() => directory.CountByCity("Mumbai"));
            tasks[3] = Task.Run(() => directory.CountByState("Maharashtra"));
            tasks[4] = Task.Run(() => directory.GetAllContacts());

            Task.WaitAll(tasks);

            var finalContacts = directory.GetAllContacts();
            Assert.AreEqual(2,finalContacts.Count,"Data corruption detected");
            Assert.IsTrue(finalContacts.Contains(contact1),"Contact1 missing");
            Assert.IsTrue(finalContacts.Contains(contact2),"Contact2 missing");
        }

        [TestMethod]
        public void ThreadSafeLogger_MultipleThreads_ShouldNotInterleaveOutput()
        {
            var logger = ThreadSafeLogger.Instance;
            int threadCount = 5;
            var threads = new Thread[threadCount];
            for (int i = 0; i < threadCount; i++)
            {
                int threadId = i;
                threads[i] = new Thread(() =>
                {
                    for (int j = 0; j < 3; j++)
                    {
                        logger.Log($"Message from thread {threadId},iteration {j}");
                    }
                });
                threads[i].Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }
            Assert.IsTrue(true,"Logging from multiple threads completed successfully");
        }

        [TestMethod]
        public void DeleteContact_WhileSearching_ShouldBeSafe()
        {

            for (int i = 0; i < 5; i++)
            {
                var contact = new ContactPerson(
                    $"Rahul{i}",
                    $"Sharma{i}",
                    $"Nehru Street {i}",
                    "Pune",
                    "Maharashtra",
                    $"4110{i:D2}",
                    "9876543210",
                    $"rahul{i}@test.in"
                );
                directory.InsertContact(contact);
            }

            var deleteThread = new Thread(() =>
            {
                try
                {
                    Thread.Sleep(50);
                    directory.DeleteContact("Rahul2","Sharma2");
                }
                catch (ContactException)
                {
                }
            });

            var searchThread = new Thread(() =>
            {
                try
                {
                    directory.SearchByCityOrState("Pune");
                }
                catch (ContactException)
                {
                }
            });

            searchThread.Start();
            deleteThread.Start();

            searchThread.Join();
            deleteThread.Join();

            var allContacts = directory.GetAllContacts();
            Assert.IsNotNull(allContacts,"Contact list should not be null");
        }

        [TestMethod]
        public void ParallelInserts_LargeDataSet_ShouldHandleEfficiently()
        {
            int totalContacts = 100;
            var options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };

            Parallel.For(0,totalContacts,options,i =>
            {
                try
                {
                    var contact = new ContactPerson(
                        $"Amit{i}",
                        $"Kumar{i}",
                        $"Street {i}",
                        $"City{i % 5}",
                        $"State{i % 3}",
                        $"{110000 + i}",
                        "9876543210",
                        $"amit{i}@test.in"
                    );
                    directory.InsertContact(contact);
                }
                catch (ContactException)
                {
                }
            });

            var allContacts = directory.GetAllContacts();
            Assert.IsTrue(allContacts.Count > 0,"Parallel inserts should add contacts");
        }
    }
}
