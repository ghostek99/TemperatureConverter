﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace View
{
    public class ConverterViewModel : INotifyPropertyChanged
    {
        private double temperatureInKelvin;

        public ConverterViewModel()
        {
            this.Kelvin = new TemperatureScaleViewModel(this, new KelvinTemperatureScale());
            this.Celsius = new TemperatureScaleViewModel(this, new CelsiusTemperatureScale());
            this.Fahrenheit = new TemperatureScaleViewModel(this, new FahrenheitTemperatureScale());
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

        public TemperatureScaleViewModel Kelvin { get; set; }

        public TemperatureScaleViewModel Celsius { get; set; }

        public TemperatureScaleViewModel Fahrenheit { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class TemperatureScaleViewModel : INotifyPropertyChanged
    {
        private readonly ConverterViewModel parent;
        private readonly ITemperatureScale scale;

        public TemperatureScaleViewModel(ConverterViewModel parent, ITemperatureScale scale)
        {
            this.parent = parent;
            this.scale = scale;

            this.parent.PropertyChanged += (sender, args) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Temperature)));
        }

        public string Name => scale.Name;

        public double Temperature 
        {
            get
            {
                return Temperature;
            }
            set
            {
                parent.TemperatureInKelvin = scale.ConvertToKelvin(value);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
