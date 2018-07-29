using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI.Model.WeahterCurrent
{
    public class Location : Base.Location
    {
        public override string ToString()
        {
            string temp = base.ToString() ;
            return temp;
        }
    }
    public class Weather : Base.Weather
    {
        public DateTime sunrise { get; set; } //Time Sunrise
        public DateTime sunset { get; set; } //Time Sunset
        public int visibilityMeter { get; set; } //Visibility, meter

        public override string ToString()
        {
        string temp = base.ToString();
            temp += "\nTime of Sunrise: " + sunrise;
            temp += "\nTime of Sunset: " + sunset;
            temp += "\nVisibility: " + visibilityMeter + "m";
            return temp;
        }
    }

    public class WeatherModelCurn
    {
        public Weather weather = new Weather();
        public Location location = new Location();
        
    }
}
