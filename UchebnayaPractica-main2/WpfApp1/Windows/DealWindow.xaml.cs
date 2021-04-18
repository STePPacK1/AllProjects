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
    /// Логика взаимодействия для DealWindow.xaml
    /// </summary>
    public partial class DealWindow : Window
    {
        bool isCreate;
        public DealWindow(bool isCreate)
        {
            InitializeComponent();
            this.isCreate = isCreate;
            NeedCBox.ItemsSource = MainWindow.Db.Need.ToList();
            OfferCBox.ItemsSource = MainWindow.Db.Offer.ToList();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NeedCBox.SelectedItem == null ||
                OfferCBox.SelectedItem == null ||
                !DateDPicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Необходимо заполнить все обязательные поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (isCreate)
            {
                Deal deal = new Deal()
                {
                    Need = NeedCBox.SelectedItem as Need,
                    Offer = OfferCBox.SelectedItem as Offer,
                    Date = DateDPicker.SelectedDate ?? DateTime.Today
                };
                MainWindow.Db.Deal.Add(deal);
            }
            else
            {
                Deal deal = MainWindow.Db.Deal.Attach(DataContext as Deal);
                deal.Need = NeedCBox.SelectedItem as Need;
                deal.Offer = OfferCBox.SelectedItem as Offer;
                deal.Date = DateDPicker.SelectedDate ?? DateTime.Today;
            }
            MainWindow.Db.SaveChanges();
            MessageBox.Show("Сделка успешно сохранен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
