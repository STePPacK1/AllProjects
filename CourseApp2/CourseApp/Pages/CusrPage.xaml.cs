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
using CourseApp.Windows;

namespace CourseApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для CusrPage.xaml
    /// </summary>
    public partial class CusrPage : Page
    {
        public CusrPage()
        {
            InitializeComponent();

            lb_cate.ItemsSource = MainWindow.db.Course.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddCursWindow(true)
            {
                Title = "Добавление"
            }.ShowDialog();
            lb_cate.ItemsSource = null;
            lb_cate.ItemsSource = MainWindow.db.Course.ToList();
        }

        private void b_edit_Click(object sender, RoutedEventArgs e)
        {
            new AddCursWindow(false)
            {
                Title = "Редактирование",
                DataContext = (sender as Button).DataContext
            }.ShowDialog();
            lb_cate.ItemsSource = null;
            lb_cate.ItemsSource = MainWindow.db.Course.ToList();
        }

        private void b_del_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (MessageBox.Show("Вы уверены что хотите безвозратно удалить запись?",
                "Предупреждение об удалении", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var context = MainWindow.db.Course.Attach(btn.DataContext as Course);
                context.Deleted = true;

                MainWindow.db.SaveChanges();
                lb_cate.ItemsSource = null;
                lb_cate.ItemsSource = MainWindow.db.Course.ToList();
            }
        }
    }
}
