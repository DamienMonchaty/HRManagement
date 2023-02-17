using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HRManagement.Web.Models
{
    public class User : IdentityUser
    {
        public string NatCardNumber { get; set; }
        public string SecCardNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string BirthCountry { get; set; }
        public string Nationality { get; set; }
        public float NetSalary { get; set; }
        public float BrutSalary { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public PositionEnum PositionEnum { get; set; }
        [JsonIgnore]
        public string AddressId { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<Diploma> Diplomas { get; set; }
        public virtual ICollection<School> Schools { get; set; }
        public User()
        {
            Diplomas = new List<Diploma>();
            Schools = new List<School>();
        }
    }
}
