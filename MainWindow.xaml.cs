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

namespace Peregruz
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Manager.mainFrame = MainFrame;
            Manager.mainFrame.Navigate(new UserInfoPage());
            if(Manager.role == "Admin")
            {
                btnRoutes.Visibility = Visibility.Hidden;
                btnClients.Visibility = Visibility.Hidden;
                btnOrders.Visibility = Visibility.Hidden;
                btnDrivers.Visibility = Visibility.Hidden;
                btnCars.Visibility = Visibility.Hidden;
                
            }
            if(Manager.role == "Manager")
            {
                btnUsers.Visibility = Visibility.Hidden;
            }
            if (Manager.role == "Driver")
            {
                btnUsers.Visibility = Visibility.Hidden;
                btnRoutes.Visibility = Visibility.Hidden;
                btnClients.Visibility = Visibility.Hidden;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.GoBack();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Close();
        }
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                btnBack.Visibility = Visibility.Visible;
            }
            else
            {
                btnBack.Visibility = Visibility.Hidden;
            }
        }
        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new UsersPage());
        }
        private void btnDrivers_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new DriverPage());
        }
        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new ClientsPage());
        }

        private void btnRoutes_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new RoutePage());
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new OrdesPage());
        }

        private void btnCars_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new CarsPage());
        }
    }
}
