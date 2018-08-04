using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI.Model.Base
{
    //Lokalisation
        //Coord
        //Ortschaft
        //Land
    //Wetter
        //ID
        //main (Rain, Snow, Extreme etc.)
        //Beschreibung
        //icon
        

    public class Coord
    {
        public double lon { get; set; }//
        public double lat { get; set; }//
    }
    public class Wind
    {
        public double speed { get; set; }//
        public double deg { get; set; }//
    }
    public abstract class Weather
    {
        public int id { get; set; }//
        public string main { get; set; }//
        public string description { get; set; }//
        public string icon { get; set; }//
        public double temperatur { get; set; }//
        public double pressure { get; set; }//
        public int humidity { get; set; }//
        public double temperatur_min { get; set; }//
        public double temperatur_max { get; set; }//
        public Wind wind = new Wind();
        public double clouds { get; set; }//



        public DateTime dt { get; set; }//Zeit der Wetterdaten

        public override string ToString()
        {
            string temp = "";
            temp += "\nWheather ID: " + id;
            temp += "\nKind of wheather: " + main;
            temp += "\nDescripton: " + description;
            temp += "\nIconID: " + icon;
            temp += "\nTemperatur: " + this.temperatur + "°C";
            temp += "\nPressure: " + pressure + "hPA" ;
            temp += "\nHumidity: " + humidity + "%";
            temp += "\nMax. Temperture: " + temperatur_max;
            temp += "\nMin. Temperture: " + temperatur_min;
            temp += "\nWind Speed: " + wind.speed;
            temp += "\nWind Deg.:" + wind.deg+"°";
            temp += "\nClouds: " + clouds;

            temp += "\nTime of Wheaterdata: " + dt;

            return temp;

        }
    }

    public abstract class Location
    {
        public Coord coord = new Coord();
        public string nameCountry { get; set; }//UK
        public int idCity { get; set; }
        public string nameLocality { get; set; }//London

        public override string ToString()
        {
            string temp =  base.ToString();
            temp += "\nlon: " + coord.lon + "°";
            temp += "\nlat: " + coord.lat + "°";
            temp += "\nCountry: " + nameCountry;
            temp += "\nCity ID: " + idCity;
            temp += "\nLocality: " + nameLocality;

            return temp;
        }

    }

    class WeatherMain
    {
    }
}
/*
 * 
 * coord
        coord.lon City geo location, longitude
        coord.lat City geo location, latitude
weather (more info Weather condition codes)
        weather.id Weather condition id
        weather.main Group of weather parameters (Rain, Snow, Extreme etc.)
        weather.description Weather condition within the group
        weather.icon Weather icon id
        base Internal parameter
main
        main.temp Temperature. Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        main.pressure Atmospheric pressure (on the sea level, if there is no sea_level or grnd_level data), hPa
        main.humidity Humidity, %
        main.temp_min Minimum temperature at the moment. This is deviation from current temp that is possible for large cities and megalopolises geographically expanded (use these parameter optionally). Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        main.temp_max Maximum temperature at the moment. This is deviation from current temp that is possible for large cities and megalopolises geographically expanded (use these parameter optionally). Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        main.sea_level Atmospheric pressure on the sea level, hPa
        main.grnd_level Atmospheric pressure on the ground level, hPa
wind
        wind.speed Wind speed. Unit Default: meter/sec, Metric: meter/sec, Imperial: miles/hour.
        wind.deg Wind direction, degrees (meteorological)
clouds
        clouds.all Cloudiness, %
rain
        rain.3h Rain volume for the last 3 hours
snow
        snow.3h Snow volume for the last 3 hours
dt Time of data calculation, unix, UTC
sys
        sys.type Internal parameter
        sys.id Internal parameter
        sys.message Internal parameter
        sys.country Country code (GB, JP etc.)
        sys.sunrise Sunrise time, unix, UTC
        sys.sunset Sunset time, unix, UTC
        id City ID
        name City name
        cod Internal parameter
 */
