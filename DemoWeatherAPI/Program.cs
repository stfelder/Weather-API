using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI;

namespace DemoWeatherAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherDataManager weatherData = new WeatherDataManager("1be547da8c882a9417d9993e7320c090", "Obfelden,CH");
            //WeatherDataManager weatherData = new WeatherDataManager("YOUR-API- KEY", "London,UK");

            //Current Wetter
            Console.WriteLine("LON: {0}, LAT: {1}", weatherData.weatherCurrent.location.coord.lon, weatherData.weatherCurrent.location.coord.lat); //The coordinates of the weather
            Console.WriteLine("Current Temperture: {0} °C", weatherData.weatherCurrent.weather.temperatur); //Current temperature
            Console.WriteLine("description weather: {0}", weatherData.weatherCurrent.weather.description); //Description of current weather
            


            //weather forecasting next 5 Days in 3 hour steps
            double maxTemperatur = -999;
            DateTime date = new DateTime();
            foreach (WeatherAPI.Model.WeatherInNext5Days.Weather x in weatherData.weatherNext5Days.list){
               if(x.temperatur > maxTemperatur)
                {
                    maxTemperatur = x.temperatur;
                    date = x.dt;
                } 
            }

            Console.WriteLine("Maximum expected temperature in the next five days {0}°C at {1}", maxTemperatur, date.ToString());


            
            Console.ReadLine();
        }
    }
}
