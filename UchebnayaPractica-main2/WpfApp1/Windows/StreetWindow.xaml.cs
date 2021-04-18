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
using System.Windows.Shapes;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для StreetWindow.xaml
    /// </summary>
    public partial class StreetWindow : Window
    {
        readonly bool isCreate;
        public StreetWindow(bool isCreate)
        {
            InitializeComponent();
            this.isCreate = isCreate;
            CityCBox.ItemsSource = MainWindow.Db.City.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isCreate)
            {
                Street street = new Street()
                {
                    Name = NameTBox.Text.Trim(),
                    City = CityCBox.SelectedItem as City
                };
                MainWindow.Db.Street.Add(street);
            }
            else
            {
                Street street = MainWindow.Db.Street.Attach(DataContext as Street);
                street.Name = NameTBox.Text.Trim();
                street.City = CityCBox.SelectedItem as City;
            }
            MainWindow.Db.SaveChanges();
            MessageBox.Show("Улица успешно сохранен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
