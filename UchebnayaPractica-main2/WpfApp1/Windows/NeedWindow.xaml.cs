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
    /// Логика взаимодействия для NeedWindow.xaml
    /// </summary>
    public partial class NeedWindow : Window
    {
        bool isCreate;
        public NeedWindow(bool isCreate)
        {
            InitializeComponent();
            this.isCreate = isCreate;
            ClientCBox.ItemsSource = MainWindow.Db.Client.ToList();
            RealtorCBox.ItemsSource = MainWindow.Db.Realtor.ToList();
            PropertyTypeCBox.ItemsSource = MainWindow.Db.TypeProperty.ToList();
            AddressCBox.ItemsSource = MainWindow.Db.Address.ToList();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ClientCBox.SelectedItem == null ||
                RealtorCBox.SelectedItem == null ||
                PropertyTypeCBox.SelectedItem == null ||
                AddressCBox.SelectedItem == null)
            {
                MessageBox.Show("Необходимо заполнить все обязательные поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (isCreate)
            {
                Need need = new Need()
                {
                    Client = ClientCBox.SelectedItem as Client,
                    Realtor = RealtorCBox.SelectedItem as Realtor,
                    TypeProperty = PropertyTypeCBox.SelectedItem as TypeProperty,
                    Address = AddressCBox.SelectedItem as Address,
                    MinPrice = decimal.Parse(MinPriceTBox.Text.Trim()),
                    MaxPrice = decimal.Parse(MaxPriceTBox.Text.Trim())
                };
                MainWindow.Db.Need.Add(need);
            }
            else
            {
                Need need = MainWindow.Db.Need.Attach(DataContext as Need);
                need.Client = ClientCBox.SelectedItem as Client;
                need.Realtor = RealtorCBox.SelectedItem as Realtor;
                need.TypeProperty = PropertyTypeCBox.SelectedItem as TypeProperty;
                need.Address = AddressCBox.SelectedItem as Address;
                need.MinPrice = decimal.Parse(MinPriceTBox.Text.Trim());
                need.MaxPrice = decimal.Parse(MaxPriceTBox.Text.Trim());
            }
            MainWindow.Db.SaveChanges();
            MessageBox.Show("Потребность успешно сохранен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
