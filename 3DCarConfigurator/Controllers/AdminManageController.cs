using _3DCarConfigurator.Data;
using _3DCarConfigurator.Models;
using _3DCarConfigurator.Services;
using _3DCarConfigurator.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

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
        public IActionResult Index(ItemsListsViewModel itemsLists)
        {
            ViewBag.CarList = Car_Repo.GetAll().ToList();
            ViewBag.DetailList = Detail_Repo.GetAll().ToList();
            ViewBag.ConfigurationList = Config_Repo.GetAll().ToList();
            ItemsListsViewModel items = new ItemsListsViewModel() { CarSelected = 1, ConfigurationSelected = 1, DetailSelected = 1 };
            return View(itemsLists);
        }
        [HttpPost]
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

        //ItemsListsViewModel
        [HttpPost]
        public IActionResult EditCar(ItemsListsViewModel vm)
        {
            int selected = vm.CarSelected;

            return View(vm);
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