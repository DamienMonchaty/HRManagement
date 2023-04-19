using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagement.Web.Migrations
{
    public partial class ini5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: "B22699V4-42A2-4666-9631-1C2D1E2QE4F7",
                columns: new[] { "City", "Street1", "Street2", "Street3", "ZipCode" },
                values: new object[] { "qWxdptf99V53m3HvJKwiyg==", "nrYvHAOpYT1icobLTkQ4XQ==", "UhTX5ZpJ4y2iv3Vcblzqvw==", "UhTX5ZpJ4y2iv3Vcblzqvw==", "jT5NXNJs3hNAgncxRV5IJg==" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: "C44698B8-89A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "City", "Street1", "Street2", "Street3", "ZipCode" },
                values: new object[] { "cC5WEXQrlF8DxQZ5INUEcQ==", "YUOKTkjPIcCdp0RFv0M995E9FNrV4Yqf0AZO/w4K8VA=", "UhTX5ZpJ4y2iv3Vcblzqvw==", "UhTX5ZpJ4y2iv3Vcblzqvw==", "fqv0JX8PgBMMSKadKO8wUA==" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "ea0fe62a-01e9-4480-bd74-3f70d7f070a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "fa029fd4-1f54-4886-b66b-0ae4980b6c23");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "BirthCountry", "BirthPlace", "ConcurrencyStamp", "FirstName", "LastName", "Nationality", "PasswordHash", "SecurityStamp" },
                values: new object[] { "JQA8CV5rxSF0/Hp6+X36Ww==", "jLy3HqDCK0+/NECBgw3iQA==", "f801b26e-4eff-4417-a713-cb3b35136d17", "N6MDRdQ5tjDgV3SOTj5zNw==", "JTPS3VOqAy9L3+KCQ/Xsew==", "/JPYnJI6bQjl6aZqqg748Q==", "AQAAAAEAACcQAAAAEHNeNvZgrhWB+MCBa48OWF6qrqNis9YnCiLnm/Fx19InjnqoYS3HtBKKWP1qoCikHA==", "165aea0e-60a6-496b-a1a2-865671ff68b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "BirthCountry", "BirthPlace", "ConcurrencyStamp", "FirstName", "LastName", "Nationality", "PasswordHash", "SecurityStamp" },
                values: new object[] { "JQA8CV5rxSF0/Hp6+X36Ww==", "jLy3HqDCK0+/NECBgw3iQA==", "970aefab-c6ce-409a-8872-69b15111f1ba", "5x085+9LSkk1t5g/+Lf+kQ==", "3Qi++WAQBaBchTBSJ5JWWg==", "/JPYnJI6bQjl6aZqqg748Q==", "AQAAAAEAACcQAAAAEDUUEz+o7i0Ao44YND6Yk/c0J1Scv7Rgd/VBQj5+gatB3+k+olAYzI0e9zdZ5Y8z9g==", "b92efeef-6c97-4bbc-a82a-5b9052cb2831" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: "B22699V4-42A2-4666-9631-1C2D1E2QE4F7",
                columns: new[] { "City", "Street1", "Street2", "Street3", "ZipCode" },
                values: new object[] { "NICE", "RUE ALBERT 1er", "autres", "autres", "06000" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: "C44698B8-89A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "City", "Street1", "Street2", "Street3", "ZipCode" },
                values: new object[] { "LYON", "RUE Jean Jaurès", "autres", "autres", "69000" });

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
                columns: new[] { "BirthCountry", "BirthPlace", "ConcurrencyStamp", "FirstName", "LastName", "Nationality", "PasswordHash", "SecurityStamp" },
                values: new object[] { "pays1", "place1", "52ea81eb-e258-4688-8f55-0ceb757d2079", "prenom1", "nom1", "nat1", "AQAAAAEAACcQAAAAEMd/5tgbqaQCRLM7p3NdCLdvIHyatQjU/zjxK7AeYzy7dl2g/ZN0Q1QWEwSNyVSVJg==", "63303c06-7d53-4957-af21-0c9f983a68ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "BirthCountry", "BirthPlace", "ConcurrencyStamp", "FirstName", "LastName", "Nationality", "PasswordHash", "SecurityStamp" },
                values: new object[] { "pays1", "place1", "4acb6c61-1644-40b5-9d85-73f1f16b05e3", "prenom2", "nom2", "nat1", "AQAAAAEAACcQAAAAEL5R3GoAO7/QBuCz6F2MSswBGc6jJM7IGn7w36RFfjC3N+CJnOk+U8a5RXAu3UxQQw==", "d0f7387e-fd4c-4995-9eef-ab00c2260571" });
        }
    }
}
