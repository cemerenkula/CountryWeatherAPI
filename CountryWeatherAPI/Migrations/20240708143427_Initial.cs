using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    ResponsiblePersonId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_ResponsiblePersons_ResponsiblePersonId",
                        column: x => x.ResponsiblePersonId,
                        principalTable: "ResponsiblePersons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Latitude = table.Column<int>(type: "integer", nullable: false),
                    Longitude = table.Column<int>(type: "integer", nullable: false),
                    WeatherMain = table.Column<string>(type: "text", nullable: false),
                    WeatherDescription = table.Column<string>(type: "text", nullable: false),
                    Temperature = table.Column<double>(type: "double precision", nullable: false),
                    FeelsLike = table.Column<double>(type: "double precision", nullable: false),
                    Pressure = table.Column<double>(type: "double precision", nullable: false),
                    Humidity = table.Column<int>(type: "integer", nullable: false),
                    WindSpeed = table.Column<double>(type: "double precision", nullable: false),
                    WindDeg = table.Column<int>(type: "integer", nullable: false),
                    WindGust = table.Column<double>(type: "double precision", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weathers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "LatitudeRangeEnd", "LatitudeRangeStart", "LongitudeRangeEnd", "LongitudeRangeStart", "Name", "ResponsiblePersonId" },
                values: new object[,]
                {
                    { 1, 39, 30, 75, 60, "Afghanistan", null },
                    { 2, 43, 39, 21, 19, "Albania", null },
                    { 3, 37, 19, 12, -9, "Algeria", null },
                    { 4, 43, 42, 2, 1, "Andorra", null },
                    { 5, -4, -18, 24, 12, "Angola", null },
                    { 6, 18, 16, -61, -62, "Antigua and Barbuda", null },
                    { 7, -22, -55, -53, -73, "Argentina", null },
                    { 8, 42, 39, 47, 44, "Armenia", null },
                    { 9, -10, -43, 154, 113, "Australia", null },
                    { 10, 49, 46, 17, 9, "Austria", null },
                    { 11, 42, 38, 51, 44, "Azerbaijan", null },
                    { 12, 27, 20, -72, -79, "Bahamas", null },
                    { 13, 26, 25, 51, 50, "Bahrain", null },
                    { 14, 27, 20, 93, 88, "Bangladesh", null },
                    { 15, 14, 13, -59, -59, "Barbados", null },
                    { 16, 57, 52, 33, 24, "Belarus", null },
                    { 17, 51, 50, 6, 2, "Belgium", null },
                    { 18, 18, 16, -88, -89, "Belize", null },
                    { 19, 12, 6, 4, 0, "Benin", null },
                    { 20, 29, 27, 92, 88, "Bhutan", null },
                    { 21, -9, -23, -57, -69, "Bolivia", null },
                    { 22, 45, 42, 20, 15, "Bosnia and Herzegovina", null },
                    { 23, -18, -27, 30, 20, "Botswana", null },
                    { 24, 5, -34, -34, -74, "Brazil", null },
                    { 25, 5, 4, 115, 114, "Brunei Darussalam", null },
                    { 26, 44, 41, 29, 22, "Bulgaria", null },
                    { 27, 15, 10, 3, -6, "Burkina Faso", null },
                    { 28, -2, -4, 30, 29, "Burundi", null },
                    { 29, 18, 16, -22, -26, "Cabo Verde", null },
                    { 30, 15, 10, 108, 102, "Cambodia", null },
                    { 31, 13, 2, 17, 8, "Cameroon", null },
                    { 32, 84, 42, -52, -141, "Canada", null },
                    { 33, 11, 2, 28, 14, "Central African Republic", null },
                    { 34, 24, 7, 24, 13, "Chad", null },
                    { 35, -18, -56, -66, -75, "Chile", null },
                    { 36, 53, 18, 135, 73, "China", null },
                    { 37, 13, -4, -66, -79, "Colombia", null },
                    { 38, -11, -12, 44, 43, "Comoros", null },
                    { 39, 5, -5, 31, 12, "Congo", null },
                    { 40, 11, 8, -82, -86, "Costa Rica", null },
                    { 41, 47, 42, 20, 14, "Croatia", null },
                    { 42, 23, 20, -74, -85, "Cuba", null },
                    { 43, 36, 35, 34, 32, "Cyprus", null },
                    { 44, 51, 48, 19, 12, "Czech Republic", null },
                    { 45, 58, 54, 15, 8, "Denmark", null },
                    { 46, 12, 10, 44, 41, "Djibouti", null },
                    { 47, 16, 15, -61, -62, "Dominica", null },
                    { 48, 20, 17, -68, -72, "Dominican Republic", null },
                    { 49, 2, -5, -75, -81, "Ecuador", null },
                    { 50, 32, 22, 35, 25, "Egypt", null },
                    { 51, 15, 13, -88, -91, "El Salvador", null },
                    { 52, 3, 0, 12, 8, "Equatorial Guinea", null },
                    { 53, 18, 12, 43, 36, "Eritrea", null },
                    { 54, 60, 57, 29, 21, "Estonia", null },
                    { 55, -25, -27, 32, 31, "Eswatini", null },
                    { 56, 15, 3, 48, 33, "Ethiopia", null },
                    { 57, -12, -21, 178, 177, "Fiji", null },
                    { 58, 70, 60, 32, 20, "Finland", null },
                    { 59, 51, 41, 10, -5, "France", null },
                    { 60, 3, -4, 15, 8, "Gabon", null },
                    { 61, 14, 13, -15, -17, "Gambia", null },
                    { 62, 44, 42, 47, 40, "Georgia", null },
                    { 63, 55, 47, 15, 5, "Germany", null },
                    { 64, 12, 4, 1, -3, "Ghana", null },
                    { 65, 42, 35, 29, 19, "Greece", null },
                    { 66, 13, 11, -61, -62, "Grenada", null },
                    { 67, 18, 14, -88, -93, "Guatemala", null },
                    { 68, 12, 7, -7, -15, "Guinea", null },
                    { 69, 12, 10, -13, -17, "Guinea-Bissau", null },
                    { 70, 9, 1, -57, -61, "Guyana", null },
                    { 71, 20, 18, -71, -75, "Haiti", null },
                    { 72, 17, 13, -83, -89, "Honduras", null },
                    { 73, 48, 46, 23, 16, "Hungary", null },
                    { 74, 67, 63, -13, -24, "Iceland", null },
                    { 75, 36, 8, 98, 68, "India", null },
                    { 76, 6, -11, 141, 95, "Indonesia", null },
                    { 77, 40, 25, 63, 44, "Iran (Islamic Republic of)", null },
                    { 78, 38, 29, 49, 39, "Iraq", null },
                    { 79, 55, 51, -5, -11, "Ireland", null },
                    { 80, 34, 29, 36, 34, "Israel", null },
                    { 81, 47, 36, 19, 6, "Italy", null },
                    { 82, 19, 17, -76, -79, "Jamaica", null },
                    { 83, 46, 24, 153, 123, "Japan", null },
                    { 84, 34, 29, 39, 35, "Jordan", null },
                    { 85, 56, 40, 88, 46, "Kazakhstan", null },
                    { 86, 5, -4, 42, 34, "Kenya", null },
                    { 87, 4, -4, 173, 169, "Kiribati", null },
                    { 88, 30, 28, 49, 46, "Kuwait", null },
                    { 89, 43, 39, 81, 69, "Kyrgyzstan", null },
                    { 90, 23, 14, 108, 100, "Lao People's Democratic Republic", null },
                    { 91, 58, 56, 29, 21, "Latvia", null },
                    { 92, 34, 33, 37, 35, "Lebanon", null },
                    { 93, -28, -30, 29, 27, "Lesotho", null },
                    { 94, 9, 4, -7, -12, "Liberia", null },
                    { 95, 34, 19, 26, 10, "Libya", null },
                    { 96, 48, 47, 10, 9, "Liechtenstein", null },
                    { 97, 57, 54, 27, 20, "Lithuania", null },
                    { 98, 51, 49, 7, 5, "Luxembourg", null },
                    { 99, -12, -26, 51, 43, "Madagascar", null },
                    { 100, -9, -17, 36, 32, "Malawi", null },
                    { 101, 7, 1, 119, 100, "Malaysia", null },
                    { 102, 7, -1, 74, 72, "Maldives", null },
                    { 103, 25, 10, 5, -12, "Mali", null },
                    { 104, 36, 35, 15, 14, "Malta", null },
                    { 105, 15, 5, 173, 162, "Marshall Islands", null },
                    { 106, 27, 15, -4, -17, "Mauritania", null },
                    { 107, -19, -21, 58, 56, "Mauritius", null },
                    { 108, 33, 15, -86, -118, "Mexico", null },
                    { 109, 10, 0, 162, 138, "Micronesia (Federated States of)", null },
                    { 110, 44, 43, 8, 7, "Monaco", null },
                    { 111, 52, 41, 120, 87, "Mongolia", null },
                    { 112, 43, 41, 21, 18, "Montenegro", null },
                    { 113, 36, 27, -2, -13, "Morocco", null },
                    { 114, -10, -27, 41, 30, "Mozambique", null },
                    { 115, 29, 10, 102, 92, "Myanmar", null },
                    { 116, -17, -29, 25, 12, "Namibia", null },
                    { 117, -1, -1, 167, 166, "Nauru", null },
                    { 118, 31, 27, 89, 80, "Nepal", null },
                    { 119, 54, 50, 8, 3, "Netherlands", null },
                    { 120, -34, -47, 179, 166, "New Zealand", null },
                    { 121, 15, 10, -82, -88, "Nicaragua", null },
                    { 122, 24, 11, 16, 0, "Niger", null },
                    { 123, 14, 4, 15, 3, "Nigeria", null },
                    { 124, 42, 40, 23, 20, "North Macedonia", null },
                    { 125, 71, 58, 32, 4, "Norway", null },
                    { 126, 26, 17, 60, 52, "Oman", null },
                    { 127, 37, 24, 77, 60, "Pakistan", null },
                    { 128, 8, 6, 135, 131, "Palau", null },
                    { 129, 10, 8, -77, -83, "Panama", null },
                    { 130, -1, -12, 160, 140, "Papua New Guinea", null },
                    { 131, -19, -27, -54, -62, "Paraguay", null },
                    { 132, 0, -18, -68, -81, "Peru", null },
                    { 133, 21, 4, 127, 115, "Philippines", null },
                    { 134, 55, 49, 25, 14, "Poland", null },
                    { 135, 43, 37, -6, -9, "Portugal", null },
                    { 136, 27, 24, 52, 50, "Qatar", null },
                    { 137, 39, 33, 130, 125, "Republic of Korea", null },
                    { 138, 48, 45, 30, 27, "Republic of Moldova", null },
                    { 139, 48, 44, 30, 20, "Romania", null },
                    { 140, 82, 41, 190, 19, "Russian Federation", null },
                    { 141, -1, -3, 31, 29, "Rwanda", null },
                    { 142, 18, 17, -62, -63, "Saint Kitts and Nevis", null },
                    { 143, 14, 13, -60, -62, "Saint Lucia", null },
                    { 144, 14, 12, -60, -62, "Saint Vincent and the Grenadines", null },
                    { 145, -13, -14, -171, -173, "Samoa", null },
                    { 146, 44, 43, 13, 12, "San Marino", null },
                    { 147, 2, 0, 7, 6, "Sao Tome and Principe", null },
                    { 148, 32, 16, 56, 34, "Saudi Arabia", null },
                    { 149, 17, 12, -11, -17, "Senegal", null },
                    { 150, 44, 42, 22, 19, "Serbia", null },
                    { 151, -4, -5, 57, 55, "Seychelles", null },
                    { 152, 10, 6, -10, -13, "Sierra Leone", null },
                    { 153, 2, 1, 105, 103, "Singapore", null },
                    { 154, 50, 48, 23, 16, "Slovakia", null },
                    { 155, 47, 46, 17, 13, "Slovenia", null },
                    { 156, -6, -12, 168, 155, "Solomon Islands", null },
                    { 157, 12, -1, 52, 41, "Somalia", null },
                    { 158, -22, -35, 33, 16, "South Africa", null },
                    { 159, 12, 3, 36, 24, "South Sudan", null },
                    { 160, 43, 28, 4, -18, "Spain", null },
                    { 161, 10, 6, 82, 79, "Sri Lanka", null },
                    { 162, 33, 31, 35, 34, "State of Palestine", null },
                    { 163, 22, 9, 39, 22, "Sudan", null },
                    { 164, 6, 2, -54, -59, "Suriname", null },
                    { 165, 70, 56, 25, 11, "Sweden", null },
                    { 166, 48, 46, 10, 6, "Switzerland", null },
                    { 167, 37, 32, 42, 35, "Syrian Arab Republic", null },
                    { 168, 41, 36, 75, 67, "Tajikistan", null },
                    { 169, 21, 5, 105, 97, "Thailand", null },
                    { 170, -8, -9, 128, 125, "Timor-Leste", null },
                    { 171, 11, 6, 2, -1, "Togo", null },
                    { 172, -16, -22, -173, -177, "Tonga", null },
                    { 173, 11, 10, -60, -62, "Trinidad and Tobago", null },
                    { 174, 38, 30, 12, 7, "Tunisia", null },
                    { 175, 42, 36, 45, 26, "Turkey", null },
                    { 176, 43, 35, 66, 52, "Turkmenistan", null },
                    { 177, -6, -9, 180, 176, "Tuvalu", null },
                    { 178, 4, -2, 36, 30, "Uganda", null },
                    { 179, 53, 45, 41, 23, "Ukraine", null },
                    { 180, 26, 23, 57, 51, "United Arab Emirates", null },
                    { 181, 60, 50, 2, -8, "United Kingdom of Great Britain and Northern Ireland", null },
                    { 182, 0, -12, 41, 30, "United Republic of Tanzania", null },
                    { 183, 49, 25, -67, -125, "United States of America", null },
                    { 184, -30, -35, -53, -58, "Uruguay", null },
                    { 185, 46, 37, 73, 56, "Uzbekistan", null },
                    { 186, -12, -17, 171, 166, "Vanuatu", null },
                    { 187, 13, 1, -59, -73, "Venezuela (Bolivarian Republic of)", null },
                    { 188, 24, 9, 110, 102, "Viet Nam", null },
                    { 189, 19, 12, 54, 42, "Yemen", null },
                    { 190, -8, -18, 34, 22, "Zambia", null },
                    { 191, -15, -22, 34, 26, "Zimbabwe", null }
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
