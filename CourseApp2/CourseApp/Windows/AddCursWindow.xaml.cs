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
    /// Логика взаимодействия для AddCursWindow.xaml
    /// </summary>
    public partial class AddCursWindow : Window
    {
        readonly bool isCreate;
        public AddCursWindow(bool isCreate)
        {
            InitializeComponent();
            this.isCreate = isCreate;
        }

        private void b_add_Click(object sender, RoutedEventArgs e)
        {
            if (isCreate)
            {
                tbl_titleW.Text = "Добавление новой записи";

                Course productCategories = new Course()
                {
                    Name = tb_name.Text.Trim(),
                    Description = tb_dis.Text.Trim()
                };
                MainWindow.db.Course.Add(productCategories);
            }
            else
            {
                tbl_titleW.Text = "Изменение записи";

                Course course = MainWindow.db.Course.Attach(DataContext as Course);

                course.Name = tb_name.Text.Trim();
                course.Description = tb_dis.Text.Trim();

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
