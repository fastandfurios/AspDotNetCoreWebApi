using System;
using System.Collections.Generic;

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

		public WeatherForecast() => _temperatures = new SortedDictionary<DateTime, int>();

		internal void ChangeDictionary(DateTime time, int temperature)
		{
			var changeDictionary = new SortedDictionary<DateTime, int>();

			foreach (var valuePair in _temperatures)
			{
				changeDictionary.Add(valuePair.Key, valuePair.Key == time ? temperature : valuePair.Value);
			}

			_temperatures.Clear();
			_temperatures = changeDictionary;
		}

		internal void DeleteRangeTimeWithTemperatures(DateTime lowTime, DateTime upTime)
		{
			var newDictionary = new SortedDictionary<DateTime, int>();

			foreach (var pair in _temperatures)
			{
				if (pair.Key < lowTime)
				{
					newDictionary.Add(pair.Key, pair.Value);
				}

				if (pair.Key > upTime)
				{
					newDictionary.Add(pair.Key, pair.Value);
				}
			}

			_temperatures.Clear();
			_temperatures = newDictionary;
		}

		internal SortedDictionary<DateTime, int> ReadRangeTimeWithTemperature(DateTime lowTime, DateTime upTime)
		{
			var newDictionary = new SortedDictionary<DateTime, int>();

			foreach (var pair in _temperatures)
			{
				if (pair.Key >= lowTime && pair.Key <= upTime)
				{
					newDictionary.Add(pair.Key, pair.Value);
				}
			}

			return newDictionary;
		}
	}
}
