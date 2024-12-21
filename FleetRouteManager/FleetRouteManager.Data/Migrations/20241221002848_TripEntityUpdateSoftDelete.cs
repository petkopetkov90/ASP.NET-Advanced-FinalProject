using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class TripEntityUpdateSoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Trips",
                type: "datetime2",
                nullable: true,
                comment: "Date and time when the Trip was marked as deleted");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Trips",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Indicates if the Trip was deleted");

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeletedOn", "IsDeleted" },
                values: new object[] { null, false });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeletedOn", "IsDeleted" },
                values: new object[] { null, false });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DeletedOn", "IsDeleted" },
                values: new object[] { null, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Trips");
        }
    }
}
