using HRManagement.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using BC = BCrypt.Net.BCrypt;

namespace HRManagement.Business.Context
{
    public class ModelDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Holidays> Holidays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HRManagement.db51;integrated security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Utilise Fluent API pour configurer notre Db, cad, tables, index et relation

            // Mappings vers le tables
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Employee>().ToTable("employees");
            modelBuilder.Entity<Project>().ToTable("employee_projects");
            modelBuilder.Entity<EmployeeProject>().ToTable("projects");
            modelBuilder.Entity<Enterprise>().ToTable("enterprises");
            modelBuilder.Entity<Appointment>().ToTable("appointments");
            modelBuilder.Entity<Address>().ToTable("addresses");
            modelBuilder.Entity<Holidays>().ToTable("holydays");


            // Declare PK
            //modelBuilder.Entity<User>().HasKey(u => u.Id).HasName("PK_Users");
            //modelBuilder.Entity<Appointment>().HasKey(u => u.Id).HasName("PK_Appointment");
            //modelBuilder.Entity<Address>().HasKey(u => u.Id).HasName("PK_Address");
            //modelBuilder.Entity<Holidays>().HasKey(u => u.Id).HasName("PK_Holidays");

            // Configuration des tables

            // Table User
            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            modelBuilder.Entity<User>().Property(u => u.UserName).HasColumnType("nvarchar(100)").IsRequired(false);
            modelBuilder.Entity<User>().Property(u => u.FirstName).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.LastName).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Email).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Sexe).HasColumnType("nvarchar(100)").IsRequired(false);
            modelBuilder.Entity<User>().Property(u => u.BirthDate).HasColumnType("date").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.BirthPlace).HasColumnType("nvarchar(100)").IsRequired(false);
            modelBuilder.Entity<User>().Property(u => u.BirthCountry).HasColumnType("nvarchar(100)").IsRequired(false);
            modelBuilder.Entity<User>().Property(u => u.Nationality).HasColumnType("nvarchar(100)").IsRequired(false);
            modelBuilder.Entity<User>().Property(u => u.AddressId).HasColumnType("int");
            modelBuilder.Entity<User>().HasIndex(u => u.AddressId).IsUnique(); 
            modelBuilder.Entity<User>().Property(u => u.Active).HasDefaultValue(true);

            // Relation OneToOne
            // Un User peut avoir une et une seule adresse
            modelBuilder.Entity<User>().HasOne(s => s.Address).WithOne(ad => ad.User).HasForeignKey<User>(ad => ad.AddressId);

            // Table Address
            modelBuilder.Entity<Address>().Property(u => u.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            modelBuilder.Entity<Address>().Property(u => u.Street1).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Address>().Property(u => u.Street2).HasColumnType("nvarchar(100)").IsRequired(false);
            modelBuilder.Entity<Address>().Property(u => u.Street3).HasColumnType("nvarchar(100)").IsRequired(false);
            modelBuilder.Entity<Address>().Property(u => u.ZipCode).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Address>().Property(u => u.City).HasColumnType("nvarchar(100)").IsRequired();

            // Table Enterprise
            modelBuilder.Entity<Enterprise>().Property(u => u.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            modelBuilder.Entity<Enterprise>().Property(u => u.EmployeeId).HasColumnType("int").IsRequired(false);
            modelBuilder.Entity<Enterprise>().Property(u => u.RhEmployeeId).HasColumnType("int").IsRequired(false);

            // Relation OneToOne
            // Un Employe peut avoir un et un seul referent
            modelBuilder.Entity<Enterprise>().HasOne(e => e.Employee).WithOne().HasForeignKey<Enterprise>(e => e.EmployeeId).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Enterprise>().HasOne(e => e.RhEmployee).WithOne().HasForeignKey<Enterprise>(e => e.RhEmployeeId).OnDelete(DeleteBehavior.ClientSetNull);

            // Table Project
            modelBuilder.Entity<Project>().Property(u => u.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            modelBuilder.Entity<Project>().Property(u => u.Title).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Project>().Property(u => u.Description).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Project>().Property(u => u.StartDate).HasColumnType("date").IsRequired();
            modelBuilder.Entity<Project>().Property(u => u.EndDate).HasColumnType("date").IsRequired(false);

            // Table Employee
            //modelBuilder.Entity<Employee>().Property(u => u.RegistrationNumber).HasColumnType("nvarchar(100)").IsRequired();
            //modelBuilder.Entity<Employee>().Property(u => u.SocialSecurityNumber).HasColumnType("nvarchar(100)").IsRequired();
            //modelBuilder.Entity<Employee>().Property(u => u.Fonction).HasColumnType("nvarchar(100)").IsRequired();
            //modelBuilder.Entity<Employee>().Property(u => u.ContractType).HasColumnType("nvarchar(100)").IsRequired(false);
            //modelBuilder.Entity<Employee>().Property(u => u.ContractDuration).HasColumnType("nvarchar(100)").IsRequired(false);
            //modelBuilder.Entity<Employee>().Property(u => u.Experience).HasColumnType("float").IsRequired(false);
            //modelBuilder.Entity<Employee>().Property(u => u.RawSalary).HasColumnType("double").IsRequired(false);
            //modelBuilder.Entity<Employee>().Property(u => u.AdditionalIndemnity).HasColumnType("double").IsRequired(false);
            //modelBuilder.Entity<Employee>().Property(u => u.Salary).HasColumnType("double").IsRequired(false);
            //modelBuilder.Entity<Employee>().Property(u => u.MaritalStatus).HasColumnType("nvarchar(100)").IsRequired();
            //modelBuilder.Entity<Employee>().Property(u => u.CommitmentDate).HasColumnType("date").IsRequired();
            //modelBuilder.Entity<Employee>().Property(u => u.Seniority).HasColumnType("float").IsRequired();

            // Relation OneToMany
            // Un employe peut demander une ou plusieurs vacances
            modelBuilder.Entity<Holidays>().HasOne<Employee>().WithMany(g => g.Holidays).HasPrincipalKey(u => u.Id)
               .HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_Employes_HolidaysGroup");

            // Un employe peut demander un ou plusieurs rendez-vous
            modelBuilder.Entity<Appointment>().HasOne<Employee>().WithMany(g => g.Appointments).HasPrincipalKey(u => u.Id)
                .HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_Employes_AppointmentsGroup");

            // Table EmployeeProject
            modelBuilder.Entity<EmployeeProject>().HasKey(c => new { c.EmployeeId, c.ProjectId });

            // Relation ManyToMany
            // Un employee peut travailler sur un ou plusieurs projets
            // Un projet peut etre concu par un ou plusieurs employees
            modelBuilder.Entity<EmployeeProject>().HasOne(sc => sc.Employee).WithMany(s => s.EmployeeProjects).HasForeignKey(sc => sc.EmployeeId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<EmployeeProject>().HasOne(sc => sc.Project).WithMany(s => s.EmployeeProjects).HasForeignKey(sc => sc.ProjectId).OnDelete(DeleteBehavior.Cascade);

            // Table Appointment
            modelBuilder.Entity<Appointment>().Property(u => u.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            modelBuilder.Entity<Appointment>().Property(u => u.Title).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Appointment>().Property(u => u.Description).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Appointment>().Property(u => u.AppointmentDate).HasColumnType("date").IsRequired();

            // Table Holidays
            modelBuilder.Entity<Holidays>().Property(u => u.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            modelBuilder.Entity<Holidays>().Property(u => u.StartDate).HasColumnType("date").IsRequired();
            modelBuilder.Entity<Holidays>().Property(u => u.EndDate).HasColumnType("date").IsRequired();

            // Seeding Data
            modelBuilder.Entity<Address>().HasData(
               new Address
               {
                   Id = 1,
                   Street1 = "rue1",
                   Street2 = "opt rue2",
                   Street3 = "opt rue2",
                   ZipCode = "cp000",
                   City = "ville",
               },
               new Address
               {
                   Id = 2,
                   Street1 = "rue1",
                   Street2 = "opt rue2",
                   Street3 = "opt rue2",
                   ZipCode = "cp000",
                   City = "ville",
               },
               new Address
               {
                   Id = 3,
                   Street1 = "rue1",
                   Street2 = "opt rue2",
                   Street3 = "opt rue2",
                   ZipCode = "cp000",
                   City = "ville",
               },
               new Address
               {
                   Id = 4,
                   Street1 = "rue1",
                   Street2 = "opt rue2",
                   Street3 = "opt rue2",
                   ZipCode = "cp000",
                   City = "ville",
               },
               new Address
               {
                   Id = 5,
                   Street1 = "rue1",
                   Street2 = "opt rue2",
                   Street3 = "opt rue2",
                   ZipCode = "cp000",
                   City = "ville",
               },
               new Address
               {
                   Id = 6,
                   Street1 = "rue1",
                   Street2 = "opt rue2",
                   Street3 = "opt rue2",
                   ZipCode = "cp000",
                   City = "ville",
               }
           );

            //modelBuilder.Entity<User>().HasData(
            //    new User
            //    {
            //        Id = 1,
            //        UserName = "prenom1",
            //        FirstName = "nom1",
            //        LastName = "prenom1",
            //        Email = "email1@email.fr",
            //        Password = BC.HashPassword("password"),
            //        Sexe = "sexe1",
            //        BirthDate = new DateTime(2015, 12, 25, 10, 30, 45),
            //        BirthPlace = "villeNaissance1",
            //        BirthCountry = "pays1",
            //        Nationality = "Nat1",
            //        Active = true,
            //        Role = "User",
            //        AddressId = 1
            //    },
            //    new User
            //    {
            //        Id = 2,
            //        UserName = "prenom2",
            //        FirstName = "nom2",
            //        LastName = "prenom2",
            //        Email = "email2@email.fr",
            //        Password = BC.HashPassword("password"),
            //        Sexe = "sexe1",
            //        BirthDate = new DateTime(2015, 12, 25, 10, 30, 45),
            //        BirthPlace = "villeNaissance2",
            //        BirthCountry = "pays2",
            //        Nationality = "Nat2",
            //        Active = true,
            //        Role = "Admin",
            //        AddressId = 2
            //    },
            //    new User
            //    {
            //        Id = 3,
            //        UserName = "prenom3",
            //        FirstName = "nom3",
            //        LastName = "prenom3",
            //        Email = "email3@email.fr",
            //        Password = BC.HashPassword("password"),
            //        Sexe = "sexe3",
            //        BirthDate = new DateTime(2015, 12, 25, 10, 30, 45),
            //        BirthPlace = "villeNaissance3",
            //        BirthCountry = "pays3",
            //        Nationality = "Nat3",
            //        Active = true,
            //        Role = "Admin",
            //        AddressId = 3
            //    }
            //); ;

          //  modelBuilder.Entity<Employee>().HasData(
          //    new Employee
          //    {
          //        Id = 4,
          //        UserName = "prenom4",
          //        FirstName = "nom4",
          //        LastName = "prenom4",
          //        Email = "email4@email.fr",
          //        Password = BC.HashPassword("password"),
          //        Sexe = "sexe2",
          //        BirthDate = new DateTime(2015, 12, 25, 10, 30, 45),
          //        BirthPlace = "villeNaissance4",
          //        BirthCountry = "pays2",
          //        Nationality = "Nat2",
          //        Active = true,
          //        RegistrationNumber = "RegistrationNumber4",
          //        SocialSecurityNumber = "SocialSecurityNumber4",
          //        Fonction = "Fonction1",
          //        ContractType = "ContratType1",
          //        ContractDuration = "ContratDuration1",
          //        Experience = 10.0f,
          //        RawSalary = 1000.0d,
          //        AdditionalIndemnity = 200.0d,
          //        Salary = 1200.0d,
          //        MaritalStatus = "Status1",
          //        CommitmentDate = new DateTime(2019, 12, 25, 10, 30, 45),
          //        Seniority = 5.0f,
          //        Role = "User",
          //        AddressId = 4
          //    },
          //    new Employee
          //    {
          //        Id = 5,
          //        UserName = "prenom5",
          //        FirstName = "nom5",
          //        LastName = "prenom5",
          //        Email = "email5@email.fr",
          //        Password = BC.HashPassword("password"),
          //        Sexe = "sexe1",
          //        BirthDate = new DateTime(2015, 12, 25, 10, 30, 45),
          //        BirthPlace = "villeNaissance5",
          //        BirthCountry = "pays1",
          //        Nationality = "Nat1",
          //        Active = true,
          //        RegistrationNumber = "RegistrationNumber5",
          //        SocialSecurityNumber = "SocialSecurityNumber5",
          //        Fonction = "Fonction1",
          //        ContractType = "ContratType2",
          //        ContractDuration = "ContratDuration2",
          //        Experience = 10.0f,
          //        RawSalary = 1000.0d,
          //        AdditionalIndemnity = 200.0d,
          //        Salary = 1200.0d,
          //        MaritalStatus = "Status2",
          //        CommitmentDate = new DateTime(2019, 12, 25, 10, 30, 45),
          //        Seniority = 5.0f,
          //        Role = "User",
          //        AddressId = 5
          //    },
          //    new Employee
          //    {
          //        Id = 6,
          //        UserName = "prenom6",
          //        FirstName = "nom6",
          //        LastName = "prenom6",
          //        Email = "email6@email.fr",
          //        Password = BC.HashPassword("password"),
          //        Sexe = "sexe6",
          //        BirthDate = new DateTime(2015, 12, 25, 10, 30, 45),
          //        BirthPlace = "villeNaissance6",
          //        BirthCountry = "pays2",
          //        Nationality = "Nat2",
          //        Active = true,
          //        RegistrationNumber = "RegistrationNumber6",
          //        SocialSecurityNumber = "SocialSecurityNumber6",
          //        Fonction = "Fonction1",
          //        ContractType = "ContratType1",
          //        ContractDuration = "ContratDuration1",
          //        Experience = 10.0f,
          //        RawSalary = 1000.0d,
          //        AdditionalIndemnity = 200.0d,
          //        Salary = 1200.0d,
          //        MaritalStatus = "Status1",
          //        CommitmentDate = new DateTime(2019, 12, 25, 10, 30, 45),
          //        Seniority = 5.0f,
          //        Role = "User",
          //        AddressId = 6
          //    }
          //);

            modelBuilder.Entity<Enterprise>().HasData(
               new Enterprise
               {
                   Id = 1,
                   EmployeeId = 4,
                   RhEmployeeId = 6
               },
               new Enterprise
               {
                   Id = 2,
                   EmployeeId = 5,
                   RhEmployeeId = 6
               }
           );

            modelBuilder.Entity<Project>().HasData(
               new Project
               {
                   Id = 1,
                   Title = "Projet1",
                   Description = "desc1",
                   StartDate = new DateTime(2018, 12, 25, 10, 30, 45)
               },
               new Project
               {
                   Id = 2,
                   Title = "Projet2",
                   Description = "desc2",
                   StartDate = new DateTime(2018, 12, 25, 10, 30, 45)
               },
               new Project
               {
                   Id = 3,
                   Title = "Projet3",
                   Description = "desc3",
                   StartDate = new DateTime(2018, 12, 25, 10, 30, 45)
               }
           );

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    EmployeeId = 4,
                    ProjectId = 2
                },
                new EmployeeProject
                {
                    EmployeeId = 4,
                    ProjectId = 3
                },
                 new EmployeeProject
                 {
                     EmployeeId = 5,
                     ProjectId = 1
                 }
              );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 1,
                    Title = "titre1",
                    Description = "desc1",
                    AppointmentDate = new DateTime(2018, 12, 25, 10, 30, 45),
                    Status = Status.ACCEPTED,
                    UserId = 4
                },
                new Appointment
                {
                    Id = 2,
                    Title = "titre2",
                    Description = "desc2",
                    AppointmentDate = new DateTime(2018, 12, 25, 10, 30, 45),
                    Status = Status.ACCEPTED,
                    UserId = 4
                },
                new Appointment
                {
                    Id = 3,
                    Title = "titre3",
                    Description = "desc3",
                    AppointmentDate = new DateTime(2018, 12, 25, 10, 30, 45),
                    Status = Status.ACCEPTED,
                    UserId = 5
                },
                new Appointment
                {
                    Id = 4,
                    Title = "titre4",
                    Description = "desc4",
                    AppointmentDate = new DateTime(2018, 12, 25, 10, 30, 45),
                    Status = Status.ACCEPTED,
                    UserId = 5
                },
                new Appointment
                {
                    Id = 5,
                    Title = "titre5",
                    Description = "desc5",
                    AppointmentDate = new DateTime(2018, 12, 25, 10, 30, 45),
                    Status = Status.ACCEPTED,
                    UserId = 6
                },
                new Appointment
                {
                    Id = 6,
                    Title = "titre6",
                    Description = "desc6",
                    AppointmentDate = new DateTime(2018, 12, 25, 10, 30, 45),
                    Status = Status.ACCEPTED,
                    UserId = 6
                }
            );

            modelBuilder.Entity<Holidays>().HasData(
                new Holidays
                {
                    Id = 1,
                    StartDate = new DateTime(2018, 12, 25, 10, 30, 45),
                    EndDate = new DateTime(2018, 12, 27, 10, 30, 45),
                    Status = Status.ACCEPTED,
                    UserId = 4
                },
                new Holidays
                {
                    Id = 2,
                    StartDate = new DateTime(2018, 12, 25, 10, 30, 45),
                    EndDate = new DateTime(2018, 12, 27, 10, 30, 45),
                    Status = Status.IN_PROGRESS,
                    UserId = 4
                },
                new Holidays
                {
                    Id = 3,
                    StartDate = new DateTime(2018, 12, 25, 10, 30, 45),
                    EndDate = new DateTime(2018, 12, 27, 10, 30, 45),
                    Status = Status.ACCEPTED,
                    UserId = 5
                },
                new Holidays
                {
                    Id = 4,
                    StartDate = new DateTime(2018, 12, 25, 10, 30, 45),
                    EndDate = new DateTime(2018, 12, 27, 10, 30, 45),
                    Status = Status.NOT_ACCEPTED,
                    UserId = 5
                },
                new Holidays
                {
                    Id = 5,
                    StartDate = new DateTime(2018, 12, 25, 10, 30, 45),
                    EndDate = new DateTime(2018, 12, 27, 10, 30, 45),
                    Status = Status.ACCEPTED,
                    UserId = 6
                },
                new Holidays
                {
                    Id = 6,
                    StartDate = new DateTime(2018, 12, 25, 10, 30, 45),
                    EndDate = new DateTime(2018, 12, 27, 10, 30, 45),
                    Status = Status.IN_PROGRESS,
                    UserId = 6
                }
            );
        }
    }
}
