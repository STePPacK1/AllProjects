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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void SignOutBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
            NavigationService.RemoveBackEntry();
        }

        private void ClientsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientsPage());
        }

        private void RealtorsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RealtorsPage());
        }

        private void UtilityBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UtilityPage());
        }

        private void PropertiesBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PropertiesPage());
        }

        private void OffersBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OfferPage());
        }

        private void NeedsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NeedPage());
        }

        private void DealsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DealPage());
        }
    }
}
