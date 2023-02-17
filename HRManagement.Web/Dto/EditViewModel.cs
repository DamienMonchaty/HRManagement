using HRManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Web.Dto
{
    public class EditViewModel
    {
        public string Id { get; set; }
        [Required]
        public string NatCardNumber { get; set; }
        [Required]
        public string SecCardNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string BirthPlace { get; set; }
        [Required]
        public string BirthCountry { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public Address Address { get; set; }
        public float NetSalary { get; set; }
        public float BrutSalary { get; set; }
        public string PositionEnum { get; set; }
        public List<DiplomaViewModel> Diplomas { get; set; }
        public List<SchoolViewModel> Schools { get; set; }
    }
}
