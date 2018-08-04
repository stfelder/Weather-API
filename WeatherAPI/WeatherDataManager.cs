using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


//Wetter2228899
            //https://openweathermap.org/weather-conditions
            //https://openweathermap.org/weather-data
//Calling API http://openweathermap.org/api */
namespace WeatherAPI
{
    public class WeatherDataManager
    {
        string apiKey { get; set; }
        string city { get; set; }
        public Model.WeahterCurrent.WeatherModelCurn weatherCurrent = new Model.WeahterCurrent.WeatherModelCurn();
        public Model.WeatherInNext5Days.weatherInNext5Days weatherNext5Days = new Model.WeatherInNext5Days.weatherInNext5Days();
        public List<Model.WeatherInNext5Days.Weather> list = new List<Model.WeatherInNext5Days.Weather>();
        //public DateTime dt = new DateTime();

        //public WeatherDataManager() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="city"></param>
        public WeatherDataManager(string apiKey, string city)
        {
            this.apiKey = apiKey;
            this.city = city;
            updateWeatherCurrent();
            updateWheatherNext5Days();
        }
        public void updateWeatherCurrent()
        {

            HttpWebRequest apiRequest = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=" + apiKey + "&units=metric") as HttpWebRequest;

            string apiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }

            Model.WeahterCurrent.JSONHelper.RootObject rootObject = JsonConvert.DeserializeObject<Model.WeahterCurrent.JSONHelper.RootObject>(apiResponse);
            //Cord
            weatherCurrent.location.coord.lat = rootObject.coord.lat;
            weatherCurrent.location.coord.lon = rootObject.coord.lon;
            weatherCurrent.location.nameCountry =  rootObject.sys.country;
            weatherCurrent.location.idCity = rootObject.id;//City ID
            weatherCurrent.location.nameLocality = rootObject.name; //Name Ortschaft

            //Wheather
            weatherCurrent.weather.description = rootObject.weather[0].description;
            weatherCurrent.weather.icon = rootObject.weather[0].icon;
            weatherCurrent.weather.id = rootObject.weather[0].id;
            weatherCurrent.weather.main = rootObject.weather[0].main;
            weatherCurrent.weather.clouds = rootObject.clouds.all;
            weatherCurrent.weather.humidity = rootObject.main.humidity;
            weatherCurrent.weather.pressure = rootObject.main.pressure;
            weatherCurrent.weather.temperatur = rootObject.main.temp;
            weatherCurrent.weather.temperatur_max = rootObject.main.temp_max;
            weatherCurrent.weather.temperatur_min = rootObject.main.temp_min;
            weatherCurrent.weather.wind.deg = rootObject.wind.deg;
            weatherCurrent.weather.wind.speed = rootObject.wind.speed;
            weatherCurrent.weather.sunrise = UnixTimeStampToDateTime(rootObject.sys.sunrise);
            weatherCurrent.weather.sunset = UnixTimeStampToDateTime(rootObject.sys.sunset);
            weatherCurrent.weather.visibilityMeter = rootObject.visibility;
            weatherCurrent.weather.dt = UnixTimeStampToDateTime(rootObject.dt); // Zeit der Wetterdateb
        }

        public void updateWheatherNext5Days()
        {


            //https://openweathermap.org/weather-conditions
            //https://openweathermap.org/weather-data
            //http://openweathermap.org/api


            HttpWebRequest apiRequest = WebRequest.Create("http://api.openweathermap.org/data/2.5/forecast?q=" + city + "&appid=" + apiKey + "&units=metric") as HttpWebRequest;
            string apiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }




            Model.WeatherInNext5Days.JSONHelper.RootObject rootObject = JsonConvert.DeserializeObject<Model.WeatherInNext5Days.JSONHelper.RootObject>(apiResponse);
            //wheathercur
            //Location
            weatherNext5Days.location.coord.lat = rootObject.city.coord.lat;
            weatherNext5Days.location.coord.lon = rootObject.city.coord.lon;
            weatherNext5Days.location.nameCountry = rootObject.city.country;
            weatherNext5Days.location.idCity = rootObject.city.id;//City ID
            weatherNext5Days.location.nameLocality = rootObject.city.name;  //Name Ortschaft

            foreach (Model.WeatherInNext5Days.JSONHelper.List x in rootObject.list)
            { 
            Model.WeatherInNext5Days.Weather weather = new Model.WeatherInNext5Days.Weather();
                weather.clouds = x.clouds.all;
                weather.description = x.weather[0].description;
                weather.icon = x.weather[0].icon;
                weather.id = x.weather[0].id;
                weather.main = x.weather[0].main;
                weather.clouds = x.clouds.all;
                weather.humidity = x.main.humidity;
                weather.pressure = x.main.pressure;
                weather.temperatur = x.main.temp;
                weather.temperatur_max = x.main.temp_max;
                weather.temperatur_min = x.main.temp_min;
                weather.wind.deg =x.wind.deg;
                weather.wind.speed = x.wind.speed;
                weather.dt = UnixTimeStampToDateTime(x.dt);

                weatherNext5Days.list.Add(weather);
            }
        


            double maxSpeed = 0;
            string maxSpeedTime = "";

            

        }

        public override string ToString()
        {
            string temp = weatherCurrent.location.ToString();
            temp += "\n" + weatherCurrent.weather.ToString();
            return temp;
        }

        /// <summary>
        /// Konvertiert eine UNIX Zeitstempel in eine C# «DataTime» Objekt.
        /// Converts a UNIX timestamp to a "C# DataTime" object.
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public string getCurrentWeatherAsJSON()
        {
            /*Calling API http://openweathermap.org/api */

            HttpWebRequest apiRequest = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=" + apiKey + "&units=metric") as HttpWebRequest;

            string apiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }

            Model.WeahterCurrent.JSONHelper.RootObject rootObject = JsonConvert.DeserializeObject<Model.WeahterCurrent.JSONHelper.RootObject>(apiResponse);

            return apiResponse;
        }
    }
}
