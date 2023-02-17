using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Common.Models
{
    public class Employee : User, IDisposable
    {
        public string RegistrationNumber { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Fonction { get; set; }
        public string ContractType { get; set; }
        public string ContractDuration { get; set; }
        public float Experience { get; set; }
        public double RawSalary { get; set; }
        public double AdditionalIndemnity { get; set; }
        public double Salary { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime CommitmentDate { get; set; }
        public float Seniority { get; set; }
        public virtual ICollection<Holidays> Holidays { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }

        public void Dispose()
        {
           
        }
    }
}
