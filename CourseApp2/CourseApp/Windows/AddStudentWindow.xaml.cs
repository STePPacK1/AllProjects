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
    /// Логика взаимодействия для AddStudentWindow.xaml
    /// </summary>
    public partial class AddStudentWindow : Window
    {
        readonly bool isCreate;
        public AddStudentWindow(bool isCreate)
        {
            InitializeComponent();
            this.isCreate = isCreate;

            cb_gender.ItemsSource = MainWindow.db.Gender.ToList();
            cb_class.ItemsSource = MainWindow.db.Class.ToList();
        }

        private void b_add_Click(object sender, RoutedEventArgs e)
        {
            if(isCreate)
            {
                tbl_titleW.Text = "Добавление новой записи";

                Student teacher = new Student()
                {
                    FirstName = tb_surn.Text.Trim(),
                    LastName = tb_name.Text.Trim(),
                    Patronymic = tb_patro.Text.Trim(),
                    Class1 = cb_class.SelectedItem as Class,
                    Gender1 = cb_gender.SelectedItem as Gender,
                    Phone = tb_phone.Text.Trim()
                };
                MainWindow.db.Student.Add(teacher); 
            }
            else
            {
                tbl_titleW.Text = "Изменение записи";

                Student teacher = MainWindow.db.Student.Attach(DataContext as Student);

                teacher.FirstName = tb_surn.Text.Trim();
                teacher.LastName = tb_name.Text.Trim();
                teacher.Patronymic = tb_patro.Text.Trim();
                teacher.Class1 = cb_class.SelectedItem as Class;
                   teacher.Gender1 = cb_gender.SelectedItem as Gender;
                teacher.Phone = tb_phone.Text.Trim();
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
