using HRManagement.Web.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Web.Configuration
{
    public class MissionSkillConfiguration : IEntityTypeConfiguration<MissionSkill>
    {
        public void Configure(EntityTypeBuilder<MissionSkill> builder)
        {
            builder.HasKey(c => new { c.MissionId, c.SkillId });
        }
    }
}
