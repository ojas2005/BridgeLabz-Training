using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AddressBookApp.Tests
{

    [TestClass]
    public class ExceptionHandlingTests
    {
        private ContactDirectory directory;
        private ContactService service;

        [TestInitialize]
        public void SetUp()
        {
            directory = new ContactDirectory();
            service = new ContactService();
        }

        [TestMethod]
        [ExpectedException(typeof(ContactException))]
        public void InsertContact_WithNullContact_ShouldThrowContactException()
        {
            directory.InsertContact(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateContact_WithEmptyFirstName_ShouldThrowArgumentException()
        {
            new ContactPerson("","Sharma","45 MG Road","Mumbai","Maharashtra","400001","9876543210","rahul@test.in");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateContact_WithEmptyLastName_ShouldThrowArgumentException()
        {
            new ContactPerson("Rahul","","45 MG Road","Mumbai","Maharashtra","400001","9876543210","rahul@test.in");
        }

        [TestMethod]
        [ExpectedException(typeof(ContactException))]
        public void SearchByCityOrState_WithEmptyValue_ShouldThrowContactException()
        {
            var contact = new ContactPerson("Rahul","Sharma","45 MG Road","Mumbai","Maharashtra","400001","9876543210","rahul@test.in");
            directory.InsertContact(contact);
            directory.SearchByCityOrState("");
        }

        [TestMethod]
        [ExpectedException(typeof(ContactException))]
        public void ViewPersonsByCity_WithEmptyCity_ShouldThrowContactException()
        {
            var contact = new ContactPerson("Rahul","Sharma","45 MG Road","Mumbai","Maharashtra","400001","9876543210","rahul@test.in");
            directory.InsertContact(contact);

            directory.ViewPersonsByCity("");
        }

        [TestMethod]
        [ExpectedException(typeof(ContactException))]
        public void ViewPersonsByState_WithEmptyState_ShouldThrowContactException()
        {
            var contact = new ContactPerson("Rahul","Sharma","45 MG Road","Mumbai","Maharashtra","400001","9876543210","rahul@test.in");
            directory.InsertContact(contact);

            directory.ViewPersonsByState("");
        }

        [TestMethod]
        [ExpectedException(typeof(ContactException))]
        public void SortByFirstName_WithInvalidData_ShouldThrowContactException()
        {
            directory.SortByFirstName();
        }
    }
}
