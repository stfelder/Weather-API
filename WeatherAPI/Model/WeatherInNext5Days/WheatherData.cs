using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI.Model.WeatherInNext5Days
{
    public class Location : Base.Location
    {
        public override string ToString()
        {
            string temp = base.ToString();
            return temp;
        }
    }
    public class Weather : Base.Weather
    {
        public override string ToString()
        {
            string temp = base.ToString();
            return temp;
        }
    }

    public class weatherInNext5Days{
        public List<Weather> list = new List<Weather>();
        //public Weather weather = new Weather();
        public Location location = new Location();
        }
}
