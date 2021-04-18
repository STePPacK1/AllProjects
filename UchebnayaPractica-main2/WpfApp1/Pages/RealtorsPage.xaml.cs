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
    /// Логика взаимодействия для RealtorsPage.xaml
    /// </summary>
    public partial class RealtorsPage : Page
    {
        public RealtorsPage()
        {
            InitializeComponent();
            RealtorsLBox.ItemsSource = MainWindow.Db.Realtor.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            new RealtorWindow(true)
            {
                Title = "Добавление нового риэлтора",
            }.ShowDialog();
            RealtorsLBox.ItemsSource = null;
            RealtorsLBox.ItemsSource = MainWindow.Db.Realtor.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            new RealtorWindow(false)
            {
                Title = "Редактирование риэлтора",
                DataContext = (sender as Button).DataContext
            }.ShowDialog();
            RealtorsLBox.ItemsSource = null;
            RealtorsLBox.ItemsSource = MainWindow.Db.Realtor.ToList();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (MessageBox.Show("Вы уверены что хотите безвозратно удалить клиента?", "Предупреждение об удалении клиента", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                MainWindow.Db.Realtor.Remove(btn.DataContext as Realtor);
                MainWindow.Db.Account.Remove(MainWindow.Db.Account.Find((btn.DataContext as Realtor).AccountId));
                MainWindow.Db.SaveChanges();
                RealtorsLBox.ItemsSource = null;
                RealtorsLBox.ItemsSource = MainWindow.Db.Realtor.ToList();
            }
        }
    }
}
