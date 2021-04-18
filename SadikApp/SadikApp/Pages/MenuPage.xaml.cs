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
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void b_pupil_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PupilPage());
        }

        private void b_guar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GuardianPage());

        }

        private void b_vl_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new VisitLogPage());
        }
    }
}
