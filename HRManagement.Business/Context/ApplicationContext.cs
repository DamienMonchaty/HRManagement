using HRManagement.Common.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Business.Context
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HRManagement.db51;integrated security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mappings vers le tables
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Employee>().ToTable("employees");
            modelBuilder.Entity<Project>().ToTable("employee_projects");
            modelBuilder.Entity<EmployeeProject>().ToTable("projects");
            modelBuilder.Entity<Enterprise>().ToTable("enterprises");
            modelBuilder.Entity<Appointment>().ToTable("appointments");
            modelBuilder.Entity<Address>().ToTable("addresses");
            modelBuilder.Entity<Holidays>().ToTable("holydays");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
