using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Nest;
using EntityFrameworkCore.EncryptColumn.Attribute;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.Web.Models
{
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Libelle { get; set; }
        [JsonIgnore]
        public CompletionField LibelleSearch { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }
        [EncryptColumn]
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? EndDate { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public StatusEnum ProjectEnum { get; set; }
        [JsonIgnore]
        public string ClientId { get; set; }
        public Client Client { get; set; }
        public virtual ICollection<UserProject> UserProjects { get; set; }
        public virtual ICollection<Mission> Missios { get; set; }
        //public Project()
        //{
        //    UserProjects = new List<UserProject>();
        //}
    }
}
