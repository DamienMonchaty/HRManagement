using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManagement.Business.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "holydays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: 6,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "enterprises",
                keyColumn: "Id",
                keyValue: 1,
                column: "RhEmployeeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "holydays",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "holydays",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "holydays",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "holydays",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: 1);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "holydays");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "appointments");

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
                value: "$2a$11$ufdKnEUtzGRG32hY30eUx.nd4ryxO/ndge0Zx/tvVXSfdmrJoh.QW");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$knwmYEvBL9u0sNeIwOe8h.L8mr6JpEs3uc1eudL9v.otY3Ncyvrf.");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$GEorXt5JUXxKpbc5wyDHHujLZJs8eahtdR4PoGim2BPbBTigWQnUa");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$gep9DivyExIooUGBFu8n0uBHsUTGKTDeWQL49oNiM93CGvysYCOxK");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$Db5.Oul7SiyJFleMWa5rD.7IIEWSXzf.BbeYb8BIwGZTM0oIKgoEW");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$HMkjIiI/qXjLUpjKAVbSG.BPEzJRK4CQpxxLbdnk1551Xh5kEE1MG");
        }
    }
}
