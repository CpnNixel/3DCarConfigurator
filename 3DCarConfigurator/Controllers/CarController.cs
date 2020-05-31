using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using _3DCarConfigurator.Models;
using _3DCarConfigurator.Data;

namespace _3DCarConfigurator.Controllers
{
    public class CarController : Controller
    {
        ApplicationDbContext db;
        public CarController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult AllCars(int? id)
        {
            if (id != null)
            {
                return RedirectToAction("Car", new { id = id });
            }
            return View(db.Cars.ToList());
        }

        public IActionResult CarPage(int id)
        {
            Models.Car result = (from kek in db.Cars
                                 where kek.Id == id
                                 select kek).FirstOrDefault();
            //db.Users.FirstOrDefault().LikedConfigs = db.Configurations.ToList();
            //db.SaveChanges();
            CarConfigViewModel cfgViewModel = new CarConfigViewModel { Car = result, Configs = db.Configurations.Where(x => x.CarId == result.Id) };

            foreach (var conf in cfgViewModel.Configs)
            {
                string[] arr = conf.DetailsString.Split(",");

                List<Detail> det = new List<Detail>();
                foreach (var element in arr)
                {
                    det.Add(db.Details.Where(x => x.Id == Convert.ToInt32(element)).FirstOrDefault());
                }
                conf.Details = det;
            }

            List<int> detailsNumbers = new List<int>();
            cfgViewModel.Details = new List<Detail>();
            foreach (var item in cfgViewModel.Configs)
            {
                string[] arr = item.DetailsString.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!detailsNumbers.Contains(Convert.ToInt32(arr[i])))
                    {
                        detailsNumbers.Add(Convert.ToInt32(arr[i]));
                        cfgViewModel.Details.Add(db.Details.Where(x => x.Id == Convert.ToInt32(arr[i])).FirstOrDefault());
                    }
                }
            }
            string[] pickedDet = db.Configurations.Where(x => x.Id == cfgViewModel.Car.CurrentConfigurationId).First().DetailsString.Split(',');
            cfgViewModel.PickedDetails = new List<int>();
            foreach (var item in pickedDet)
            {
                cfgViewModel.PickedDetails.Add(Convert.ToInt32(item));
            }

            return View(cfgViewModel);
        }

        public RedirectResult SetLike(string id)
        {
            string[] arr = id.ToString().Split(",");
            int carId = Convert.ToInt32(arr[0]);
            string configDetails = string.Join(",", arr, 1, arr.Length - 1);

            Configuration config = db.Configurations.Where(x => x.DetailsString == configDetails).Where(x => x.CarId == carId).FirstOrDefault();
            Car car = db.Cars.Where(x => x.Id == carId).FirstOrDefault();
            ApplicationUser user = db.Users.Where(x => x.Email == User.Identity.Name).First();

            if (config == null)
            {
                db.Configurations.Add(new Configuration() {
                    CarId = car.Id,
                    DetailsString = configDetails
                });
                car.CurrentConfigurationId = db.Configurations.Last().Id;
            } else
            {
                car.CurrentConfigurationId = config.Id;
                
            }
            int confId = car.CurrentConfigurationId;


            if (user.LikedString == "" || user.LikedString == null)
            {
                user.LikedString = confId.ToString();
            }
            else
            {
                List<string> likes = new List<string>(user.LikedString.Split(','));
                if (!likes.Contains(confId.ToString()))
                {
                    user.LikedString += "," + confId.ToString();
                }
            }

            db.SaveChanges();
            return Redirect("/Car/CarPage/" + carId.ToString());
        }
    }
}
