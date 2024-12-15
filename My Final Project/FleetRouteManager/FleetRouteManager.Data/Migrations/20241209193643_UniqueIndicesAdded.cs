using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class UniqueIndicesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Vehicles_VehicleId",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Clients_TaxNumber",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "ComputedNumber",
                table: "Addresses",
                type: "nvarchar(450)",
                nullable: false,
                computedColumnSql: "ISNULL(Number, '-1')",
                stored: false);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_Type",
                table: "VehicleTypes",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Name_AddressId",
                table: "Locations",
                columns: new[] { "Name", "AddressId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name_ContinentId",
                table: "Countries",
                columns: new[] { "Name", "ContinentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Continents_Name",
                table: "Continents",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Name_AddressId_TaxNumber",
                table: "Clients",
                columns: new[] { "Name", "AddressId", "TaxNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Street_ComputedNumber_PostCode_City_CountryId",
                table: "Addresses",
                columns: new[] { "Street", "ComputedNumber", "PostCode", "City", "CountryId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Vehicles_VehicleId",
                table: "Drivers",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Vehicles_VehicleId",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_VehicleTypes_Type",
                table: "VehicleTypes");

            migrationBuilder.DropIndex(
                name: "IX_Locations_Name_AddressId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Countries_Name_ContinentId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Continents_Name",
                table: "Continents");

            migrationBuilder.DropIndex(
                name: "IX_Clients_Name_AddressId_TaxNumber",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_Street_ComputedNumber_PostCode_City_CountryId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ComputedNumber",
                table: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TaxNumber",
                table: "Clients",
                column: "TaxNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Vehicles_VehicleId",
                table: "Drivers",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}
