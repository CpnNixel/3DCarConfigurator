using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _3DCarConfigurator.Models;
using _3DCarConfigurator.Services;
using _3DCarConfigurator.Data;

namespace _3DCarConfigurator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Car> _carsRepo;
        ApplicationDbContext db;

        public HomeController(ILogger<HomeController> logger, IRepository<Car> car, ApplicationDbContext context)
        {
            _logger = logger;
            _carsRepo = car;
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Cars(int? id)
        {
            if(id != null)
            {
                return RedirectToAction("Car", new { id = id });
            }
            return View(db.Cars.ToList());
        }

        public IActionResult Car(int id)
        {
            Models.Car result = (from kek in db.Cars
                                 where kek.Id == id
                                 select kek).FirstOrDefault();
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
