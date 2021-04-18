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
    /// Логика взаимодействия для OfferPage.xaml
    /// </summary>
    public partial class OfferPage : Page
    {
        public OfferPage()
        {
            InitializeComponent();
            OffersLBox.ItemsSource = MainWindow.Db.Offer.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            new OfferWindow(true)
            {
                Title = "Добавить предложение"
            }.ShowDialog();

            OffersLBox.ItemsSource = null;
            OffersLBox.ItemsSource = MainWindow.Db.Offer.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            new OfferWindow(false)
            {
                Title = "Редактирование предложения",
                DataContext = (sender as Button).DataContext
            }.ShowDialog();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите безвозратно удалить предложение?", "Предупреждение об удалении предложения", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Offer offer = (sender as Button).DataContext as Offer;

                MainWindow.Db.Offer.Remove(offer);
                MainWindow.Db.SaveChanges();

                OffersLBox.ItemsSource = null;
                OffersLBox.ItemsSource = MainWindow.Db.Offer.ToList();
            }
        }
    }
}
