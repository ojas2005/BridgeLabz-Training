using CoreApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp_MS_Testing
{
    [TestClass]
    public class ListManagerMSTests
    {
        private ListManager manager;
        private List<int> list;

        [TestInitialize]
        public void Setup()
        {
            manager = new ListManager();
            list = new List<int>();
        }

        [TestMethod]
        public void AddElement_AddsItem()
        {
            manager.AddElement(list, 10);
            Assert.Contains(10, list);
        }

        [TestMethod]
        public void RemoveElement_RemovesItem()
        {
            list.Add(5);
            manager.RemoveElement(list, 5);
            Assert.IsFalse(list.Contains(5));
        }

        [TestMethod]
        public void GetSize_ReturnsCorrectCount()
        {
            manager.AddElement(list, 1);
            manager.AddElement(list, 2);
            Assert.AreEqual(2, manager.GetSize(list));
        }
    }
}
