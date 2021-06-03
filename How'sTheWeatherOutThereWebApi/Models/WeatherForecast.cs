using System;
using System.Collections.Generic;
using System.Linq;

namespace HowsTheWeatherOutThereWebApi.Models
{
	public class WeatherForecast
	{
		private Dictionary<string, int> _temperatures;
		public Dictionary<string, int> Temperatures
		{
			get => _temperatures;
			set => value = _temperatures;
		}

		public WeatherForecast() => _temperatures = new Dictionary<string, int>();

		internal void ChangeDictionary(string time, int newValueTemperature)
		{
			var changeDictionary = new Dictionary<string, int>();

			foreach (var valuePair in _temperatures)
			{
				changeDictionary.Add(valuePair.Key, valuePair.Key == time ? newValueTemperature : valuePair.Value);
			}

			_temperatures.Clear();
			_temperatures = changeDictionary;
		}

		internal Dictionary<string, int> ReadRangeTimeWithTemperature(string lowTime, string upTime)
		{
			var newDictionary = new Dictionary<string, int>();

			foreach (var pair in _temperatures)
			{
				if (pair.Key.Equals(upTime))
				{
					newDictionary.Add(pair.Key, pair.Value);
					break;
				}

				newDictionary.Add(pair.Key, pair.Value);
			}

			foreach (var pair in newDictionary)
			{
				if (pair.Key.Equals(lowTime))
				{
					break;
				}

				newDictionary.Remove(pair.Key);
			}

			return newDictionary;
		}
	}
}
