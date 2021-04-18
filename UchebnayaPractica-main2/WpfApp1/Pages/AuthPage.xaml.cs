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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Remember)
            {
                LoginTBox.Text = Properties.Settings.Default.Login;
                PasswordPBox.Password = Properties.Settings.Default.Password;
                RememberCheckBox.IsChecked = Properties.Settings.Default.Remember;
            }
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            Account account = MainWindow.Db.Account.FirstOrDefault(a => a.Login == LoginTBox.Text.Trim());

            if (account != null && account.Password.Trim() == PasswordPBox.Password.Trim())
            {
                if (RememberCheckBox.IsChecked ?? false)
                {
                    Properties.Settings.Default.Login = LoginTBox.Text.Trim();
                    Properties.Settings.Default.Password = PasswordPBox.Password.Trim();
                    Properties.Settings.Default.Remember = RememberCheckBox.IsChecked ?? false;
                }
                else
                {
                    Properties.Settings.Default.Login = string.Empty;
                    Properties.Settings.Default.Password = string.Empty;
                    Properties.Settings.Default.Remember = false;
                }
                Properties.Settings.Default.Save();
                NavigationService.Navigate(new MenuPage());
                MainWindow.AuthAccount = account;
            }
            else
            {
                MessageBox.Show("Ошибка: Неправильный логин или пароль", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage());
        }
    }
}
