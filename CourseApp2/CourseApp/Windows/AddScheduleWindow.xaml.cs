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

namespace CourseApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddScheduleWindow.xaml
    /// </summary>
    public partial class AddScheduleWindow : Window
    {
        readonly bool isCreate;
        public AddScheduleWindow( bool isCreate)
        {
            InitializeComponent();

            this.isCreate = isCreate;

            cb_cours.ItemsSource = MainWindow.db.Course.ToList();
            cb_dOW.ItemsSource = MainWindow.db.DayOfWeek.ToList();
            cb_teach.ItemsSource = MainWindow.db.Teacher.ToList();
        }

        private void b_add_Click(object sender, RoutedEventArgs e)
        {
            if (isCreate)
            {
                tbl_titleW.Text = "Добавление новой записи";

                Schedule teacher = new Schedule()
                {
                    Course1 = cb_cours.SelectedItem as Course,
                    Teacher1 = cb_teach.SelectedItem as Teacher,
                    DayOfWeek1 = cb_dOW.SelectedItem as DayOfWeek,
                    Time = dp_date.DisplayDate
                };
                MainWindow.db.Schedule.Add(teacher);
            }
            else
            {
                tbl_titleW.Text = "Изменение записи";

                Schedule teacher = MainWindow.db.Schedule.Attach(DataContext as Schedule);

                teacher.Course1 = cb_cours.SelectedItem as Course;
                teacher.Teacher1 = cb_teach.SelectedItem as Teacher;
                teacher.DayOfWeek1 = cb_dOW.SelectedItem as DayOfWeek;
                teacher.Time = dp_date.DisplayDate;
            }
            MainWindow.db.SaveChanges();
            MessageBox.Show("Сохраненно успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void b_close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
