using Microsoft.VisualStudio.TestTools.UnitTesting;
using pr14.Pages; 
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UserTests
    {
        /* --- ТЕСТИРОВАНИЕ АВТОРИЗАЦИИ (EnterPage) --- */

        [TestMethod]
       
        public void AuthTestSuccess()
        {
            var page = new EnterPage();
            bool result = page.Auth("qwe", "qwe");
            Assert.IsTrue(result, "Ожидался успешный вход (PASS)");
        }   

        [TestMethod]
       
        public void AuthTestFail_WrongPassword() 
        {
            var page = new EnterPage();
           
            bool result = page.Auth("user", "123456");
            Assert.IsFalse(result, "Вход должен быть отклонен при неверном пароле");
        }

        [TestMethod]
       
        public void AuthTestFail_EmptyFields() 
        {
            var page = new EnterPage();
           
            bool result = page.Auth("", "");
            Assert.IsFalse(result, "Вход невозможен с пустыми полями");
        }


        /* --- ТЕСТИРОВАНИЕ РЕГИСТРАЦИИ (AuthPage) --- */

        [TestMethod]
       
        public void RegisterTestSuccess() 
        {
            var page = new AuthPage();
            bool result = page.Register("new_user_777", "1234", "1234");
            Assert.IsTrue(result, "Регистрация должна быть успешной"); 
        }

        [TestMethod]
       
        public void RegisterTestFail_DifferentPasswords() 
        {
            var page = new AuthPage();
            bool result = page.Register("test_user", "test123", "test1234");
            Assert.IsFalse(result, "Ожидалась ошибка: Пароли не совпадают"); 
        }

        [TestMethod]
       
        public void RegisterTestFail_EmptyLogin() 
        {
            var page = new AuthPage();
            bool result = page.Register("", "123", "123");
            Assert.IsFalse(result, "Регистрация без логина должна быть невозможна"); 
        }
    }
}