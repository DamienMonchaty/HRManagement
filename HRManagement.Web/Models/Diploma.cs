using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Web.Models
{
    public class Diploma
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Libelle { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
