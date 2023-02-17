using HRManagement.Web.Models;
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

        private const string adminId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";
        private const string employeId = "E22678B8-42A2-4115-9631-1CE51E2AC5F7";

        public void Configure(EntityTypeBuilder<User> builder)
        {
            var user1 = new User
            {
                Id = adminId,
                UserName = "p1@p.fr",
                NormalizedUserName = "P1@P.FR",
                FirstName = "prenom1",
                LastName = "nom1",
                Email = "p1@p.fr",
                NormalizedEmail = "P1@P.FR",
                BirthPlace = "place1",
                BirthCountry = "pays1",
                Nationality = "nat1",
                AddressId = adressId1,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            var user2 = new User
            {
                Id = employeId,
                UserName = "prenom2",
                NormalizedUserName = "P2@P.FR",
                FirstName = "prenom2",
                LastName = "nom2",
                Email = "p2@p.fr",
                NormalizedEmail = "P2@P.FR",
                BirthPlace = "place1",
                BirthCountry = "pays1",
                Nationality = "nat1",
                AddressId = adressId2,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            var hasher = new PasswordHasher<User>();
            user1.PasswordHash = hasher.HashPassword(user1, "Jo012345!");
            user2.PasswordHash = hasher.HashPassword(user2, "Jo012345!");
            builder.HasData(user1, user2);
        }
    }

}