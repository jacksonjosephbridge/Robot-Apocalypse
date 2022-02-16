using Microsoft.EntityFrameworkCore;

namespace Robot_Apocalypse.DataLayer.Entities
{
    public class SurvivorContext : DbContext
    {
        public SurvivorContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Survivor> Survivors { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ContaminationReport> ContaminationReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survivor>().HasData(new Survivor
            {
                SurviverId = 1,
                FirstName = "Uncle",
                LastName = "Bob",
                Age = 26,
                Gender = "Male",
            }, new Survivor
            {
                SurviverId = 2,
                FirstName = "Jan",
                LastName = "Kirsten",
                Age = 32,
                Gender = "Female"
            });
            modelBuilder.Entity<Location>().HasData(new Location
            {
                LocationId = 1,
                Latitude = "37.42216",
                Longitude = "-122.08427",
                SurvivorId = 1
            },
            new Location
            {
                LocationId = 2,
                Latitude = "26.2755239",
                Longitude = "-80.08995099999999",
                SurvivorId = 2
            });
            modelBuilder.Entity<Inventory>().HasData(new Inventory
            {
                InventoryId =1,
                SurvivorId = 1,
                Food = "Diced tomatoes, Canned meat and fish, Beans, Diced green chiles",
                Water = "1 liter",
                Medication = "test",
                Ammunition = ".9mm 2 rounds, .45mm 3 rounds",

            }, new Inventory
            {
                InventoryId =2,
                SurvivorId = 2,
                Food = "Diced tomatoes, Diced green chiles",
                Water = "5 liter",
                Medication = "paracetamol",
                Ammunition = ".9mm 3 rounds, .45mm 1 rounds",

            });
        }
    }
}
