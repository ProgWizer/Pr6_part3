using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static pr14.Pages.KinoSelect;

namespace pr14.Pages
{
    /// <summary>
    /// Логика взаимодействия для KinoSelect.xaml
    /// </summary>
    public partial class KinoSelect : Page
    {


        public KinoSelect()
        {
            InitializeComponent();

            NameKino.Text = Core.kino.ToString();
            LoadSeats();
        }

        private void LoadSeats()
        {

            int currentHalId = 1;

            var seatsFromDb = Core.Db.Seats.Where(s => s.IdHal == currentHalId).ToList();

            if (seatsFromDb.Count == 0)
            {
                for (int r = 1; r <= 3; r++)
                {
                    for (int n = 1; n <= 5; n++)
                    {
                        Core.Db.Seats.Add(new Seats { Row = r, Number = n, IdHal = currentHalId });
                    }
                }
                Core.Db.SaveChanges();
                seatsFromDb = Core.Db.Seats.Where(s => s.IdHal == currentHalId).ToList();
            }
            SeatsList.ItemsSource = seatsFromDb;
        }


        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            var seat = activeCheckBox.DataContext as Seats;

            MessageBoxResult result = MessageBox.Show($"Вы хотите забронировать {seat.Row} ряд, место {seat.Number}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Ticket newTicket = new Ticket()
                    {
                        IdSession = Core.SelectedSession.Id, 
                        IdSeat = seat.Id,                   
                        IdUser = Core.CurrentUser.Id         
                    };

                    Core.Db.Ticket.Add(newTicket);
                    Core.Db.SaveChanges();

                    activeCheckBox.IsChecked = true;
                    activeCheckBox.Background = System.Windows.Media.Brushes.Gold;
                    activeCheckBox.IsEnabled = false; 

                    MessageBox.Show("Место успешно забронировано!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении: " + ex.Message);
                }
            }
            else
            {
                activeCheckBox.IsChecked = false;
                activeCheckBox.Background = System.Windows.Media.Brushes.White;
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            LoadSeats();
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MovieDetail());

        }
    } 
}
