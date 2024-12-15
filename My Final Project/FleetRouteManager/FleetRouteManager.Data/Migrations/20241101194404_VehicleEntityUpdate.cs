using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class VehicleEntityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "VehicleTypeId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                comment: "Foreign key to the VehicleType",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Type of Vehicle");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                comment: "Foreign key to the Manufacturer",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Vehicle Manufacturer");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                comment: "Indicates if the vehicle was deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Soft Delete");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                table: "Vehicles",
                type: "datetime2",
                nullable: true,
                comment: "Date and time when the vehicle was marked as deleted",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Deletion date");

            migrationBuilder.AlterColumn<int>(
                name: "Axles",
                table: "Vehicles",
                type: "int",
                nullable: false,
                comment: "Vehicle number of axles",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Vehicle Axles count");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedOn",
                table: "Vehicles",
                type: "datetime2",
                nullable: false,
                comment: "Vehicle Date of Purchase",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Vehicle date of bought");

            migrationBuilder.AddColumn<string>(
                name: "LiabilityInsurance",
                table: "Vehicles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Vehicle Liability Insurance policy number");

            migrationBuilder.AddColumn<DateTime>(
                name: "LiabilityInsuranceExpirationDate",
                table: "Vehicles",
                type: "datetime2",
                nullable: true,
                comment: "Vehicle Liability Insurance expiration date");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Vehicles",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                comment: "Vehicle Model");

            migrationBuilder.AddColumn<DateTime>(
                name: "TachographExpirationDate",
                table: "Vehicles",
                type: "datetime2",
                nullable: true,
                comment: "Vehicle Tachograph Certification expiration date");

            migrationBuilder.AddColumn<DateTime>(
                name: "TechnicalReviewExpirationDate",
                table: "Vehicles",
                type: "datetime2",
                nullable: true,
                comment: "Vehicle Technical Review expiration date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LiabilityInsurance",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "LiabilityInsuranceExpirationDate",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "TachographExpirationDate",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "TechnicalReviewExpirationDate",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleTypeId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                comment: "Type of Vehicle",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Foreign key to the VehicleType");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                comment: "Vehicle Manufacturer",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Foreign key to the Manufacturer");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                comment: "Soft Delete",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicates if the vehicle was deleted");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                table: "Vehicles",
                type: "datetime2",
                nullable: true,
                comment: "Deletion date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Date and time when the vehicle was marked as deleted");

            migrationBuilder.AlterColumn<int>(
                name: "Axles",
                table: "Vehicles",
                type: "int",
                nullable: false,
                comment: "Vehicle Axles count",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Vehicle number of axles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedOn",
                table: "Vehicles",
                type: "datetime2",
                nullable: false,
                comment: "Vehicle date of bought",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Vehicle Date of Purchase");
        }
    }
}
