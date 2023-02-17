using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManagement.Web.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "080dcff4-246c-49e1-9b94-cf8c5286a4a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "d0a685e3-4061-4fd8-99aa-78efc5ef51c0");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "E22678B8-42A2-4115-9631-1CE51E2AC5F7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff847fee-c80b-4bfb-a220-26bd440040ed", "AQAAAAEAACcQAAAAECfX/+STD07B6n1X9meDy/3HXweGLUTdXxDBZbI4VdDQqiRw0A7dlSUuOMOp9PGgKg==", "49c7d14c-9564-4f3a-a62c-54970c0538e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ead91464-e714-44c5-9f82-b87e12288fd0", "AQAAAAEAACcQAAAAEGUVzpOKBwROlabhpk99hUIAl3D3vG5iD2lu5W1OByZUrjRnyL9jZX/W/6oUfllx5Q==", "b6e0632a-65fe-4355-90c5-a11a7a0c0a1b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "E22678B8-42A2-4115-9631-1CE51E2AC5F7" });

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6cae2bef-be45-4e99-9564-c83e4142842e", "AQAAAAEAACcQAAAAEBBY2jShvOhxBcqxvUXFBpfAqQZxsQ5Y9UohsIUdhKLukz/JwXQru/99PRzwcMDnnw==", "6f1440a6-85b8-41fa-91c8-61fe84cd86b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be4ff4a1-1089-4acd-aa5a-88f1c3e96f32", "AQAAAAEAACcQAAAAEFpwYzL0R97mf6JYin4Venk1pVYH+uNb+GFIThfv2JME/2CSY95QSLVaWn/KJLzhuA==", "9bd73d27-02ce-475f-b950-cd44641eb4ac" });
        }
    }
}
