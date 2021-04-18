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
    /// Логика взаимодействия для AddSchStuWindow.xaml
    /// </summary>
    public partial class AddSchStuWindow : Window
    {
        readonly bool isCreate;
        public AddSchStuWindow(bool isCreate)
        {
            InitializeComponent();
            this.isCreate = isCreate;

            cb_stud.ItemsSource = MainWindow.db.Student.ToList();
            cb_sche.ItemsSource = MainWindow.db.Schedule.ToList();
        }

        private void b_close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void b_add_Click(object sender, RoutedEventArgs e)
        {

            if (isCreate)
            {
                tbl_titleW.Text = "Добавление новой записи";

                ScheduleStudent teacher = new ScheduleStudent()
                {
                    Student1 = cb_stud.SelectedItem as Student,
                    Schedule1 = cb_sche.SelectedItem as Schedule
                };
                MainWindow.db.ScheduleStudent.Add(teacher);
            }
            else
            {
                tbl_titleW.Text = "Изменение записи";

                ScheduleStudent teacher = MainWindow.db.ScheduleStudent.Attach(DataContext as ScheduleStudent);

                teacher.Student1 = cb_stud.SelectedItem as Student;
                teacher.Schedule1 = cb_sche.SelectedItem as Schedule;
            }
            MainWindow.db.SaveChanges();
            MessageBox.Show("Сохраненно успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
