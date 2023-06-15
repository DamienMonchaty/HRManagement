using System.Text.Json.Serialization;

namespace HRManagement.Web.Models
{
    public class DiplomaSkill
    {
        public string DiplomaId { get; set; }
        [JsonIgnore]
        public virtual Diploma Diploma { get; set; }
        public string SkillId { get; set; }
        [JsonIgnore]
        public virtual Skill Skill { get; set; }
    }
}
