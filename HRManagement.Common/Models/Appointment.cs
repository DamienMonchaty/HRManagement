using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HRManagement.Common.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Status Status { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
    }
}