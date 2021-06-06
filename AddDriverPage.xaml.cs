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
    /// Логика взаимодействия для AddDriverPage.xaml
    /// </summary>
    public partial class AddDriverPage : Page
    {
        private Driver currentDriver;
        public AddDriverPage()
        {
            InitializeComponent();
            currentDriver = new Driver();
            DataContext = currentDriver;
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
            if (string.IsNullOrEmpty(currentDriver.Passport))
            {
                stringBuilder.AppendLine("Не введен паспорт");
            }
            if (string.IsNullOrEmpty(currentDriver.DriverLicense))
            {
                stringBuilder.AppendLine("Не введен номер В/У");
            }
            if (stringBuilder.Length != 0)
            {
                MessageBox.Show(stringBuilder.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                TransportCompanyEntities.getContext().Driver.Add(currentDriver);
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
