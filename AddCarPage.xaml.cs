﻿using System;
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
    /// Логика взаимодействия для AddCarPage.xaml
    /// </summary>
    public partial class AddCarPage : Page
    {
        private Car currentCar;
        public AddCarPage()
        {
            InitializeComponent();
            currentCar = new Car();
            DataContext = currentCar;
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
                TransportCompanyEntities.getContext().Car.Add(currentCar);
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
