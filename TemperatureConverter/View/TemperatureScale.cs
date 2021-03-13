using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public interface ITemperatureScale
    {
        string Name { get; }
        double ConvertToKelvin(double temperature);
        double ConvertFromKelvin(double temperature);
    }

    class KelvinTemperatureScale : ITemperatureScale
    {
        public KelvinTemperatureScale()
        {
            this.Name = "KelvinTemperatureScale";
        }

        public string Name { get; }

        public double ConvertFromKelvin(double temperature)
        {
            return temperature;
        }

        public double ConvertToKelvin(double temperature)
        {
            return temperature;
        }
    }

    class CelsiusTemperatureScale : ITemperatureScale
    {
    
        public CelsiusTemperatureScale()
        {
            this.Name = "CelsiusTemperatureScale";
        }

        public string Name { get; }

        public double ConvertFromKelvin(double temperature)
        {
            return temperature - 273.15;
        }

        public double ConvertToKelvin(double temperature)
        {
            return temperature + 273.15;
        }
    }

    class FahrenheitTemperatureScale : ITemperatureScale
    {

        public FahrenheitTemperatureScale()
        {
            this.Name = "FahrenheitTemperatureScale";
        }

        public string Name { get; }

        public double ConvertFromKelvin(double temperature)
        {
            var fahrenheit = (temperature - 273.15) * 18 / 10 + 32;
            return fahrenheit;
        }

        public double ConvertToKelvin(double temperature)
        {
            var kelvin = 273.15 + ((temperature - 32.0) * (5.0 / 9.0));
            return kelvin;
        }
    }
}
