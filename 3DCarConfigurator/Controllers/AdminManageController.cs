using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3DCarConfigurator.Data;
using _3DCarConfigurator.Models;
using _3DCarConfigurator.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace _3DCarConfigurator.Controllers
{
    public class AdminManageController : Controller
    {
        public AdminManageController(ApplicationDbContext dbContext,
                                       ILogger<AdminManageController> logger,
                                       IRepository<Car> car_repo,
                                       IRepository<Detail> detail_repo,
                                       IRepository<Configuration> config_repo
                                       )
        {
            DbContext = dbContext;
            Logger = logger;
            Car_Repo = car_repo;
            Detail_Repo = detail_repo;
            Config_Repo = config_repo;
        }

        public ApplicationDbContext DbContext { get; }
        public ILogger<AdminManageController> Logger { get; }
        public IRepository<Car> Car_Repo { get; }
        public IRepository<Detail> Detail_Repo { get; }
        public IRepository<Configuration> Config_Repo { get; }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditCar(int id)
        {
            Car kek = Car_Repo.GetAll().FirstOrDefault(x => x.Id == id);
            if (kek == null)
            {
                ViewBag.ErrorMesage = $"Car with id {id} cannot be found";
                return View("NotFound");
            }

            return View(kek);
        }
        [HttpPost]
        public IActionResult EditCar(Car car)
        {
            Car kek = Car_Repo.GetAll().FirstOrDefault(x => x.Id == car.Id);
            if (kek == null)
            {
                ViewBag.ErrorMesage = $"Car with id {car.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                Car_Repo.Edit(car);
            }
            return View("/Views/Home/Index.cshtml");
        }
    }
}
