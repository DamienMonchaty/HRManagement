using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManagement.Web.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "ed5d107c-0999-4e5e-9c52-c62e4ba9a4a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "0bfaead5-416e-4885-a905-0b90bb0fcacb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdd4b0ec-7aed-4020-8912-94355e40b957", "p1@p.fr", true, "$2a$11$Wbp1/74789.Dr5kmFZgBYuGTjQF8..Iu7HTdUfLmicDCTKS4bQan.", "3f10b981-9b36-4b93-869f-18a1ea1fb5a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92306ee0-e3a9-4c41-829b-340d0827c46f", "p2@p.fr", true, "$2a$11$ppBJR8mGGajYzgvZL41A/uJztKN62XfA5VjrTACyxDYCLXBRQbGty", "7f5e9ecd-95bc-4160-86e6-3e655e7e1268" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "e15b5f32-7c03-4a37-9c83-21ffcfd1d0bb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "c801d6a6-ef8a-4b22-a218-0e8d2deeedc5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3f8a128-61e5-45a9-bed8-ccac80e8c430", null, false, "$2a$11$W9nd.fw8d7VFNoszFBaFV.oF94xyKotv3P4VqYPQ9P..KTxG0ktHC", "5ae2b609-fd46-4f3e-859d-1adff22d99a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38c5e2ae-8840-4fc2-a7bc-4586c1ca7877", null, false, "$2a$11$B9JCIekOZMzgUdM6OeBLWeLUotDNWIXieYAW.eDkvJRsn4pueRHW.", "3deba771-f85c-4daa-ad9d-0594834caae5" });
        }
    }
}
