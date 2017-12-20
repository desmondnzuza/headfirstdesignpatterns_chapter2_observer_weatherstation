using System;
using System.Collections.Generic;
using System.Linq;
using WeatherStation.Observer;
using WeatherStation.Subject;

namespace WeatherStation.Equipment.DisplayElement
{
    public class StatisticsDisplayElement : IObserver, IDisplayElement
    {
        private ISubject _subject;
        private readonly List<float> _temparatureHistory;

        public StatisticsDisplayElement(ISubject subject)
        {
            _subject = subject;
            _temparatureHistory = new List<float>();
            
           subject.RegisterObserver(this);
        }

        public void Update(float temp, float humidity, float pressure)
        {
            _temparatureHistory.Add(temp);
            this.Display();
        }

        public void Display()
        {
            var avg = _temparatureHistory.Average();
            var max = _temparatureHistory.Max();
            var min = _temparatureHistory.Min();
            Console.WriteLine($"Avg/Max/Min temperature = {avg}/{max}/{min}");
        }
    }
}
