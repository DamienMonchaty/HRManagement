using HRManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Web.Dto
{
    public class ProjectViewModel
    {
        public string Id { get; set; }
        [Required]
        public string Libelle { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        public string ProjectEnum { get; set; }
        public Client Client { get; set; }
        public string ClientId { get; set; }
        public List<User> Users { get; set; }
        public List<string> UsersIds { get; set; }

        public ProjectViewModel()
        {
            Users = new List<User>();
        }
    }
}
