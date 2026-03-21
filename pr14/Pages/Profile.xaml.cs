using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr14.Pages
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public Profile()
        {
            InitializeComponent();
            if (Core.CurrentUser != null)
            {
                this.DataContext = Core.CurrentUser;
            }
            LoadMyTickets();
        }
        private void LoadMyTickets()
        {
            if (Core.CurrentUser == null) return;

            // 2. Идем в таблицу Ticket, фильтруем по нашему UserID
            // .Include использовать не будем, чтобы тебя не путать, сделаем через Select
            var myTickets = Core.Db.Ticket
                .Where(t => t.IdUser == Core.CurrentUser.Id)
                .Select(t => new {
                    // Вытягиваем данные через связи (Навигационные свойства)
                    MovieTitle = t.Session.Movie.Title,
                    Time = t.Session.TimeStart,
                    Row = t.Seats.Row,
                    Num = t.Seats.Number
                })
                .ToList();

            KinoList.ItemsSource = myTickets;
        }
        private void Main_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new General());
        }
    }
}
