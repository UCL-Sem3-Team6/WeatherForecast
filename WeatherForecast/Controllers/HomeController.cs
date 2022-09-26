using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
            HttpClient client = new HttpClient();
            string URL = "http://api.openweathermap.org/data/2.5/forecast?lat=44.34&lon=10.99&appid=3ac5b1a92ec7eaef083239fbd5ecedb8";
            var result = client.GetFromJsonAsync<Root>(URL);
            return View(result.Result);
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