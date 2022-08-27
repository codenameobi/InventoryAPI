using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAPI.Migrations
{
    public partial class SeededDefaultRolesandEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2cbf9a43-a757-4cde-8388-c0c08839eca0", "944f1a57-cf6d-4d17-ac5c-6eb8737828fe", "Administrator", "ADMINISTRATOR" },
                    { "87768f73-aa92-4e94-a3bf-9514efd1b0ff", "27170b2a-1ceb-4860-b8e7-b4d05ca54ca1", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ModifiedBy", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), " ", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Main Event" },
                    { 2, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), " ", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ladies Nite" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cbf9a43-a757-4cde-8388-c0c08839eca0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87768f73-aa92-4e94-a3bf-9514efd1b0ff");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
