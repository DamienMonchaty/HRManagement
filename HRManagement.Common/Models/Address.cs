using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace HRManagement.Common.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Street3 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}