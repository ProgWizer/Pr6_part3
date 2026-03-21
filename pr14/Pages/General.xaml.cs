using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;

namespace pr14.Pages
{
    public partial class General : Page
    {
        public General()
        {
            InitializeComponent();

            if (!Core.Db.Movie.Any())
            {
                var Kinos = new List<Movie>
                {
                    new Movie {Title = "Звездные войны", ReleaseDate= new DateTime(2025, 4, 1), Rating=9, Image="/Photo/qwe.jpg" },
                    new Movie {Title = "Мстители", ReleaseDate = new DateTime(2025, 5, 10), Rating = 8, Image = "/Photo/qwe.jpg" },
                    new Movie {Title = "Аватар", ReleaseDate= new DateTime(2025, 4, 1), Rating=7, Image="/Photo/qwe.jpg" },
                    new Movie {Title = "Бэтмен", ReleaseDate= new DateTime(2025, 4, 1), Rating=10, Image="/Photo/qwe.jpg" },
                };
                Core.Db.Movie.AddRange(Kinos);
                Core.Db.SaveChanges();
            }

            UpdateData();
        }

        private void UpdateData()
        {

            if (nameInput == null || cmbSort == null || KinoList == null)
                return;

            var currentData = Core.Db.Movie.ToList();

            if (!string.IsNullOrWhiteSpace(nameInput.Text))
            {
                currentData = currentData.Where(x => x.Title.ToLower().Contains(nameInput.Text.ToLower())).ToList();
            }


            if (cmbSort.SelectedItem == sortByName)
            {
                currentData = currentData.OrderBy(x => x.Title).ToList();
            }
            else if (cmbSort.SelectedItem == sortByRate)
            {
                currentData = currentData.OrderByDescending(x => x.Rating).ToList();
            }

            KinoList.ItemsSource = currentData;
        }

        private void nameInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            nameInput.Text = "";
            cmbSort.SelectedIndex = 0; 
            UpdateData();
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Profile());
        }

        private void auth_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EnterPage());

        }

        private void KinoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (KinoList.SelectedItem is Movie selected)
            {
                Core.kino = selected.Title;
                Core.SelectedKino = selected;

                if (Core.IsProfile == true)
                {
                    NavigationService.Navigate(new MovieDetail());
                }
            }
        }


    }
}