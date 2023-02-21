using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace HRManagement.Web.Models
{
    public class UserProject
    {
        public string UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        public string ProjectId { get; set; }
        [JsonIgnore]
        public virtual Project Project { get; set; }
    }
}
