using Microsoft.AspNetCore.Mvc;
using MyFirstProject.Shared.Models;
using Newtonsoft.Json;

namespace MyFirstProject.WebApp.Controllers
{
    public class NYCrashController : Controller
    {
        private readonly ILogger<NYCrashController> _logger;
        private IConfiguration _configuration;

        public NYCrashController(ILogger<NYCrashController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                _logger.LogInformation("Controller:NYCrashController - Method:Index");

                List<NYCrashItem> lst = new List<NYCrashItem>();
                string _urlApi = string.Empty;

                using (var httpClient = new HttpClient())
                {
                    _urlApi = _configuration.GetSection("Api:Url").Value + "/api/NYCrash";
                    _logger.LogInformation("URL API = " + _urlApi);

                    using (var response = await httpClient.GetAsync(_urlApi))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        lst = JsonConvert.DeserializeObject<List<NYCrashItem>>(apiResponse);
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
