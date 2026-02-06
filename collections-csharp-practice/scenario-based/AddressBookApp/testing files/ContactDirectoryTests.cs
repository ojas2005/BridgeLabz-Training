using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookApp.Tests
{
    [TestClass]
    public class ContactDirectoryTests
    {
        private ContactDirectory directory;

        [TestInitialize]
        public void SetUp()
        {
            directory=new ContactDirectory();
        }

        [TestMethod]
        public void InsertContact_WithValidContact_ShouldAddContact()
        {
            //Arrange
            ContactPerson contact=new ContactPerson("Amit","Sharma","12 MG Road","Mumbai","MH","400001","9876543210","amit@test.com");

            //Act
            directory.InsertContact(contact);
            List<ContactPerson> allContacts=directory.GetAllContacts();

            //Assert
            Assert.AreEqual(1,allContacts.Count);
            Assert.IsTrue(allContacts.Contains(contact));
        }

        [TestMethod]
        public void InsertContact_WithDuplicateContact_ShouldNotAdd()
        {
            //Arrange
            ContactPerson contact=new ContactPerson("Amit","Sharma","12 MG Road","Mumbai","MH","400001","9876543210","amit@test.com");
            directory.InsertContact(contact);

            //Act
            directory.InsertContact(contact);
            List<ContactPerson> allContacts=directory.GetAllContacts();

            //Assert
            Assert.AreEqual(1,allContacts.Count);
        }

        [TestMethod]
        public void InsertContact_WithNullContact_ShouldNotCrash()
        {
            //Act
            directory.InsertContact(null);

            //Assert
            Assert.AreEqual(0,directory.GetAllContacts().Count);
        }

        [TestMethod]
        public void DeleteContact_WithValidContact_ShouldRemove()
        {
            //Arrange
            ContactPerson contact=new ContactPerson("Amit","Sharma","12 MG Road","Mumbai","MH","400001","9876543210","amit@test.com");
            directory.InsertContact(contact);

            //Act
            directory.DeleteContact("Amit","Sharma");

            //Assert
            Assert.AreEqual(0,directory.GetAllContacts().Count);
        }

        [TestMethod]
        public void CountByCity_WithMultipleContacts_ShouldReturnCorrectCount()
        {
            //Arrange
            ContactPerson contact1=new ContactPerson("Amit","Sharma","12 MG Road","Mumbai","MH","400001","9876543210","amit@test.com");
            ContactPerson contact2=new ContactPerson("Neha","Verma","45 Park Street","Mumbai","MH","400002","9123456780","neha@test.com");
            ContactPerson contact3=new ContactPerson("Rohit","Mehta","78 Brigade Road","Bengaluru","KA","560001","9988776655","rohit@test.com");

            directory.InsertContact(contact1);
            directory.InsertContact(contact2);
            directory.InsertContact(contact3);

            //Act
            int count=directory.CountByCity("Mumbai");

            //Assert
            Assert.AreEqual(2,count);
        }

        [TestMethod]
        public void CountByState_WithMultipleContacts_ShouldReturnCorrectCount()
        {
            //Arrange
            ContactPerson contact1=new ContactPerson("Amit","Sharma","12 MG Road","Mumbai","MH","400001","9876543210","amit@test.com");
            ContactPerson contact2=new ContactPerson("Neha","Verma","22 FC Road","Pune","MH","411001","9123456780","neha@test.com");
            ContactPerson contact3=new ContactPerson("Rohit","Mehta","78 Brigade Road","Bengaluru","KA","560001","9988776655","rohit@test.com");

            directory.InsertContact(contact1);
            directory.InsertContact(contact2);
            directory.InsertContact(contact3);

            //Act
            int count=directory.CountByState("MH");

            //Assert
            Assert.AreEqual(2,count);
        }

        [TestMethod]
        public void SortByFirstName_WithMultipleContacts_ShouldSortCorrectly()
        {
            //Arrange
            ContactPerson contact1=new ContactPerson("Karan","Singh","12 Road","City","State","12345","9876543210","karan@test.com");
            ContactPerson contact2=new ContactPerson("Anita","Kapoor","34 Road","City","State","12345","9123456780","anita@test.com");
            ContactPerson contact3=new ContactPerson("Bhavesh","Patel","56 Road","City","State","12345","9988776655","bhavesh@test.com");

            directory.InsertContact(contact1);
            directory.InsertContact(contact2);
            directory.InsertContact(contact3);

            //Act
            directory.SortByFirstName();
            List<ContactPerson> allContacts=directory.GetAllContacts();

            //Assert
            Assert.AreEqual("Anita",allContacts[0].FirstName);
            Assert.AreEqual("Bhavesh",allContacts[1].FirstName);
            Assert.AreEqual("Karan",allContacts[2].FirstName);
        }

        [TestMethod]
        public void SortByCity_WithMultipleContacts_ShouldSortCorrectly()
        {
            //Arrange
            ContactPerson contact1=new ContactPerson("Amit","Sharma","12 MG Road","Mumbai","MH","400001","9876543210","amit@test.com");
            ContactPerson contact2=new ContactPerson("Neha","Verma","22 FC Road","Ahmedabad","GJ","380001","9123456780","neha@test.com");
            ContactPerson contact3=new ContactPerson("Rohit","Mehta","78 Brigade Road","Chennai","TN","600001","9988776655","rohit@test.com");

            directory.InsertContact(contact1);
            directory.InsertContact(contact2);
            directory.InsertContact(contact3);

            //Act
            directory.SortByCity();
            List<ContactPerson> allContacts=directory.GetAllContacts();

            //Assert
            Assert.AreEqual("Ahmedabad",allContacts[0].City);
            Assert.AreEqual("Chennai",allContacts[1].City);
            Assert.AreEqual("Mumbai",allContacts[2].City);
        }
    }
}
