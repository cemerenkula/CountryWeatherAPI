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
            // Configure relationships and other settings
            modelBuilder.Entity<Country>()
                .HasOne(c => c.ResponsiblePerson)
                .WithMany(r => r.Countries)
                .HasForeignKey(c => c.ResponsiblePersonId);

            modelBuilder.Entity<Country>()
                .HasOne(c => c.Weather)
                .WithOne(w => w.Country)
                .HasForeignKey<Weather>(w => w.CountryId);

            modelBuilder.Entity<ResponsiblePerson>()
                .HasIndex(r => r.Email)
                .IsUnique();

            modelBuilder.Entity<ResponsiblePerson>()
                .HasIndex(r => new { r.FirstName, r.LastName, r.BirthDate })
                .IsUnique();
        }
    }
}