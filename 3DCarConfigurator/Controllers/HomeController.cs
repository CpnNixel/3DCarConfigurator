using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _3DCarConfigurator.Models;
using _3DCarConfigurator.Services;

namespace _3DCarConfigurator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Car> _carsRepo;

        public HomeController(ILogger<HomeController> logger, IRepository<Car> car)
        {
            _logger = logger;
            _carsRepo = car;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Topcars()
        {
            
            return View(new Car()
            {
                Id = 1,
                Name = "dasdsa"

            });
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
