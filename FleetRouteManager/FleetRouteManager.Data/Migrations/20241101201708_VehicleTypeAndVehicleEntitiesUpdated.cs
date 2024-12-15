using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class VehicleTypeAndVehicleEntitiesUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Vehicles_Axles",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Axles",
                table: "Vehicles");

            migrationBuilder.AddColumn<int>(
                name: "Axles",
                table: "VehicleTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Vehicle number of axles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Axles",
                table: "VehicleTypes");

            migrationBuilder.AddColumn<int>(
                name: "Axles",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Vehicle number of axles");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Vehicles_Axles",
                table: "Vehicles",
                sql: "Axles >= 2 AND Axles <= 6");
        }
    }
}
