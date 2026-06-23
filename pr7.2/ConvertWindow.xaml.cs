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
        }
        private int currentNumber;
        private string currentResult;
        private void DoClick(object sender, RoutedEventArgs e)
        {
            bool isNumber = int.TryParse(textBoxForInput.Text, out int number);
            if (!isNumber)
            {
                MessageBox.Show("Please enter a valid integer", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int baseValue;
            if (radBtnFor2.IsChecked == true)
                baseValue = 2;
            else if (radBtnFor8.IsChecked == true)
                baseValue = 8;
            else
                baseValue = 16;
            try
            {
                string result = Convert.ToString(number, baseValue).ToUpper();
                labelResult.Content = result;
                currentNumber = number;
                currentResult = result;
            }
            catch(Exception ex) 
            {
                MessageBox.Show($"Conversion error: {ex.Message}", "Error", MessageBoxButton.OK , MessageBoxImage.Error);
            }
        }
        private void OkClick(object sender, RoutedEventArgs e) 
        {
            if (string.IsNullOrEmpty(currentResult))
            {
                MessageBox.Show("Please press 'Do' first to convert the number", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return; // ✅ Выходим, не закрывая окно
            }

            // ✅ Показываем подтверждение с введёнными данными
            string baseName = GetSelectedBase().ToString();
            string message = $"You entered: {currentNumber}\nConverted to base {baseName} = {currentResult}";
            MessageBox.Show(message, "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);

            // ✅ Закрываем окно
            this.Close();
        }
        private int GetSelectedBase()
        {
            if (radBtnFor2.IsChecked == true) return 2;
            if (radBtnFor8.IsChecked == true) return 8;
            else return 16;
        }
    }
}
