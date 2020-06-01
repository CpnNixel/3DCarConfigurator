using _3DCarConfigurator.Data;
using _3DCarConfigurator.Models;
using _3DCarConfigurator.Services;
using _3DCarConfigurator.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            ItemsListsViewModel items = new ItemsListsViewModel() { ItemIdSelected = 1 };
            return View(itemsLists);
        }

        [HttpPost]
        public IActionResult Index(int ItemIdSelected)
        {
            Car temp = (Car)Car_Repo.GetAll().FirstOrDefault(x => x.Id == ItemIdSelected);
            return EditCar(temp);
        }

        [HttpGet]
        public IActionResult EditConfiguration(int ItemIdSelected)
        {
            Configuration kek = Config_Repo.GetAll().FirstOrDefault(x => x.Id == ItemIdSelected);
            if (kek == null)
            {
                ViewBag.ErrorMesage = $"Car with id {kek.Id} cannot be found";
                return View("NotFound");
            }

            return View(kek);
        }

        [HttpPost]
        public IActionResult EditConfiguration(Configuration configuration)
        {
            Configuration kek = Config_Repo.GetAll().FirstOrDefault(x => x.Id == configuration.Id);
            if (kek == null)
            {
                ViewBag.ErrorMesage = $"Car with id {configuration.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                Config_Repo.Edit(configuration);
            }
            return View("/Views/Home/Index.cshtml");
        }

        [HttpGet]
        public IActionResult EditDetail(int ItemIdSelected)
        {
            Detail kek = Detail_Repo.GetAll().FirstOrDefault(x => x.Id == ItemIdSelected);
            if (kek == null)
            {
                ViewBag.ErrorMesage = $"Car with id {kek.Id} cannot be found";
                return View("NotFound");
            }

            return View(kek);
        }

        [HttpPost]
        public IActionResult EditDetail(Detail detail)
        {
            Detail kek = Detail_Repo.GetAll().FirstOrDefault(x => x.Id == detail.Id);
            if (kek == null)
            {
                ViewBag.ErrorMesage = $"Car with id {kek.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                Detail_Repo.Edit(kek);
            }
            return View("/Views/Home/Index.cshtml");
        }

        [HttpGet]
        public IActionResult EditCar(int ItemIdSelected)
        {
            Car kek = Car_Repo.GetAll().FirstOrDefault(x => x.Id == ItemIdSelected);
            if (kek == null)
            {
                ViewBag.ErrorMesage = $"Car with id {kek.Id} cannot be found";
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