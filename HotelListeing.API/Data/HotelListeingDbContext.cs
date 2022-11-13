using HotelListeing.API.Data.Configration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelListeing.API.Data
{
    public class HotelListeingDbContext:IdentityDbContext<ApiUser>
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
