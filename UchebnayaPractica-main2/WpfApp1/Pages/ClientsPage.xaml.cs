using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp1.Windows;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
            ClientsLBox.ItemsSource = MainWindow.Db.Client.ToList();
            GenderCBox.ItemsSource = MainWindow.Db.Gender.ToList();
            GenderCBox.SelectedItem = MainWindow.Db.Gender.FirstOrDefault(g => g.Name == "Все");
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ClientsLBox.ItemsSource);
            view.Filter = c => NameFilter(c) && GenderFilter(c);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            new ClientWindow(true)
            {
                Title = "Добавление нового клиента",
            }.ShowDialog();
            ClientsLBox.ItemsSource = null;
            ClientsLBox.ItemsSource = MainWindow.Db.Client.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            new ClientWindow(false)
            {
                Title = "Редактирование клиента",
                DataContext = (sender as Button).DataContext
            }.ShowDialog();
            ClientsLBox.ItemsSource = null;
            ClientsLBox.ItemsSource = MainWindow.Db.Client.ToList();

        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (MessageBox.Show("Вы уверены что хотите безвозратно удалить клиента?", "Предупреждение об удалении клиента", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                MainWindow.Db.Client.Remove(btn.DataContext as Client);
                MainWindow.Db.Account.Remove(MainWindow.Db.Account.Find((btn.DataContext as Client).AccountId));
                MainWindow.Db.SaveChanges();
                ClientsLBox.ItemsSource = null;
                ClientsLBox.ItemsSource = MainWindow.Db.Client.ToList();
            }
        }

        private void NameFilterTBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(ClientsLBox.ItemsSource).Refresh();
        }

        private void SortAscendingRB_Checked(object sender, RoutedEventArgs e)
        {
            ClientsLBox.Items.SortDescriptions.Clear();
            ClientsLBox.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("FirstName", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void SortDescendingRB_Checked(object sender, RoutedEventArgs e)
        {
            ClientsLBox.Items.SortDescriptions.Clear();
            ClientsLBox.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("FirstName", System.ComponentModel.ListSortDirection.Descending));
        }

        private void GenderCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(ClientsLBox.ItemsSource).Refresh();
        }

        private bool GenderFilter(object c) => (c as Client).Gender1 == (GenderCBox.SelectedItem as Gender) || (GenderCBox.SelectedItem as Gender).Name == "Все";

        private bool NameFilter(object c) =>
            (c as Client).FirstName.ToLower().StartsWith(NameFilterTBox.Text.Trim().ToLower()) ||
            (c as Client).LastName.ToLower().StartsWith(NameFilterTBox.Text.Trim().ToLower()) ||
            (c as Client).Patronymic.ToLower().StartsWith(NameFilterTBox.Text.Trim().ToLower()) ||
            string.IsNullOrWhiteSpace(NameFilterTBox.Text.Trim());
    }
}
