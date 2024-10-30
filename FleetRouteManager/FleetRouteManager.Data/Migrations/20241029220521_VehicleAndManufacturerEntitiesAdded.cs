using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class VehicleAndManufacturerEntitiesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key for Manufacturer entity")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Manufacturer Name"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Soft Delete"),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Deletion date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key for Vehicle entity")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Vehicle Registration Number"),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false, comment: "Type of Vehicle"),
                    VIN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Vehicle VIN/frame number"),
                    FirstRegistration = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Vehicle first registration"),
                    EuroClass = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Vehicle Emission Class"),
                    Axles = table.Column<int>(type: "int", nullable: false, comment: "Vehicle Axles count"),
                    Vehicleweight = table.Column<double>(name: "Vehicle weight", type: "float", nullable: false),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Vehicle Type"),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Vehicle adding date"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Soft Delete"),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Deletion date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.CheckConstraint("CK_Vehicles_Axles", "Axles >= 2 AND Axles <= 6");
                    table.ForeignKey(
                        name: "FK_Vehicles_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "DeletedOn", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, null, false, "Mercedes" },
                    { 2, null, false, "Ford" },
                    { 3, null, false, "Renault" },
                    { 4, null, false, "Volkswagen" },
                    { 5, null, false, "Iveco" },
                    { 6, null, false, "Man" },
                    { 7, null, false, "Scania" },
                    { 8, null, false, "Volvo" },
                    { 9, null, false, "Schmitz" },
                    { 10, null, false, "Krone" },
                    { 11, null, false, "Fruehauf" },
                    { 12, null, false, "Peugeot" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_Name",
                table: "Manufacturers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ManufacturerId",
                table: "Vehicles",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_RegistrationNumber",
                table: "Vehicles",
                column: "RegistrationNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
