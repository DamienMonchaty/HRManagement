using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HRManagement.Web.Models
{
    public class Mission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public StatusEnum MissionEnum { get; set; }
        [JsonIgnore]
        public string ProjectId { get; set; }
        public Project Project { get; set; }
        [JsonIgnore]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
