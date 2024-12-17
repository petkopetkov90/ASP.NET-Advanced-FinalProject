using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetRouteManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClientPostalLocationPropertyRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Locations_PostalAddressId",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "PostalAddressId",
                table: "Clients",
                newName: "PostalLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_PostalAddressId",
                table: "Clients",
                newName: "IX_Clients_PostalLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Locations_PostalLocationId",
                table: "Clients",
                column: "PostalLocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Locations_PostalLocationId",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "PostalLocationId",
                table: "Clients",
                newName: "PostalAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_PostalLocationId",
                table: "Clients",
                newName: "IX_Clients_PostalAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Locations_PostalAddressId",
                table: "Clients",
                column: "PostalAddressId",
                principalTable: "Locations",
                principalColumn: "Id");
        }
    }
}
