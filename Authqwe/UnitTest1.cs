using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using pr14.Pages;
using System;

namespace UnitTestProject // Ќазвание должно совпадать с именем проекта
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void AuthTest_EmptyFields_ReturnsFalse()
        {
            var page = new EnterPage();
            bool result = page.Auth("", "");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
        }

        [TestMethod]
        public void RegisterTest_DifferentPasswords_ReturnsFalse()
        {
            var page = new AuthPage();
            bool result = page.Register("test", "123", "321");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
        }

        [TestMethod]
        public void AuthTest_ValidUser_ReturnsTrue()
        {
            var page = new EnterPage();
            // «амените на данные, которые есть в вашей базе
            bool result = page.Auth("admin", "admin");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result);
        }
    }
}