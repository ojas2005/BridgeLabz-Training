using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Tests
{
    [TestFixture]
    public class UserRegistrationTests
    {
        private UserRegistration registration = new UserRegistration();

        [Test]
        public void RegisterUser_ValidInput_DoesNotThrow()
        {
            Assert.DoesNotThrow(() =>
                registration.RegisterUser("john", "john@mail.com", "secret123"));
        }

        [Test]
        public void RegisterUser_InvalidEmail_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                registration.RegisterUser("john", "invalidEmail", "secret123"));
        }

        [Test]
        public void RegisterUser_InvalidPassword_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                registration.RegisterUser("john", "john@mail.com", "123"));
        }
    }

}
