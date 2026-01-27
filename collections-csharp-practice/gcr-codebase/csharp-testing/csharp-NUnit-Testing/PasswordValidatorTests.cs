using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Tests
{
    [TestFixture]
    internal class PasswordValidatorTests
    {
        private PasswordValidator validator = new PasswordValidator();

        [TestCase("Password1", true)]
        [TestCase("password1", false)]
        [TestCase("Password", false)]
        [TestCase("Pass1", false)]
        public void Password_Validation_WorksCorrectly(string password, bool expected)
        {
            Assert.AreEqual(expected, validator.IsValid(password));
        }
    }
}
