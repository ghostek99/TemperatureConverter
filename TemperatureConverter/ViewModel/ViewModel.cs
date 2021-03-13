using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Model;

namespace ViewModel
{
    public class ConverterViewModel
    {
        public ConverterViewModel()
        {
            this.TemperatureInKelvin = new Cell<double>();
            this.Kelvin = new TemperatureScaleViewModel(this, new KelvinTemperatureScale());
            this.Celsius = new TemperatureScaleViewModel(this, new CelsiusTemperatureScale());
            this.Fahrenheit = new TemperatureScaleViewModel(this, new FahrenheitTemperatureScale());
        }

        public Cell<double> TemperatureInKelvin { get; }

        public TemperatureScaleViewModel Kelvin { get; set; }

        public TemperatureScaleViewModel Celsius { get; set; }

        public TemperatureScaleViewModel Fahrenheit { get; set; }

        public IEnumerable<TemperatureScaleViewModel> Scales
        {
            get
            {
                yield return Celsius;
                yield return Fahrenheit;
                yield return Kelvin;
            }
        }
    }

    public class TemperatureScaleViewModel
    {
        private ConverterViewModel parent;
        private ITemperatureScale scale;

        public TemperatureScaleViewModel(ConverterViewModel parent, ITemperatureScale scale)
        {
            this.parent = parent;
            this.scale = scale;

            this.Temperature = this.parent.TemperatureInKelvin.Derive(kelvin => scale.ConvertFromKelvin(kelvin));
        }

        public string Name => scale.Name;

        public Cell<double> Temperature { get; }

    }
}