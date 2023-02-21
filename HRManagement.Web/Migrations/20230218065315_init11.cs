using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManagement.Web.Migrations
{
    public partial class init11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "7aed4f30-c323-4545-af9d-afdb2bacb84e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "ac89b189-8d34-4e4f-9944-9f6bd297bc76");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "470e1185-3fa9-4dc4-845d-12df990d0e2e", "AQAAAAEAACcQAAAAEJAYeSx7DBWC9EGozMFqmTBK+Uu3XEU4w0xULBsvoOGMzkc2Ah7PVwE0NuUf11ssDQ==", "88dd722b-eb7e-40d0-8a60-f86b4f3bc739" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da1d10cd-3bd0-41e1-ae11-81ba746ab461", "AQAAAAEAACcQAAAAELwmv1Z8ZQqKdKArGQ05s/t5inLfExG3HE7NIGkfEDYLaNYa4JALqGu27gF/ndFPcg==", "99be1755-8d2a-4292-89a9-a1f8b04f3d1a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
