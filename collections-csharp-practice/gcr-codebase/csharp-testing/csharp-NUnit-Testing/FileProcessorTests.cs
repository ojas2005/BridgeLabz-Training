using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
namespace CoreApp.Tests
{
    [TestFixture]
    public class FileProcessorTests
    {
        private string filePath;
        private FileProcessor processor;

        [SetUp]
        public void Setup()
        {
            processor = new FileProcessor();
            filePath = "testfile.txt";
        }

        [TearDown]
        public void Cleanup()
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        [Test]
        public void WriteAndRead_File_WorksCorrectly()
        {
            processor.WriteToFile(filePath, "Hello");
            string content = processor.ReadFromFile(filePath);
            Assert.AreEqual("Hello", content);
        }

        [Test]
        public void File_Exists_AfterWrite()
        {
            processor.WriteToFile(filePath, "Data");
            Assert.IsTrue(File.Exists(filePath));
        }

        [Test]
        public void Read_NonExistingFile_ThrowsException()
        {
            Assert.Throws<FileNotFoundException>(() => processor.ReadFromFile("nofile.txt"));
        }
    }

}
