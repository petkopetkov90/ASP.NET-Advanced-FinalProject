using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class VehicleTypeAndVehicleRefactored : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Axles",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "BodyType",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "TruckType",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "WeightCapacity",
                table: "VehicleTypes");

            migrationBuilder.RenameColumn(
                name: "AddedOn",
                table: "Vehicles",
                newName: "AcquiredOn");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "VehicleTypes",
                type: "bit",
                nullable: false,
                comment: "Indicates if the Type was deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Soft Delete");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                table: "VehicleTypes",
                type: "datetime2",
                nullable: true,
                comment: "Date and time when the Type was marked as deleted",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Deletion date");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "VehicleTypes",
                type: "int",
                nullable: false,
                comment: "Primary key for Vehicle Type",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Primary Key for VehicleType")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "VehicleTypes",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "Type of vehicle");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleTypeId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                comment: "Vehicle type foreign key",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Foreign key to the VehicleType");

            migrationBuilder.AddColumn<int>(
                name: "Axles",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Vehicle number of axles");

            migrationBuilder.AddColumn<string>(
                name: "BodyType",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Body type");

            migrationBuilder.AddColumn<double>(
                name: "WeightCapacity",
                table: "Vehicles",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "Total capacity in tons");

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Solo 7.5t");

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "Solo 12.0t");

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: "Solo 18.0t");

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Type",
                value: "Truck 26.0t");

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Type",
                value: "Tractor");

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Type",
                value: "Van 3.5t");

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Type",
                value: "Semitrailer");

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "Type",
                value: "Trailer");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Axles", "BodyType", "WeightCapacity" },
                values: new object[] { 2, "Curtain", 1.6399999999999999 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Axles", "BodyType", "WeightCapacity" },
                values: new object[] { 2, "Box", 4.7000000000000002 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Axles", "BodyType", "WeightCapacity" },
                values: new object[] { 3, "Frigo", 9.0 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Axles", "BodyType", "WeightCapacity" },
                values: new object[] { 2, "None", 0.0 });

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "Axles",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "BodyType",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "WeightCapacity",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "AcquiredOn",
                table: "Vehicles",
                newName: "AddedOn");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "VehicleTypes",
                type: "bit",
                nullable: false,
                comment: "Soft Delete",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicates if the Type was deleted");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                table: "VehicleTypes",
                type: "datetime2",
                nullable: true,
                comment: "Deletion date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Date and time when the Type was marked as deleted");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "VehicleTypes",
                type: "int",
                nullable: false,
                comment: "Primary Key for VehicleType",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Primary key for Vehicle Type")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Axles",
                table: "VehicleTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Vehicle number of axles");

            migrationBuilder.AddColumn<string>(
                name: "BodyType",
                table: "VehicleTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Body type");

            migrationBuilder.AddColumn<string>(
                name: "TruckType",
                table: "VehicleTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Truck type");

            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "VehicleTypes",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "Vehicle type name");

            migrationBuilder.AddColumn<double>(
                name: "WeightCapacity",
                table: "VehicleTypes",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "Total capacity in tons");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleTypeId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                comment: "Foreign key to the VehicleType",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Vehicle type foreign key");

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Axles", "BodyType", "TruckType", "TypeName", "WeightCapacity" },
                values: new object[] { 2, "Curtain", "Truck", "Solo 7.5t", 1.6299999999999999 });

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Axles", "BodyType", "TruckType", "TypeName", "WeightCapacity" },
                values: new object[] { 2, "Curtain", "Truck", "Solo 12.0t", 4.2999999999999998 });

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Axles", "BodyType", "TruckType", "TypeName", "WeightCapacity" },
                values: new object[] { 3, "Curtain", "Truck", "Solo 18.0t", 9.8000000000000007 });

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Axles", "BodyType", "TruckType", "TypeName", "WeightCapacity" },
                values: new object[] { 3, "Curtain", "Truck", "Solo 26.0t", 14.0 });

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Axles", "BodyType", "TruckType", "TypeName", "WeightCapacity" },
                values: new object[] { 2, "None", "Tractor", "Tractor", 0.0 });

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Axles", "BodyType", "TruckType", "TypeName", "WeightCapacity" },
                values: new object[] { 2, "Box", "Van", "Van 3.5t", 1.3300000000000001 });

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Axles", "BodyType", "TruckType", "TypeName", "WeightCapacity" },
                values: new object[] { 3, "Open", "Semitrailer", "Semitrailer", 24.989999999999998 });

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Axles", "BodyType", "TruckType", "TypeName", "WeightCapacity" },
                values: new object[] { 2, "Open", "Trailer", "Trailer", 8.0999999999999996 });

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id");
        }
    }
}
