using Lesson35.Classwork.Models;
using Lesson35.Classwork.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lesson35.Classwork.Controllers
{
    [LoggingFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
                
        public IActionResult Index()
        {
            Console.WriteLine("LOG FROM CONTROLLER!");
            Console.WriteLine(HttpContext.Items["MyData"]);
            return View();
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