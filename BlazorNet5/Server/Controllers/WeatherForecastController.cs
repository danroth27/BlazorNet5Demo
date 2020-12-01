using BlazorNet5.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorNet5.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public async Task<ActionResult<WeatherForecast[]>> Get(int daysFromNow, int count)
        {
            if (daysFromNow + count > 10000)
            {
                return BadRequest("The weather can only be predicted 10,000 days in the future!");
            }
            return await _weatherForecastService.GetForecastAsync(daysFromNow, count);
        }
    }
}
