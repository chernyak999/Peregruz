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
    /// Логика взаимодействия для AddRoutePage.xaml
    /// </summary>
    public partial class AddRoutePage : Page
    {
        private Route currentRoute;
        public AddRoutePage()
        {
            InitializeComponent();
            currentRoute = new Route();
            DataContext = currentRoute;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (string.IsNullOrEmpty(currentRoute.Destination))
            {
                stringBuilder.AppendLine("Не введена точка назначения");
            }
            if (string.IsNullOrEmpty(currentRoute.Distance.ToString()))
            {
                stringBuilder.AppendLine("Не введено расстояние");
            }
            if (string.IsNullOrEmpty(currentRoute.DeliveryTime.ToString()))
            {
                stringBuilder.AppendLine("Не введено время доставки");
            }
            if (string.IsNullOrEmpty(currentRoute.PriceOfDelivery.ToString()))
            {
                stringBuilder.AppendLine("Не введена цена");
            }
            if (stringBuilder.Length != 0)
            {
                MessageBox.Show(stringBuilder.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                TransportCompanyEntities.getContext().Route.Add(currentRoute);
                TransportCompanyEntities.getContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!");
                Manager.mainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message.ToString());
            }
        }
    }
}
