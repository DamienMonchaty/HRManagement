using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using HRManagement.Web.Configuration;
using HRManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Web.Context
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        private readonly IEncryptionProvider _provider;

        public ApplicationContext(DbContextOptions options)
        : base(options)
        {
            this._provider = new GenerateEncryptionProvider("mysmallkey123456");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseEncryption(this._provider);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UsersWithRolesConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new UserProjectConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new DiplomaConfiguration());
            modelBuilder.ApplyConfiguration(new SchoolConfiguration());

            modelBuilder.ApplyConfiguration(new SkillConfiguration());
            modelBuilder.ApplyConfiguration(new DiplomaSkillConfiguration());
            modelBuilder.ApplyConfiguration(new MissionSkillConfiguration());
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Diploma> Diplomas { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<Mission> Missions { get; set; }
        
        public DbSet<Skill> Skills { get; set; }
        public DbSet<MissionSkill> MissionSkills { get; set; }
        public DbSet<DiplomaSkill> DiplomaSkills { get; set; }
    }
}
