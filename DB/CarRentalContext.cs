using ForCar.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace ForCar.DB
{
    class CarRentalContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=.;Initial Catalog=BazaForCar;User ID=admin;Password=admin1;");
        }
    }
}
