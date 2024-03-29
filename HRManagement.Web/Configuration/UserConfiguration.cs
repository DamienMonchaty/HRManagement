﻿using HRManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace HRManagement.Web.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private const string adressId1 = "B22699V4-42A2-4666-9631-1C2D1E2QE4F7";
        private const string adressId2 = "C44698B8-89A2-4115-9631-1C2D1E2AC5F7";
        private const string adressId3 = "D55699V4-42A2-4666-9631-1C2D1E2QE4F7";
        private const string adressId4 = "E66698B8-89A2-4115-9631-1C2D1E2AC5F7";

        private const string adminId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";
        private const string employeId1 = "E22678B8-42A2-4115-9631-1CE51E2AC5F7";
        private const string employeId2 = "F33678B8-4G62-4115-9631-1CE51E2AC5F7";
        private const string employeId3 = "C55678B8-4209-4115-9631-1CE51E2AC5F7";

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(b => b.Diplomas).WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.Schools).WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            var user1 = new User
            {
                Id = adminId,
                NatCardNumber = "ASFD686G45",
                SecCardNumber = "2132127439873",
                UserName = "Admin1",
                NormalizedUserName = "ADMIN1@ADMIN.FR",
                FirstName = "Admin1",
                LastName = "Admin",
                Email = "admin1@admin.fr",
                NormalizedEmail = "ADMIN1@ADMIN.FR",
                BirthDate = new DateTime(1996, 01, 31),
                BirthPlace = "place1",
                BirthCountry = "pays1",
                Nationality = "nat1",
                AddressId = adressId1,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            var user2 = new User
            {
                Id = employeId1,
                NatCardNumber = "ASFD686G45",
                SecCardNumber = "2132127439873",
                UserName = "Emp2",
                NormalizedUserName = "EMP2@EMP.FR",
                FirstName = "Emp2",
                LastName = "Emp",
                Email = "emp2@emp.fr",
                NormalizedEmail = "EMP2@EMP.FR",
                BirthDate = new DateTime(1986, 10, 11),
                BirthPlace = "place1",
                BirthCountry = "pays1",
                Nationality = "nat1",
                AddressId = adressId2,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            var user3 = new User
            {
                Id = employeId2,
                NatCardNumber = "ASFD686G45",
                SecCardNumber = "2132127439873",
                UserName = "Emp3",
                NormalizedUserName = "EMP3@EMP.FR",
                FirstName = "Emp3",
                LastName = "Emp",
                Email = "emp3@emp.fr",
                NormalizedEmail = "EMP3@EMP.FR",
                BirthDate = new DateTime(1990, 12, 31),
                BirthPlace = "place3",
                BirthCountry = "pays1",
                Nationality = "nat1",
                AddressId = adressId3,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            var user4 = new User
            {
                Id = employeId3,
                NatCardNumber = "ASFD686G45",
                SecCardNumber = "2132127439873",
                UserName = "Emp4",
                NormalizedUserName = "EMP4@EMP.FR",
                FirstName = "Emp4",
                LastName = "emp4",
                Email = "emp4@emp.fr",
                NormalizedEmail = "EMP4@EMP.FR",
                BirthDate = new DateTime(1975, 05, 21),
                BirthPlace = "place4",
                BirthCountry = "pays1",
                Nationality = "nat1",
                AddressId = adressId4,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            var hasher = new PasswordHasher<User>();
            user1.PasswordHash = hasher.HashPassword(user1, "Man012345!");
            user2.PasswordHash = hasher.HashPassword(user2, "Emp012345!");
            user3.PasswordHash = hasher.HashPassword(user3, "Emp012345!");
            user4.PasswordHash = hasher.HashPassword(user4, "Emp012345!");
            builder.HasData(user1, user2, user3 ,user4);
        }
    }

}