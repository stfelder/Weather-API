using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WeatherAPI.View
{
    public partial class SimpelGUI : UserControl
    {
        WeatherDataManager weather;

        public SimpelGUI() {
            InitializeComponent();
        }
        public SimpelGUI(WeatherDataManager weather)
        {
            InitializeComponent();
            setWeather(weather);
        }
        public void setWeather (WeatherDataManager weather)
        {
            this.weather = weather;
            temperatur.Text = weather.weatherCurrent.weather.temperatur.ToString() + "°C";
            lbl_Location.Text = weather.weatherCurrent.location.nameLocality;
            string path = Path.Combine(Environment.CurrentDirectory, @"GUI\ImageWeather\",  weather.weatherCurrent.weather.icon +".png");
            Image image = Image.FromFile(path);
            pictureBox1.Image = image;
        }
    }
}
