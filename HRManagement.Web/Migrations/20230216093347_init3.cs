using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManagement.Web.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthCountry",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BirthPlace",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Street1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Street1", "Street2", "Street3", "ZipCode" },
                values: new object[,]
                {
                    { "B22699V4-42A2-4666-9631-1C2D1E2QE4F7", "NICE", "RUE ALBERT 1er", "autres", "autres", "06000" },
                    { "C44698B8-89A2-4115-9631-1C2D1E2AC5F7", "LYON", "RUE Jean Jaurès", "autres", "autres", "69000" }
                });

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
                columns: new[] { "AddressId", "BirthCountry", "BirthPlace", "ConcurrencyStamp", "FirstName", "LastName", "Nationality", "PasswordHash", "SecurityStamp" },
                values: new object[] { "B22699V4-42A2-4666-9631-1C2D1E2QE4F7", "pays1", "place1", "df0370b9-65bc-48bc-be48-36e6879c2177", "prenom1", "nom1", "nat1", "$2a$11$9pztfjFTae7zVQuw/3vWbu/oIyNfWWR93VBAJCUl0eK/m2.YxeZTm", "ce16a570-1732-4867-8574-82428aaa9aa3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "AddressId", "BirthCountry", "BirthPlace", "ConcurrencyStamp", "FirstName", "LastName", "Nationality", "PasswordHash", "SecurityStamp" },
                values: new object[] { "C44698B8-89A2-4115-9631-1C2D1E2AC5F7", "pays1", "place1", "c486ac3a-cda2-4eb2-9cb9-306868252d2f", "prenom2", "nom2", "nat1", "$2a$11$FNLWLa6A6aMfYE.q83aJWelYN3Kq22JVcN0/2dsV2/qGoHTCxPBzS", "6f0aee73-462d-43a8-a276-972ba1d9d8f3" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Address_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Address_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BirthCountry",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BirthPlace",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "AspNetUsers");

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
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdd4b0ec-7aed-4020-8912-94355e40b957", null, null, "$2a$11$Wbp1/74789.Dr5kmFZgBYuGTjQF8..Iu7HTdUfLmicDCTKS4bQan.", "3f10b981-9b36-4b93-869f-18a1ea1fb5a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92306ee0-e3a9-4c41-829b-340d0827c46f", null, null, "$2a$11$ppBJR8mGGajYzgvZL41A/uJztKN62XfA5VjrTACyxDYCLXBRQbGty", "7f5e9ecd-95bc-4160-86e6-3e655e7e1268" });
        }
    }
}
