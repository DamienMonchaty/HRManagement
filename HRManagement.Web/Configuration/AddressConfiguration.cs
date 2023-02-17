using HRManagement.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Web.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        private const string adressId1 = "B22699V4-42A2-4666-9631-1C2D1E2QE4F7";
        private const string adressId2 = "C44698B8-89A2-4115-9631-1C2D1E2AC5F7";

        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasData(
            new Address
            {
                Id = adressId1,
                Street1 = "RUE ALBERT 1er",
                Street2 = "autres",
                Street3 = "autres",
                ZipCode = "06000",
                City = "NICE",
            },
            new Address
            {
                Id = adressId2,
                Street1 = "RUE Jean Jaurès",
                Street2 = "autres",
                Street3 = "autres",
                ZipCode = "69000",
                City = "LYON",
            });
        }
    }

}