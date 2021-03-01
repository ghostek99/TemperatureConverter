using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConvertCelsius(object sender, RoutedEventArgs e)
        {
            string celsius = celsiusTextBox.Text;
            var val = double.Parse(celsius);
            var fahrenheit = (val * 9) / 5 + 32;
            var kelvin = val + 273.15;
            fahrenheitTextBox.Text = fahrenheit.ToString();
            kelvinTextBox.Text = kelvin.ToString();
        }

        private void ConvertFahrenheit(object sender, RoutedEventArgs e)
        {
            string fahrenheit = fahrenheitTextBox.Text;
            var val = double.Parse(fahrenheit);
            var celsius = (val - 32) * 5 / 9;
            var kelvin = celsius + 273.15;
            celsiusTextBox.Text = celsius.ToString();
            kelvinTextBox.Text = kelvin.ToString();
        }

        private void SliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            string kelvin = kelvinTextBox.Text;
            var val = double.Parse(kelvin);
            var celsius = val - 273.15;
            var fahrenheit = (celsius * 9) / 5 + 32;
            celsiusTextBox.Text = celsius.ToString();
            fahrenheitTextBox.Text = fahrenheit.ToString();
        }
    }

    public class CelsiusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var kelvin = (double)value;
            var celsius = kelvin - 273.15;

            return celsius.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var celsius = double.Parse((string)value);
            var kelvin = celsius + 273.15;

            return kelvin;
        }
    }
}
