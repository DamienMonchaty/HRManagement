using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Web.Configuration
{
    public class UsersWithRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        private const string adminUserId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";
        private const string adminRoleId = "2301D884-221A-4E7D-B509-0113DCC043E1";

        private const string empUserId = "E22678B8-42A2-4115-9631-1CE51E2AC5F7";
        private const string empRoleId = "7D9B7113-A8F8-4035-99A7-A20DD400F6A3";

        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            IdentityUserRole<string> iur = new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminUserId
            };
            IdentityUserRole<string> iur2 = new IdentityUserRole<string>
            {
                RoleId = empRoleId,
                UserId = empUserId
            };
            builder.HasData(iur);
            builder.HasData(iur2);
        }
    }
}
