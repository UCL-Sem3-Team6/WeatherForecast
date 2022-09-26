using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using WeatherForecast.Models;

namespace WeatherForecast.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using (HttpClient client = new HttpClient())
            {
                string URL = "http://api.openweathermap.org/data/2.5/forecast?q=Odense,DK&cnt=8&appid=f1cee7f9e0458329352f11617b9d5bb2";
                var json = client.GetFromJsonAsync<WeatherInfo.Root>(URL);
                var result = JsonConvert.DeserializeObject<WeatherInfo.Root>(json);

                WeatherInfo.Root output = result;
                return Ok(output);
            }

            //HttpClient client = new HttpClient();
            //string URL = "http://api.openweathermap.org/data/2.5/forecast?q=Odense,DK&cnt=8&appid=f1cee7f9e0458329352f11617b9d5bb2";
            //var result = client.GetFromJsonAsync<Root>(URL);
            //return View(result.Result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}