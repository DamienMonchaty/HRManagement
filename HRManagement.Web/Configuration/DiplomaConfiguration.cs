using HRManagement.Web.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Web.Configuration
{
    public class DiplomaConfiguration : IEntityTypeConfiguration<Diploma>
    {
        private const string diplomaId1 = "B123V455-42A2-3456-9631-1DHZSE2QE4F7";
        private const string diplomaId2 = "C4469D48-89A2-3615-9631-1C2D1E2AC2&7";
        private const string diplomaId3 = "C4H83D48-89A2-3615-9631-1C2DAL0AC9&7";

        private const string adminId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";
        private const string employeId = "E22678B8-42A2-4115-9631-1CE51E2AC5F7";

        public void Configure(EntityTypeBuilder<Diploma> builder)
        {
            builder.HasData(
            new Diploma
            {
                Id = diplomaId1,
                Libelle = "BTS SIO",
                EndDate = "10-09-2015",
                StartDate = "10-07-2017",
                UserId = employeId,
            },
            new Diploma
            {
                Id = diplomaId2,
                Libelle = "DUT informatique",
                EndDate = "09-10-2011",
                StartDate = "03-07-2013",
                UserId = employeId,
            },
             new Diploma
             {
                 Id = diplomaId3,
                 Libelle = "Licence RH",
                 EndDate = "10-09-20110",
                 StartDate = "10-07-2013",
                 UserId = adminId,
             }
            );
        }
    }
}
