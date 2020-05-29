using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _3DCarConfigurator.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _3DCarConfigurator.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<ConfigurationDetail> ConfigurationDetails { get; set; }

        protected override void
        OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfigurationDetail>()
                .HasKey(x => new { x.ConfigurationId, x.DetailId });

            modelBuilder.Entity<ConfigurationDetail>()
                .HasOne(pc => pc.Configuration)
                .WithMany( p => p.ConfDetails)
                .HasForeignKey(pc => pc.ConfigurationId);

            modelBuilder.Entity<ConfigurationDetail>()
                .HasOne(pc => pc.Detail)
                .WithMany(c => c.ConfDetails)
                .HasForeignKey(pc => pc.DetailId);
        }
    }
}
