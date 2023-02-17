using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManagement.Web.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "b2a991d3-64c2-41f5-ada0-33e06c7e4f0f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "7bc295cd-d840-4996-82c2-6a2109dc1a73");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "6cae2bef-be45-4e99-9564-c83e4142842e", "AQAAAAEAACcQAAAAEBBY2jShvOhxBcqxvUXFBpfAqQZxsQ5Y9UohsIUdhKLukz/JwXQru/99PRzwcMDnnw==", true, "6f1440a6-85b8-41fa-91c8-61fe84cd86b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "be4ff4a1-1089-4acd-aa5a-88f1c3e96f32", "AQAAAAEAACcQAAAAEFpwYzL0R97mf6JYin4Venk1pVYH+uNb+GFIThfv2JME/2CSY95QSLVaWn/KJLzhuA==", true, "9bd73d27-02ce-475f-b950-cd44641eb4ac" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "4e05c87c-e14d-458d-a558-27c6f94fd964");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "bd54d703-e248-4cd2-86b6-4d92a0eff559");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "e51fd985-5d10-463f-8b5d-48360cb9d5f6", "$2a$11$9VALPRFIZ/opL2W98vRfwulqhf2iG7NmZMHdtCc.wWeN4ESrm4b4q", false, "e727bcd4-29cf-46c9-85ce-6395cafe42df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "1da3b206-e301-4c01-acc3-0015c3cb465c", "$2a$11$Qocihg9wWabUNUXWmS/xwuM2w2W5VNTKBB9JhyWE9ltX2RnbtcZIS", false, "5e4e4f28-40bc-4e9e-857a-7816d25f7b9a" });
        }
    }
}
