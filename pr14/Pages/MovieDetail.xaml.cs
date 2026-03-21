using pr14.Pages;
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

namespace pr14
{
    /// <summary>
    /// Логика взаимодействия для MovieDetail.xaml
    /// </summary>
    public partial class MovieDetail : Page
    {
        public MovieDetail()
        {
            InitializeComponent();
            LoadSessions();
        }

        private void LoadSessions()
        {
            if (Core.SelectedKino != null)
            {
                this.DataContext = Core.SelectedKino;
            }
            int movieId = Core.SelectedKino.Id;


        //    Core.Db.Hal.Add(new Hal { Number = 1 });

        //    Core.Db.SaveChanges();
        //    var testSessions = new List<Session>
        //{
        //    new Session {
        //        IdMovie = movieId,
        //        IdHal = Core.Db.Hal.First().Id,
        //        DateStart = DateTime.Now.Date,
        //        TimeStart = new TimeSpan(12, 0, 0), // 12:00
        //        Price = 300
        //    },
        //    new Session {
        //        IdMovie = movieId,
        //        IdHal = Core.Db.Hal.First().Id,
        //        DateStart = DateTime.Now.Date,
        //        TimeStart = new TimeSpan(15, 30, 0), // 15:30
        //        Price = 350
        //    },
        //    new Session {
        //        IdMovie = movieId,
        //        IdHal = Core.Db.Hal.First().Id,
        //        DateStart = DateTime.Now.Date,
        //        TimeStart = new TimeSpan(19, 0, 0), // 19:00
        //        Price = 450
        //    }
        //};

        //    Core.Db.Session.AddRange(testSessions);
        //    Core.Db.SaveChanges();

            var sessions = Core.Db.Session.Where(s => s.IdMovie == movieId).ToList();
            SessionsList.ItemsSource = sessions;



        }

        private void SessionsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SessionsList.SelectedItem is Session selectedSession)
            {
                Core.SelectedSession = selectedSession;

                NavigationService.Navigate(new KinoSelect());
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new General());
        }





    }
}
