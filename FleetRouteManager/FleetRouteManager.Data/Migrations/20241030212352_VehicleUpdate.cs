using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class VehicleUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vehicle weight",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleType",
                table: "Vehicles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Vehicle weight",
                table: "Vehicles",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "VehicleType",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Vehicle Type");
        }
    }
}
