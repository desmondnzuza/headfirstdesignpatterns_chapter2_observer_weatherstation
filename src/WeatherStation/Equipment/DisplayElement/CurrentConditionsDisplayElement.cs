using System;
using WeatherStation.Observer;
using WeatherStation.Subject;

namespace WeatherStation.Equipment.DisplayElement
{
    public class CurrentConditionsDisplayElement : IObserver, IDisplayElement
    {
        private float _temp;
        private float _humidity;

        private ISubject _subject;

        public CurrentConditionsDisplayElement(ISubject subject)
        {
            _subject = subject;
            subject.RegisterObserver(this);
        }

        public void Update(float temp, float humidity, float pressure)
        {
            _temp = temp;
            _humidity = humidity;

            this.Display();
        }

        public void Display()
        {
            Console.WriteLine($"Current Condition : {_temp }F degrees and {_humidity} humidity");
        }
    }
}
