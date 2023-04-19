﻿// <auto-generated />
using System;
using HRManagement.Web.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HRManagement.Web.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230419111654_ini5")]
    partial class ini5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HRManagement.Web.Models.Address", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Street1")
                        .HasColumnType("longtext");

                    b.Property<string>("Street2")
                        .HasColumnType("longtext");

                    b.Property<string>("Street3")
                        .HasColumnType("longtext");

                    b.Property<string>("ZipCode")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = "B22699V4-42A2-4666-9631-1C2D1E2QE4F7",
                            City = "qWxdptf99V53m3HvJKwiyg==",
                            Street1 = "nrYvHAOpYT1icobLTkQ4XQ==",
                            Street2 = "UhTX5ZpJ4y2iv3Vcblzqvw==",
                            Street3 = "UhTX5ZpJ4y2iv3Vcblzqvw==",
                            ZipCode = "jT5NXNJs3hNAgncxRV5IJg=="
                        },
                        new
                        {
                            Id = "C44698B8-89A2-4115-9631-1C2D1E2AC5F7",
                            City = "cC5WEXQrlF8DxQZ5INUEcQ==",
                            Street1 = "YUOKTkjPIcCdp0RFv0M995E9FNrV4Yqf0AZO/w4K8VA=",
                            Street2 = "UhTX5ZpJ4y2iv3Vcblzqvw==",
                            Street3 = "UhTX5ZpJ4y2iv3Vcblzqvw==",
                            ZipCode = "fqv0JX8PgBMMSKadKO8wUA=="
                        });
                });

            modelBuilder.Entity("HRManagement.Web.Models.Client", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = "B22699V4-42A2-4666-9631-1D9D1E2QE4F7",
                            Description = "DESC CLIENT1",
                            Name = "CLIENT1"
                        },
                        new
                        {
                            Id = "C4469D48-89A2-3615-9631-1C2D1E2AC/&7",
                            Description = "DESC CLIENT2",
                            Name = "CLIENT2"
                        });
                });

            modelBuilder.Entity("HRManagement.Web.Models.Diploma", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("EndDate")
                        .HasColumnType("longtext");

                    b.Property<string>("Libelle")
                        .HasColumnType("longtext");

                    b.Property<string>("StartDate")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Diplomas");
                });

            modelBuilder.Entity("HRManagement.Web.Models.Mission", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("MissionEnum")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("ProjectId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("HRManagement.Web.Models.Project", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ClientId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("EndDate")
                        .HasColumnType("longtext");

                    b.Property<string>("Libelle")
                        .HasColumnType("longtext");

                    b.Property<string>("ProjectEnum")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("StartDate")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("HRManagement.Web.Models.School", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("EndDate")
                        .HasColumnType("longtext");

                    b.Property<string>("Libelle")
                        .HasColumnType("longtext");

                    b.Property<string>("StartDate")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("HRManagement.Web.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("AddressId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BirthCountry")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("BirthPlace")
                        .HasColumnType("longtext");

                    b.Property<float>("BrutSalary")
                        .HasColumnType("float");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NatCardNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("Nationality")
                        .HasColumnType("longtext");

                    b.Property<float>("NetSalary")
                        .HasColumnType("float");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PositionEnum")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("SecCardNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                            AccessFailedCount = 0,
                            AddressId = "B22699V4-42A2-4666-9631-1C2D1E2QE4F7",
                            BirthCountry = "JQA8CV5rxSF0/Hp6+X36Ww==",
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BirthPlace = "jLy3HqDCK0+/NECBgw3iQA==",
                            BrutSalary = 0f,
                            ConcurrencyStamp = "f801b26e-4eff-4417-a713-cb3b35136d17",
                            Email = "p1@p.fr",
                            EmailConfirmed = true,
                            FirstName = "N6MDRdQ5tjDgV3SOTj5zNw==",
                            LastName = "JTPS3VOqAy9L3+KCQ/Xsew==",
                            LockoutEnabled = false,
                            Nationality = "/JPYnJI6bQjl6aZqqg748Q==",
                            NetSalary = 0f,
                            NormalizedEmail = "P1@P.FR",
                            NormalizedUserName = "P1@P.FR",
                            PasswordHash = "AQAAAAEAACcQAAAAEHNeNvZgrhWB+MCBa48OWF6qrqNis9YnCiLnm/Fx19InjnqoYS3HtBKKWP1qoCikHA==",
                            PhoneNumberConfirmed = true,
                            PositionEnum = "MANAGER",
                            SecurityStamp = "165aea0e-60a6-496b-a1a2-865671ff68b1",
                            TwoFactorEnabled = false,
                            UserName = "p1@p.fr"
                        },
                        new
                        {
                            Id = "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                            AccessFailedCount = 0,
                            AddressId = "C44698B8-89A2-4115-9631-1C2D1E2AC5F7",
                            BirthCountry = "JQA8CV5rxSF0/Hp6+X36Ww==",
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BirthPlace = "jLy3HqDCK0+/NECBgw3iQA==",
                            BrutSalary = 0f,
                            ConcurrencyStamp = "970aefab-c6ce-409a-8872-69b15111f1ba",
                            Email = "p2@p.fr",
                            EmailConfirmed = true,
                            FirstName = "5x085+9LSkk1t5g/+Lf+kQ==",
                            LastName = "3Qi++WAQBaBchTBSJ5JWWg==",
                            LockoutEnabled = false,
                            Nationality = "/JPYnJI6bQjl6aZqqg748Q==",
                            NetSalary = 0f,
                            NormalizedEmail = "P2@P.FR",
                            NormalizedUserName = "P2@P.FR",
                            PasswordHash = "AQAAAAEAACcQAAAAEDUUEz+o7i0Ao44YND6Yk/c0J1Scv7Rgd/VBQj5+gatB3+k+olAYzI0e9zdZ5Y8z9g==",
                            PhoneNumberConfirmed = true,
                            PositionEnum = "MANAGER",
                            SecurityStamp = "b92efeef-6c97-4bbc-a82a-5b9052cb2831",
                            TwoFactorEnabled = false,
                            UserName = "prenom2"
                        });
                });

            modelBuilder.Entity("HRManagement.Web.Models.UserProject", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProjectId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("UserProjects");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                            ConcurrencyStamp = "fa029fd4-1f54-4886-b66b-0ae4980b6c23",
                            Name = "Visitor",
                            NormalizedName = "VISITOR"
                        },
                        new
                        {
                            Id = "2301D884-221A-4E7D-B509-0113DCC043E1",
                            ConcurrencyStamp = "ea0fe62a-01e9-4480-bd74-3f70d7f070a1",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                            RoleId = "2301D884-221A-4E7D-B509-0113DCC043E1"
                        },
                        new
                        {
                            UserId = "E22678B8-42A2-4115-9631-1CE51E2AC5F7",
                            RoleId = "7D9B7113-A8F8-4035-99A7-A20DD400F6A3"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HRManagement.Web.Models.Diploma", b =>
                {
                    b.HasOne("HRManagement.Web.Models.User", null)
                        .WithMany("Diplomas")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("HRManagement.Web.Models.Mission", b =>
                {
                    b.HasOne("HRManagement.Web.Models.Project", "Project")
                        .WithMany("Missios")
                        .HasForeignKey("ProjectId");

                    b.HasOne("HRManagement.Web.Models.User", "User")
                        .WithMany("Missions")
                        .HasForeignKey("UserId");

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HRManagement.Web.Models.Project", b =>
                {
                    b.HasOne("HRManagement.Web.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("HRManagement.Web.Models.School", b =>
                {
                    b.HasOne("HRManagement.Web.Models.User", null)
                        .WithMany("Schools")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("HRManagement.Web.Models.User", b =>
                {
                    b.HasOne("HRManagement.Web.Models.Address", "Address")
                        .WithOne("User")
                        .HasForeignKey("HRManagement.Web.Models.User", "AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("HRManagement.Web.Models.UserProject", b =>
                {
                    b.HasOne("HRManagement.Web.Models.Project", "Project")
                        .WithMany("UserProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRManagement.Web.Models.User", "User")
                        .WithMany("UserProjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HRManagement.Web.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HRManagement.Web.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRManagement.Web.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HRManagement.Web.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HRManagement.Web.Models.Address", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("HRManagement.Web.Models.Project", b =>
                {
                    b.Navigation("Missios");

                    b.Navigation("UserProjects");
                });

            modelBuilder.Entity("HRManagement.Web.Models.User", b =>
                {
                    b.Navigation("Diplomas");

                    b.Navigation("Missions");

                    b.Navigation("Schools");

                    b.Navigation("UserProjects");
                });
#pragma warning restore 612, 618
        }
    }
}