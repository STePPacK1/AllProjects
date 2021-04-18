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
using WpfApp1.Windows;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для UtilityPage.xaml
    /// </summary>
    public partial class UtilityPage : Page
    {
        public UtilityPage()
        {
            InitializeComponent();
            TypesLBox.ItemsSource = MainWindow.Db.TypeProperty.ToList();
            DistrictsLBox.ItemsSource = MainWindow.Db.District.ToList();
            StreetsLBox.ItemsSource = MainWindow.Db.Street.ToList();
            CitiesLBox.ItemsSource = MainWindow.Db.City.ToList();
        }

        #region Addition button
        private void AddTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            new TypePropertyWindow(true)
            {
                Title = "Добавить тип недвижимости"
            }.ShowDialog();

            TypesLBox.ItemsSource = null;
            TypesLBox.ItemsSource = MainWindow.Db.TypeProperty.ToList();
        }

        private void AddDistrictBtn_Click(object sender, RoutedEventArgs e)
        {
            new DistrictWindow(true)
            {
                Title = "Добавить район"
            }.ShowDialog();

            DistrictsLBox.ItemsSource = null;
            DistrictsLBox.ItemsSource = MainWindow.Db.District.ToList();
        }

        private void AddStreetBtn_Click(object sender, RoutedEventArgs e)
        {
            new StreetWindow(true)
            {
                Title = "Добавить улицу"
            }.ShowDialog();

            StreetsLBox.ItemsSource = null;
            StreetsLBox.ItemsSource = MainWindow.Db.Street.ToList();
        }

        private void AddCityBtn_Click(object sender, RoutedEventArgs e)
        {
            new CityWindow(true)
            {
                Title = "Добавить город"
            }.ShowDialog();

            CitiesLBox.ItemsSource = null;
            CitiesLBox.ItemsSource = MainWindow.Db.City.ToList();
        }
        #endregion

        #region Removal Buttons
        private void RemoveTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите безвозратно удалить тип недвижимости?", "Предупреждение об удалении типа недвижимости", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                TypeProperty type = (sender as Button).DataContext as TypeProperty;
                MainWindow.Db.TypeProperty.Remove(type);
                MainWindow.Db.SaveChanges();

                TypesLBox.ItemsSource = null;
                TypesLBox.ItemsSource = MainWindow.Db.TypeProperty.ToList();
            }
        }

        private void RemoveDistrictBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите безвозратно удалить район?", "Предупреждение об удалении района", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                District district = (sender as Button).DataContext as District;
                MainWindow.Db.District.Remove(district);
                MainWindow.Db.SaveChanges();

                DistrictsLBox.ItemsSource = null;
                DistrictsLBox.ItemsSource = MainWindow.Db.District.ToList();
            }
        }

        private void RemoveStreetBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите безвозратно удалить улицу?", "Предупреждение об удалении улицы", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Street street = (sender as Button).DataContext as Street;
                MainWindow.Db.Street.Remove(street);
                MainWindow.Db.SaveChanges();

                StreetsLBox.ItemsSource = null;
                StreetsLBox.ItemsSource = MainWindow.Db.Street.ToList();
            }
        }

        private void RemoveCityBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите безвозратно удалить город?", "Предупреждение об удалении города", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                City city = (sender as Button).DataContext as City;
                MainWindow.Db.City.Remove(city);
                MainWindow.Db.SaveChanges();

                TypesLBox.ItemsSource = null;
                TypesLBox.ItemsSource = MainWindow.Db.City.ToList();
            }
        }

        #endregion

        #region Edition buttons
        private void EditTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            new TypePropertyWindow(false)
            {
                Title = "Редактирование типа недвижимости",
                DataContext = (sender as Button).DataContext
            }.ShowDialog();
        }

        private void EditDistrictBtn_Click(object sender, RoutedEventArgs e)
        {
            new DistrictWindow(false)
            {
                Title = "Редактирование района",
                DataContext = (sender as Button).DataContext
            }.ShowDialog();
        }

        private void EditStreetBtn_Click(object sender, RoutedEventArgs e)
        {
            new StreetWindow(false)
            {
                Title = "Редактирование улицы",
                DataContext = (sender as Button).DataContext
            }.ShowDialog();
        }

        private void EditCityBtn_Click(object sender, RoutedEventArgs e)
        {
            new CityWindow(false)
            {
                Title = "Редактирование города",
                DataContext = (sender as Button).DataContext
            }.ShowDialog();
        }
        #endregion
    }
}
