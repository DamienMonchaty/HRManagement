using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagement.Web.Migrations
{
    public partial class ap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Libelle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DiplomaSkills",
                columns: table => new
                {
                    DiplomaId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SkillId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiplomaSkills", x => new { x.DiplomaId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_DiplomaSkills_Diplomas_DiplomaId",
                        column: x => x.DiplomaId,
                        principalTable: "Diplomas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiplomaSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MissionSkills",
                columns: table => new
                {
                    MissionId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SkillId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionSkills", x => new { x.MissionId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_MissionSkills_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MissionSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                values: new object[] { "qWxdptf99V53m3HvJKwiyg==", "YUOKTkjPIcCdp0RFv0M995E9FNrV4Yqf0AZO/w4K8VA=", "UhTX5ZpJ4y2iv3Vcblzqvw==", "UhTX5ZpJ4y2iv3Vcblzqvw==", "fqv0JX8PgBMMSKadKO8wUA==" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: "D55699V4-42A2-4666-9631-1C2D1E2QE4F7",
                columns: new[] { "City", "Street1", "Street2", "Street3", "ZipCode" },
                values: new object[] { "qWxdptf99V53m3HvJKwiyg==", "N8SZmdEorA16bD1D14eQgA==", "UhTX5ZpJ4y2iv3Vcblzqvw==", "UhTX5ZpJ4y2iv3Vcblzqvw==", "jT5NXNJs3hNAgncxRV5IJg==" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: "E66698B8-89A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "City", "Street1", "Street2", "Street3", "ZipCode" },
                values: new object[] { "cC5WEXQrlF8DxQZ5INUEcQ==", "4nL/FfFSsPNEECz4eSRT8ENay+dNU7kUoTZxBrlniPE=", "UhTX5ZpJ4y2iv3Vcblzqvw==", "UhTX5ZpJ4y2iv3Vcblzqvw==", "fqv0JX8PgBMMSKadKO8wUA==" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "b551c7e5-651a-40e2-9997-40073cfba895");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "661e5a96-59fa-4ecb-8ac6-ba77545409f4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "BirthCountry", "BirthPlace", "ConcurrencyStamp", "FirstName", "LastName", "NatCardNumber", "Nationality", "PasswordHash", "SecCardNumber", "SecurityStamp" },
                values: new object[] { "JQA8CV5rxSF0/Hp6+X36Ww==", "jLy3HqDCK0+/NECBgw3iQA==", "836ad91b-bbe8-4949-b42b-35030f5a2fdd", "/Jd2bzeOttDTlAepi7Vj7Q==", "HarYCrqDtXq0aGL4Euy0Zw==", "lPfqw/4To4cUqkFXmjr99A==", "/JPYnJI6bQjl6aZqqg748Q==", "AQAAAAEAACcQAAAAEEDSQxGwirlmjGvb87GqEgEq0qECAUxnYt57+yeui+aqcohm6Q3wEsGagXafNQdczg==", "RKni2nEve0sgoL7KKwYx5A==", "943ccd6f-e18f-411e-aec8-c5d6af7900aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C55678B8-4209-4115-9631-1CE51E2AC5F7",
                columns: new[] { "BirthCountry", "BirthPlace", "ConcurrencyStamp", "FirstName", "LastName", "NatCardNumber", "Nationality", "PasswordHash", "SecCardNumber", "SecurityStamp" },
                values: new object[] { "JQA8CV5rxSF0/Hp6+X36Ww==", "g+PoCWm3amX+lswFWV8cAA==", "6d9c64b3-0b3c-44d8-bb8a-da03e68b9684", "/D2ZmG3Ut4D7HZnQ4LIC3A==", "9KxG3ftafKogzxBycgaaqw==", "lPfqw/4To4cUqkFXmjr99A==", "/JPYnJI6bQjl6aZqqg748Q==", "AQAAAAEAACcQAAAAEDkoWoqd+7DSDDoKudy1pxjZKd6R2YPZaXhkmdiHGYHDuycsIaUnKNtGyZcPdthNAQ==", "RKni2nEve0sgoL7KKwYx5A==", "b5b9254f-0c84-4822-86d6-862eab628822" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "BirthCountry", "BirthPlace", "ConcurrencyStamp", "FirstName", "LastName", "NatCardNumber", "Nationality", "PasswordHash", "SecCardNumber", "SecurityStamp" },
                values: new object[] { "JQA8CV5rxSF0/Hp6+X36Ww==", "jLy3HqDCK0+/NECBgw3iQA==", "5860acb3-6a2d-452e-99f8-92961cd5214c", "X+XAHEIv6iQhza/ISyly4w==", "RsGU0ra9qNyUFez5reZDig==", "lPfqw/4To4cUqkFXmjr99A==", "/JPYnJI6bQjl6aZqqg748Q==", "AQAAAAEAACcQAAAAEOHDHKW9UKnMvFQxsKdPB1H/gYPllZhCg1bqpdErcA6bRXx1v+vC3oUb2V0dsjE4fg==", "RKni2nEve0sgoL7KKwYx5A==", "90784aed-fdb7-49e4-bc50-713be4fe6ed5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F33678B8-4G62-4115-9631-1CE51E2AC5F7",
                columns: new[] { "BirthCountry", "BirthPlace", "ConcurrencyStamp", "FirstName", "LastName", "NatCardNumber", "Nationality", "PasswordHash", "SecCardNumber", "SecurityStamp" },
                values: new object[] { "JQA8CV5rxSF0/Hp6+X36Ww==", "ScRQbVozn+lzAJOs41qD0g==", "1f5b870e-808e-4704-aaa8-9f1bdca1bb6d", "XPm7I7D6QN8s2mq8hyy/sg==", "RsGU0ra9qNyUFez5reZDig==", "lPfqw/4To4cUqkFXmjr99A==", "/JPYnJI6bQjl6aZqqg748Q==", "AQAAAAEAACcQAAAAEHncxwwmEyO8ryEsqZcG5cdrWXNH0Z2zr7pMlVQBvwI9aocHq5L8FzRmybIQixm8TA==", "RKni2nEve0sgoL7KKwYx5A==", "0cdda8bf-5478-4450-a04e-cead4459635b" });

            migrationBuilder.UpdateData(
                table: "Diplomas",
                keyColumn: "Id",
                keyValue: "B123V455-42A2-3456-9631-1DHZSE2QE4F7",
                column: "Libelle",
                value: "E7HAk0sSrG5MNlEhSSXbxg==");

            migrationBuilder.UpdateData(
                table: "Diplomas",
                keyColumn: "Id",
                keyValue: "C4469D48-89A2-3615-9631-1C2D1E2AC2&7",
                column: "Libelle",
                value: "FE4M/Q+DQs2gVsq8mNFgZb2mENKClUVBSW1T8OM6MHw=");

            migrationBuilder.UpdateData(
                table: "Diplomas",
                keyColumn: "Id",
                keyValue: "C4H83D48-89A2-3615-9631-1C2DAL0AC9&7",
                column: "Libelle",
                value: "ktJ4K+MXoJcFcwftaKi7Wg==");

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: "B123V455-42A2-3456-9631-1DHZSE2QE4F7",
                column: "Libelle",
                value: "q8ieydXLnJMphy5L4wp76A==");

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: "C4469D48-89A2-3615-9631-1C2D1E2AC2&7",
                column: "Libelle",
                value: "Pet7i993BgS+uQZJeQYSVQ==");

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: "C4H83D48-89A2-3615-9631-1C2DAL0AC9&7",
                column: "Libelle",
                value: "b+8rJ0ACwlqFzv48DSeleVeJCjkXxP9RxmDOTM5cfLc=");

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Description", "Libelle" },
                values: new object[,]
                {
                    { "B22699V4-42A2-4666-9631-1C2D1E2QE4F7", "Lorem ispum", "Python" },
                    { "C44698B8-89A2-4115-9631-1C2D1E2AC5F7", "Lorem ispum", "Java" },
                    { "D55699V4-42A2-4666-9631-1C2D1E2QE4F7", "Lorem ispum", "C#" },
                    { "E66698B8-89A2-4115-9631-1C2D1E2AC5F7", "Lorem ispum", "PHP" },
                    { "E87658B8-89A2-4115-9631-1C2D1E2AC5F7", "Lorem ispum", "NodeJS" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiplomaSkills_SkillId",
                table: "DiplomaSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionSkills_SkillId",
                table: "MissionSkills",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiplomaSkills");

            migrationBuilder.DropTable(
                name: "MissionSkills");

            migrationBuilder.DropTable(
                name: "Skills");

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
                values: new object[] { "qWxdptf99V53m3HvJKwiyg==", "YUOKTkjPIcCdp0RFv0M995E9FNrV4Yqf0AZO/w4K8VA=", "UhTX5ZpJ4y2iv3Vcblzqvw==", "UhTX5ZpJ4y2iv3Vcblzqvw==", "fqv0JX8PgBMMSKadKO8wUA==" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: "D55699V4-42A2-4666-9631-1C2D1E2QE4F7",
                columns: new[] { "City", "Street1", "Street2", "Street3", "ZipCode" },
                values: new object[] { "qWxdptf99V53m3HvJKwiyg==", "N8SZmdEorA16bD1D14eQgA==", "UhTX5ZpJ4y2iv3Vcblzqvw==", "UhTX5ZpJ4y2iv3Vcblzqvw==", "jT5NXNJs3hNAgncxRV5IJg==" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: "E66698B8-89A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "City", "Street1", "Street2", "Street3", "ZipCode" },
                values: new object[] { "cC5WEXQrlF8DxQZ5INUEcQ==", "4nL/FfFSsPNEECz4eSRT8ENay+dNU7kUoTZxBrlniPE=", "UhTX5ZpJ4y2iv3Vcblzqvw==", "UhTX5ZpJ4y2iv3Vcblzqvw==", "fqv0JX8PgBMMSKadKO8wUA==" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "a006bf27-38be-4e17-b0bd-c91f2af6382f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "9207c289-664f-4b88-abb6-4c0373ef2d68");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "BirthCountry", "BirthPlace", "ConcurrencyStamp", "FirstName", "LastName", "NatCardNumber", "Nationality", "PasswordHash", "SecCardNumber", "SecurityStamp" },
                values: new object[] { "JQA8CV5rxSF0/Hp6+X36Ww==", "jLy3HqDCK0+/NECBgw3iQA==", "f34b92b4-1737-4979-97d1-84c00ff54d39", "/Jd2bzeOttDTlAepi7Vj7Q==", "HarYCrqDtXq0aGL4Euy0Zw==", "lPfqw/4To4cUqkFXmjr99A==", "/JPYnJI6bQjl6aZqqg748Q==", "AQAAAAEAACcQAAAAEJvgCy9V7F7mEs4LmNiA7nq/E45QPnegwMMmXxTJ4R04sIzq19PMKKYK1tnPgduWSA==", "RKni2nEve0sgoL7KKwYx5A==", "ae9838c6-005a-42c7-8065-bed127257fd1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C55678B8-4209-4115-9631-1CE51E2AC5F7",
                columns: new[] { "BirthCountry", "BirthPlace", "ConcurrencyStamp", "FirstName", "LastName", "NatCardNumber", "Nationality", "PasswordHash", "SecCardNumber", "SecurityStamp" },
                values: new object[] { "JQA8CV5rxSF0/Hp6+X36Ww==", "g+PoCWm3amX+lswFWV8cAA==", "344a55c2-3dba-4864-9059-3a3e026a213b", "/D2ZmG3Ut4D7HZnQ4LIC3A==", "9KxG3ftafKogzxBycgaaqw==", "lPfqw/4To4cUqkFXmjr99A==", "/JPYnJI6bQjl6aZqqg748Q==", "AQAAAAEAACcQAAAAEAX8F3GUbwm5XPRfgWmSYpJtY6i6vVkJqUfcTzPYBCVPZjSwIPWAwY4hPTW9/HqxsA==", "RKni2nEve0sgoL7KKwYx5A==", "c5868439-f469-479f-a87c-b9208974e126" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                columns: new[] { "BirthCountry", "BirthPlace", "ConcurrencyStamp", "FirstName", "LastName", "NatCardNumber", "Nationality", "PasswordHash", "SecCardNumber", "SecurityStamp" },
                values: new object[] { "JQA8CV5rxSF0/Hp6+X36Ww==", "jLy3HqDCK0+/NECBgw3iQA==", "194d1b8c-1ef0-4e19-b316-6b91db829232", "X+XAHEIv6iQhza/ISyly4w==", "RsGU0ra9qNyUFez5reZDig==", "lPfqw/4To4cUqkFXmjr99A==", "/JPYnJI6bQjl6aZqqg748Q==", "AQAAAAEAACcQAAAAEFGT4o9ked7UlTsmZabzXvGKjbTd85Aon+beAdlcYA7+toWNFhkW2VUjMQyJkXB9oA==", "RKni2nEve0sgoL7KKwYx5A==", "4cbba3a2-f165-48f0-9d34-b087cbcd3d2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F33678B8-4G62-4115-9631-1CE51E2AC5F7",
                columns: new[] { "BirthCountry", "BirthPlace", "ConcurrencyStamp", "FirstName", "LastName", "NatCardNumber", "Nationality", "PasswordHash", "SecCardNumber", "SecurityStamp" },
                values: new object[] { "JQA8CV5rxSF0/Hp6+X36Ww==", "ScRQbVozn+lzAJOs41qD0g==", "e56da7e8-04e9-44a1-8e51-3e7bf32f6fe9", "XPm7I7D6QN8s2mq8hyy/sg==", "RsGU0ra9qNyUFez5reZDig==", "lPfqw/4To4cUqkFXmjr99A==", "/JPYnJI6bQjl6aZqqg748Q==", "AQAAAAEAACcQAAAAEKlnC3ZA0d6CEV1i4FNNsa6iUL7WECIqWqZU2X7Xw6owUuGwrwN3Z2KAS0mg+bhRSg==", "RKni2nEve0sgoL7KKwYx5A==", "2a01b31a-55d2-4a4c-a556-4fafb63cbb95" });

            migrationBuilder.UpdateData(
                table: "Diplomas",
                keyColumn: "Id",
                keyValue: "B123V455-42A2-3456-9631-1DHZSE2QE4F7",
                column: "Libelle",
                value: "E7HAk0sSrG5MNlEhSSXbxg==");

            migrationBuilder.UpdateData(
                table: "Diplomas",
                keyColumn: "Id",
                keyValue: "C4469D48-89A2-3615-9631-1C2D1E2AC2&7",
                column: "Libelle",
                value: "FE4M/Q+DQs2gVsq8mNFgZb2mENKClUVBSW1T8OM6MHw=");

            migrationBuilder.UpdateData(
                table: "Diplomas",
                keyColumn: "Id",
                keyValue: "C4H83D48-89A2-3615-9631-1C2DAL0AC9&7",
                column: "Libelle",
                value: "ktJ4K+MXoJcFcwftaKi7Wg==");

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: "B123V455-42A2-3456-9631-1DHZSE2QE4F7",
                column: "Libelle",
                value: "q8ieydXLnJMphy5L4wp76A==");

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: "C4469D48-89A2-3615-9631-1C2D1E2AC2&7",
                column: "Libelle",
                value: "Pet7i993BgS+uQZJeQYSVQ==");

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: "C4H83D48-89A2-3615-9631-1C2DAL0AC9&7",
                column: "Libelle",
                value: "b+8rJ0ACwlqFzv48DSeleVeJCjkXxP9RxmDOTM5cfLc=");
        }
    }
}
