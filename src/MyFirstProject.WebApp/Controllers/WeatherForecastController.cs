﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyFirstProject.Shared.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MyFirstProject.WebApp.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _config;
        private static readonly HttpClient client = new HttpClient();

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration config)
        {
            _config = config;
            _logger = logger;
        }

        // GET: WeatherForecastController
        public async Task<IActionResult> Index()
        {
            try
            {
                _logger.LogInformation("WeatherForecast Page");

                List<WeatherForecastItem> lst = new List<WeatherForecastItem>();

                using (var httpClient = new HttpClient())
                {
                    string _urlApi = _config.GetSection("Api:Url").Value;
                    _logger.LogInformation("URL API = " + _urlApi);

                    httpClient.BaseAddress = new Uri(_urlApi);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync("/api/WeatherForecast"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        lst = JsonConvert.DeserializeObject<List<WeatherForecastItem>>(apiResponse);
                    }
                }
                return View(lst);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on WeatherForecast Page");
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: WeatherForecastController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WeatherForecastController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeatherForecastController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WeatherForecastController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WeatherForecastController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WeatherForecastController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WeatherForecastController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
