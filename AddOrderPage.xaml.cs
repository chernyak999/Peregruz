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
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        private Order currentOrder;
        public AddOrderPage()
        {
            InitializeComponent();
            currentOrder = new Order();
            DataContext = currentOrder;
            comboBoxClient.ItemsSource = TransportCompanyEntities.getContext().Customer.ToList();
            comboBoxRoute.ItemsSource = TransportCompanyEntities.getContext().Route.ToList();
            comboBoxCar.ItemsSource = TransportCompanyEntities.getContext().Car.ToList();
            comboBoxDriver.ItemsSource = TransportCompanyEntities.getContext().Driver.ToList();
            comboBoxStatus.ItemsSource = TransportCompanyEntities.getContext().OrderStatus.ToList();
        }
        private void comboBoxClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxClient.ItemsSource = TransportCompanyEntities.getContext().Customer.ToList();
        }
        private void comboBoxRoute_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxRoute.ItemsSource = TransportCompanyEntities.getContext().Route.ToList();
        }
        private void comboBoxCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxCar.ItemsSource = TransportCompanyEntities.getContext().Car.ToList();
        }
        private void comboBoxDriver_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxDriver.ItemsSource = TransportCompanyEntities.getContext().Driver.ToList();
        }
        private void comboBoxStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxStatus.ItemsSource = TransportCompanyEntities.getContext().OrderStatus.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TransportCompanyEntities.getContext().Order.Add(currentOrder);
                TransportCompanyEntities.getContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                Manager.mainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message.ToString());
            }
        }
    }
}
