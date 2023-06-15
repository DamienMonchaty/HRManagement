using EntityFrameworkCore.EncryptColumn.Attribute;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Web.Models
{
    public class Skill
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public virtual ICollection<MissionSkill> MissionSkills { get; set; }
        public virtual ICollection<DiplomaSkill> DiplomaSkills { get; set; }
    }
}
