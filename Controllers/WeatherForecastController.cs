using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using UserSecrets2.Models;

namespace UserSecrets2.Controllers
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
        private readonly IConfiguration _configuration;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        [HttpGet("GetAzureSecrets")]
        public string GetAzureSecrets()
        {
            //var connectionProducts = _configuration.GetConnectionString("ProductsDBConnection");
            //ProductsModel products = _configuration.GetSection("ConnectionStrings").Get<ProductsModel>();

            var userApiKey = _configuration["userKeyApi"];
            var connectionProducts = _configuration["ProductsDBConnection"];

            var value = $"[ProductsDBConnection] ={connectionProducts} -- [userApiKey]={userApiKey}";
            return value;
        }

        //[HttpGet("GetWeatherForecast")]

        [HttpGet]
        public String Get()
        {
            //var connectionProducts = _configuration.GetConnectionString("ProductsDBConnection");
            //ProductsModel products = _configuration.GetSection("ConnectionStrings").Get<ProductsModel>();

            var userApiKey = _configuration["userKeyApi"];
            var connectionProducts = _configuration["ProductsDBConnection"];

            var value = $"[ProductsDBConnection] ={connectionProducts} -- [userApiKey]={userApiKey}";
            return value;
        }

    }
}
