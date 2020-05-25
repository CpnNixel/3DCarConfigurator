using System;
using System.Collections.Generic;
using System.Text;
using _3DCarConfigurator.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _3DCarConfigurator.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Detail> Details { get; set; }
        public DbSet<Car> Cars{ get; set; }
        public DbSet<Configuration> Configurations { get; set; }
    }
}
