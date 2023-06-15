using System.Text.Json.Serialization;

namespace HRManagement.Web.Models
{
    public class MissionSkill
    {
        public string MissionId { get; set; }
        [JsonIgnore]
        public virtual Mission Mission { get; set; }
        public string SkillId { get; set; }
        [JsonIgnore]
        public virtual Skill Skill { get; set; }
    }
}
