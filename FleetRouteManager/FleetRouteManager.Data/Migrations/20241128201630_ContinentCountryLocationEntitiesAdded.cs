using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class ContinentCountryLocationEntitiesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                comment: "Indicates if the Vehicle was deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicates if the vehicle was deleted");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                table: "Vehicles",
                type: "datetime2",
                nullable: true,
                comment: "Date and time when the Vehicle was marked as deleted",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Date and time when the vehicle was marked as deleted");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Manufacturers",
                type: "bit",
                nullable: false,
                comment: "Indicates if the Manufacturer was deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Soft Delete");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                table: "Manufacturers",
                type: "datetime2",
                nullable: true,
                comment: "Date and time when the Manufacturer was marked as deleted",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Deletion date");

            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key of Continent entity")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false, comment: "Continent name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key of Country entity")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Country name"),
                    ContinentId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key to Continent"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicates if the Country was deleted"),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date and time when the Country was marked as deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Continents_ContinentId",
                        column: x => x.ContinentId,
                        principalTable: "Continents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key of Location entity")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Location name"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Location phone number"),
                    Street = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false, comment: "Street name"),
                    Number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "Street number"),
                    PostCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Post code"),
                    City = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "City name"),
                    CountryId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key to Country"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicates if the Location was deleted"),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date and time when the Location was marked as deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Continents",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Africa" },
                    { 2, "Antarctica" },
                    { 3, "Asia" },
                    { 4, "Europe" },
                    { 5, "North America" },
                    { 6, "Australia" },
                    { 7, "South America" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ContinentId", "DeletedOn", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 1, null, false, "Algeria" },
                    { 2, 1, null, false, "Angola" },
                    { 3, 1, null, false, "Benin" },
                    { 4, 1, null, false, "Botswana" },
                    { 5, 1, null, false, "Burkina Faso" },
                    { 6, 1, null, false, "Burundi" },
                    { 7, 1, null, false, "Cabo Verde" },
                    { 8, 1, null, false, "Cameroon" },
                    { 9, 1, null, false, "Central African Republic" },
                    { 10, 1, null, false, "Chad" },
                    { 11, 1, null, false, "Comoros" },
                    { 12, 1, null, false, "Congo" },
                    { 13, 1, null, false, "Congo (Democratic Republic of the)" },
                    { 14, 1, null, false, "Djibouti" },
                    { 15, 1, null, false, "Egypt" },
                    { 16, 1, null, false, "Equatorial Guinea" },
                    { 17, 1, null, false, "Eritrea" },
                    { 18, 1, null, false, "Eswatini" },
                    { 19, 1, null, false, "Ethiopia" },
                    { 20, 1, null, false, "Gabon" },
                    { 21, 1, null, false, "Gambia" },
                    { 22, 1, null, false, "Ghana" },
                    { 23, 1, null, false, "Guinea" },
                    { 24, 1, null, false, "Guinea-Bissau" },
                    { 25, 1, null, false, "Ivory Coast" },
                    { 26, 1, null, false, "Kenya" },
                    { 27, 1, null, false, "Lesotho" },
                    { 28, 1, null, false, "Liberia" },
                    { 29, 1, null, false, "Libya" },
                    { 30, 1, null, false, "Madagascar" },
                    { 31, 1, null, false, "Malawi" },
                    { 32, 1, null, false, "Mali" },
                    { 33, 1, null, false, "Mauritania" },
                    { 34, 1, null, false, "Mauritius" },
                    { 35, 1, null, false, "Morocco" },
                    { 36, 1, null, false, "Mozambique" },
                    { 37, 1, null, false, "Namibia" },
                    { 38, 1, null, false, "Niger" },
                    { 39, 1, null, false, "Nigeria" },
                    { 40, 1, null, false, "Rwanda" },
                    { 41, 1, null, false, "Sao Tome and Principe" },
                    { 42, 1, null, false, "Senegal" },
                    { 43, 1, null, false, "Seychelles" },
                    { 44, 1, null, false, "Sierra Leone" },
                    { 45, 1, null, false, "Somalia" },
                    { 46, 1, null, false, "South Africa" },
                    { 47, 1, null, false, "South Sudan" },
                    { 48, 1, null, false, "Sudan" },
                    { 49, 1, null, false, "Togo" },
                    { 50, 1, null, false, "Tunisia" },
                    { 51, 1, null, false, "Uganda" },
                    { 52, 1, null, false, "Zambia" },
                    { 53, 1, null, false, "Zimbabwe" },
                    { 100, 2, null, false, "Antarctica" },
                    { 101, 3, null, false, "Afghanistan" },
                    { 102, 3, null, false, "Armenia" },
                    { 103, 3, null, false, "Azerbaijan" },
                    { 104, 3, null, false, "Bahrain" },
                    { 105, 3, null, false, "Bangladesh" },
                    { 106, 3, null, false, "Bhutan" },
                    { 107, 3, null, false, "Brunei" },
                    { 108, 3, null, false, "Cambodia" },
                    { 109, 3, null, false, "China" },
                    { 110, 3, null, false, "Cyprus" },
                    { 111, 3, null, false, "Georgia" },
                    { 112, 3, null, false, "India" },
                    { 113, 3, null, false, "Indonesia" },
                    { 114, 3, null, false, "Iran" },
                    { 115, 3, null, false, "Iraq" },
                    { 116, 3, null, false, "Israel" },
                    { 117, 3, null, false, "Japan" },
                    { 118, 3, null, false, "Jordan" },
                    { 119, 3, null, false, "Kazakhstan" },
                    { 120, 3, null, false, "Kuwait" },
                    { 121, 3, null, false, "Kyrgyzstan" },
                    { 122, 3, null, false, "Laos" },
                    { 123, 3, null, false, "Lebanon" },
                    { 124, 3, null, false, "Malaysia" },
                    { 125, 3, null, false, "Maldives" },
                    { 126, 3, null, false, "Mongolia" },
                    { 127, 3, null, false, "Myanmar (Burma)" },
                    { 128, 3, null, false, "Nepal" },
                    { 129, 3, null, false, "North Korea" },
                    { 130, 3, null, false, "Oman" },
                    { 131, 3, null, false, "Pakistan" },
                    { 132, 3, null, false, "Palestine" },
                    { 133, 3, null, false, "Philippines" },
                    { 134, 3, null, false, "Qatar" },
                    { 135, 3, null, false, "Russia" },
                    { 136, 3, null, false, "Saudi Arabia" },
                    { 137, 3, null, false, "Singapore" },
                    { 138, 3, null, false, "South Korea" },
                    { 139, 3, null, false, "Sri Lanka" },
                    { 140, 3, null, false, "Syria" },
                    { 141, 3, null, false, "Tajikistan" },
                    { 142, 3, null, false, "Thailand" },
                    { 143, 3, null, false, "Timor-Leste" },
                    { 144, 3, null, false, "Turkey" },
                    { 145, 3, null, false, "Turkmenistan" },
                    { 146, 3, null, false, "United Arab Emirates" },
                    { 147, 3, null, false, "Uzbekistan" },
                    { 148, 3, null, false, "Vietnam" },
                    { 149, 3, null, false, "Yemen" },
                    { 201, 4, null, false, "Albania" },
                    { 202, 4, null, false, "Andorra" },
                    { 203, 4, null, false, "Austria" },
                    { 204, 4, null, false, "Belarus" },
                    { 205, 4, null, false, "Belgium" },
                    { 206, 4, null, false, "Bosnia and Herzegovina" },
                    { 207, 4, null, false, "Bulgaria" },
                    { 208, 4, null, false, "Croatia" },
                    { 209, 4, null, false, "Cyprus" },
                    { 210, 4, null, false, "Czech Republic" },
                    { 211, 4, null, false, "Denmark" },
                    { 212, 4, null, false, "Estonia" },
                    { 213, 4, null, false, "Finland" },
                    { 214, 4, null, false, "France" },
                    { 215, 4, null, false, "Georgia" },
                    { 216, 4, null, false, "Germany" },
                    { 217, 4, null, false, "Greece" },
                    { 218, 4, null, false, "Hungary" },
                    { 219, 4, null, false, "Iceland" },
                    { 220, 4, null, false, "Ireland" },
                    { 221, 4, null, false, "Italy" },
                    { 222, 4, null, false, "Kazakhstan" },
                    { 223, 4, null, false, "Kosovo" },
                    { 224, 4, null, false, "Latvia" },
                    { 225, 4, null, false, "Liechtenstein" },
                    { 226, 4, null, false, "Lithuania" },
                    { 227, 4, null, false, "Luxembourg" },
                    { 228, 4, null, false, "Malta" },
                    { 229, 4, null, false, "Moldova" },
                    { 230, 4, null, false, "Monaco" },
                    { 231, 4, null, false, "Montenegro" },
                    { 232, 4, null, false, "Netherlands" },
                    { 233, 4, null, false, "North Macedonia" },
                    { 234, 4, null, false, "Norway" },
                    { 235, 4, null, false, "Poland" },
                    { 236, 4, null, false, "Portugal" },
                    { 237, 4, null, false, "Romania" },
                    { 238, 4, null, false, "Russia" },
                    { 239, 4, null, false, "San Marino" },
                    { 240, 4, null, false, "Serbia" },
                    { 241, 4, null, false, "Slovakia" },
                    { 242, 4, null, false, "Slovenia" },
                    { 243, 4, null, false, "Spain" },
                    { 244, 4, null, false, "Sweden" },
                    { 245, 4, null, false, "Switzerland" },
                    { 301, 5, null, false, "Antigua and Barbuda" },
                    { 302, 5, null, false, "Bahamas" },
                    { 303, 5, null, false, "Barbados" },
                    { 304, 5, null, false, "Belize" },
                    { 305, 5, null, false, "Canada" },
                    { 306, 5, null, false, "Costa Rica" },
                    { 307, 5, null, false, "Cuba" },
                    { 308, 5, null, false, "Dominica" },
                    { 309, 5, null, false, "Dominican Republic" },
                    { 310, 5, null, false, "El Salvador" },
                    { 311, 5, null, false, "Grenada" },
                    { 312, 5, null, false, "Guatemala" },
                    { 313, 5, null, false, "Haiti" },
                    { 314, 5, null, false, "Honduras" },
                    { 315, 5, null, false, "Jamaica" },
                    { 316, 5, null, false, "Mexico" },
                    { 317, 5, null, false, "Nicaragua" },
                    { 318, 5, null, false, "Panama" },
                    { 319, 5, null, false, "Saint Kitts and Nevis" },
                    { 320, 5, null, false, "Saint Lucia" },
                    { 321, 5, null, false, "Saint Vincent and the Grenadines" },
                    { 322, 5, null, false, "Trinidad and Tobago" },
                    { 323, 5, null, false, "United States" },
                    { 400, 6, null, false, "Australia" },
                    { 401, 6, null, false, "Fiji" },
                    { 402, 6, null, false, "Kiribati" },
                    { 403, 6, null, false, "Marshall Islands" },
                    { 404, 6, null, false, "Micronesia" },
                    { 405, 6, null, false, "Nauru" },
                    { 406, 6, null, false, "New Zealand" },
                    { 407, 6, null, false, "Palau" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "CountryId", "DeletedOn", "IsDeleted", "Name", "Number", "PhoneNumber", "PostCode", "Street" },
                values: new object[,]
                {
                    { 1, "Munich", 216, null, false, "Messe Munich", "2", null, "81829", "Am Messesee" },
                    { 2, "Sofia", 207, null, false, "DB Schenker Bulgaria", "5", null, "1540", "Maria Atanasova" },
                    { 3, "Kufstein", 203, null, false, "LKW Walter Kufstein", "1", null, "6330", "Zeller Str." },
                    { 4, "Sofia", 207, null, false, "DHL Bulgaria", "1A", null, "2227", "Europa" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ContinentId",
                table: "Countries",
                column: "ContinentId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CountryId",
                table: "Locations",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Continents");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                comment: "Indicates if the vehicle was deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicates if the Vehicle was deleted");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                table: "Vehicles",
                type: "datetime2",
                nullable: true,
                comment: "Date and time when the vehicle was marked as deleted",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Date and time when the Vehicle was marked as deleted");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Manufacturers",
                type: "bit",
                nullable: false,
                comment: "Soft Delete",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicates if the Manufacturer was deleted");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                table: "Manufacturers",
                type: "datetime2",
                nullable: true,
                comment: "Deletion date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Date and time when the Manufacturer was marked as deleted");
        }
    }
}
