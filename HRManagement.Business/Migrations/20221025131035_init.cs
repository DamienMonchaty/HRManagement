using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManagement.Business.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street1 = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Street2 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Street3 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Sexe = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    BirthCountry = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialSecurityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fonction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<float>(type: "real", nullable: false),
                    RawSalary = table.Column<double>(type: "float", nullable: false),
                    AdditionalIndemnity = table.Column<double>(type: "float", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommitmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Seniority = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employees_users_Id",
                        column: x => x.Id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "date", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employes_AppointmentsGroup",
                        column: x => x.UserId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enterprises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    RhEmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enterprises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_enterprises_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_enterprises_employees_RhEmployeeId",
                        column: x => x.RhEmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "holydays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_holydays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employes_HolidaysGroup",
                        column: x => x.UserId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "addresses",
                columns: new[] { "Id", "City", "Street1", "Street2", "Street3", "ZipCode" },
                values: new object[,]
                {
                    { 1, "ville", "rue1", "opt rue2", "opt rue2", "cp000" },
                    { 2, "ville", "rue1", "opt rue2", "opt rue2", "cp000" },
                    { 3, "ville", "rue1", "opt rue2", "opt rue2", "cp000" },
                    { 4, "ville", "rue1", "opt rue2", "opt rue2", "cp000" },
                    { 5, "ville", "rue1", "opt rue2", "opt rue2", "cp000" },
                    { 6, "ville", "rue1", "opt rue2", "opt rue2", "cp000" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Active", "AddressId", "BirthCountry", "BirthDate", "BirthPlace", "Email", "FirstName", "LastName", "Nationality", "Password", "Role", "Sexe", "Token", "UserName" },
                values: new object[,]
                {
                    { 1, true, 1, "pays1", new DateTime(2015, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), "villeNaissance1", "email1@email.fr", "nom1", "prenom1", "Nat1", "$2a$11$gep9DivyExIooUGBFu8n0uBHsUTGKTDeWQL49oNiM93CGvysYCOxK", "User", "sexe1", null, "prenom1" },
                    { 2, true, 2, "pays2", new DateTime(2015, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), "villeNaissance2", "email2@email.fr", "nom2", "prenom2", "Nat2", "$2a$11$Db5.Oul7SiyJFleMWa5rD.7IIEWSXzf.BbeYb8BIwGZTM0oIKgoEW", "Admin", "sexe1", null, "prenom2" },
                    { 3, true, 3, "pays3", new DateTime(2015, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), "villeNaissance3", "email3@email.fr", "nom3", "prenom3", "Nat3", "$2a$11$HMkjIiI/qXjLUpjKAVbSG.BPEzJRK4CQpxxLbdnk1551Xh5kEE1MG", "Admin", "sexe3", null, "prenom3" },
                    { 4, true, 4, "pays2", new DateTime(2015, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), "villeNaissance4", "email4@email.fr", "nom4", "prenom4", "Nat2", "$2a$11$ufdKnEUtzGRG32hY30eUx.nd4ryxO/ndge0Zx/tvVXSfdmrJoh.QW", "User", "sexe2", null, "prenom4" },
                    { 5, true, 5, "pays1", new DateTime(2015, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), "villeNaissance5", "email5@email.fr", "nom5", "prenom5", "Nat1", "$2a$11$knwmYEvBL9u0sNeIwOe8h.L8mr6JpEs3uc1eudL9v.otY3Ncyvrf.", "User", "sexe1", null, "prenom5" },
                    { 6, true, 6, "pays2", new DateTime(2015, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), "villeNaissance6", "email6@email.fr", "nom6", "prenom6", "Nat2", "$2a$11$GEorXt5JUXxKpbc5wyDHHujLZJs8eahtdR4PoGim2BPbBTigWQnUa", "User", "sexe6", null, "prenom6" }
                });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "AdditionalIndemnity", "CommitmentDate", "ContractDuration", "ContractType", "Experience", "Fonction", "MaritalStatus", "RawSalary", "RegistrationNumber", "Salary", "Seniority", "SocialSecurityNumber" },
                values: new object[] { 4, 200.0, new DateTime(2019, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), "ContratDuration1", "ContratType1", 10f, "Fonction1", "Status1", 1000.0, "RegistrationNumber4", 1200.0, 5f, "SocialSecurityNumber4" });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "AdditionalIndemnity", "CommitmentDate", "ContractDuration", "ContractType", "Experience", "Fonction", "MaritalStatus", "RawSalary", "RegistrationNumber", "Salary", "Seniority", "SocialSecurityNumber" },
                values: new object[] { 5, 200.0, new DateTime(2019, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), "ContratDuration2", "ContratType2", 10f, "Fonction1", "Status2", 1000.0, "RegistrationNumber5", 1200.0, 5f, "SocialSecurityNumber5" });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "AdditionalIndemnity", "CommitmentDate", "ContractDuration", "ContractType", "Experience", "Fonction", "MaritalStatus", "RawSalary", "RegistrationNumber", "Salary", "Seniority", "SocialSecurityNumber" },
                values: new object[] { 6, 200.0, new DateTime(2019, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), "ContratDuration1", "ContratType1", 10f, "Fonction1", "Status1", 1000.0, "RegistrationNumber6", 1200.0, 5f, "SocialSecurityNumber6" });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "Id", "AppointmentDate", "Description", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), "desc1", "titre1", 4 },
                    { 2, new DateTime(2018, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), "desc2", "titre2", 4 },
                    { 3, new DateTime(2018, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), "desc3", "titre3", 5 },
                    { 4, new DateTime(2018, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), "desc4", "titre4", 5 },
                    { 5, new DateTime(2018, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), "desc5", "titre5", 6 },
                    { 6, new DateTime(2018, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), "desc6", "titre6", 6 }
                });

            migrationBuilder.InsertData(
                table: "enterprises",
                columns: new[] { "Id", "EmployeeId", "RhEmployeeId" },
                values: new object[,]
                {
                    { 1, 4, null },
                    { 2, 5, 6 }
                });

            migrationBuilder.InsertData(
                table: "holydays",
                columns: new[] { "Id", "EndDate", "StartDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 12, 27, 10, 30, 45, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), 4 },
                    { 2, new DateTime(2018, 12, 27, 10, 30, 45, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), 4 },
                    { 3, new DateTime(2018, 12, 27, 10, 30, 45, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), 5 },
                    { 4, new DateTime(2018, 12, 27, 10, 30, 45, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), 5 },
                    { 5, new DateTime(2018, 12, 27, 10, 30, 45, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), 6 },
                    { 6, new DateTime(2018, 12, 27, 10, 30, 45, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 25, 10, 30, 45, 0, DateTimeKind.Unspecified), 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_UserId",
                table: "appointments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_enterprises_EmployeeId",
                table: "enterprises",
                column: "EmployeeId",
                unique: false,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_enterprises_RhEmployeeId",
                table: "enterprises",
                column: "RhEmployeeId",
                unique: false,
                filter: "[RhEmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_holydays_UserId",
                table: "holydays",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_users_AddressId",
                table: "users",
                column: "AddressId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "enterprises");

            migrationBuilder.DropTable(
                name: "holydays");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "addresses");
        }
    }
}
