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
    /// Логика взаимодействия для NeedPage.xaml
    /// </summary>
    public partial class NeedPage : Page
    {
        public NeedPage()
        {
            InitializeComponent();
            NeedsLBox.ItemsSource = MainWindow.Db.Need.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            new NeedWindow(true)
            {
                Title = "Добавить потребность"
            }.ShowDialog();

            NeedsLBox.ItemsSource = null;
            NeedsLBox.ItemsSource = MainWindow.Db.Offer.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            new NeedWindow(false)
            {
                Title = "Редактирование потребности",
                DataContext = (sender as Button).DataContext
            }.ShowDialog();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите безвозратно удалить потребность?", "Предупреждение об удалении потребности", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Need need = (sender as Button).DataContext as Need;

                MainWindow.Db.Need.Remove(need);
                MainWindow.Db.SaveChanges();

                NeedsLBox.ItemsSource = null;
                NeedsLBox.ItemsSource = MainWindow.Db.Need.ToList();
            }
        }
    }
}
