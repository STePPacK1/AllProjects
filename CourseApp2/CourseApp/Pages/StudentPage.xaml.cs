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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CourseApp.Windows;

namespace CourseApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        public StudentPage()
        {
            InitializeComponent();

            lb_customers.ItemsSource = MainWindow.db.Student.ToList();
            //List<Gender> genders = MainWindow.db.Gender.ToList();
            //genders.Add(new Gender() { Name = "Все" });
            //GenderCBox.ItemsSource = genders;
            //GenderCBox.SelectedItem = MainWindow.db.Gender.FirstOrDefault(g => g.Name == "Все");
            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lb_customers.ItemsSource);
            //view.Filter = c => NameFilter(c) && GenderFilter(c);
        }

        private void b_edit_Click(object sender, RoutedEventArgs e)
        {
            new AddStudentWindow(false)
            {
                Title = "Редактирование",
                DataContext = (sender as Button).DataContext
            }.ShowDialog();
            lb_customers.ItemsSource = null;
            lb_customers.ItemsSource = MainWindow.db.Student.ToList();
        }

        private void b_del_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (MessageBox.Show("Вы уверены что хотите безвозратно удалить запись?",
                "Предупреждение об удалении", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Student teacher = MainWindow.db.Student.Attach(DataContext as Student);
                teacher.Deleted = true;
                MainWindow.db.SaveChanges();
                lb_customers.ItemsSource = null;
                lb_customers.ItemsSource = MainWindow.db.Student.ToList();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddStudentWindow(true)
            {
                Title = "Добавление"
            }.ShowDialog();
            lb_customers.ItemsSource = null;
            lb_customers.ItemsSource = MainWindow.db.Student.ToList();
        }
        private void NameFilterTBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lb_customers.ItemsSource).Refresh();
        }

        private void SortAscendingRB_Checked(object sender, RoutedEventArgs e)
        {
            lb_customers.Items.SortDescriptions.Clear();
            lb_customers.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("FirstName", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void SortDescendingRB_Checked(object sender, RoutedEventArgs e)
        {
            lb_customers.Items.SortDescriptions.Clear();
            lb_customers.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("FirstName", System.ComponentModel.ListSortDirection.Descending));
        }

        private void GenderCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lb_customers.ItemsSource).Refresh();
        }

        //private bool GenderFilter(object c) => (c as Student).Gender1 == (GenderCBox.SelectedItem as Gender) || (GenderCBox.SelectedItem as Gender).Name == "Все";

        private bool NameFilter(object c) =>
            (c as Student).FirstName.ToLower().StartsWith(NameFilterTBox.Text.Trim().ToLower()) ||
            (c as Student).LastName.ToLower().StartsWith(NameFilterTBox.Text.Trim().ToLower()) ||
            (c as Student).Patronymic.ToLower().StartsWith(NameFilterTBox.Text.Trim().ToLower()) ||
            string.IsNullOrWhiteSpace(NameFilterTBox.Text.Trim());
    }
}
