﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //Aufrufende URL: https://localhost:5001/api/WeatherForecast
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



        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("{city}")]
        public WeatherForecast Get(string city)
        {
            if (!string.Equals(city?.TrimEnd(), "Redmond", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    $"we dont offer a weather forecast for {city}.", nameof(city));
            }

            return Get().First();
        }


        [HttpGet("error")]
        public IActionResult GetError() //Beispiel Referenz -> https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/web-api/advanced/formatting/5.0samples/WebAPI5PascalCase
        {
            return Problem("Something went wrong!");
        } //RFC 7807 -> https://tools.ietf.org/html/rfc7807#appendix-A
    }
}
