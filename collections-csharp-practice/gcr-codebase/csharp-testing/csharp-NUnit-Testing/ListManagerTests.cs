using NUnit.Framework;
using System.Collections.Generic;
using CoreApp;

namespace CoreApp.Tests
{
    [TestFixture]
    public class ListManagerTests
    {
        private ListManager manager;
        private List<int> list;

        [SetUp]
        public void Setup()
        {
            manager = new ListManager();
            list = new List<int>();
        }

        [Test]
        public void AddElement_AddsItem()
        {
            manager.AddElement(list, 10);
            Assert.Contains(10, list);
        }

        [Test]
        public void RemoveElement_RemovesItem()
        {
            list.Add(5);
            manager.RemoveElement(list, 5);
            Assert.IsFalse(list.Contains(5));
        }

        [Test]
        public void GetSize_ReturnsCorrectCount()
        {
            manager.AddElement(list, 1);
            manager.AddElement(list, 2);
            Assert.AreEqual(2, manager.GetSize(list));
        }
    }

}