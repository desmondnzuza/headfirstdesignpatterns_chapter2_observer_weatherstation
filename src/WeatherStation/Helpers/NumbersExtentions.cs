using System.Collections.Generic;

namespace WeatherStation.Helpers
{
    internal static class NumbersExtentions
    {
        private static bool HasHistory(List<float> numbers)
        {
            return numbers != null && numbers.Count > 1;
        }

        internal static float Previous(this List<float> numbers, float defaultValue = 0)
        {
            if (HasHistory(numbers))
            {
                return numbers[numbers.Count - 2];
            }

            return defaultValue;
        }
    }
}
