using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using _3DCarConfigurator.Data;
using _3DCarConfigurator.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace _3DCarConfigurator
{
    public class InitData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Cars.Any())
            {
                context.Cars.AddRange(
                        new Models.Car
                        {
                            Name = "BMW Blue",
                            PathToModel = "blueBMW.png",
                            CarPrice = 100000
                        },
                        new Models.Car
                        {
                            Name = "BMW Red",
                            PathToModel = "redBMW.png",
                            CarPrice = 70000
                        },
                        new Models.Car
                        {
                            Name = "BMW White",
                            PathToModel = "whiteBMW.png",
                            CarPrice = 119000
                        }
                    );
                context.SaveChanges();

            }
            if (!context.Details.Any())
            {
                context.Details.AddRange(
                        new Models.Detail
                        {
                            Category = "Color",
                            Name = "Green",
                            DetailPrice = 3000
                        },
                        new Models.Detail
                        {
                            Category = "Color",
                            Name = "White",
                            DetailPrice = 1000
                        },
                        new Models.Detail
                        {
                            Category = "Wheels",
                            Name = "18 radius",
                            DetailPrice = 1500
                        },
                        new Models.Detail
                        {
                            Category = "Wheels",
                            Name = "20 radius",
                            DetailPrice = 4500
                        }
                    );
                context.SaveChanges();
            }
            if (!context.Configurations.Any())
            {
                context.Configurations.AddRange(
                        new Models.Configuration
                        {
                            CarId = context.Cars.First().Id,
                            /*Details = new List<Models.Detail>
                            {
                                context.Details.Where(x => x.Name == "White").FirstOrDefault(),
                                context.Details.Where(x => x.Name == "18 radius").FirstOrDefault()
                            }*/

                            DetailsString = (context.Details.Where(x => x.Name == "White").FirstOrDefault().Id.ToString() + "," +
                            context.Details.Where(x => x.Name == "18 radius").FirstOrDefault().Id.ToString())
                        },
                        new Models.Configuration
                        {
                            CarId = context.Cars.First().Id,
                            /*Details = new List<Models.Detail>
                            {
                                context.Details.Where(x => x.Name == "Green").FirstOrDefault(),
                                context.Details.Where(x => x.Name == "20 radius").FirstOrDefault()
                            }*/
                            DetailsString = (context.Details.Where(x => x.Name == "Green").FirstOrDefault().Id.ToString() + "," +
                            context.Details.Where(x => x.Name == "20 radius").FirstOrDefault().Id.ToString())
                        }
                    );
                context.SaveChanges();

                context.Cars.First().CurrentConfigurationId = context.Configurations.Where(x => x.CarId == context.Cars.First().Id).First().Id;
                context.SaveChanges();
            }
        }
    }
}
