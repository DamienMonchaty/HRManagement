using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManagement.Web.Migrations
{
    public partial class init23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "cf5e1f87-77f9-4117-937f-50b161d31578");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "2a4ca95b-9c20-4189-9bf4-a5ee034038cf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73768a64-fac9-4dfa-95a8-626b36f56d70", "AQAAAAEAACcQAAAAEMvPkJ+ZbRe0rPq/qT36t3os/LBYimjktUgUPfKwL3M53mjZJ84ZeTDb5Z02CNKRXw==", "d4d3a9f5-3b2c-4753-8db1-cb8298c765ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afde54ec-3403-4d80-a7d8-6a5c43f7e1a9", "AQAAAAEAACcQAAAAEI6pRHxH3ihaUj5B2lBjt8iBH6Q4W32n7l0q/Q1ilgChKYrsKi7NYj9l28S5mpK7ew==", "739147c5-794e-411a-b9fc-e4a456f25936" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "20a62299-a776-4082-a08c-f0f10ed14ae2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "bfe6609e-e382-4e35-88f2-8bea8e06a4f5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4218d6a4-31f3-46f0-abcb-4885d656c9ba", "AQAAAAEAACcQAAAAEJqXyd7qAtKH/r0RMFyTHB9NNHZ9LeAXBirZmiGkCXbcbeyPzR7n54ZZUotWj3XAgg==", "d9d3502d-5b23-49b2-8e25-40f6b8801b4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2310ee2b-5fcf-4550-bf94-4746edb5e909", "AQAAAAEAACcQAAAAENIZXMsYqK814QhD5j0zXMGuRLhhvv+3vJ1WflpqlMvktBIH8n41VrA57QUD0vnstg==", "d921287f-c686-4f75-9bb0-c9703f4c3b60" });
        }
    }
}
