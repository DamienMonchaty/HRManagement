using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManagement.Business.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "users",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Sexe",
                table: "users",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                table: "users",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "BirthPlace",
                table: "users",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "BirthCountry",
                table: "users",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.CreateTable(
                name: "employee_projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => new { x.EmployeeId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_projects_employee_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "employee_projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projects_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "employee_projects",
                columns: new[] { "Id", "Description", "EndDate", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, "desc1", null, new DateTime(2018, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), "Projet1" },
                    { 2, "desc2", null, new DateTime(2018, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), "Projet2" },
                    { 3, "desc3", null, new DateTime(2018, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), "Projet3" }
                });

            migrationBuilder.UpdateData(
                table: "enterprises",
                keyColumn: "Id",
                keyValue: 1,
                column: "RhEmployeeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$eKe6/MTorHhqY10MGJyIaODuutAn3X1HERz.I04xcFtTyP3hWMTdO");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$VaBXztGHIWhPX5kqs.../.oiZ0YtMLDv6zNw3YAkS7.DxrzgY5HqK");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$RH4TsGxN3g1e/0TD6FhLTu7A1RXGB.cEAl34xtPJRp3jR9GXJrSEW");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$UdA/a5pr1Lfg6qeBk6qUJuu/oe8Mcmjt8Gx4vOmZCsoJDWpHB51De");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$LM1dDJV/t1ARh2QIyfoideSAlE52buGAShOkSJjdBfXKV3Z0.E0ia");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$kvedbquiqIpQruUmM4CIIe/x7twDqocaiTGWrKC7H.0apO5M8fPhK");

            migrationBuilder.InsertData(
                table: "projects",
                columns: new[] { "EmployeeId", "ProjectId" },
                values: new object[] { 5, 1 });

            migrationBuilder.InsertData(
                table: "projects",
                columns: new[] { "EmployeeId", "ProjectId" },
                values: new object[] { 4, 2 });

            migrationBuilder.InsertData(
                table: "projects",
                columns: new[] { "EmployeeId", "ProjectId" },
                values: new object[] { 4, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_projects_ProjectId",
                table: "projects",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "employee_projects");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "users",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sexe",
                table: "users",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                table: "users",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BirthPlace",
                table: "users",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BirthCountry",
                table: "users",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "enterprises",
                keyColumn: "Id",
                keyValue: 1,
                column: "RhEmployeeId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$nNG338ageYtgQQy8uKH8d.9cm/ldMPCBi50Bn.6dlPE3WVtAadOV2");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$DWKprphQsU0cpyFVOa7dNe5H4qcPO1Cu4DPTm08mzVHMFCQVImy.6");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$nB2kZkbvd7GOW5J24gF9U.E/MO.lxfrbUxm6IIYZTipZ8.fMXWjZW");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$ZeDQgbYx.pZw0jk/0QLCHeqTqG8.tsP5xGJPSIBBMtQaA4C.1TB0u");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$3vXLNE2bJuv3KtYDx9j7iesLbV8I/bqXrWVovKhRaF20QLcZCZwai");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$A4DkDPqB/sUmAX31STQvmOngLRaT1T.gJael60dhf4Pd99JDX9hC2");
        }
    }
}
