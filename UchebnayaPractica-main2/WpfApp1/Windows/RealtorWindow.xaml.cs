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
    /// Логика взаимодействия для RealtorWindow.xaml
    /// </summary>
    public partial class RealtorWindow : Window
    {
        bool isCreate;
        public RealtorWindow(bool isCreate)
        {
            InitializeComponent();
            this.isCreate = isCreate;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTBox.Text.Trim()) ||
                string.IsNullOrWhiteSpace(PasswordPBox.Password.Trim()))
            {
                MessageBox.Show("Необходимо заполнить все обязательные поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (isCreate)
            {
                if (MainWindow.Db.Account.Any(a => a.Login == LoginTBox.Text.Trim()))
                {
                    MessageBox.Show("Такой логин уже существует, пожалуйста, придумайте другой логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Realtor realtor = new Realtor()
                {
                    FirstName = FirstNameTBox.Text.Trim(),
                    LastName = LastNameTBox.Text.Trim(),
                    Patronymic = PatronymicTBox.Text.Trim(),
                    Account = new Account()
                    {
                        Login = LoginTBox.Text.Trim(),
                        Password = PasswordPBox.Password.Trim()
                    }
                };
                MainWindow.Db.Realtor.Add(realtor);
            }
            else
            {
                Realtor realtor = MainWindow.Db.Realtor.Attach(DataContext as Realtor);
                realtor.FirstName = FirstNameTBox.Text.Trim();
                realtor.LastName = LastNameTBox.Text.Trim();
                realtor.Patronymic = PatronymicTBox.Text.Trim();
                realtor.Account.Login = LoginTBox.Text.Trim();
                realtor.Account.Password = PasswordPBox.Password.Trim();
            }
            MainWindow.Db.SaveChanges();
            MessageBox.Show("Риэлтор успешно сохранен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void LocalWindow_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!isCreate)
            {
                PasswordPBox.Password = (DataContext as Realtor).Account.Password;
            }
        }
    }
}
