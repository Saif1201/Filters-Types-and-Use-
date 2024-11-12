using FilterPractice.Filters;
using FilterPractice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FilterPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [TypeFilter(typeof(EmployeeListActionFilter))]
        public IActionResult Index()
        {
            return View();
        }

        [TypeFilter(typeof(MyResultFilter))]
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
