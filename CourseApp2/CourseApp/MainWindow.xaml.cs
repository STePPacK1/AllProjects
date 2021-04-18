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

namespace CourseApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static SchoolCoursesEntities1 db;
        
        public MainWindow()
        {
            InitializeComponent();

            db = new SchoolCoursesEntities1();
        }

        public static Account AuthAccount { get; set; }

        private void b_back_Click(object sender, RoutedEventArgs e)
        {
            if (f_mineFrame.CanGoBack)
            {
                f_mineFrame.GoBack();
            }
        }

        private void b_exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
