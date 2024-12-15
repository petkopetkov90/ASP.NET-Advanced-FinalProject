using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClientUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Addresses_LegalAddressId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Addresses_PostalAddressId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Manufacturers_ManufacturerId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "PostalAddressId",
                table: "Clients",
                type: "int",
                nullable: true,
                comment: "Foreign key to location used for postal address",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Foreign key to address");

            migrationBuilder.AlterColumn<int>(
                name: "LegalAddressId",
                table: "Clients",
                type: "int",
                nullable: false,
                comment: "Foreign key to address used for legal address",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Foreign key to address");

            migrationBuilder.AddColumn<string>(
                name: "LegalName",
                table: "Clients",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                comment: "Client legal name");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "CountryId", "DeletedOn", "IsDeleted", "Number", "PostCode", "Street" },
                values: new object[] { 6, "Sofia", 207, null, false, "2B", "1528", "Nedelcho Bonchev" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LegalName", "PaymentEmail" },
                values: new object[] { "DHL Express Bulgaria EOOD", "payments@dhl.bg" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LegalAddressId", "LegalName", "PostalAddressId" },
                values: new object[] { 5, "Schenker EOOD", 4 });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "LegalName",
                value: "LKW WALTER Internationale Transportorganisation AG");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TaxNumber",
                table: "Clients",
                column: "TaxNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Addresses_LegalAddressId",
                table: "Clients",
                column: "LegalAddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Locations_PostalAddressId",
                table: "Clients",
                column: "PostalAddressId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Manufacturers_ManufacturerId",
                table: "Vehicles",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Addresses_LegalAddressId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Locations_PostalAddressId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Manufacturers_ManufacturerId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Clients_TaxNumber",
                table: "Clients");

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "LegalName",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "PostalAddressId",
                table: "Clients",
                type: "int",
                nullable: true,
                comment: "Foreign key to address",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Foreign key to location used for postal address");

            migrationBuilder.AlterColumn<int>(
                name: "LegalAddressId",
                table: "Clients",
                type: "int",
                nullable: false,
                comment: "Foreign key to address",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Foreign key to address used for legal address");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentEmail",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LegalAddressId", "PostalAddressId" },
                values: new object[] { 4, null });

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Addresses_LegalAddressId",
                table: "Clients",
                column: "LegalAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Addresses_PostalAddressId",
                table: "Clients",
                column: "PostalAddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Manufacturers_ManufacturerId",
                table: "Vehicles",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id");
        }
    }
}
