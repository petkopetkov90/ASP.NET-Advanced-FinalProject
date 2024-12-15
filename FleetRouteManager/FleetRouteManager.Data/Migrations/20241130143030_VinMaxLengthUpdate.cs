using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class VinMaxLengthUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VIN",
                table: "Vehicles",
                type: "nvarchar(17)",
                maxLength: 17,
                nullable: false,
                comment: "Vehicle VIN/Frame number",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Vehicle VIN/Frame number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VIN",
                table: "Vehicles",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "Vehicle VIN/Frame number",
                oldClrType: typeof(string),
                oldType: "nvarchar(17)",
                oldMaxLength: 17,
                oldComment: "Vehicle VIN/Frame number");
        }
    }
}
