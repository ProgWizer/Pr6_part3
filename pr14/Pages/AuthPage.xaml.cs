using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace pr14.Pages
{
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        // Метод для тестов: возвращает true если регистрация успешна
        public bool Register(string loginStr, string passStr, string confirmPassStr)
        {
            if (string.IsNullOrWhiteSpace(loginStr) || string.IsNullOrWhiteSpace(passStr) || string.IsNullOrWhiteSpace(confirmPassStr))
            {
                return false; // Поля не заполнены
            }

            if (passStr != confirmPassStr)
            {
                return false; // Пароли не совпадают
            }

            try
            {
                Users newUser = new Users()
                {
                    Login = loginStr,
                    Password = passStr
                };
                Core.Db.Users.Add(newUser);
                Core.Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            // Вызываем логику
            if (Register(login.Text, password.Text, confirmpassword.Text))
            {
                MessageBox.Show("Регистрация успешна!");
                NavigationService.Navigate(new EnterPage());
            }
            else
            {
                if (password.Text != confirmpassword.Text)
                    MessageBox.Show("Пароли не совпадают");
                else
                    MessageBox.Show("Ошибка заполнения или базы данных");
            }
        }

        private void Last_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new General());
        private void Auth_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new EnterPage());
    }
}