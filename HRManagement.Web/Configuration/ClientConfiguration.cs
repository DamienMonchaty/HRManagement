using HRManagement.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Web.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        private const string clientId1 = "B22699V4-42A2-4666-9631-1D9D1E2QE4F7";
        private const string clientId2 = "C4469D48-89A2-3615-9631-1C2D1E2AC/&7";

        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasData(
            new Client
            {
                Id = clientId1,
                Name = "CLIENT1",
                Description = "DESC CLIENT1"
            },
            new Client
            {
                Id = clientId2,
                Name = "CLIENT2",
                Description = "DESC CLIENT2"
            });
        }
    }
}
