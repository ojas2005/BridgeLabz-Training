using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AddressBookApp.Tests
{
    [TestClass]
    public class HashMapTests
    {
        private HashMap hashMap;

        [TestInitialize]
        public void SetUp()
        {
            hashMap=new HashMap();
        }

        [TestMethod]
        public void Put_WithValidKeyAndValue_ShouldStoreEntry()
        {
            //Arrange
            string key="AddressBook1";
            ContactDirectory value=new ContactDirectory();

            //Act
            hashMap.Put(key, value);

            //Assert
            Assert.AreEqual(1, hashMap.Size);
            Assert.AreEqual(value, hashMap.Get(key));
        }

        [TestMethod]
        public void Get_WithExistingKey_ShouldReturnValue()
        {
            //Arrange
            string key="AddressBook1";
            ContactDirectory value=new ContactDirectory();
            hashMap.Put(key, value);

            //Act
            ContactDirectory retrieved=hashMap.Get(key);

            //Assert
            Assert.AreEqual(value, retrieved);
        }

        [TestMethod]
        public void Get_WithNonExistingKey_ShouldReturnNull()
        {
            //Act
            ContactDirectory retrieved=hashMap.Get("NonExistent");

            //Assert
            Assert.IsNull(retrieved);
        }

        [TestMethod]
        public void ContainsKey_WithExistingKey_ShouldReturnTrue()
        {
            //Arrange
            string key="AddressBook1";
            hashMap.Put(key, new ContactDirectory());

            //Act
            bool contains=hashMap.ContainsKey(key);

            //Assert
            Assert.IsTrue(contains);
        }

        [TestMethod]
        public void ContainsKey_WithNonExistingKey_ShouldReturnFalse()
        {
            //Act
            bool contains=hashMap.ContainsKey("NonExistent");

            //Assert
            Assert.IsFalse(contains);
        }

        [TestMethod]
        public void Size_WithMultipleEntries_ShouldReturnCorrectCount()
        {
            //Arrange
            hashMap.Put("Book1", new ContactDirectory());
            hashMap.Put("Book2", new ContactDirectory());
            hashMap.Put("Book3", new ContactDirectory());

            //Act & Assert
            Assert.AreEqual(3, hashMap.Size);
        }

        [TestMethod]
        public void GetAllKeys_WithMultipleEntries_ShouldReturnAllKeys()
        {
            //Arrange
            hashMap.Put("Book1", new ContactDirectory());
            hashMap.Put("Book2", new ContactDirectory());
            hashMap.Put("Book3", new ContactDirectory());

            //Act
            string[] keys=hashMap.GetAllKeys();

            //Assert
            Assert.AreEqual(3, keys.Length);
            Assert.IsTrue(keys.Contains("Book1"));
            Assert.IsTrue(keys.Contains("Book2"));
            Assert.IsTrue(keys.Contains("Book3"));
        }

        [TestMethod]
        public void GetAllValues_WithMultipleEntries_ShouldReturnAllValues()
        {
            //Arrange
            ContactDirectory dir1=new ContactDirectory();
            ContactDirectory dir2=new ContactDirectory();
            ContactDirectory dir3=new ContactDirectory();

            hashMap.Put("Book1", dir1);
            hashMap.Put("Book2", dir2);
            hashMap.Put("Book3", dir3);

            //Act
            ContactDirectory[] values=hashMap.GetAllValues();

            //Assert
            Assert.AreEqual(3, values.Length);
            Assert.IsTrue(values.Contains(dir1));
            Assert.IsTrue(values.Contains(dir2));
            Assert.IsTrue(values.Contains(dir3));
        }

        [TestMethod]
        public void Remove_WithExistingKey_ShouldRemoveEntry()
        {
            //Arrange
            string key="AddressBook1";
            hashMap.Put(key, new ContactDirectory());

            //Act
            bool removed=hashMap.Remove(key);

            //Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(0, hashMap.Size);
            Assert.IsFalse(hashMap.ContainsKey(key));
        }

        [TestMethod]
        public void Remove_WithNonExistingKey_ShouldReturnFalse()
        {
            //Act
            bool removed=hashMap.Remove("NonExistent");

            //Assert
            Assert.IsFalse(removed);
        }

        [TestMethod]
        public void Put_UpdateExistingKey_ShouldUpdateValue()
        {
            //Arrange
            string key="AddressBook1";
            ContactDirectory value1=new ContactDirectory();
            ContactDirectory value2=new ContactDirectory();

            hashMap.Put(key, value1);

            //Act
            hashMap.Put(key, value2);

            //Assert
            Assert.AreEqual(1, hashMap.Size);
            Assert.AreEqual(value2, hashMap.Get(key));
        }

        [TestMethod]
        public void Clear_WithMultipleEntries_ShouldRemoveAllEntries()
        {
            //Arrange
            hashMap.Put("Book1", new ContactDirectory());
            hashMap.Put("Book2", new ContactDirectory());
            hashMap.Put("Book3", new ContactDirectory());

            //Act
            hashMap.Clear();

            //Assert
            Assert.AreEqual(0, hashMap.Size);
        }
    }
}
