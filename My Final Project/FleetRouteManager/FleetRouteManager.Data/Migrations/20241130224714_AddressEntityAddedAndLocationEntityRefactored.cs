using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddressEntityAddedAndLocationEntityRefactored : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Locations_LegalAddressId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Locations_PostalAddressId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Countries_CountryId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_CountryId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Locations");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Foreign key to Address");

            migrationBuilder.AlterColumn<int>(
                name: "PostalAddressId",
                table: "Clients",
                type: "int",
                nullable: true,
                comment: "Foreign key to address",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Foreign key to location");

            migrationBuilder.AlterColumn<int>(
                name: "LegalAddressId",
                table: "Clients",
                type: "int",
                nullable: false,
                comment: "Foreign key to address",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Foreign key to location");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key of Address entity")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false, comment: "Street name"),
                    Number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "Street number"),
                    PostCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Post code"),
                    City = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "City name"),
                    CountryId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key to Country"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicates if the Address was deleted"),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date and time when the Address was marked as deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "CountryId", "DeletedOn", "IsDeleted", "Number", "PostCode", "Street" },
                values: new object[,]
                {
                    { 1, "Munich", 216, null, false, "2", "81829", "Am Messesee" },
                    { 2, "Sofia", 207, null, false, "5", "1540", "Maria Atanasova" },
                    { 3, "Kufstein", 203, null, false, "1", "6330", "Zeller Str." },
                    { 4, "Sofia", 207, null, false, "1A", "2227", "Europa" },
                    { 5, "Wiener Neudorf", 203, null, false, "1", "2355", "IZ No-Sud Strasse 14" }
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LegalAddressId", "PostalAddressId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "LegalAddressId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddressId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddressId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddressId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                column: "AddressId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5,
                column: "AddressId",
                value: 5);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AddressId",
                table: "Locations",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

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
                name: "FK_Locations_Addresses_AddressId",
                table: "Locations",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Addresses_LegalAddressId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Addresses_PostalAddressId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Addresses_AddressId",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Locations_AddressId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Locations");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Locations",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "",
                comment: "City name");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Foreign key to Country");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Locations",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                comment: "Street number");

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "Locations",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "Post code");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Locations",
                type: "nvarchar(58)",
                maxLength: 58,
                nullable: false,
                defaultValue: "",
                comment: "Street name");

            migrationBuilder.AlterColumn<int>(
                name: "PostalAddressId",
                table: "Clients",
                type: "int",
                nullable: true,
                comment: "Foreign key to location",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Foreign key to address");

            migrationBuilder.AlterColumn<int>(
                name: "LegalAddressId",
                table: "Clients",
                type: "int",
                nullable: false,
                comment: "Foreign key to location",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Foreign key to address");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LegalAddressId", "PostalAddressId" },
                values: new object[] { 4, 4 });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "LegalAddressId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "CountryId", "Number", "PostCode", "Street" },
                values: new object[] { "Munich", 216, "2", "81829", "Am Messesee" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "City", "CountryId", "Number", "PostCode", "Street" },
                values: new object[] { "Sofia", 207, "5", "1540", "Maria Atanasova" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "City", "CountryId", "Number", "PostCode", "Street" },
                values: new object[] { "Kufstein", 203, "1", "6330", "Zeller Str." });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "City", "CountryId", "Number", "PostCode", "Street" },
                values: new object[] { "Sofia", 207, "1A", "2227", "Europa" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "City", "CountryId", "Number", "PostCode", "Street" },
                values: new object[] { "Wiener Neudorf", 203, "1", "2355", "IZ No-Sud Strasse 14" });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CountryId",
                table: "Locations",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Locations_LegalAddressId",
                table: "Clients",
                column: "LegalAddressId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Locations_PostalAddressId",
                table: "Clients",
                column: "PostalAddressId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Countries_CountryId",
                table: "Locations",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
