using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherWebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly WeatherForecast _forecast;
		private const string MessageError = "Неверно были заданы границы временного интервала! Повторите запрос";

		public WeatherForecastController(WeatherForecast forecast) => _forecast = forecast;

		[HttpPost("create")]
		public IActionResult AddTemperature([FromQuery] DateTime time, [FromQuery] int temperature)
		{
			_forecast.AddValues(time, temperature);
			return Ok(_forecast.ListTemperaturesTime);
		}

		[HttpPut("edit")]
		public IActionResult ChangeTheTemperatureOverTime([FromQuery] DateTime time, [FromQuery] int temperature)
		{
			_forecast.ChangeValues(time, temperature);
			return Ok(_forecast.ListTemperaturesTime);
		}

		[HttpDelete("delete")]
		public IActionResult DeleteTemperature([FromQuery] DateTime lowTime, [FromQuery] DateTime upTime)
		{
			if (lowTime > upTime)
			{
				return Ok(MessageError);
			}

			_forecast.DeleteRangeTimeWithTemperatures(lowTime, upTime);
			return Ok(_forecast.ListTemperaturesTime);
		}

		[HttpGet("read")]
		public IActionResult Read([FromQuery] DateTime lowTime, [FromQuery] DateTime upTime)
		{
			if (lowTime > upTime)
			{
				return Ok(MessageError);
			}

			return Ok(_forecast.ReadRangeTimeWithTemperature(lowTime, upTime));
		}
	}
}
