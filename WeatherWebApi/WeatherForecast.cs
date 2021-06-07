using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherWebApi
{
	public class WeatherForecast
	{
		public List<Values> List { get; private set; }

		public WeatherForecast()
		{
			List = new List<Values>();
		}

		internal void AddValues(DateTime time, int temperature)
		{
			if (List != null && !List.Contains(new Values { Temperature = temperature, Time = time }))
			{
				List.Add(new Values { Temperature = temperature, Time = time });
				List.Sort(((values, values1) => values.Time.CompareTo(values1.Time)));
			}
		}

		internal void ChangeValues(DateTime time, int temperature)
			=> List = List.Select(s =>
				{
					if (s.Time == time)
					{
						s.Temperature = temperature;
					}

					return s;
				}).ToList();

		internal void DeleteRangeTimeWithTemperatures(DateTime lowTime, DateTime upTime)
			=> List = List.Where(values => values.Time < lowTime || values.Time > upTime).ToList();
		

		internal IEnumerable<Values> ReadRangeTimeWithTemperature(DateTime lowTime, DateTime upTime)
			=> List.Where(values => values.Time >= lowTime && values.Time <= upTime);
	}
}
