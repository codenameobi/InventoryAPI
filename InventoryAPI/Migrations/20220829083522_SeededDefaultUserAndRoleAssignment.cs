using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAPI.Migrations
{
    public partial class SeededDefaultUserAndRoleAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4091a765-fc39-43f2-bb8a-85d3d74ffb3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccb7d2af-3b8e-409a-a3f6-be29352ac3ee");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5e1bfb55-3421-474d-b06c-f5137f4e7072", "05dd2ab1-a875-4b24-b470-c152653c1276", "Administrator", "ADMINISTRATOR" },
                    { "b8efb1bf-d355-4058-9d5e-3073b4a0b1f3", "10371898-a5e2-47fb-b3c2-914c8d351d20", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a001f060-5fe2-488b-a199-60cf373f761a", 0, "5e20c659-1c94-4d66-b17b-73ec53567555", "user@localhost.com", true, "Obiora", "Nwude", false, null, "USER@LOCALHOST.COM", "USER", "AQAAAAEAACcQAAAAEKSSivsYQmLH3WSfH7cY72pBDSt+M7ybZcXTGDGAHk3KWoBHcWpl204hI8yPockx0g==", null, false, "f89254e7-475d-46c7-bec7-59f7cc965175", false, "user" },
                    { "a8113fe9-7cee-432c-bc30-fc91cbf56ff6", 0, "b8438697-26dc-4634-80be-0a1913d318df", "admin@localhost.com", true, "Administrator", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", "AQAAAAEAACcQAAAAECx+nv3XMIip0GbENxiz2MDD68SgdBllwEHOYRi/MpHvl2qEPG8+bcrE3kPyCYARjA==", null, false, "4ce1c79d-9c81-47f9-9127-6d67ea4c67fc", false, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b8efb1bf-d355-4058-9d5e-3073b4a0b1f3", "a001f060-5fe2-488b-a199-60cf373f761a" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5e1bfb55-3421-474d-b06c-f5137f4e7072", "a8113fe9-7cee-432c-bc30-fc91cbf56ff6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b8efb1bf-d355-4058-9d5e-3073b4a0b1f3", "a001f060-5fe2-488b-a199-60cf373f761a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5e1bfb55-3421-474d-b06c-f5137f4e7072", "a8113fe9-7cee-432c-bc30-fc91cbf56ff6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e1bfb55-3421-474d-b06c-f5137f4e7072");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8efb1bf-d355-4058-9d5e-3073b4a0b1f3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a001f060-5fe2-488b-a199-60cf373f761a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8113fe9-7cee-432c-bc30-fc91cbf56ff6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4091a765-fc39-43f2-bb8a-85d3d74ffb3a", "98e8bcb2-d747-4243-8bf3-c434a4454b25", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ccb7d2af-3b8e-409a-a3f6-be29352ac3ee", "c2310b68-f0c1-41b6-8860-132bda6fb794", "Administrator", "ADMINISTRATOR" });
        }
    }
}
