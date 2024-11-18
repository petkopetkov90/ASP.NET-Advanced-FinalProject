using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class DriverEntityAddedAndSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key for Driver entity")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Driver's First Name"),
                    MiddleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Driver's Middle Name"),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Driver's Last Name"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Driver's main Phone Number"),
                    AdditionalPhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Driver's second Phone Number, if have"),
                    DrivingLicense = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Driver's Driving License"),
                    DrivingLicenseExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Driver's Driving License expiration date"),
                    IdentityCard = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Driver's Identity Card"),
                    IdentityCardExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Driver's Identity Card expiration date"),
                    PersonalIdentificationNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Driver's Personal Identification Number"),
                    ProfessionalQualificationCard = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Driver's Professional Qualification Card"),
                    ProfessionalQualificationCardExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Driver's Professional Qualification Card expiration date"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Driver's date of birth"),
                    EmployedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Driver's employing date"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicates if the Driver was released"),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date and time when the Driver was marked as released")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "AdditionalPhoneNumber", "DateOfBirth", "DeletedOn", "DrivingLicense", "DrivingLicenseExpirationDate", "EmployedAt", "FirstName", "IdentityCard", "IdentityCardExpirationDate", "IsDeleted", "LastName", "MiddleName", "PersonalIdentificationNumber", "PhoneNumber", "ProfessionalQualificationCard", "ProfessionalQualificationCardExpirationDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D111111111", new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivan", "111111111", new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Ivanov", "Ivanov", "0101010101", "+359 888 111111", "PQ111111", new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, new DateTime(2002, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D222222222", new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Georgi", "222222222", new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Georgiev", "Georgiev", "0202020202", "+359 888 222222", "PQ222222", new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "D333333333", new DateTime(2025, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Petar", "333333333", new DateTime(2025, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Petrov", "Petrov", "0303030303", "+359 888 333333", "PQ111111", new DateTime(2025, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_PersonalIdentificationNumber",
                table: "Drivers",
                column: "PersonalIdentificationNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
