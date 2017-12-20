using System.Collections.Generic;
using WeatherStation.Observer;

namespace WeatherStation.Subject
{
    public class WeatherData : ISubject
    {
        private readonly List<IObserver> _observers;
        private float _temp;
        private float _humidity;
        private float _pressure;

        public WeatherData()
        {
            _observers = new List<IObserver>();
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_temp, _humidity, _pressure);
            }
        }

        public void RegisterObserver(IObserver o)
        {
            _observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            if (_observers.Contains(o))
            {
                _observers.Remove(o);
            }
        }

        public void MeausreMentsChanged()
        {
            this.NotifyObservers();
        }

        public void SetMeasurements(float temp, float humidiy, float pressure)
        {
            _temp = temp;
            _humidity = humidiy;
            _pressure = pressure;

            this.MeausreMentsChanged();

        }
    }
}
