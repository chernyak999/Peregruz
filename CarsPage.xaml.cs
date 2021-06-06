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
    /// Логика взаимодействия для CarsPage.xaml
    /// </summary>
    public partial class CarsPage : Page
    {
        public CarsPage()
        {
            InitializeComponent();
            DGridCars.ItemsSource = TransportCompanyEntities.getContext().Car.ToList();
            if (Manager.role == "Driver")
            {
                btnAdd.Visibility = Visibility.Hidden;
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new EditCarPage((sender as Button).DataContext as Car));
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                TransportCompanyEntities.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new AddCarPage());
        }

    }
}
