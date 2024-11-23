using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class LocationEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key of Location entity")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Location name"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Location phone number"),
                    AddressId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key to Address"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicates if the Location was deleted"),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date and time when the Location was marked as deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AddressId", "DeletedOn", "IsDeleted", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 4, null, false, "Messe Munich", null },
                    { 2, 2, null, false, "DB Schenker Bulgaria", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AddressId",
                table: "Locations",
                column: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
