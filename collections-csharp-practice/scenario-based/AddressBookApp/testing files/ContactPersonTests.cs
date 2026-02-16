using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AddressBookApp.Tests
{
    [TestClass]
    public class ContactPersonTests
    {
        [TestMethod]
        public void CreateContactPerson_WithValidData_ShouldCreateSuccessfully()
        {
            //Arrange
            string firstName = "Rahul";
            string lastName = "Sharma";
            string address = "45 MG Road";
            string city = "Mumbai";
            string state = "Maharashtra";
            string zip = "400001";
            string phone = "9876543210";
            string email = "rahul@example.in";

            //Act
            ContactPerson contact = new ContactPerson(firstName, lastName, address, city, state, zip, phone, email);

            //Assert
            Assert.AreEqual(firstName, contact.FirstName);
            Assert.AreEqual(lastName, contact.LastName);
            Assert.AreEqual(city, contact.City);
            Assert.AreEqual(state, contact.State);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateContactPerson_WithEmptyFirstName_ShouldThrowException()
        {
            //Arrange & Act
            ContactPerson contact = new ContactPerson("", "Sharma", "12 Park Street", "Delhi", "Delhi", "110001", "9876543210", "test@test.in");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateContactPerson_WithEmptyLastName_ShouldThrowException()
        {
            //Arrange & Act
            ContactPerson contact = new ContactPerson("Rahul", "", "12 Park Street", "Delhi", "Delhi", "110001", "9876543210", "test@test.in");
        }

        [TestMethod]
        public void Equals_WithSameFirstAndLastName_ShouldReturnTrue()
        {
            //Arrange
            ContactPerson contact1 = new ContactPerson("Rahul", "Sharma", "12 Park Street", "Delhi", "Delhi", "110001", "9876543210", "test@test.in");
            ContactPerson contact2 = new ContactPerson("Rahul", "Sharma", "88 Brigade Road", "Bengaluru", "Karnataka", "560001", "9123456780", "another@test.in");

            //Act & Assert
            Assert.IsTrue(contact1.Equals(contact2));
        }

        [TestMethod]
        public void Equals_WithDifferentNames_ShouldReturnFalse()
        {
            //Arrange
            ContactPerson contact1 = new ContactPerson("Rahul", "Sharma", "12 Park Street", "Delhi", "Delhi", "110001", "9876543210", "test@test.in");
            ContactPerson contact2 = new ContactPerson("Anjali", "Sharma", "12 Park Street", "Delhi", "Delhi", "110001", "9876543210", "test@test.in");

            //Act & Assert
            Assert.IsFalse(contact1.Equals(contact2));
        }

        [TestMethod]
        public void GetHashCode_WithSamePerson_ShouldBeEqual()
        {
            //Arrange
            ContactPerson contact1 = new ContactPerson("Rahul", "Sharma", "12 Park Street", "Delhi", "Delhi", "110001", "9876543210", "test@test.in");
            ContactPerson contact2 = new ContactPerson("Rahul", "Sharma", "88 Brigade Road", "Delhi", "Delhi", "110001", "9876543210", "test@test.in");

            //Act & Assert
            Assert.AreEqual(contact1.GetHashCode(), contact2.GetHashCode());
        }
    }
}
