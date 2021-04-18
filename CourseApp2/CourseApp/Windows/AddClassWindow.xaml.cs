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
    /// Логика взаимодействия для AddClassWindow.xaml
    /// </summary>
    public partial class AddClassWindow : Window
    {
        readonly bool isCreate;
        public AddClassWindow(bool isCreate)
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

                Class productCategories = new Class()
                {
                    Name = tb_name.Text.Trim(),
                };
                MainWindow.db.Class.Add(productCategories);
            }
            else
            {
                tbl_titleW.Text = "Изменение записи";

                Class course = MainWindow.db.Class.Attach(DataContext as Class);

                course.Name = tb_name.Text.Trim();
            }
            MainWindow.db.SaveChanges();
            MessageBox.Show("Сохраненно успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
