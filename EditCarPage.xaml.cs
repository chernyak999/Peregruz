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
    /// Логика взаимодействия для EditCarPage.xaml
    /// </summary>
    public partial class EditCarPage : Page
    {
        private Car currentCar;
        public EditCarPage(Car car)
        {
            InitializeComponent();
            currentCar = new Car();
            if (car != null)
                currentCar = car;
            DataContext = currentCar;

            if (Manager.role == "Driver")
            {
                btnAdd.Visibility = Visibility.Hidden;            
            }    
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (string.IsNullOrEmpty(currentCar.CarBrand))
            {
                stringBuilder.AppendLine("Не введена марка");
            }
            if (string.IsNullOrEmpty(currentCar.CarModel))
            {
                stringBuilder.AppendLine("Не введена модель");
            }
            if (string.IsNullOrEmpty(currentCar.LicensePlate))
            {
                stringBuilder.AppendLine("Не введен гос. номер");
            }
            if (string.IsNullOrEmpty(currentCar.VIN))
            {
                stringBuilder.AppendLine("Не введен VIN номер");
            }
            if (string.IsNullOrEmpty(currentCar.CarPassport))
            {
                stringBuilder.AppendLine("Не введен номер ПТС");
            }
            if (stringBuilder.Length != 0)
            {
                MessageBox.Show(stringBuilder.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
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
