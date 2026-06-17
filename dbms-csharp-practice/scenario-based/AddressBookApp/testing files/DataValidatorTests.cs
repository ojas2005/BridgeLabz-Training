using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AddressBookApp.Tests
{

    [TestClass]
    public class DataValidatorTests
    {
        private IDataValidator validator;

        [TestInitialize]
        public void SetUp()
        {
            validator = new DataValidator();
        }

        [TestMethod]
        public void ValidateContactPerson_WithValidData_ShouldReturnTrue()
        {
            //Act
            bool result = validator.ValidateContactPerson(
                "Rahul","Sharma","45 MG Road","Mumbai","Maharashtra","400001","9876543210","rahul@test.in"
            );

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(DataValidationException))]
        public void ValidateContactPerson_WithEmptyFirstName_ShouldThrowException()
        {
            //Act
            validator.ValidateContactPerson(
                "","Sharma","45 MG Road","Mumbai","Maharashtra","400001","9876543210","rahul@test.in"
            );
        }

        [TestMethod]
        [ExpectedException(typeof(DataValidationException))]
        public void ValidateContactPerson_WithEmptyLastName_ShouldThrowException()
        {
            //Act
            validator.ValidateContactPerson(
                "Rahul","","45 MG Road","Mumbai","Maharashtra","400001","9876543210","rahul@test.in"
            );
        }

        [TestMethod]
        [ExpectedException(typeof(DataValidationException))]
        public void ValidateContactPerson_WithInvalidEmail_ShouldThrowException()
        {
            //Act
            validator.ValidateContactPerson(
                "Rahul","Sharma","45 MG Road","Mumbai","Maharashtra","400001","9876543210","invalidemail"
            );
        }

        [TestMethod]
        [ExpectedException(typeof(DataValidationException))]
        public void ValidateContactPerson_WithInvalidPhone_ShouldThrowException()
        {
            //Act
            validator.ValidateContactPerson(
                "Rahul","Sharma","45 MG Road","Mumbai","Maharashtra","400001","123","rahul@test.in"
            );
        }

        [TestMethod]
        public void ValidateCity_WithValidCity_ShouldReturnTrue()
        {
            //Act
            bool result = validator.ValidateCity("Mumbai");

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateCity_WithEmptyCity_ShouldReturnFalse()
        {
            //Act
            bool result = validator.ValidateCity("");

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateState_WithValidState_ShouldReturnTrue()
        {
            //Act
            bool result = validator.ValidateState("Maharashtra");

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateState_WithEmptyState_ShouldReturnFalse()
        {
            //Act
            bool result = validator.ValidateState("");

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateEmail_WithValidEmail_ShouldReturnTrue()
        {
            //Act
            bool result = validator.ValidateEmail("test@example.in");

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateEmail_WithInvalidEmail_ShouldReturnFalse()
        {
            //Act
            bool result = validator.ValidateEmail("invalidemail");

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateEmail_WithEmptyEmail_ShouldReturnTrue()
        {
            //Act - empty email is optional
            bool result = validator.ValidateEmail("");

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidatePhone_WithValidPhone_ShouldReturnTrue()
        {
            //Act
            bool result = validator.ValidatePhone("9876543210");

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidatePhone_WithValidFormattedPhone_ShouldReturnTrue()
        {
            //Act
            bool result = validator.ValidatePhone("98765-43210");

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidatePhone_WithInvalidPhone_ShouldReturnFalse()
        {
            //Act
            bool result = validator.ValidatePhone("123");

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidatePhone_WithEmptyPhone_ShouldReturnTrue()
        {
            bool result = validator.ValidatePhone("");
            Assert.IsTrue(result);
        }
    }
}
