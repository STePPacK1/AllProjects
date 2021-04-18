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
    /// Логика взаимодействия для CityWindow.xaml
    /// </summary>
    public partial class CityWindow : Window
    {
        bool isCreate;
        public CityWindow(bool isCreate)
        {
            InitializeComponent();
            this.isCreate = isCreate;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isCreate)
            {
                City city = new City()
                {
                    Name = NameTBox.Text.Trim()
                };
                MainWindow.Db.City.Add(city);
            }
            else
            {
                City city = MainWindow.Db.City.Attach(DataContext as City);
                city.Name = NameTBox.Text.Trim();
            }
            MainWindow.Db.SaveChanges();
            MessageBox.Show("Город успешно сохранен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
