using HRManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Web.Dto
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public float BrutSalary { get; set; }
        [Required]
        public float NetSalary { get; set; }
        [Required]
        public PositionEnum PositionEnum { get; set; }
    }
}
