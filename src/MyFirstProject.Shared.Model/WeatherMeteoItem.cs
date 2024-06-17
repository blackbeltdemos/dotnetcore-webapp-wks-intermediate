using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyFirstProject.Shared.Model
{
    //Montar o model com base na API
    // https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&current=temperature_2m,wind_speed_10m&hourly=temperature_2m,relative_humidity_2m,wind_speed_10m
    public class WeatherMeteoItem
    {

        public double latitude { get; set; }
        public double longitude { get; set; }

        [JsonPropertyName("generationtime_ms")]
        public double generationtime_ms { get; set; }

        [JsonPropertyName("utc_offset_seconds")]
        public int utc_offset_seconds { get; set; }

        public string timezone { get; set; }

        [JsonPropertyName("timezone_abbreviation")]
        public string timezone_abbreviation { get; set; }

        public long elevation { get; set; }

        [JsonPropertyName("current_units")]
        public Units current_units { get; set; }

        public CurrentWeather current { get; set; }

        [JsonPropertyName("hourly_units")]
        public Units hourly_units { get; set; }

        public HourlyForecast hourly { get; set; }
    }

    public class Units
    {
        public string time { get; set; }
        public string interval { get; set; }

        [JsonPropertyName("temperature_2m")]
        public string temperature_2m { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public string wind_speed_10m { get; set; }

        [JsonPropertyName("relative_humidity_2m")]
        public string relative_humidity_2m { get; set; } // Only in hourly_units
    }

    public class CurrentWeather
    {
        public string time { get; set; }
        public int interval { get; set; }

        [JsonPropertyName("temperature_2m")]
        public double temperature_2m { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public double wind_speed_10m { get; set; }
    }

    public class HourlyForecast
    {
        public List<string> time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public List<double> temperature_2m { get; set; }

        [JsonPropertyName("relative_humidity_2m")]
        public List<int> relative_humidity_2m { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public List<double> wind_speed_10m { get; set; }


    }
}
