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
    /// Логика взаимодействия для AddTeacherWindow.xaml
    /// </summary>
    public partial class AddTeacherWindow : Window
    {
        readonly bool isCreate;
        public AddTeacherWindow(bool isCreate)
        {
            InitializeComponent();
            this.isCreate = isCreate;
            
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

                Teacher teacher = new Teacher()
                {
                    FirstName = tb_surn.Text.Trim(),
                    LastName = tb_name.Text.Trim(),
                    Patronymic = tb_patro.Text.Trim(),
                    Phone = tb_phone.Text.Trim()
                };
                MainWindow.db.Teacher.Add(teacher);
            }
            else
            {
                tbl_titleW.Text = "Изменение записи";

                    Teacher teacher = MainWindow.db.Teacher.Attach(DataContext as Teacher);

                    teacher.FirstName = tb_surn.Text.Trim();
                teacher.LastName = tb_name.Text.Trim();
                teacher.Patronymic = tb_patro.Text.Trim();
                teacher.Phone = tb_phone.Text.Trim();
            }
            MainWindow.db.SaveChanges();
            MessageBox.Show("Сохраненно успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    } 
}
