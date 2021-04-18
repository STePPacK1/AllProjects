using SadikApp.Windows;
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

namespace SadikApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для VisitLogPage.xaml
    /// </summary>
    public partial class VisitLogPage : Page
    {
        public VisitLogPage()
        {
            InitializeComponent();

            lb_vl.ItemsSource = MainWindow.db.VisitLog.ToList();
        }

        private void b_add_Click(object sender, RoutedEventArgs e)
        {
            new VLWindow()
            {
                Title = "Добавление",
                DataContext = (sender as Button).DataContext
            }.ShowDialog();
            lb_vl.ItemsSource = null;
            lb_vl.ItemsSource = MainWindow.db.VisitLog.ToList();
        }
    }
}
