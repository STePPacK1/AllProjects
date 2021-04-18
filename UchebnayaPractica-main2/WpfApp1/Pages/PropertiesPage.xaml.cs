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
    /// Логика взаимодействия для PropertiesPage.xaml
    /// </summary>
    public partial class PropertiesPage : Page
    {
        public PropertiesPage()
        {
            InitializeComponent();
            PropertiesLBox.ItemsSource = MainWindow.Db.Property.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            new PropertyWindow(true)
            {
                Title = "Добавление новой недвижимости",
            }.ShowDialog();
            PropertiesLBox.ItemsSource = null;
            PropertiesLBox.ItemsSource = MainWindow.Db.Property.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            new PropertyWindow(false)
            {
                Title = "Редактирование недвижимости",
                DataContext = (sender as Button).DataContext
            }.ShowDialog();
            PropertiesLBox.ItemsSource = null;
            PropertiesLBox.ItemsSource = MainWindow.Db.Property.ToList();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (MessageBox.Show("Вы уверены что хотите безвозратно удалить недвижимость?", "Предупреждение об удалении недвижимости", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                MainWindow.Db.Property.Remove(btn.DataContext as Property);
                MainWindow.Db.Address.Remove(MainWindow.Db.Address.Find((btn.DataContext as Property).AddressId));
                MainWindow.Db.SaveChanges();
                PropertiesLBox.ItemsSource = null;
                PropertiesLBox.ItemsSource = MainWindow.Db.Property.ToList();
            }
        }
    }
}
