using HRManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Web.Dto
{
    public class MissionViewModel
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string StatusEnum { get; set; }
        public Project Project { get; set; }
        public string ProjectId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
