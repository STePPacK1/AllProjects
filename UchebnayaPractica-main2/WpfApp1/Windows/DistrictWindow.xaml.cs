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
    /// Логика взаимодействия для DistrictWindow.xaml
    /// </summary>
    public partial class DistrictWindow : Window
    {
        readonly bool isCreate;

        public DistrictWindow(bool isCreate)
        {
            InitializeComponent();
            this.isCreate = isCreate;
            CoordinateCBox.ItemsSource = MainWindow.Db.Coordinate.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isCreate)
            {
                District district = new District()
                {
                    Name = NameTBox.Text.Trim(),
                    Coordinate1 = CoordinateCBox.SelectedItem as Coordinate
                };
                MainWindow.Db.District.Add(district);
            }
            else
            {
                District district = MainWindow.Db.District.Attach(DataContext as District);
                district.Name = NameTBox.Text.Trim();
                district.Coordinate1 = CoordinateCBox.SelectedItem as Coordinate;
            }
            MainWindow.Db.SaveChanges();
            MessageBox.Show("Район успешно сохранен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
