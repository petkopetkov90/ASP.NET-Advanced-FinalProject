using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClientEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key of Client entity")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Client name"),
                    TaxNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Client VAT for business clients or PIN for private clients"),
                    LegalAddressId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key to location"),
                    PostalAddressId = table.Column<int>(type: "int", nullable: true, comment: "Foreign key to location"),
                    PodEmail = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true, comment: "Email address used for sending proofs of deliveries"),
                    InvoicingEmail = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true, comment: "Email address used for sending invoices"),
                    PaymentEmail = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true, comment: "Email address used for payment requests"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicates if the Client was deleted"),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date and time when the Client was marked as deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Locations_LegalAddressId",
                        column: x => x.LegalAddressId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Locations_PostalAddressId",
                        column: x => x.PostalAddressId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "DeletedOn", "InvoicingEmail", "IsDeleted", "LegalAddressId", "Name", "PaymentEmail", "PodEmail", "PostalAddressId", "TaxNumber" },
                values: new object[,]
                {
                    { 1, null, "invoices@dhl.bg", false, 4, "DHL Bulgaria", null, "pod@dhl.bg", 4, "BG11111111" },
                    { 2, null, null, false, 2, "Schenker Bulgaria", null, "pod@schenker.bg", null, "BG22222222" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "CountryId", "DeletedOn", "IsDeleted", "Name", "Number", "PhoneNumber", "PostCode", "Street" },
                values: new object[] { 5, "Wiener Neudorf", 203, null, false, "LKW Walter Wiener Neudorf", "1", null, "2355", "IZ No-Sud Strasse 14" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "VIN",
                value: "MER11111111111111");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "VIN",
                value: "MAN22222222222222");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                column: "VIN",
                value: "MAN33333333333333");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4,
                column: "VIN",
                value: "SCA44444444444444");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "DeletedOn", "InvoicingEmail", "IsDeleted", "LegalAddressId", "Name", "PaymentEmail", "PodEmail", "PostalAddressId", "TaxNumber" },
                values: new object[] { 3, null, "invoicing@lkw-walter.at", false, 5, "LKW Walter", null, "pod@lkw-walter.at", 3, "AT333333333" });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_LegalAddressId",
                table: "Clients",
                column: "LegalAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PostalAddressId",
                table: "Clients",
                column: "PostalAddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "VIN",
                value: "MER1111111111");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "VIN",
                value: "MAN2222222222");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                column: "VIN",
                value: "MAN3333333333");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4,
                column: "VIN",
                value: "SCA4444444444");
        }
    }
}
