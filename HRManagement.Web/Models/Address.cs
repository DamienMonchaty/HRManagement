using EntityFrameworkCore.EncryptColumn.Attribute;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HRManagement.Web.Models
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [EncryptColumn]
        public string Street1 { get; set; }
        [EncryptColumn]
        public string Street2 { get; set; }
        [EncryptColumn]
        public string Street3 { get; set; }
        [EncryptColumn]
        public string ZipCode { get; set; }
        [EncryptColumn]
        public string City { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}