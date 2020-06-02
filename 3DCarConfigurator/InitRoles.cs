using _3DCarConfigurator.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace _3DCarConfigurator
{
    public class InitRoles
    {
        public static async Task InitializeAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "12345678";
            if (await roleManager.FindByNameAsync("admin") == null || await roleManager.FindByNameAsync("ADMIN") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null || await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }

            ApplicationUser admin = new ApplicationUser { Email = adminEmail, UserName = adminEmail };
            IdentityResult result = await userManager.CreateAsync(admin, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "admin");
            }
            await userManager.AddToRoleAsync(admin, "admin");

        }
    }
}