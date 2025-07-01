using Contracts.Logger;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_OnionArchitecture.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
  
        private readonly ILoggerManager _loggerManager;

        public WeatherForecastController( ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            //test logging
            _loggerManager.LogInfo("Try to log");
            _loggerManager.LogError("Error");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
