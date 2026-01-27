using CoreApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp_MS_Testing
{
    [TestClass]
    public class FileProcessorMSTests
    {
        private string filePath;
        private FileProcessor processor;

        [TestInitialize]
        public void Setup()
        {
            processor = new FileProcessor();
            filePath = "testfile.txt";
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        [TestMethod]
        public void WriteAndRead_File_WorksCorrectly()
        {
            processor.WriteToFile(filePath, "Hello");
            string content = processor.ReadFromFile(filePath);
            Assert.AreEqual("Hello", content);
        }

        [TestMethod]
        public void File_Exists_AfterWrite()
        {
            processor.WriteToFile(filePath, "Data");
            Assert.IsTrue(File.Exists(filePath));
        }

        [TestMethod]
        public void Read_NonExistingFile_ThrowsException()
        {
            Assert.Throws<FileNotFoundException>(() => processor.ReadFromFile("nofile.txt"));
        }
    }
}
