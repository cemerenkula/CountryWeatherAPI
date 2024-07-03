using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CountryWeatherAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResponsiblePersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsiblePersons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LatitudeRangeStart = table.Column<int>(type: "integer", nullable: false),
                    LatitudeRangeEnd = table.Column<int>(type: "integer", nullable: false),
                    LongitudeRangeStart = table.Column<int>(type: "integer", nullable: false),
                    LongitudeRangeEnd = table.Column<int>(type: "integer", nullable: false),
                    ResponsiblePersonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_ResponsiblePersons_ResponsiblePersonId",
                        column: x => x.ResponsiblePersonId,
                        principalTable: "ResponsiblePersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    Latitude = table.Column<int>(type: "integer", nullable: false),
                    Longitude = table.Column<int>(type: "integer", nullable: false),
                    Temperature = table.Column<float>(type: "real", nullable: false),
                    FeelsLike = table.Column<float>(type: "real", nullable: false),
                    Pressure = table.Column<int>(type: "integer", nullable: false),
                    Humidity = table.Column<int>(type: "integer", nullable: false),
                    DewPoint = table.Column<float>(type: "real", nullable: false),
                    Uvi = table.Column<float>(type: "real", nullable: false),
                    Clouds = table.Column<int>(type: "integer", nullable: false),
                    Visibility = table.Column<int>(type: "integer", nullable: false),
                    WindSpeed = table.Column<float>(type: "real", nullable: false),
                    WindDeg = table.Column<int>(type: "integer", nullable: false),
                    WindGust = table.Column<float>(type: "real", nullable: false),
                    WeatherMain = table.Column<string>(type: "text", nullable: false),
                    WeatherDescription = table.Column<string>(type: "text", nullable: false),
                    WeatherIcon = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weathers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ResponsiblePersonId",
                table: "Countries",
                column: "ResponsiblePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsiblePersons_Email",
                table: "ResponsiblePersons",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResponsiblePersons_FirstName_LastName_BirthDate",
                table: "ResponsiblePersons",
                columns: new[] { "FirstName", "LastName", "BirthDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weathers_CountryId",
                table: "Weathers",
                column: "CountryId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weathers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "ResponsiblePersons");
        }
    }
}
