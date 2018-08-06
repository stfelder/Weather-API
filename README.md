# Weather-API

The «WeahterAPI» allows a simple implementation of «openweathermap.org». The following has been implemented:
+ Current weather data
+ 5 day / 3 hour forecast

The data structure is slightly adapted in my API, but the names are identical to those of openweathermap.org. Therefore, you can take the meaning of each variable from the API of openweathermap.org.
Details about the API of openweathermap.org can be found here:
+ Current weather data -> https://openweathermap.org/current
+ 5 day / 3 hour forecast -> https://openweathermap.org/forecast5


To use the API you need an API key. For this purpose you have to register at openweathermap.org.

### Sampel
You can find a quick example in the folder "DemoWeatherAPI", but still here are the most important instructions:
Initialize the API with your API key and a location from which you want to have the weather data:
```csharp
WeatherDataManager weatherData = new WeatherDataManager("API-KEY", "London,UK");
```
The coordinates from the specified location:
```csharp
Console.WriteLine("LON: {0}, LAT: {1}", weatherData.weatherCurrent.location.coord.lon, weatherData.weatherCurrent.location.coord.lat);
```
Some weather data:
```csharp
Console.WriteLine("Current Temperture: {0} °C", weatherData.weatherCurrent.weather.temperatur); //Current temperature
Console.WriteLine("description weather: {0}", weatherData.weatherCurrent.weather.description); //Description of current weather
```
weather forecasting next 5 Days in 3 hour steps:
```csharp
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
```