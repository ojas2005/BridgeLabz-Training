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
            string firstName = "John";
            string lastName = "Doe";
            string address = "123 Main St";
            string city = "New York";
            string state = "NY";
            string zip = "10001";
            string phone = "555-1234";
            string email = "john@example.com";

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
            ContactPerson contact = new ContactPerson("", "Doe", "123 St", "City", "State", "12345", "555-1234", "test@test.com");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateContactPerson_WithEmptyLastName_ShouldThrowException()
        {
            //Arrange & Act
            ContactPerson contact = new ContactPerson("John", "", "123 St", "City", "State", "12345", "555-1234", "test@test.com");
        }

        [TestMethod]
        public void Equals_WithSameFirstAndLastName_ShouldReturnTrue()
        {
            //Arrange
            ContactPerson contact1 = new ContactPerson("John", "Doe", "123 St", "City", "State", "12345", "555-1234", "test@test.com");
            ContactPerson contact2 = new ContactPerson("John", "Doe", "456 Ave", "AnotherCity", "AnotherState", "54321", "555-5678", "another@test.com");

            //Act & Assert
            Assert.IsTrue(contact1.Equals(contact2));
        }

        [TestMethod]
        public void Equals_WithDifferentNames_ShouldReturnFalse()
        {
            //Arrange
            ContactPerson contact1 = new ContactPerson("John", "Doe", "123 St", "City", "State", "12345", "555-1234", "test@test.com");
            ContactPerson contact2 = new ContactPerson("Jane", "Doe", "456 Ave", "City", "State", "12345", "555-1234", "test@test.com");

            //Act & Assert
            Assert.IsFalse(contact1.Equals(contact2));
        }

        [TestMethod]
        public void GetHashCode_WithSamePerson_ShouldBeEqual()
        {
            //Arrange
            ContactPerson contact1 = new ContactPerson("John", "Doe", "123 St", "City", "State", "12345", "555-1234", "test@test.com");
            ContactPerson contact2 = new ContactPerson("John", "Doe", "456 Ave", "City", "State", "12345", "555-1234", "test@test.com");

            //Act & Assert
            Assert.AreEqual(contact1.GetHashCode(), contact2.GetHashCode());
        }
    }
}
