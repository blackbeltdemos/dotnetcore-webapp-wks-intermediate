using Microsoft.AspNetCore.Mvc;
using MyFirstProject.Shared.Model;

namespace MyFirstProject.WebApi.Repository
{
  
public interface IWeatherMeteo
    {
        Task<WeatherMeteoItem> GetWeatherMeteoItems();
    }
}
