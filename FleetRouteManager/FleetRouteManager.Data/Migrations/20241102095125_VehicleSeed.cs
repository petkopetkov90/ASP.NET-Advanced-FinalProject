using System;
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
                    { 1, new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), null, "Euro6", new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Local), false, "010/LEV/1111111111-11", new DateTime(2025, 10, 28, 0, 0, 0, 0, DateTimeKind.Local), 1, "Atego", "CB 1111 CB", null, null, 1, "MER1111111111" },
                    { 2, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), null, "Euro5", new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), false, "020/LEV/2222222222-22", new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Local), 6, "TGL", "CB 2222 CB", null, new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Local), 2, "MAN2222222222" },
                    { 3, new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "Euro5", new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Local), false, "030/LEV/3333333333-33", new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Local), 6, "TGL", "CB 3333 CB", new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Local), null, 3, "MAN3333333333" },
                    { 4, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), null, "Euro4", new DateTime(2022, 11, 13, 0, 0, 0, 0, DateTimeKind.Local), false, "040/LEV/4444444444-44", new DateTime(2024, 12, 27, 0, 0, 0, 0, DateTimeKind.Local), 7, "R420", "CB 4444 CB", new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Local), 5, "SCA4444444444" }
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
