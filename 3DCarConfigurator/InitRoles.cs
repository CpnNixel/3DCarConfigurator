using _3DCarConfigurator.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DCarConfigurator
{
    public class InitRoles
    {
        public static async Task InitializeAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            List<ApplicationUser> users_list = new List<ApplicationUser>(10)
            {
                new ApplicationUser { Email = "keker@gmail.com", UserName = "keker@gmail.com"},
                new ApplicationUser { Email = "keker1@gmail.com", UserName = "keker1@gmail.com"},
                new ApplicationUser { Email = "keker2@gmail.com", UserName = "keker2@gmail.com"},
                new ApplicationUser { Email = "keker3@gmail.com", UserName = "keker3@gmail.com"},
                new ApplicationUser { Email = "keker432@gmail.com", UserName = "keker432@gmail.com"},
                new ApplicationUser { Email = "keker564@gmail.com", UserName = "keker564@gmail.com"},
                new ApplicationUser { Email = "keke77@gmail.com", UserName = "keke77@gmail.com"},
                new ApplicationUser { Email = "keker6@gmail.com", UserName = "keker6@gmail.com"},
                new ApplicationUser { Email = "keker9@gmail.com", UserName = "keker9@gmail.com"},
                new ApplicationUser { Email = "keker8@gmail.com", UserName = "keker8@gmail.com"},
                new ApplicationUser { Email = "keker10@gmail.com", UserName = "keker10@gmail.com"},

            };
            foreach (var user in users_list)
            {
                IdentityResult result = await userManager.CreateAsync(user, CreatePassword());
                await userManager.AddToRoleAsync(user, "user");
            }

            users_list.Add(new ApplicationUser() { Email = "admin@admin.com", UserName = "admin@admin.com" });
            IdentityResult result_admin = await userManager.CreateAsync(users_list.Last(), "_Aa123456");
            if (result_admin.Succeeded)
            {
                await userManager.AddToRoleAsync(users_list.Last(), "admin");
            }
        }

        public static string CreatePassword(int numberOfResults = 10, int minValue = 0, int maxValue = 9)
        {
            StringBuilder sb = new StringBuilder("");
            Random rand = new Random();
            for (int i = 0; i < numberOfResults; i++)
            {
                sb.Append(rand.Next(minValue, maxValue).ToString());
            }

            return sb.ToString();
        }

    }
}