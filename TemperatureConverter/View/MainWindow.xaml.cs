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
using System.Diagnostics;
using System.ComponentModel;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private double temperatureInKelvin;

        public MainWindow()
        {
            InitializeComponent();
        }

        public double TemperatureInKelvin 
        {
            get
            {
                return temperatureInKelvin;
            }
            set
            {
                temperatureInKelvin = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TemperatureInKelvin)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class TempConverter : IValueConverter
    {
        public ITemperatureScale Scale { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var kelvin = (double)value;

            return this.Scale.ConvertFromKelvin(kelvin).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var temperature = double.Parse((string)value);

            return this.Scale.ConvertToKelvin(temperature);
        }
    }

}
