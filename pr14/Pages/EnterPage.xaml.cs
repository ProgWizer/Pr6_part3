using System.Linq;
using System.Windows.Controls;
using System.Windows;

namespace pr14.Pages
{
    public partial class EnterPage : Page
    {
        public EnterPage()
        {
            InitializeComponent();
        }

        // ОСТАВЬТЕ ТОЛЬКО ЭТОТ ОДИН МЕТОД Auth
        public bool Auth(string loginStr, string passwordStr)
        {
            if (string.IsNullOrWhiteSpace(loginStr) || string.IsNullOrWhiteSpace(passwordStr))
            {
                return false;
            }

            var userFromDb = Core.Db.Users.FirstOrDefault(u => u.Login == loginStr && u.Password == passwordStr);

            if (userFromDb != null)
            {
                Core.CurrentUser = userFromDb;
                Core.IsProfile = true;
                return true;
            }
            return false;
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            // Здесь мы просто вызываем метод выше
            if (Auth(login.Text, password.Text))
            {
                MessageBox.Show("Добро пожаловать!");
                NavigationService.Navigate(new Profile());
            }
            else
            {
                MessageBox.Show("Логин или пароль не подходит");
            }
        }

        private void Last_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new General());
        private void Auth_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new AuthPage());
    }
}