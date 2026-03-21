using Microsoft.VisualStudio.TestTools.UnitTesting;
using pr14.Pages; 
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void AuthTest_EmptyFields_ReturnsFalse()
        {
            var page = new EnterPage();
            bool result = page.Auth("", "");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RegisterTest_DifferentPasswords_ReturnsFalse()
        {
            var page = new AuthPage();
            bool result = page.Register("test", "123", "321");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AuthTest_ValidUser_ReturnsTrue()
        {
            var page = new EnterPage();
            bool result = page.Auth("admin", "admin");
            Assert.IsTrue(result);
        }
    }
}