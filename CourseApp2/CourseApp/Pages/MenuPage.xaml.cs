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

namespace CourseApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void b_prodTable_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CusrPage() { DataContext = DataContext });
        }

        private void b_clientTable_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StudentPage() { DataContext = DataContext });
        }

        private void b_catTable_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClassPage() {DataContext = DataContext});
        }

        private void b_sallerTable_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeacherPage() { DataContext = DataContext });
        }

        private void b_invoiceTable_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SchedulePage() { DataContext = DataContext });
        }

        private void b_invoiceTable1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ScheduleStudentPage() { DataContext = DataContext });
        }

        private void b_ts_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeacherShedulePage() { DataContext = DataContext });

        }
    }
}
