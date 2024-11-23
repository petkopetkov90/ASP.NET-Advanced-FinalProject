using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class ContitentEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                comment: "Indicates if the Vehicle was deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicates if the vehicle was deleted");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                table: "Vehicles",
                type: "datetime2",
                nullable: true,
                comment: "Date and time when the Vehicle was marked as deleted",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Date and time when the vehicle was marked as deleted");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Manufacturers",
                type: "bit",
                nullable: false,
                comment: "Indicates if the Manufacturer was deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Soft Delete");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                table: "Manufacturers",
                type: "datetime2",
                nullable: true,
                comment: "Date and time when the Manufacturer was marked as deleted",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Deletion date");

            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key of Continent entity")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Continent name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Continents",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Africa" },
                    { 2, "Antarctica" },
                    { 3, "Asia" },
                    { 4, "Europe" },
                    { 5, "North America" },
                    { 6, "Australia" },
                    { 7, "South America" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Continents");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                comment: "Indicates if the vehicle was deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicates if the Vehicle was deleted");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                table: "Vehicles",
                type: "datetime2",
                nullable: true,
                comment: "Date and time when the vehicle was marked as deleted",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Date and time when the Vehicle was marked as deleted");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Manufacturers",
                type: "bit",
                nullable: false,
                comment: "Soft Delete",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicates if the Manufacturer was deleted");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                table: "Manufacturers",
                type: "datetime2",
                nullable: true,
                comment: "Deletion date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Date and time when the Manufacturer was marked as deleted");
        }
    }
}
