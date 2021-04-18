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
    /// Логика взаимодействия для DealPage.xaml
    /// </summary>
    public partial class DealPage : Page
    {
        public DealPage()
        {
            InitializeComponent();
            DealsLBox.ItemsSource = MainWindow.Db.Deal.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            new DealWindow(true)
            {
                Title = "Добавить сделку"
            }.ShowDialog();

            DealsLBox.ItemsSource = null;
            DealsLBox.ItemsSource = MainWindow.Db.Deal.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            new DealWindow(false)
            {
                Title = "Редактирование сделки",
                DataContext = (sender as Button).DataContext
            }.ShowDialog();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите безвозратно удалить сделку?", "Предупреждение об удалении сделки", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Deal deal = (sender as Button).DataContext as Deal;

                MainWindow.Db.Deal.Remove(deal);
                MainWindow.Db.SaveChanges();

                DealsLBox.ItemsSource = null;
                DealsLBox.ItemsSource = MainWindow.Db.Deal.ToList();
            }
        }
    }
}
