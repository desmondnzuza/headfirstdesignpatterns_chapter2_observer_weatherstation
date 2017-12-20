using System;
using WeatherStation.Equipment.DisplayElement;
using WeatherStation.Subject;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            var weatherData = new WeatherData();
            var currentConditionsDisplay = new CurrentConditionsDisplayElement(weatherData);
            var forecastDisplay = new ForcastDisplayElement(weatherData);
            var statsDisplay = new StatisticsDisplayElement(weatherData);

            weatherData.SetMeasurements(80, 50, 30.4f);
            Console.WriteLine();
            weatherData.SetMeasurements(82, 60, 29.2f);
            Console.WriteLine();
            weatherData.SetMeasurements(78, 60, 29.2f);
            Console.WriteLine();
            Console.WriteLine("**************************************************");

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
