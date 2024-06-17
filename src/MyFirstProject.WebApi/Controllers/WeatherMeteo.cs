using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyFirstProject.WebApi.Context;
using MyFirstProject.Shared.Models;
using MyFirstProject.WebApi.Repository;
using MyFirstProject.Shared.Model;

namespace MyFirstProject.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherMeteoController : ControllerBase, IWeatherMeteo
    {
        private readonly ILogger<WeatherMeteoController> _logger;
        private readonly IWeatherMeteo _repository;


        public WeatherMeteoController(ILogger<WeatherMeteoController> logger, IWeatherMeteo repository)
        {
            //testes
            _logger = logger;
            _repository = repository;
        }


        [HttpGet]
        public async Task<WeatherMeteoItem> GetWeatherMeteoItems()
        {
            return await _repository.GetWeatherMeteoItems();
        }
    }
}
