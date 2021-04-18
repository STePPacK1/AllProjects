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
    /// Логика взаимодействия для DuardianAddWindow.xaml
    /// </summary>
    public partial class DuardianAddWindow : Window
    {
        readonly bool isCreate;
        public DuardianAddWindow(bool isCreate)
        {
            InitializeComponent();
            this.isCreate = isCreate;

            if (isCreate)
            {
                tbl_titleW.Text = "Добавление новой записи";

            }
            else
            {
                tbl_titleW.Text = "Изменение записи";
            }
        }

        private void b_close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void b_add_Click(object sender, RoutedEventArgs e)
        {
            if (isCreate)
            {
                Guardian teacher = new Guardian()
                {
                    Surname = tb_surn.Text.Trim(),
                    Name = tb_name.Text.Trim(),
                    Patronymic = tb_patro.Text.Trim(),
                    Phone = tb_phone.Text.Trim(),
                    Address = tb_adr.Text.Trim()
                };
                MainWindow.db.Guardian.Add(teacher);
            }
            else
            {
                Guardian teacher = MainWindow.db.Guardian.Attach(DataContext as Guardian);

                teacher.Surname = tb_surn.Text.Trim();
                teacher.Name = tb_name.Text.Trim();
                teacher.Patronymic = tb_patro.Text.Trim();
                teacher.Phone = tb_phone.Text.Trim();
                teacher.Address = tb_adr.Text.Trim();
            }
            MainWindow.db.SaveChanges();
            MessageBox.Show("Сохраненно успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
