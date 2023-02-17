using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HRManagement.Common.Models
{
    public class User : IdentityUser
    {
        //public int Id { get; set; }
        //public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Email { get; set; }
        public string Password { get; set; }
        public string Sexe { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string BirthCountry { get; set; }
        public string Nationality { get; set; }
        [JsonIgnore]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public bool Active { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}