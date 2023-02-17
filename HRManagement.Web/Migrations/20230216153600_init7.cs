using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManagement.Web.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Address_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "182c7354-e344-4412-8c71-4f2a2a3e046a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "8005156c-fa44-420e-9740-8b61411780ad");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dec8d26b-a486-41b5-9da2-63864e858811", "AQAAAAEAACcQAAAAENKxT0+cYYB/4xAoBNaTPA2iYDts19rXI/W9hnpuv+7VVJbdofKRudcsuJUP1JH3jg==", "66386995-ba26-45b2-bea1-c7d79ce4c946" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d13a9802-6f8f-484e-b6fa-4465c00b4aba", "AQAAAAEAACcQAAAAEBFwPVyumH0+2kFjbfRvGMfTuF8ct0S7jQPk6dTy8s/4QHNp4A/00nJ7x3iW3LSyqA==", "f3ce9cba-f2f2-4f1c-b33f-4ed17271eadf" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Address_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
