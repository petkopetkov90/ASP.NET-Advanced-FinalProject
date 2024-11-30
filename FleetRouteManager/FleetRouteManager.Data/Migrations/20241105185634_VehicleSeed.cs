using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class VehicleSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "AddedOn", "DeletedOn", "EuroClass", "FirstRegistration", "IsDeleted", "LiabilityInsurance", "LiabilityInsuranceExpirationDate", "ManufacturerId", "Model", "RegistrationNumber", "TachographExpirationDate", "TechnicalReviewExpirationDate", "VehicleTypeId", "VIN" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Euro6", new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "010/LEV/1111111111-11", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Atego", "CB 1111 CB", null, null, 1, "MER11111111111111" },
                    { 2, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Euro5", new DateTime(2012, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "020/LEV/2222222222-22", new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "TGL", "CB 2222 CB", null, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "MAN22222222222222" },
                    { 3, new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Euro5", new DateTime(2013, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "030/LEV/3333333333-33", new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "TGL", "CB 3333 CB", new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "MAN33333333333333" },
                    { 4, new DateTime(2024, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Euro4", new DateTime(2014, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "040/LEV/4444444444-44", new DateTime(2025, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "R420", "CB 4444 CB", new DateTime(2025, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "SCA44444444444444" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
