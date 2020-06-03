using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using _3DCarConfigurator.Models;
using _3DCarConfigurator.Data;
using _3DCarConfigurator.ViewModels;
using Org.BouncyCastle.Bcpg;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Crypto.Tls;

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
            Car result = db.Cars.Where(x => x.Id == id).FirstOrDefault();
            /*Models.Car result = (from kek in db.Cars
                                 where kek.Id == id
                                 select kek).FirstOrDefault();*/
            //db.Users.FirstOrDefault().LikedConfigs = db.Configurations.ToList();
            //db.SaveChanges();
            if (result == null)
            {
                return View("NotFound");
            }
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
            string[] pickedDet = db.Configurations.Where(x => x.Id == cfgViewModel.Car.CurrentConfigurationId).FirstOrDefault().DetailsString.Split(',');
            cfgViewModel.PickedDetails = new List<int>();
            foreach (var item in pickedDet)
            {
                cfgViewModel.PickedDetails.Add(Convert.ToInt32(item));
            }

            cfgViewModel.CurrentConfig = db.Configurations.Where(x => x.Id == cfgViewModel.Car.CurrentConfigurationId).FirstOrDefault();

            return View(cfgViewModel); 
        }

        public RedirectResult ChangeConfig(string id)
        {
            string[] arr = id.ToString().Split(",");
            int carId = Convert.ToInt32(arr[0]);
            string configDetails = string.Join(",", arr, 1, arr.Length - 1);

            Configuration config = db.Configurations.Where(x => x.DetailsString == configDetails).Where(x => x.CarId == carId).FirstOrDefault();
            db.Cars.Where(x => x.Id == carId).FirstOrDefault().CurrentConfigurationId = config.Id;
            db.SaveChanges();

            return Redirect("/Car/CarPage/" + carId.ToString());
        }

        public string GetModel(string id)
        {
            string[] arr = id.ToString().Split(",");
            int carId = Convert.ToInt32(arr[0]);
            string configDetails = string.Join(",", arr, 1, arr.Length - 1);

            Configuration config = db.Configurations.Where(x => x.DetailsString == configDetails).Where(x => x.CarId == carId).FirstOrDefault();
    

            return config.Model3dPath;
        }

        public RedirectResult SetLike(string id)
        {
            string[] arr = id.ToString().Split(",");
            int carId = Convert.ToInt32(arr[0]);
            string configDetails = string.Join(",", arr, 1, arr.Length - 1);

            Configuration config = db.Configurations.Where(x => x.DetailsString == configDetails).Where(x => x.CarId == carId).FirstOrDefault();
            Car car = db.Cars.Where(x => x.Id == carId).FirstOrDefault();
            ApplicationUser user = db.Users.Where(x => x.Email == User.Identity.Name).FirstOrDefault();

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

        public IActionResult Likes()
        {
            LikesViewModel lvm = new LikesViewModel();

            List<Car> Cars = new List<Car>();
            List<Configuration> Configurations = new List<Configuration>();
            List<string> configurationIds = new List<string>(db.Users.Where(x => x.Email == User.Identity.Name).FirstOrDefault().LikedString.Split(','));

            foreach (var id in configurationIds)
            {
                Configuration conf = db.Configurations.Where(x => x.Id == Convert.ToInt32(id)).FirstOrDefault();
                Car car = db.Cars.Where(x => x.Id == conf.CarId).FirstOrDefault();
                Cars.Add(car);
                Configurations.Add(conf);
            }

            lvm.Configurations = Configurations;
            lvm.Cars = Cars;

            return View(lvm);
        }

        public RedirectResult OpenLiked(int id)
        {
            Configuration conf = db.Configurations.Where(x => x.Id == Convert.ToInt32(id)).FirstOrDefault();
            Car car = db.Cars.Where(x => x.Id == conf.CarId).FirstOrDefault();
            car.CurrentConfigurationId = id;
            db.SaveChanges();
            return Redirect("/Car/CarPage/" + car.Id.ToString());
        }

        public IActionResult Recommendations()
        {
            List<Car> RecommendCars = new List<Car>();
            List<Configuration> RecommendConfigs = new List<Configuration>();
            string[] arr = db.Users.Where(x => x.Email == User.Identity.Name).FirstOrDefault().LikedString.Split(',');

            List<Configuration> LikedConfigs = new List<Configuration>();
            foreach(var item in arr)
            {
                LikedConfigs.Add(db.Configurations.Where(x => x.Id == Convert.ToInt32(item)).FirstOrDefault());
            }

            Dictionary<int, int> details = new Dictionary<int, int>();
            foreach(var conf in LikedConfigs)
            {
                string[] dets = conf.DetailsString.Split(',');
                foreach(var det in dets)
                {
                    Detail detail = db.Details.Where(x => x.Id == Convert.ToInt32(det)).FirstOrDefault();
                    
                    if(detail != null)
                    {
                        if (details.ContainsKey(detail.Id))
                        {
                            details[detail.Id]++;
                        } else
                        {
                            details[detail.Id] = 1;
                        }
                    }
                }
            }

            List<int> colors = new List<int>();
            List<int> wheels = new List<int>();

            foreach (KeyValuePair<int, int> keyValue in details)
            {
                if(db.Details.Where(x => x.Id == keyValue.Key).FirstOrDefault().Category == "Color")
                {
                    for(int i = 0; i < keyValue.Value; i++)
                    {
                        colors.Add(keyValue.Key);
                    }
                } else if(db.Details.Where(x => x.Id == keyValue.Key).FirstOrDefault().Category == "Wheels")
                {
                    for (int i = 0; i < keyValue.Value; i++)
                    {
                        wheels.Add(keyValue.Key);
                    }
                }
            }

            Random rand = new Random();
            int colorId = colors[rand.Next(0, colors.Count)];
            int wheelId = wheels[rand.Next(0, wheels.Count)];
            List<Configuration> configs = db.Configurations.ToList();
            foreach(var conf in configs)
            {
                List<string> det = new List<string>(conf.DetailsString.Split(','));
                if (det.Contains(colorId.ToString()) || det.Contains(wheelId.ToString()))
                {
                    RecommendCars.Add(db.Cars.Where(x => x.Id == conf.CarId).FirstOrDefault());
                    RecommendConfigs.Add(conf);
                }
            }

            LikesViewModel lvm = new LikesViewModel
            {
                Cars = RecommendCars,
                Configurations = RecommendConfigs
            };

            while (lvm.Cars.Count() > 4)
            {
                int a = rand.Next(0, lvm.Cars.Count() - 1);
                lvm.Cars.RemoveAt(a);
                lvm.Configurations.RemoveAt(a);
            }

            return View(lvm);
        }
    }
}
