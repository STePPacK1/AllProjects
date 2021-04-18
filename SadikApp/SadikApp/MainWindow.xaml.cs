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
using SadikApp.Pages;

namespace SadikApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static KindergartenDBEntities1 db;
        public MainWindow()
        {
            InitializeComponent();

            db = new KindergartenDBEntities1();
        }
            
        private void b_back_Click(object sender, RoutedEventArgs e)
        {
            if (mineFrame.CanGoBack)
            {
                mineFrame.GoBack();
            }
            else
            {
                b_back.IsEnabled = IsEnabled;
                MessageBox.Show("Вы на главной странице!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void b_exit_Click(object sender, RoutedEventArgs e)
        {
            mineFrame.NavigationService.Navigate(new MenuPage());
        }
    }
}
