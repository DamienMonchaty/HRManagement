using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Web.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        private const string adminId = "2301D884-221A-4E7D-B509-0113DCC043E1";
        private const string employeeId = "7D9B7113-A8F8-4035-99A7-A20DD400F6A3";

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Id = employeeId,
                Name = "Employe",
                NormalizedName = "EMPLOYE"
            },
            new IdentityRole
            {
                Id = adminId,
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            });
        }
    }
}
