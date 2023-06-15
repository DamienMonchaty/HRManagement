using HRManagement.Web.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Web.Configuration
{
    public class DiplomaSkillConfiguration : IEntityTypeConfiguration<DiplomaSkill>
    {
        public void Configure(EntityTypeBuilder<DiplomaSkill> builder)
        {
            builder.HasKey(c => new { c.DiplomaId, c.SkillId });
        }
    }
}
