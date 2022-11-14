using HotelListing.API.Data.Configrations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.API.Data
{
    public class HotelListeingDbContext : IdentityDbContext<ApiUser>
    {
        public HotelListeingDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfigration());
            modelBuilder.ApplyConfiguration(new CountryConfigration());
            modelBuilder.ApplyConfiguration(new HotelConfigration());
        }
    }
}
