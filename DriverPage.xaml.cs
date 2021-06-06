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
    /// Логика взаимодействия для DriverPage.xaml
    /// </summary>
    public partial class DriverPage : Page
    {
        public DriverPage()
        {
            InitializeComponent();
            
            searchInTxtBox();
            string[] sortArray = { "По фамилии", "По имени", "По отчеству" };
            comboBoxSort.ItemsSource = sortArray;
            if (Manager.role == "Driver")
            {
                btnAdd.Visibility = Visibility.Hidden;
            }

        }
        public void searchInTxtBox()
        {
            List<Driver> currentDriver = TransportCompanyEntities.getContext().Driver.ToList();
            currentDriver = currentDriver.Where(p => p.FirstName.ToLower().Contains(txtBoxSearch.Text.ToLower()) || p.LastName.ToLower().Contains(txtBoxSearch.Text.ToLower()) || p.Patronymic.ToLower().Contains(txtBoxSearch.Text.ToLower()) || p.Passport.ToLower().Contains(txtBoxSearch.Text.ToLower()) || p.DriverLicense.ToLower().Contains(txtBoxSearch.Text.ToLower())).ToList();
            ListViewDriver.ItemsSource = currentDriver.ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                TransportCompanyEntities.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ListViewDriver.ItemsSource = TransportCompanyEntities.getContext().Driver.ToList();

            }
        }
        private void ListViewDriver_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Driver driver = (Driver)ListViewDriver.SelectedItem;
            Manager.mainFrame.Navigate(new EditDriverPage(driver));
        }
        private void txtBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchInTxtBox();
        }
        private void comboBoxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxSort.SelectedIndex == 0)
                ListViewDriver.ItemsSource = TransportCompanyEntities.getContext().Driver.OrderBy(p => p.LastName).ToList();
            if (comboBoxSort.SelectedIndex == 1)
                ListViewDriver.ItemsSource = TransportCompanyEntities.getContext().Driver.OrderBy(p => p.FirstName).ToList();
            if (comboBoxSort.SelectedIndex == 2)
                ListViewDriver.ItemsSource = TransportCompanyEntities.getContext().Driver.OrderBy(p => p.Patronymic).ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new AddDriverPage());
        }
    }
}
