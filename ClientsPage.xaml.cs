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
using Peregruz.Data;

namespace Peregruz
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
            searchInTxtBox();
            string[] sortArray = { "По фамилии", "По имени", "По отчеству" };
            comboBoxSort.ItemsSource = sortArray;
            
        }
        public void searchInTxtBox()
        {
            List<Customer> currentCustomer = TransportCompanyEntities.getContext().Customer.ToList();
            currentCustomer = currentCustomer.Where(p => p.FirstName.ToLower().Contains(txtBoxSearch.Text.ToLower()) || p.LastName.ToLower().Contains(txtBoxSearch.Text.ToLower()) || p.Patronymic.ToLower().Contains(txtBoxSearch.Text.ToLower()) || p.Phone.ToLower().Contains(txtBoxSearch.Text.ToLower())).ToList();
            ListViewClient.ItemsSource = currentCustomer.ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                TransportCompanyEntities.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ListViewClient.ItemsSource = TransportCompanyEntities.getContext().Customer.ToList();
            }
        }
        private void ListViewClient_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Customer customer = (Customer)ListViewClient.SelectedItem;
            Manager.mainFrame.Navigate(new EditClientPage(customer));
        }
        private void txtBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchInTxtBox();
        }
        private void comboBoxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxSort.SelectedIndex == 0)
                ListViewClient.ItemsSource = TransportCompanyEntities.getContext().Customer.OrderBy(p => p.LastName).ToList();
            if (comboBoxSort.SelectedIndex == 1)
                ListViewClient.ItemsSource = TransportCompanyEntities.getContext().Customer.OrderBy(p => p.FirstName).ToList();
            if (comboBoxSort.SelectedIndex == 2)
                ListViewClient.ItemsSource = TransportCompanyEntities.getContext().Customer.OrderBy(p => p.Patronymic).ToList();
        }

        private void bntAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new AddClientPage());
        }
    }
}
