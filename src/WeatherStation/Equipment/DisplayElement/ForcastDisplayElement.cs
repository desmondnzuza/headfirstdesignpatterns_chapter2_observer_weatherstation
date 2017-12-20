using System;
using System.Collections.Generic;
using System.Linq;
using WeatherStation.Helpers;
using WeatherStation.Observer;
using WeatherStation.Subject;

namespace WeatherStation.Equipment.DisplayElement
{
    public class ForcastDisplayElement : IObserver, IDisplayElement
    {
        private ISubject _subject;
        private readonly List<float> _pressureHistory;


        public ForcastDisplayElement(ISubject subject)
        {
            _subject         = subject;
            _pressureHistory = new List<float>();

            subject.RegisterObserver(this);
        }

        public void Update(float temp, float humidity, float pressure)
        {
            _pressureHistory.Add(pressure);
            this.Display();
        }

        public void Display()
        {
            var message = GenerateMessage();

            Console.WriteLine($"ForcastDisplayElement : {message}");
        }

        private string GenerateMessage()
        {
            var previouse = _pressureHistory.HasHistory() ? _pressureHistory.Previous() : 0;
            var current   = _pressureHistory.Last();

            if (current > previouse)
            {
                return "It's getting hot";
            }

            if (current < previouse)
            {
                return "It's getting colder";
            }

            return "More of the same";
        }
    }
}
