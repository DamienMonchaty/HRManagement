using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HRManagement.Web.Models
{
    public class User : IdentityUser
    {
        [EncryptColumn]
        public string NatCardNumber { get; set; }
        [EncryptColumn]
        public string SecCardNumber { get; set; }
        [EncryptColumn]
        public string FirstName { get; set; }
        [EncryptColumn]
        public string LastName { get; set; }
        [EncryptColumn]
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        [EncryptColumn]
        public string BirthPlace { get; set; }
        [EncryptColumn]
        public string BirthCountry { get; set; }
        [EncryptColumn]
        public string Nationality { get; set; }
        [EncryptColumn]
        public float NetSalary { get; set; }
        [EncryptColumn]
        public float BrutSalary { get; set; }
        [EncryptColumn]
        [Column(TypeName = "nvarchar(20)")]
        public PositionEnum PositionEnum { get; set; }
        [JsonIgnore]
        public string AddressId { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<Diploma> Diplomas { get; set; }
        public virtual ICollection<School> Schools { get; set; }
        public virtual ICollection<UserProject> UserProjects { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
        //public User()
        //{
        //    Diplomas = new List<Diploma>();
        //    Schools = new List<School>();
        //    UserProjects = new List<UserProject>();
        //}
    }
}
