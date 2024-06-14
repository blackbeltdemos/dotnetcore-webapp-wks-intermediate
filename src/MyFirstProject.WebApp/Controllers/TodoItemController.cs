﻿using Microsoft.AspNetCore.Mvc;
using MyFirstProject.Shared.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MyFirstProject.WebApp.Controllers
{
    public class TodoItemController : Controller
    {
        private readonly ILogger<TodoItemController> _logger;
        private IConfiguration _configuration;

        public TodoItemController(ILogger<TodoItemController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                _logger.LogInformation("Controller:TodoItemController - Method:Index");

                List<TodoItem> lst = new List<TodoItem>();
                string _urlApi = string.Empty;

                using (var httpClient = new HttpClient())
                {
                    _urlApi = _configuration.GetSection("Api:Url").Value + "/api/TodoItem";
                    _logger.LogInformation("URL API = " + _urlApi);

                    using (var response = await httpClient.GetAsync( _urlApi))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        lst = JsonConvert.DeserializeObject<List<TodoItem>>(apiResponse);
                    }
                }

                _logger.LogInformation("Qtde: " + lst.Count().ToString());

                return View(lst);
            }
            catch (Exception ex)
            {
                _logger.LogError("ERROR: " + ex.Message);
                return Redirect("/Home/Error");
            }
        }
    }
}
