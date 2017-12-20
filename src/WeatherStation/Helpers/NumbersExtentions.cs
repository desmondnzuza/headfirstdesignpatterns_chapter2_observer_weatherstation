using System.Collections.Generic;

namespace WeatherStation.Helpers
{
    internal static class NumbersExtentions
    {
        internal static bool HasHistory(this List<float> numbers)
        {
            return numbers.Count > 1;
        }

        internal static float Previous(this List<float> numbers)
        {
            return numbers[numbers.Count - 2];
        }
    }
}
