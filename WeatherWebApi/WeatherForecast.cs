using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherWebApi
{
	public class WeatherForecast
	{
		private SortedDictionary<DateTime, int> _temperatures;
		public SortedDictionary<DateTime, int> Temperatures
		{
			get => _temperatures;
			set => value = _temperatures;
		}

		public WeatherForecast()
		{
			_temperatures = new SortedDictionary<DateTime, int>();
		}

		internal void DeleteRangeTimeWithTemperatures(DateTime lowTime, DateTime upTime)
		{
			var newDictionary = new SortedDictionary<DateTime, int>();

			foreach (var pair in _temperatures)
			{
				if (pair.Key < lowTime || pair.Key > upTime)
				{
					newDictionary.Add(pair.Key, pair.Value);
				}
			}

			_temperatures.Clear();
			_temperatures = newDictionary;
		}

		internal IEnumerable<KeyValuePair<DateTime, int>> ReadRangeTimeWithTemperature(DateTime lowTime, DateTime upTime)
			=> _temperatures.Where(pair => pair.Key >= lowTime && pair.Key <= upTime);
	}
}
