using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DCarConfigurator.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public List<Configuration> LikedConfigs {get;set;}
    }
}
