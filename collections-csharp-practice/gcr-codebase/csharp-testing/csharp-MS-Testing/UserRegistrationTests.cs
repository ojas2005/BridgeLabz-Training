using CoreApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp_MS_Testing
{
    [TestClass]
    public class UserRegistrationTests
    {
        private UserRegistration registration;

        [TestInitialize]
        public void Setup()
        {
            registration = new UserRegistration();
        }

        [TestMethod]
        public void RegisterUser_ValidInput_DoesNotThrow()
        {
            registration.RegisterUser("john", "john@mail.com", "secret123");
        }

        [TestMethod]
        public void RegisterUser_InvalidEmail_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                registration.RegisterUser("john", "invalidEmail", "secret123"));
        }

        [TestMethod]
        public void RegisterUser_InvalidPassword_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                registration.RegisterUser("john", "john@mail.com", "123"));
        }
    }

}
