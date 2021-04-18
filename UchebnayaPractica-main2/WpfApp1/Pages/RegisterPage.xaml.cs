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
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordPBox.Password) ||
                string.IsNullOrWhiteSpace(RepeatPBox.Password) ||
                string.IsNullOrWhiteSpace(FirstNameTBox.Text) ||
                string.IsNullOrWhiteSpace(LastNameTBox.Text))
            {
                MessageBox.Show("Необходимо заполнить все обязательные поля");
                return;
            }

            if (MainWindow.Db.Account.FirstOrDefault(a => a.Login == LoginTBox.Text.Trim()) != null)
            {
                MessageBox.Show("Такой логин уже существует");
                return;
            }

            if (PasswordPBox.Password.Trim() != RepeatPBox.Password.Trim())
            {
                MessageBox.Show("Пароли должны совпадать");
                return;
            }

            Account account = new Account()
            {
                Login = LoginTBox.Text.Trim(),
                Password = PasswordPBox.Password.Trim()
            };
            Client client = new Client()
            {
                FirstName = FirstNameTBox.Text.Trim(),
                LastName = LastNameTBox.Text.Trim(),
                Patronymic = PatronymicTBox.Text.Trim(),
                Phone = PhoneTBox.Text.Trim(),
                Email = EmailTBox.Text.Trim(),
                Account = account
            };
            MainWindow.Db.Account.Add(account);
            MainWindow.Db.Client.Add(client);
            MainWindow.Db.SaveChanges();

            MessageBox.Show("Регистрация прошла успешно");

            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
            else
            {
                NavigationService.Navigate(new AuthPage());
            }
        }
    }
}
