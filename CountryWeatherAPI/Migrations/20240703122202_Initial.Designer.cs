﻿// <auto-generated />
using System;
using CountryWeatherAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CountryWeatherAPI.Migrations
{
    [DbContext(typeof(CountryWeatherDbContext))]
    [Migration("20240703122202_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CountryWeatherAPI.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("LatitudeRangeEnd")
                        .HasColumnType("integer");

                    b.Property<int>("LatitudeRangeStart")
                        .HasColumnType("integer");

                    b.Property<int>("LongitudeRangeEnd")
                        .HasColumnType("integer");

                    b.Property<int>("LongitudeRangeStart")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ResponsiblePersonId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ResponsiblePersonId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("CountryWeatherAPI.Models.ResponsiblePerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("FirstName", "LastName", "BirthDate")
                        .IsUnique();

                    b.ToTable("ResponsiblePersons");
                });

            modelBuilder.Entity("CountryWeatherAPI.Models.Weather", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Clouds")
                        .HasColumnType("integer");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<float>("DewPoint")
                        .HasColumnType("real");

                    b.Property<float>("FeelsLike")
                        .HasColumnType("real");

                    b.Property<int>("Humidity")
                        .HasColumnType("integer");

                    b.Property<int>("Latitude")
                        .HasColumnType("integer");

                    b.Property<int>("Longitude")
                        .HasColumnType("integer");

                    b.Property<int>("Pressure")
                        .HasColumnType("integer");

                    b.Property<float>("Temperature")
                        .HasColumnType("real");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("Uvi")
                        .HasColumnType("real");

                    b.Property<int>("Visibility")
                        .HasColumnType("integer");

                    b.Property<string>("WeatherDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WeatherIcon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WeatherMain")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WindDeg")
                        .HasColumnType("integer");

                    b.Property<float>("WindGust")
                        .HasColumnType("real");

                    b.Property<float>("WindSpeed")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CountryId")
                        .IsUnique();

                    b.ToTable("Weathers");
                });

            modelBuilder.Entity("CountryWeatherAPI.Models.Country", b =>
                {
                    b.HasOne("CountryWeatherAPI.Models.ResponsiblePerson", "ResponsiblePerson")
                        .WithMany("Countries")
                        .HasForeignKey("ResponsiblePersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResponsiblePerson");
                });

            modelBuilder.Entity("CountryWeatherAPI.Models.Weather", b =>
                {
                    b.HasOne("CountryWeatherAPI.Models.Country", "Country")
                        .WithOne("Weather")
                        .HasForeignKey("CountryWeatherAPI.Models.Weather", "CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("CountryWeatherAPI.Models.Country", b =>
                {
                    b.Navigation("Weather")
                        .IsRequired();
                });

            modelBuilder.Entity("CountryWeatherAPI.Models.ResponsiblePerson", b =>
                {
                    b.Navigation("Countries");
                });
#pragma warning restore 612, 618
        }
    }
}
