using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HowsTheWeatherOutThereWebApi.Models;

namespace HowsTheWeatherOutThereWebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly WeatherForecast _forecast;

		public WeatherForecastController(WeatherForecast forecast) => _forecast = forecast;

		[HttpPost("create")]
		public IActionResult AddTemperature([FromQuery] string time, [FromQuery] int temperature)
		{
			if (_forecast.Temperatures != null && !_forecast.Temperatures.ContainsKey(time))
			{
				_forecast.Temperatures.Add(time, temperature);
			}

			return Ok(_forecast.Temperatures);
		}

		[HttpPut("edit")]
		public IActionResult ChangeTheTemperatureOverTime([FromQuery] string time, [FromQuery] int newValueTemperature)
		{
			_forecast.ChangeDictionary(time, newValueTemperature);
			return Ok(_forecast.Temperatures);
		}

		[HttpDelete("delete")]
		public IActionResult DeleteTemperature([FromQuery] string time)
		{
			_forecast.Temperatures.Remove(time);
			return Ok(_forecast.Temperatures);
		}

		[HttpGet("read")]
		public IActionResult Read([FromQuery] string lowTime, [FromQuery] string upTime)
			 => Ok(_forecast.ReadRangeTimeWithTemperature(lowTime, upTime));

	}
}
