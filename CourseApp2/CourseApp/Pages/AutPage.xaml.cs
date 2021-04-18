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

namespace CourseApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutPage.xaml
    /// </summary>
    public partial class AutPage : Page
    {
        public AutPage()
        {
            InitializeComponent();
        }

        private void b_goAut_Click(object sender, RoutedEventArgs e)
        {
            Account account = MainWindow.db.Account.FirstOrDefault(a => a.Login == tb_log.Text.Trim());
            if (account != null && tb_pas.Text.Trim() == account.Password)
            {
                MainWindow.AuthAccount = account;
                NavigationService.Navigate(new MenuPage() { DataContext = MainWindow.AuthAccount });
            }
            else
            {
                MessageBox.Show("Ошибка: Неправильный логин или пароль", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
