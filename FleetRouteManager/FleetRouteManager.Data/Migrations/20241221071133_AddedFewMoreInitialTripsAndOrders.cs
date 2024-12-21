using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedFewMoreInitialTripsAndOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Amount", "ClientId", "DeletedOn", "IsDeleted", "OrderDate", "OrderNumber", "TripId", "User" },
                values: new object[] { 4, 333m, 2, null, false, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Z-11111/24", 3, "petkopetkov900808@gmail.com" });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "DeletedOn", "DriverId", "EndDate", "EndLocationId", "IsDeleted", "SecondDriverId", "StartDate", "StartLocationId", "TripNumber", "User", "VehicleId" },
                values: new object[,]
                {
                    { 4, null, 3, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, null, new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "13/3/2024", "petkopetkov900808@gmail.com", 4 },
                    { 5, null, 1, new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, false, null, new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "16/4/2024", "petkopetkov900808@gmail.com", 1 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Amount", "ClientId", "DeletedOn", "IsDeleted", "OrderDate", "OrderNumber", "TripId", "User" },
                values: new object[,]
                {
                    { 5, 555.50m, 3, null, false, new DateTime(2024, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Z-15123/24", 4, "petkopetkov900808@gmail.com" },
                    { 6, 770m, 1, null, false, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Z-53235/24", 5, "petkopetkov900808@gmail.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
