using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3DCarConfigurator.Data;

namespace _3DCarConfigurator
{
    public class InitData
    {
        public static void Initialize(ApplicationDbContext context) {
            if (!context.Cars.Any())
            {
                context.Cars.AddRange(
                        new Models.Car
                        {
                            Name = "BMW Blue",
                            PathToModel = "blueBMW.png",
                            CarPrice = 100_000F
                        },
                        new Models.Car
                        {
                            Name = "BMW Red",
                            PathToModel = "redBMW.png",
                            CarPrice = 70_000F
                        },
                        new Models.Car
                        {
                            Name = "BMW White",
                            PathToModel = "whiteBMW.png",
                            CarPrice = 119_000F
                        }
                    );
                context.SaveChanges();
            }
        }
    }
}
