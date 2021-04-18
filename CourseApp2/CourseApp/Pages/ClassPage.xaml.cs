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
    /// Логика взаимодействия для ClassPage.xaml
    /// </summary>
    public partial class ClassPage : Page
    {
        public ClassPage()
        {
            InitializeComponent();

            lb_cate.ItemsSource = MainWindow.db.Class.ToList();
        }

        private void b_edit_Click(object sender, RoutedEventArgs e)
        {
            new AddClassWindow(false)
            {
                Title = "Редактирование",
                DataContext = (sender as Button).DataContext
            }.ShowDialog();
            lb_cate.ItemsSource = null;
            lb_cate.ItemsSource = MainWindow.db.Class.ToList();
        }

        private void b_del_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (MessageBox.Show("Вы уверены что хотите безвозратно удалить запись?",
                "Предупреждение об удалении", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var context = MainWindow.db.Class.Attach(btn.DataContext as Class);
                context.Deleted = true;

                MainWindow.db.SaveChanges();
                lb_cate.ItemsSource = null;
                lb_cate.ItemsSource = MainWindow.db.Class.ToList();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddClassWindow(true)
            {
                Title = "Добавление"
            }.ShowDialog();
            lb_cate.ItemsSource = null;
            lb_cate.ItemsSource = MainWindow.db.Class.ToList();
        }
    }
}
