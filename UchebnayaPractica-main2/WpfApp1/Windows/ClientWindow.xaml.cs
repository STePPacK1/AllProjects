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
using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        bool isCreate;
        string photo;
        public ClientWindow(bool isCreate)
        {
            InitializeComponent();
            this.isCreate = isCreate;
            GenderCBox.ItemsSource = MainWindow.Db.Gender.ToList();
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
                Client client = new Client()
                {
                    FirstName = FirstNameTBox.Text.Trim(),
                    LastName = LastNameTBox.Text.Trim(),
                    Patronymic = PatronymicTBox.Text.Trim(),
                    Email = EmailTBox.Text.Trim(),
                    Phone = PhoneTBox.Text.Trim(),
                    Account = new Account()
                    {
                        Login = LoginTBox.Text.Trim(),
                        Password = PasswordPBox.Password.Trim()
                    },
                    Gender1 = GenderCBox.SelectedItem as Gender,
                    Photo = photo
                };
                MainWindow.Db.Client.Add(client);
                MainWindow.Db.SaveChanges();
            }
            else
            {
                Client client = MainWindow.Db.Client.Attach(DataContext as Client);
                client.FirstName = FirstNameTBox.Text.Trim();
                client.LastName = LastNameTBox.Text.Trim();
                client.Patronymic = PatronymicTBox.Text.Trim();
                client.Email = EmailTBox.Text.Trim();
                client.Phone = PhoneTBox.Text.Trim();
                client.Account.Login = LoginTBox.Text.Trim();
                client.Account.Password = PasswordPBox.Password.Trim();
                client.Gender1 = GenderCBox.SelectedItem as Gender;
                client.Photo = photo;
                MainWindow.Db.SaveChanges();
            }
            MessageBox.Show("Клиент успешно сохранен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void LocalWindow_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!isCreate)
            {
                PasswordPBox.Password = (DataContext as Client).Account.Password;
            }
        }

        private void PhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Filter = "Images|*.png;*.jpg",
                Multiselect = false
            };
            fileDialog.ShowDialog();
            if (File.Exists(fileDialog.FileName))
            {
                string newFileName = ((uint)DateTime.Now.Ticks) + Regex.Match(fileDialog.FileName, "(" + Regex.Escape(".") + "[a-z]{3,4})").Value;
                if (!Directory.Exists(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Images")))
                    Directory.CreateDirectory(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Images"));
                File.Copy(fileDialog.FileName, System.IO.Path.Combine(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Images"), newFileName));
                photo = newFileName;
            }
            else
            {
                MessageBox.Show("Для добавления фотографии требуется файл изображения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
