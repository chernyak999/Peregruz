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
    /// Логика взаимодействия для EditDriverPage.xaml
    /// </summary>
    public partial class EditDriverPage : Page
    {
        private Driver currentDriver;
        public EditDriverPage(Driver driver)
        {
            InitializeComponent();
            currentDriver = new Driver();
            if (driver != null)
                currentDriver = driver;
            DataContext = currentDriver;

            if (Manager.role == "Driver")
            {
                btnAdd.Visibility = Visibility.Hidden;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (string.IsNullOrEmpty(currentDriver.FirstName))
            {
                stringBuilder.AppendLine("Не введено имя");
            }
            if (string.IsNullOrEmpty(currentDriver.LastName))
            {
                stringBuilder.AppendLine("Не введена фамилия");
            }
            if (string.IsNullOrEmpty(currentDriver.Patronymic))
            {
                stringBuilder.AppendLine("Не введено отчество");
            }
            if (string.IsNullOrEmpty(currentDriver.Passport))
            {
                stringBuilder.AppendLine("Не введен паспорт");
            }
            if (string.IsNullOrEmpty(currentDriver.DriverLicense))
            {
                stringBuilder.AppendLine("Не введено В/У");
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
