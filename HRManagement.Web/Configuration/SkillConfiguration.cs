using HRManagement.Web.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Web.Configuration
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        private const string skillId1 = "B22699V4-42A2-4666-9631-1C2D1E2QE4F7";
        private const string skillId2 = "C44698B8-89A2-4115-9631-1C2D1E2AC5F7";
        private const string skillId3 = "D55699V4-42A2-4666-9631-1C2D1E2QE4F7";
        private const string skillId4 = "E66698B8-89A2-4115-9631-1C2D1E2AC5F7";
        private const string skillId5 = "E87658B8-89A2-4115-9631-1C2D1E2AC5F7";

        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasData(
                new Skill
                {
                    Id = skillId1,
                    Libelle = "Python",
                    Description = "Lorem ispum"
                },
                new Skill
                {
                    Id = skillId2,
                    Libelle = "Java",
                    Description = "Lorem ispum"
                },
                new Skill
                {
                    Id = skillId3,
                    Libelle = "C#",
                    Description = "Lorem ispum"
                },
                new Skill
                {
                    Id = skillId4,
                    Libelle = "PHP",
                    Description = "Lorem ispum"
                }
                ,
                new Skill
                {
                    Id = skillId5,
                    Libelle = "NodeJS",
                    Description = "Lorem ispum"
                }
            );
        }
    }

}