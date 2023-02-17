using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HRManagement.Common.Models
{
    public class Enterprise
    {
        public int Id { get; set; }

        public int? EmployeeId { get; set; }
        [JsonIgnore]
        public Employee Employee { get; set; }

        public int? RhEmployeeId { get; set; }
        [JsonIgnore]
        public Employee RhEmployee { get; set; }
    }
}
