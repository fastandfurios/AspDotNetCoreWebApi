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
	}
}
