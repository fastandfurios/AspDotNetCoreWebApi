using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherWebApi
{
	public class WeatherForecast
	{
		public List<Values> ListTemperaturesTime { get; private set; }

		public WeatherForecast()
		{
			ListTemperaturesTime = new List<Values>();
		}

		internal void AddValues(DateTime time, int temperature)
		{
			if (ListTemperaturesTime != null && !ListTemperaturesTime.Contains(new Values { Temperature = temperature, Time = time }))
			{
				ListTemperaturesTime.Add(new Values { Temperature = temperature, Time = time });
				ListTemperaturesTime.Sort(((values, values1) => values.Time.CompareTo(values1.Time)));
			}
		}

		internal void ChangeValues(DateTime time, int temperature)
			=> ListTemperaturesTime = ListTemperaturesTime.Select(s =>
				{
					if (s.Time == time)
					{
						s.Temperature = temperature;
					}

					return s;
				}).ToList();

		internal void DeleteRangeTimeWithTemperatures(DateTime lowTime, DateTime upTime)
			=> ListTemperaturesTime = ListTemperaturesTime.Where(values => values.Time < lowTime || values.Time > upTime).ToList();
		

		internal IEnumerable<Values> ReadRangeTimeWithTemperature(DateTime lowTime, DateTime upTime)
			=> ListTemperaturesTime.Where(values => values.Time >= lowTime && values.Time <= upTime);
	}
}
