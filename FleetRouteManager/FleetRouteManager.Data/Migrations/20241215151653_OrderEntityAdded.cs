using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrderEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key for Driver entity")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Order number"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "date of issue of the Order"),
                    ClientId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key to Client"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicates if the Order was deleted"),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date and time when the Order was marked as deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ClientId", "DeletedOn", "IsDeleted", "OrderDate", "OrderNumber" },
                values: new object[,]
                {
                    { 1, 1, null, false, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "43/ZTE/240412" },
                    { 2, 2, null, false, new DateTime(2024, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "240613/125" },
                    { 3, 3, null, false, new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "1324141" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderNumber",
                table: "Orders",
                column: "OrderNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
