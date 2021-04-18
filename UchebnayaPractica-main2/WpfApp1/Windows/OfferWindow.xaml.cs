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
    /// Логика взаимодействия для OfferWindow.xaml
    /// </summary>
    public partial class OfferWindow : Window
    {
        bool isCreate;
        public OfferWindow(bool isCreate)
        {
            InitializeComponent();
            this.isCreate = isCreate;
            ClientCBox.ItemsSource = MainWindow.Db.Client.ToList();
            RealtorCBox.ItemsSource = MainWindow.Db.Realtor.ToList();
            PropertyCBox.ItemsSource = MainWindow.Db.Property.ToList();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PriceTBox.Text.Trim()) ||
                ClientCBox.SelectedItem == null ||
                RealtorCBox.SelectedItem == null ||
                PropertyCBox.SelectedItem == null)
            {
                MessageBox.Show("Необходимо заполнить все обязательные поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (isCreate)
            {
                Offer offer = new Offer()
                {
                    Client = ClientCBox.SelectedItem as Client,
                    Realtor = RealtorCBox.SelectedItem as Realtor,
                    Property = PropertyCBox.SelectedItem as Property,
                    Price = decimal.Parse(PriceTBox.Text.Trim())
                };
                MainWindow.Db.Offer.Add(offer);
            }
            else
            {
                Offer offer = MainWindow.Db.Offer.Attach(DataContext as Offer);
                offer.Client = ClientCBox.SelectedItem as Client;
                offer.Realtor = RealtorCBox.SelectedItem as Realtor;
                offer.Property = PropertyCBox.SelectedItem as Property;
                offer.Price = decimal.Parse(PriceTBox.Text.Trim());
            }
            MainWindow.Db.SaveChanges();
            MessageBox.Show("Предложение успешно сохранен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
