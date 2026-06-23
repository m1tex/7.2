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
using System.Windows.Shapes;

namespace pr7._2
{
    /// <summary>
    /// Логика взаимодействия для ConvertWindow.xaml
    /// </summary>
    public partial class ConvertWindow : Window
    {
        public ConvertWindow()
        {
            InitializeComponent();
            label3.Visibility = Visibility.Hidden;
            labelResult.Visibility = Visibility.Hidden;
        }
        private int savedNumber;
        private sbyte savedBase;
        private bool isDataSaved = false;
        private void OkClick(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(textBoxForInput.Text, out int number))
            {
                MessageBox.Show("Please enter a valid integer", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
                sbyte baseValue;
            if (radBtnFor2.IsChecked == true)
                baseValue = 2;
            else if (radBtnFor8.IsChecked == true)
                baseValue = 8;
            else
                baseValue = 16;
            if (number < 0) MessageBox.Show("Please enter a non-negative number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                savedNumber = number;
                savedBase = baseValue;
                isDataSaved = true;
            }

        }
        private void DoClick(object sender, RoutedEventArgs e)
        {
            if (!isDataSaved)
            {
                MessageBox.Show("Please press 'Ok' first to convert the number", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            isDataSaved = false;
            try
            {
                string result = Convert.ToString(savedNumber, savedBase).ToUpper();
                labelResult.Content = result;
                label3.Visibility = Visibility.Visible;
                labelResult.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Conversion error {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
