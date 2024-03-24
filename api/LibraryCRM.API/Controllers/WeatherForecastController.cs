using LibraryCRM.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibraryCRM.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost("/generate")]
        public async Task<IActionResult> GenrateWeather([FromQuery] int resultsCount, [FromBody] TemperatureRequest request)
        {
            if (request.Min > request.Max)
            {
                return BadRequest();
            }

            if (resultsCount < 0)
            {
                return BadRequest();
            }

            var result = Enumerable.Range(1, resultsCount).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(request.Min, request.Max),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();

            return Ok(result);
        }
    }
}
