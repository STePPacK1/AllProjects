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
using System.Windows.Shapes;

namespace SadikApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для VLWindow.xaml
    /// </summary>
    public partial class VLWindow : Window
    {
        public VLWindow()
        {
            InitializeComponent();

            cb_pup.ItemsSource = MainWindow.db.Pupil.ToList();
            cb_stat.ItemsSource = MainWindow.db.PresenceStatus.ToList();
            cb_stattwo.ItemsSource = MainWindow.db.ReasonForAbsence.ToList();
        }

        private void b_close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void b_add_Click(object sender, RoutedEventArgs e)
        {
            VisitLog teacher = new VisitLog()
            {
                Pupil = cb_pup.SelectedItem as Pupil,
                Date = dp.DisplayDate,
                ArirvalTime = tb_timeone.Text.Trim(),
                DepartureTime = tb_timetwo.Text.Trim(),
                PresenceStatus = cb_stat.SelectedItem as PresenceStatus,
                ReasonForAbsence = cb_stattwo.SelectedItem as ReasonForAbsence,
            };
            MainWindow.db.VisitLog.Add(teacher);         
            MainWindow.db.SaveChanges();
            MessageBox.Show("Сохраненно успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
}
    }
}
