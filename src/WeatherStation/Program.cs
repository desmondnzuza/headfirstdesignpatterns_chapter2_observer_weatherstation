using System;
using System.Collections.Generic;
using WeatherStation.Equipment.DisplayElement;
using WeatherStation.Observer;
using WeatherStation.Subject;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            var endProgram = false;
            var weatherData = new WeatherData();
            var displays = new Dictionary<string, IObserver>()
            {
                { "1", new CurrentConditionsDisplayElement(weatherData) },
                { "2", new ForcastDisplayElement(weatherData) },
                { "3", new StatisticsDisplayElement(weatherData) }
            };

            KickOffStation(weatherData);

            do
            {
                Console.WriteLine("What do you want to do? 1) Update Measurements 2) Subscribe 3) UnSubscribe 4)Refesh");
                var answer = Console.ReadLine();

                if (answer == "1")
                {
                    Console.WriteLine("Enter New Measurements([temp], [humidity], [pressure])");
                    var newMeasurementsRaw = Console.ReadLine();
                    var newMeasurements = newMeasurementsRaw.Split(",");

                    weatherData.SetMeasurements(int.Parse(newMeasurements[0]), int.Parse(newMeasurements[1]), int.Parse(newMeasurements[2]));
                }
                else if (answer == "2")
                {
                    Console.WriteLine("What do want to subscribe? 1)CurrentConditions 2)ForeCast 3)Stats");
                    var candidate = Console.ReadLine();

                    weatherData.RegisterObserver(displays[candidate]);
                }
                else if (answer == "3")
                {
                    Console.WriteLine("What do want to unsubscribe? 1)CurrentConditions 2)ForeCast 3)Stats");
                    var candidate = Console.ReadLine();
                    
                    weatherData.RemoveObserver(displays[candidate]);
                }
                else if (answer == "4")
                {
                    weatherData.MeausreMentsChanged();
                }
                else
                {
                    endProgram = true;
                }

            } while (!endProgram);

            Console.WriteLine("press any key to exit");
            Console.ReadLine();
        }

        private static void KickOffStation(WeatherData weatherData)
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("*****************Kick-OFF*************************");
            Console.WriteLine("**************************************************");
            weatherData.SetMeasurements(80, 50, 30.4f);
            Console.WriteLine();
            weatherData.SetMeasurements(82, 60, 29.2f);
            Console.WriteLine();
            weatherData.SetMeasurements(78, 60, 29.2f);
            Console.WriteLine();
            Console.WriteLine("**************************************************");
            Console.WriteLine("*****************Kick-OFF-Complete*****************");
            Console.WriteLine("**************************************************");
        }
    }
}
