using Microsoft.EntityFrameworkCore;

namespace PatchExample.Data
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options) { }

        public DbSet<Weather> Weather => Set<Weather>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseInMemoryDatabase("Weather");

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.Entity<Weather>().HasData(
                new Weather(1, "London", "UK", 20, 5, 0.0),
                new Weather(2, "Paris", "France", 13, 10, 4.3),
                new Weather(3, "Berlin", "Germany", 25, 15, 0.0),
                new Weather(4, "Madrid", "Spain", 30, 20, 0.0),
                new Weather(5, "Rome", "Italy", 35, 25, 0.0),
                new Weather(6, "New York", "USA", 40, 30, 0.0),
                new Weather(7, "Tokyo", "Japan", 45, 35, 0.0),
                new Weather(8, "Mumbai", "India", 50, 40, 0.0),
                new Weather(9, "Seoul", "South Korea", 15, 45, 8.1)
            );
    }
}
