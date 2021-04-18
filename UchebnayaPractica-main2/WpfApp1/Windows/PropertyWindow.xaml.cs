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
    /// Логика взаимодействия для PropertyWindow.xaml
    /// </summary>
    public partial class PropertyWindow : Window
    {
        readonly bool isCreate;
        public PropertyWindow(bool isCreate)
        {
            InitializeComponent();
            this.isCreate = isCreate;
            DistrictCBox.ItemsSource = MainWindow.Db.District.ToList();
            CityCBox.ItemsSource = MainWindow.Db.City.ToList();
            TypeCBox.ItemsSource = MainWindow.Db.TypeProperty.ToList();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isCreate)
            {
                Address address = new Address()
                {
                    ApartmentNumber = int.Parse(ApartmentTBox.Text.Trim()),
                    HomeNumber = HouseTBox.Text.Trim(),
                    Street = StreetCBox.SelectedItem as Street,
                    District = DistrictCBox.SelectedItem as District
                };
                Property property = new Property()
                {
                    Area = decimal.Parse(AreaTBox.Text.Trim()),
                    Floor = int.Parse(FloorTBox.Text.Trim()),
                    Room = int.Parse(RoomTBox.Text.Trim()),
                    Address = address,
                    TypeProperty = TypeCBox.SelectedItem as TypeProperty
                };
                MainWindow.Db.Address.Add(address);
                MainWindow.Db.Property.Add(property);
            }
            else
            {
                Property property = MainWindow.Db.Property.Attach(DataContext as Property);
                property.Floor = int.Parse(FloorTBox.Text.Trim());
                property.Area = decimal.Parse(AreaTBox.Text.Trim());
                property.Room = int.Parse(RoomTBox.Text.Trim());
                Address address = MainWindow.Db.Address.Attach(property.Address);
                address.ApartmentNumber = int.Parse(ApartmentTBox.Text.Trim());
                address.HomeNumber = HouseTBox.Text.Trim();
                address.District = DistrictCBox.SelectedItem as District;
                address.Street = StreetCBox.SelectedItem as Street;
                property.TypeProperty = TypeCBox.SelectedItem as TypeProperty;
            }
            MainWindow.Db.SaveChanges();
            MessageBox.Show("Недвижимость успешно сохранен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void CityCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StreetCBox.ItemsSource = MainWindow.Db.Street.ToList().Where(s => s.City == CityCBox.SelectedItem as City);
            StreetCBox.IsEnabled = true;
        }
    }
}
