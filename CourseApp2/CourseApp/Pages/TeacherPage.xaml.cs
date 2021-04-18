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
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {       
        public TeacherPage()
        {
            InitializeComponent();          

            lb_customers.ItemsSource = MainWindow.db.Teacher.ToList();
        }

        private void b_edit_Click(object sender, RoutedEventArgs e)
        {
            new AddTeacherWindow(false)
            {
                Title = "Редактирование",
                DataContext = (sender as Button).DataContext
            }.ShowDialog();
            lb_customers.ItemsSource = null;
            lb_customers.ItemsSource = MainWindow.db.Teacher.ToList();
        }

        private void b_del_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (MessageBox.Show("Вы уверены что хотите безвозратно удалить запись?",
                "Предупреждение об удалении", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var context = MainWindow.db.Teacher.Attach(btn.DataContext as Teacher);
                context.Deleted = true;

                MainWindow.db.SaveChanges();
                lb_customers.ItemsSource = null;
                lb_customers.ItemsSource = MainWindow.db.Teacher.ToList();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddTeacherWindow(true)
            {
                Title = "Добавление"
            }.ShowDialog();
            lb_customers.ItemsSource = null;
            lb_customers.ItemsSource = MainWindow.db.Teacher.ToList();
        }
    }
}
