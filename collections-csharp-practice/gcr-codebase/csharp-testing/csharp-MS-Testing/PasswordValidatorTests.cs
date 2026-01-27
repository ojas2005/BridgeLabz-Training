using System;
using CoreApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp_MS_Testing
{
    [TestClass]
    public class PasswordValidatorTests
    {
        private PasswordValidator validator;

        [TestInitialize]
        public void Setup()
        {
            validator = new PasswordValidator();
        }

        [DataTestMethod]
        [DataRow("Password1", true)]
        [DataRow("password1", false)]
        [DataRow("Password", false)]
        [DataRow("Pass1", false)]
        public void PasswordValidation_WorksCorrectly(string password, bool expected)
        {
            Assert.AreEqual(expected, validator.IsValid(password));
        }
    }

}
