using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManagement.Web.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "e51fd985-5d10-463f-8b5d-48360cb9d5f6", "P1@P.FR", "P1@P.FR", "$2a$11$9VALPRFIZ/opL2W98vRfwulqhf2iG7NmZMHdtCc.wWeN4ESrm4b4q", "e727bcd4-29cf-46c9-85ce-6395cafe42df", "p1@p.fr" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1da3b206-e301-4c01-acc3-0015c3cb465c", "P2@P.FR", "P2@P.FR", "$2a$11$Qocihg9wWabUNUXWmS/xwuM2w2W5VNTKBB9JhyWE9ltX2RnbtcZIS", "5e4e4f28-40bc-4e9e-857a-7816d25f7b9a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "89f255b2-9b22-4914-9005-5ea62cd92050");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "eb8d053d-46bf-4057-9477-5d24911dd9a1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "df0370b9-65bc-48bc-be48-36e6879c2177", null, null, "$2a$11$9pztfjFTae7zVQuw/3vWbu/oIyNfWWR93VBAJCUl0eK/m2.YxeZTm", "ce16a570-1732-4867-8574-82428aaa9aa3", "prenom1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c486ac3a-cda2-4eb2-9cb9-306868252d2f", null, null, "$2a$11$FNLWLa6A6aMfYE.q83aJWelYN3Kq22JVcN0/2dsV2/qGoHTCxPBzS", "6f0aee73-462d-43a8-a276-972ba1d9d8f3" });
        }
    }
}
