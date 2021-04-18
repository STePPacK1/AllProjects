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

namespace SadikApp
{
    /// <summary>
    /// Логика взаимодействия для PupilCardWindow.xaml
    /// </summary>
    public partial class PupilCardWindow : Window
    {
        readonly bool isCreate;
        string photo;

        public PupilCardWindow(bool isCreate)
        {
            InitializeComponent();

            this.isCreate = isCreate;

            Pupil pupil = (Pupil)DataContext;

            lb_guard.ItemsSource = MainWindow.db.PupilGuardian.ToList();
            //lb_guard.Items.Filter = c => (c as PupilGuardian).Guardian.FullNameG == ;

            cb_gender.ItemsSource = MainWindow.db.Gender.ToList();
            cb_group.ItemsSource = MainWindow.db.Group.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            g_tbl.Visibility = Visibility.Hidden;
            g_tbANDb.Visibility = Visibility.Visible;
        }

        private void b_save_Click(object sender, RoutedEventArgs e)
        {
            if (cb_gender.SelectedItem == null ||
                cb_group.SelectedItem == null ||
                cb_guard.SelectedItem == null ||
                tb_surn.Text.Trim() == null ||
                tb_name.Text.Trim() == null ||
                tb_note.Text.Trim() == null ||
                dp_date.SelectedDate == null)
            {
                MessageBox.Show("Необходимо заполнить все обязательные поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (MessageBox.Show("Вы уверены что хотите сохранить изменения?", "Предупреждение об изменении данных", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Pupil pupil = new Pupil()
                {
                    Surname = tb_surn.Text.Trim(),
                    Name = tb_name.Text.Trim(),
                    Patronymic = tb_patr.Text.Trim(),
                    Gender = cb_gender.SelectedItem as Gender,
                    Group = cb_group.SelectedItem as Group,
                    Birthday = dp_date.DisplayDate
                };
                MainWindow.db.Pupil.Add(pupil);

                g_tbl.Visibility = Visibility.Visible;
                g_tbANDb.Visibility = Visibility.Hidden;
            }
            else
            {
                return;
            }
        }
    }
}
