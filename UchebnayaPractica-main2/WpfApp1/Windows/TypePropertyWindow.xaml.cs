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

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для TypePropertyWindow.xaml
    /// </summary>
    public partial class TypePropertyWindow : Window
    {
        readonly bool isCreate;
        
        public TypePropertyWindow(bool isCreate)
        {
            InitializeComponent();
            this.isCreate = isCreate;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isCreate)
            {
                TypeProperty typeProperty = new TypeProperty()
                {
                    Name = NameTBox.Text.Trim()
                };
                MainWindow.Db.TypeProperty.Add(typeProperty);
            }
            else
            {
                TypeProperty typeProperty = MainWindow.Db.TypeProperty.Attach(DataContext as TypeProperty);
                typeProperty.Name = NameTBox.Text.Trim();
            }
            MainWindow.Db.SaveChanges();
            MessageBox.Show("Тип недвижимости успешно сохранен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
