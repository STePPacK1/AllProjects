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
using SadikApp.Windows;


namespace SadikApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для GuardianPage.xaml
    /// </summary>
    public partial class GuardianPage : Page
    {
        public GuardianPage()
        {
            InitializeComponent();

            lb_guad.ItemsSource = MainWindow.db.Guardian.ToList();
        }

        private void b_edit_Click(object sender, RoutedEventArgs e)
        {
            new DuardianAddWindow(false)
            {
                Title = "Редактирование",
                DataContext = (sender as Button).DataContext
            }.ShowDialog();
            lb_guad.ItemsSource = null;
            lb_guad.ItemsSource = MainWindow.db.Guardian.ToList();
        }

        private void b_del_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (MessageBox.Show("Вы уверены что хотите безвозратно удалить запись?",
                "Предупреждение об удалении", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var context = MainWindow.db.Guardian.Attach(btn.DataContext as Guardian);
                context.Deleted = true;

                MainWindow.db.SaveChanges();
                lb_guad.ItemsSource = null;
                lb_guad.ItemsSource = MainWindow.db.Guardian.ToList();

            }
        }

        private void b_add_Click(object sender, RoutedEventArgs e)
        {
            new DuardianAddWindow(true)
            {
                Title = "Добавление"
            }.ShowDialog();
            lb_guad.ItemsSource = null;
            lb_guad.ItemsSource = MainWindow.db.Guardian.ToList();
        }
    }
}
