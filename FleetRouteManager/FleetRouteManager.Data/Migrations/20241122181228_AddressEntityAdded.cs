using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddressEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key of Address Entity")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false, comment: "Street name"),
                    Number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "Street number"),
                    PostCode = table.Column<int>(type: "int", nullable: false, comment: "Post code"),
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
                    { 1, "Sofia", 207, null, false, "5", 1540, "Maria Atanasova" },
                    { 2, "Sofia", 207, null, false, "1A", 1540, "Europa" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
