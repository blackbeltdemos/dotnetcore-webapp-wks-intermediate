using Microsoft.AspNetCore.Mvc;
using MyFirstProject.Shared.Model;
using Newtonsoft.Json;

namespace MyFirstProject.WebApi.Repository
{
    public class WeatherMeteoRepository : IWeatherMeteo
    {
        private readonly HttpClient _client;

        public WeatherMeteoRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<WeatherMeteoItem> GetWeatherMeteoItems()
        {
            var response = await _client.GetAsync("https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&current=temperature_2m,wind_speed_10m&hourly=temperature_2m,relative_humidity_2m,wind_speed_10m");
            var content = await response.Content.ReadAsStringAsync();
            var weatherMeteo = JsonConvert.DeserializeObject<WeatherMeteoItem>(content);
            return weatherMeteo;
        }

    }
}
