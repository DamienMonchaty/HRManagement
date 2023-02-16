using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Web.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Fonction { get; set; }
        public string ContractType { get; set; }
        public string ContractDuration { get; set; }
    }
}
