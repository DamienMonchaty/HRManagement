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
        private const string adminId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";
        private const string employeId = "E22678B8-42A2-4115-9631-1CE51E2AC5F7";

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
            new User
            {
                Id = adminId,
                UserName = "prenom1",
                Email = "p1@p.fr",
                PasswordHash = BC.HashPassword("password"),
                EmailConfirmed = true
            },
            new User
            {
                Id = employeId,
                UserName = "prenom2",
                Email = "p2@p.fr",
                PasswordHash = BC.HashPassword("password"),
                EmailConfirmed = true
            }); 
        }
    }

}