using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class VehicleTypeEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VIN",
                table: "Vehicles",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "Vehicle VIN/Frame number",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Vehicle VIN/frame number");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                comment: "Vehicle Manufacturer",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Type of Vehicle");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FirstRegistration",
                table: "Vehicles",
                type: "datetime2",
                nullable: false,
                comment: "Vehicle First Registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Vehicle first registration");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedOn",
                table: "Vehicles",
                type: "datetime2",
                nullable: false,
                comment: "Vehicle date of bought",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Vehicle adding date");

            migrationBuilder.AddColumn<int>(
                name: "VehicleTypeId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Type of Vehicle");

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key for VehicleType")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TruckType = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Truck type"),
                    BodyType = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Body type"),
                    WeightCapacity = table.Column<double>(type: "float", nullable: false, comment: "Total capacity in tons"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Soft Delete"),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Deletion date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<string>(
                name: "VIN",
                table: "Vehicles",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "Vehicle VIN/frame number",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Vehicle VIN/Frame number");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                comment: "Type of Vehicle",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Vehicle Manufacturer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FirstRegistration",
                table: "Vehicles",
                type: "datetime2",
                nullable: false,
                comment: "Vehicle first registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Vehicle First Registration");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedOn",
                table: "Vehicles",
                type: "datetime2",
                nullable: false,
                comment: "Vehicle adding date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Vehicle date of bought");
        }
    }
}
