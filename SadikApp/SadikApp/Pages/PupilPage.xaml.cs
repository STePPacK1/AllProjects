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
    /// Логика взаимодействия для PupilPage.xaml
    /// </summary>
    public partial class PupilPage : Page
    {
        public PupilPage()
        {
            InitializeComponent();

            lb_pupil.ItemsSource = MainWindow.db.Pupil.ToList();
        }

        private void b_openCard_Click(object sender, RoutedEventArgs e)
        {
            new PupilCardWindow(false)
            {
                Title = "Карточка воспитаника",
                DataContext = (sender as Button).DataContext
            }.ShowDialog();
            lb_pupil.ItemsSource = null;
            lb_pupil.ItemsSource = MainWindow.db.Pupil.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new ApWindow()
            {
                Title = "Добавление воспитаника",
                DataContext = (sender as Button).DataContext
            }.ShowDialog();
            lb_pupil.ItemsSource = null;
            lb_pupil.ItemsSource = MainWindow.db.Pupil.ToList();
        }
    }
}
