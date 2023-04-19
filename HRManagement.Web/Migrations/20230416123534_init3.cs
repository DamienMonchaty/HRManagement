using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagement.Web.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "fa7b1d7d-8c0a-46ed-8346-b82ca1e1d4d3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "7f57391e-8609-4f49-b465-7524053e4eab");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52ea81eb-e258-4688-8f55-0ceb757d2079", "AQAAAAEAACcQAAAAEMd/5tgbqaQCRLM7p3NdCLdvIHyatQjU/zjxK7AeYzy7dl2g/ZN0Q1QWEwSNyVSVJg==", "63303c06-7d53-4957-af21-0c9f983a68ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4acb6c61-1644-40b5-9d85-73f1f16b05e3", "AQAAAAEAACcQAAAAEL5R3GoAO7/QBuCz6F2MSswBGc6jJM7IGn7w36RFfjC3N+CJnOk+U8a5RXAu3UxQQw==", "d0f7387e-fd4c-4995-9eef-ab00c2260571" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "a6a56662-645b-4cab-8647-3334c8e0ef80");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "80e5ae7d-c472-48cc-b8ee-f2e59f7e84fd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07cdda57-b759-432e-b5ff-e4d0ccf07e91", "AQAAAAEAACcQAAAAEJXb/LigJ7lMdbllQuGT+tjrAoqtbl0kiD7bR89j8ya4e6iAM3HIKO57+73XjNZt/Q==", "906acfd0-fe32-406e-9349-83f51cdaf725" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "747358ff-2001-4762-a848-2f4c4984ad7e", "AQAAAAEAACcQAAAAEHhg8tkc9Ocg4hzqwWgfRK1Ml3Xg0DP7aisR6yixKG4vSJaqLvHoOlClUmwXfKj2qw==", "73def3aa-e485-4d66-9084-9450a74f3020" });
        }
    }
}
