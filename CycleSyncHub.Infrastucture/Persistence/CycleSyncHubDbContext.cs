using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleSyncHub.Infrastucture.Persistence
{
    public class CycleSyncHubDbContext : IdentityDbContext
    {
        public CycleSyncHubDbContext(DbContextOptions<CycleSyncHubDbContext> options) :base(options)
        {

        }
        public DbSet<Domain.Entities.Bike> Bikes { get; set; }
        public DbSet<Domain.Entities.BikeInfo> Infos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.Bike>()
                .OwnsOne(c => c.BikesDetails);

            modelBuilder.Entity<Domain.Entities.Bike>()
                .HasMany(c => c.Infos)
                .WithOne(s => s.Bike)
                .HasForeignKey(s => s.BikeId);
        }
    }
}
