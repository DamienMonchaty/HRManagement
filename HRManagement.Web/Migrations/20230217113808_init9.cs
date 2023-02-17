using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManagement.Web.Migrations
{
    public partial class init9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PositionEnum",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "eac3c699-cb13-403d-af4e-6ceb5fad0d44");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "360b6886-2418-436c-b034-782086fa89ec");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae4ab299-9d20-4601-b1a3-52d66a51fba7", "AQAAAAEAACcQAAAAELMSOUvUf58xxOc5h/LLA0hsIeYdxxbUaPpK8yCJmB0kGvmr8SBsOpxWi4GeZJNcEw==", "bcaed2fc-4411-43ec-87cc-a849f3ff2ccf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "834a7609-14ee-4bbd-ae1b-97c707381c10", "AQAAAAEAACcQAAAAEIqA8ixfuNui9zIBV+G3IH98d0f7i/qK3btpUZc2Isf5R2iQ8ZGTIjRxIglSCoGNgg==", "821ac208-78cf-46ea-b5b9-6a3580e75a32" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PositionEnum",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "f9f56b4b-f19b-4fff-9eb8-3533ced3921d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "ed045040-2648-46f8-9798-617fb0ce6279");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fcfad1e8-0685-4dce-9f4a-8de09a5b1932", "AQAAAAEAACcQAAAAEBfpdmKtyD9ShEsc6qDTtfP/tdyjX7gwskP4ACJ2DTfhT8URkIhPDSCFgsb50Z8hzg==", "d9b01853-54c2-4668-877f-4743e66b96ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "570ba8f4-d634-40b5-a120-671d9388640a", "AQAAAAEAACcQAAAAEOHB232/RlLZqwCu9S2f1f+d8RX5gZLzl3QsmHXXE3O30HRRIIQVXFJ09xLvXPprKQ==", "bdc31f65-fd20-40b4-a89d-e9a19e8fcbab" });
        }
    }
}
