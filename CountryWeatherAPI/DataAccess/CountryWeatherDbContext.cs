using CountryWeatherAPI.Concrete;
using CountryWeatherAPI.DataAccess.DataConfigurations;
using CountryWeatherAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CountryWeatherAPI.DataAccess
{
    public class CountryWeatherDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public CountryWeatherDbContext(DbContextOptions<CountryWeatherDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<ResponsiblePerson> ResponsiblePersons { get; set; }
        public DbSet<Weather> Weathers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new CountryRelationshipConfiguration());
            modelBuilder.ApplyConfiguration(new ResponsiblePersonRelationshipConfiguration());
            modelBuilder.ApplyConfiguration(new WeatherRelationshipConfiguration());
        }
    }
}