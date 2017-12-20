using System;
using System.Collections.Generic;
using System.Linq;
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
            _subject = subject;
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
            var prev = _pressureHistory.Count() > 1 ? _pressureHistory[_pressureHistory.Count - 2] : 0;
            var current = _pressureHistory.Last();
            var message = string.Empty;

            if (current > prev)
            {
                message = "It's getting hot";
            }
            else if (current == prev)
            {
                message = "More of the same";
            }
            else if (current < prev)
            {
                message = "It's getting colder";
            }


            Console.WriteLine($"ForcastDisplayElement : {message}");
        }
    }
}
