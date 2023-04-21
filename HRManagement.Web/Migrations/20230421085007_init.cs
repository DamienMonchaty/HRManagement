using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagement.Web.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Street1 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Street2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Street3 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ZipCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NatCardNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecCardNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "Date", nullable: false),
                    BirthPlace = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthCountry = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nationality = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NetSalary = table.Column<float>(type: "float", nullable: false),
                    BrutSalary = table.Column<float>(type: "float", nullable: false),
                    PositionEnum = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AddressId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Libelle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: true),
                    ProjectEnum = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ClientId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Diplomas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Libelle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diplomas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diplomas_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Libelle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schools_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MissionEnum = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ProjectId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Missions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Missions_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserProjects",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjects", x => new { x.UserId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_UserProjects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Street1", "Street2", "Street3", "ZipCode" },
                values: new object[,]
                {
                    { "B22699V4-42A2-4666-9631-1C2D1E2QE4F7", "qWxdptf99V53m3HvJKwiyg==", "nrYvHAOpYT1icobLTkQ4XQ==", "UhTX5ZpJ4y2iv3Vcblzqvw==", "UhTX5ZpJ4y2iv3Vcblzqvw==", "jT5NXNJs3hNAgncxRV5IJg==" },
                    { "C44698B8-89A2-4115-9631-1C2D1E2AC5F7", "qWxdptf99V53m3HvJKwiyg==", "YUOKTkjPIcCdp0RFv0M995E9FNrV4Yqf0AZO/w4K8VA=", "UhTX5ZpJ4y2iv3Vcblzqvw==", "UhTX5ZpJ4y2iv3Vcblzqvw==", "fqv0JX8PgBMMSKadKO8wUA==" },
                    { "D55699V4-42A2-4666-9631-1C2D1E2QE4F7", "qWxdptf99V53m3HvJKwiyg==", "N8SZmdEorA16bD1D14eQgA==", "UhTX5ZpJ4y2iv3Vcblzqvw==", "UhTX5ZpJ4y2iv3Vcblzqvw==", "jT5NXNJs3hNAgncxRV5IJg==" },
                    { "E66698B8-89A2-4115-9631-1C2D1E2AC5F7", "cC5WEXQrlF8DxQZ5INUEcQ==", "4nL/FfFSsPNEECz4eSRT8ENay+dNU7kUoTZxBrlniPE=", "UhTX5ZpJ4y2iv3Vcblzqvw==", "UhTX5ZpJ4y2iv3Vcblzqvw==", "fqv0JX8PgBMMSKadKO8wUA==" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2301D884-221A-4E7D-B509-0113DCC043E1", "76fd6885-b827-4af1-9f00-e2d7811c7006", "Administrator", "ADMINISTRATOR" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "508223b4-e089-4362-a564-31ae07a5a358", "Visitor", "VISITOR" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { "B22699V4-42A2-4666-9631-1D9D1E2QE4F7", "DESC CLIENT1", "CLIENT1" },
                    { "C4469D48-89A2-3615-9631-1C2D1E2AC/&7", "DESC CLIENT2", "CLIENT2" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "BirthCountry", "BirthDate", "BirthPlace", "BrutSalary", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NatCardNumber", "Nationality", "NetSalary", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PositionEnum", "SecCardNumber", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "B22698B8-42A2-4115-9631-1C2D1E2AC5F7", 0, "B22699V4-42A2-4666-9631-1C2D1E2QE4F7", "JQA8CV5rxSF0/Hp6+X36Ww==", new DateTime(1996, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "jLy3HqDCK0+/NECBgw3iQA==", 0f, "ca87af70-21da-4851-9860-ffdcee1e2ce2", "p1@p.fr", true, "N6MDRdQ5tjDgV3SOTj5zNw==", "JTPS3VOqAy9L3+KCQ/Xsew==", false, null, "lPfqw/4To4cUqkFXmjr99A==", "/JPYnJI6bQjl6aZqqg748Q==", 0f, "P1@P.FR", "P1@P.FR", "AQAAAAEAACcQAAAAEBqvKNWTTh8beJK0HVousvbmP2gRzosJBmQ5iRefy6B/7lMDRgt/qHvm4DZ29DzuCQ==", null, true, "MANAGER", "RKni2nEve0sgoL7KKwYx5A==", "ad6d49d1-f157-48ab-b157-c848863d47f6", false, "prenom1" },
                    { "C55678B8-4209-4115-9631-1CE51E2AC5F7", 0, "E66698B8-89A2-4115-9631-1C2D1E2AC5F7", "JQA8CV5rxSF0/Hp6+X36Ww==", new DateTime(1975, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "g+PoCWm3amX+lswFWV8cAA==", 0f, "78536db1-4687-4738-9c8b-055420114d96", "p4@p.fr", true, "ldyluZxesa9HepZURsYDDw==", "ko6mebyb/PHb8FCTgPfWkA==", false, null, "lPfqw/4To4cUqkFXmjr99A==", "/JPYnJI6bQjl6aZqqg748Q==", 0f, "P4@P.FR", "P4@P.FR", "AQAAAAEAACcQAAAAEAPLSYVoj9xVKepmWDJrQcbJutSshvR9BfBrgiGslJMhbsiL30LLHh922jptSnLEYA==", null, true, "MANAGER", "RKni2nEve0sgoL7KKwYx5A==", "c006289e-9989-4405-9efa-7ef01515431c", false, "prenom4" },
                    { "E22678B8-42A2-4115-9631-1CE51E2AC5F7", 0, "C44698B8-89A2-4115-9631-1C2D1E2AC5F7", "JQA8CV5rxSF0/Hp6+X36Ww==", new DateTime(1986, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "jLy3HqDCK0+/NECBgw3iQA==", 0f, "7212ebdf-0388-4c81-b98c-36d02295a85c", "p2@p.fr", true, "5x085+9LSkk1t5g/+Lf+kQ==", "3Qi++WAQBaBchTBSJ5JWWg==", false, null, "lPfqw/4To4cUqkFXmjr99A==", "/JPYnJI6bQjl6aZqqg748Q==", 0f, "P2@P.FR", "P2@P.FR", "AQAAAAEAACcQAAAAEI5B2SF/UCz2U44qKIqeiuLwsECxvViAA9yA6CyWi98ntrh0Cgr5QDbxAY/ZNI8MdA==", null, true, "MANAGER", "RKni2nEve0sgoL7KKwYx5A==", "cd3919cf-5ddc-4bdc-92ed-3a96389c2c54", false, "prenom2" },
                    { "F33678B8-4G62-4115-9631-1CE51E2AC5F7", 0, "D55699V4-42A2-4666-9631-1C2D1E2QE4F7", "JQA8CV5rxSF0/Hp6+X36Ww==", new DateTime(1990, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "ScRQbVozn+lzAJOs41qD0g==", 0f, "9d4d4f59-8be5-488c-88a5-f014a7777fa3", "p3@p.fr", true, "LcuFzJpcvDw28Ssrsx1pwQ==", "QnmDnO3P160R6LGSWcpuuw==", false, null, "lPfqw/4To4cUqkFXmjr99A==", "/JPYnJI6bQjl6aZqqg748Q==", 0f, "P3@P.FR", "P3@P.FR", "AQAAAAEAACcQAAAAEAX2n02hr9LB7K+zTZSOgzqb7do+CQ2DfOohEkmd0kICB0L3VM/rA4kmrpHcQ4t3VQ==", null, true, "MANAGER", "RKni2nEve0sgoL7KKwYx5A==", "d64ab04d-1a36-4524-8a08-3a7a6f3cb163", false, "prenom3" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2301D884-221A-4E7D-B509-0113DCC043E1", "B22698B8-42A2-4115-9631-1C2D1E2AC5F7" },
                    { "7D9B7113-A8F8-4035-99A7-A20DD400F6A3", "E22678B8-42A2-4115-9631-1CE51E2AC5F7" }
                });

            migrationBuilder.InsertData(
                table: "Diplomas",
                columns: new[] { "Id", "EndDate", "Libelle", "StartDate", "UserId" },
                values: new object[,]
                {
                    { "B123V455-42A2-3456-9631-1DHZSE2QE4F7", new DateTime(2015, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "E7HAk0sSrG5MNlEhSSXbxg==", new DateTime(2017, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "E22678B8-42A2-4115-9631-1CE51E2AC5F7" },
                    { "C4469D48-89A2-3615-9631-1C2D1E2AC2&7", new DateTime(2009, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "FE4M/Q+DQs2gVsq8mNFgZb2mENKClUVBSW1T8OM6MHw=", new DateTime(2011, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "E22678B8-42A2-4115-9631-1CE51E2AC5F7" },
                    { "C4H83D48-89A2-3615-9631-1C2DAL0AC9&7", new DateTime(2013, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ktJ4K+MXoJcFcwftaKi7Wg==", new DateTime(2016, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "B22698B8-42A2-4115-9631-1C2D1E2AC5F7" }
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "EndDate", "Libelle", "StartDate", "UserId" },
                values: new object[,]
                {
                    { "B123V455-42A2-3456-9631-1DHZSE2QE4F7", new DateTime(2013, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "q8ieydXLnJMphy5L4wp76A==", new DateTime(2016, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "E22678B8-42A2-4115-9631-1CE51E2AC5F7" },
                    { "C4469D48-89A2-3615-9631-1C2D1E2AC2&7", new DateTime(2013, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pet7i993BgS+uQZJeQYSVQ==", new DateTime(2016, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "E22678B8-42A2-4115-9631-1CE51E2AC5F7" },
                    { "C4H83D48-89A2-3615-9631-1C2DAL0AC9&7", new DateTime(2013, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "b+8rJ0ACwlqFzv48DSeleVeJCjkXxP9RxmDOTM5cfLc=", new DateTime(2016, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "B22698B8-42A2-4115-9631-1C2D1E2AC5F7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diplomas_UserId",
                table: "Diplomas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_ProjectId",
                table: "Missions",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_UserId",
                table: "Missions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                table: "Projects",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_UserId",
                table: "Schools",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_ProjectId",
                table: "UserProjects",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Diplomas");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "UserProjects");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
