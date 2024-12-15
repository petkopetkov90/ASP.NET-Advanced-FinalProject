using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class VehicleTypeSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Axles", "BodyType", "DeletedOn", "IsDeleted", "TruckType", "TypeName", "WeightCapacity" },
                values: new object[,]
                {
                    { 1, 2, "Curtain", null, false, "Truck", "Solo 7.5t", 1.6299999999999999 },
                    { 2, 2, "Curtain", null, false, "Truck", "Solo 12.0t", 4.2999999999999998 },
                    { 3, 3, "Curtain", null, false, "Truck", "Solo 18.0t", 9.8000000000000007 },
                    { 4, 3, "Curtain", null, false, "Truck", "Solo 26.0t", 14.0 },
                    { 5, 2, "None", null, false, "Tractor", "Tractor", 0.0 },
                    { 6, 2, "Box", null, false, "Van", "Van 3.5t", 1.3300000000000001 },
                    { 7, 3, "Open", null, false, "Semitrailer", "Semitrailer", 24.989999999999998 },
                    { 8, 2, "Open", null, false, "Trailer", "Trailer", 8.0999999999999996 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
