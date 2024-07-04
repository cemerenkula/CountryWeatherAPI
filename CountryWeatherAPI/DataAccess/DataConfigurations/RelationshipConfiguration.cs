using CountryWeatherAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CountryWeatherAPI.DataAccess.DataConfigurations
{
    //COUNTRY RELATIONSHIP
    public class CountryRelationshipConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasOne(c => c.ResponsiblePerson)
                .WithMany(r => r.Countries)
                .HasForeignKey(c => c.ResponsiblePersonId);

            builder.HasOne(c => c.Weather)
                .WithOne(w => w.Country)
                .HasForeignKey<Weather>(w => w.CountryId);
        }
    }

    //RESPOSIBLE PERSON RELATIONSHIP
    public class ResponsiblePersonRelationshipConfiguration : IEntityTypeConfiguration<ResponsiblePerson>
    {
        public void Configure(EntityTypeBuilder<ResponsiblePerson> builder)
        {
            builder.HasIndex(r => r.Email)
                .IsUnique();

            builder.HasIndex(r => new { r.FirstName, r.LastName, r.BirthDate })
                .IsUnique();
        }
    }

    //WEATHER RELATIONSHIP
    public class WeatherRelationshipConfiguration : IEntityTypeConfiguration<Weather>
    {
        public void Configure(EntityTypeBuilder<Weather> builder)
        {
            // Add any specific configurations for Weather if needed
        }
    }
}