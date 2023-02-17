using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HRManagement.Common.Models
{
    public class EmployeeProject
    {
        public int EmployeeId { get; set; }
        [JsonIgnore]
        public virtual Employee Employee { get; set; }
        public int ProjectId { get; set; }
        [JsonIgnore]
        public virtual Project Project { get; set; }
    }
}
