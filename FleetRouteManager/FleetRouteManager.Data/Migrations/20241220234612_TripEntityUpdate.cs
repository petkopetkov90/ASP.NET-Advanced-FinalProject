using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class TripEntityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Trip_TripId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trip",
                table: "Trip");

            migrationBuilder.RenameTable(
                name: "Trip",
                newName: "Trips");

            migrationBuilder.AlterColumn<string>(
                name: "User",
                table: "Orders",
                type: "nvarchar(254)",
                maxLength: 254,
                nullable: false,
                comment: "User who created the Order",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldComment: "User who created the Order");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Orders",
                type: "int",
                nullable: false,
                comment: "Primary Key for Order entity",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Primary Key for Driver entity")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Trips",
                type: "int",
                nullable: false,
                comment: "Primary Key for Trip entity",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Foreign key to Driver");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Trips",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Trip end date");

            migrationBuilder.AddColumn<int>(
                name: "EndLocationId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Foreign key to Location");

            migrationBuilder.AddColumn<int>(
                name: "SecondDriverId",
                table: "Trips",
                type: "int",
                nullable: true,
                comment: "Foreign key to Driver");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Trips",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Trip start date");

            migrationBuilder.AddColumn<int>(
                name: "StartLocationId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Foreign key to Location");

            migrationBuilder.AddColumn<string>(
                name: "TripNumber",
                table: "Trips",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                comment: "Trip number");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Trips",
                type: "nvarchar(254)",
                maxLength: 254,
                nullable: false,
                defaultValue: "",
                comment: "Person who managing this Trip");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Foreign key to Vehicle");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trips",
                table: "Trips",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "DriverId", "EndDate", "EndLocationId", "SecondDriverId", "StartDate", "StartLocationId", "TripNumber", "User", "VehicleId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "1/1/2024", "admin@myapp.com", 1 },
                    { 2, 2, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "1/1/2024", "admin@myapp.com", 2 },
                    { 3, 3, new DateTime(2024, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "1/1/2024", "admin@myapp.com", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_DriverId",
                table: "Trips",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_EndLocationId",
                table: "Trips",
                column: "EndLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_SecondDriverId",
                table: "Trips",
                column: "SecondDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_StartLocationId",
                table: "Trips",
                column: "StartLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_TripNumber_VehicleId",
                table: "Trips",
                columns: new[] { "TripNumber", "VehicleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_VehicleId",
                table: "Trips",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Trips_TripId",
                table: "Orders",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Drivers_DriverId",
                table: "Trips",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Drivers_SecondDriverId",
                table: "Trips",
                column: "SecondDriverId",
                principalTable: "Drivers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Locations_EndLocationId",
                table: "Trips",
                column: "EndLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Locations_StartLocationId",
                table: "Trips",
                column: "StartLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Vehicles_VehicleId",
                table: "Trips",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Trips_TripId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Drivers_DriverId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Drivers_SecondDriverId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Locations_EndLocationId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Locations_StartLocationId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Vehicles_VehicleId",
                table: "Trips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trips",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_DriverId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_EndLocationId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_SecondDriverId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_StartLocationId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_TripNumber_VehicleId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_VehicleId",
                table: "Trips");

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "EndLocationId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "SecondDriverId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "StartLocationId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "TripNumber",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Trips");

            migrationBuilder.RenameTable(
                name: "Trips",
                newName: "Trip");

            migrationBuilder.AlterColumn<string>(
                name: "User",
                table: "Orders",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                comment: "User who created the Order",
                oldClrType: typeof(string),
                oldType: "nvarchar(254)",
                oldMaxLength: 254,
                oldComment: "User who created the Order");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Orders",
                type: "int",
                nullable: false,
                comment: "Primary Key for Driver entity",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Primary Key for Order entity")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Trip",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Primary Key for Trip entity")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trip",
                table: "Trip",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Trip_TripId",
                table: "Orders",
                column: "TripId",
                principalTable: "Trip",
                principalColumn: "Id");
        }
    }
}
