using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using HRManagement.Web.Context;
using HRManagement.Web.Models;
using HRManagement.Web.Repository;
using System.Threading.Tasks;

namespace HRManagement.Tests.Repository
{
    [TestClass]
    public class ProjectRepositoryTest
    {
        [TestInitialize]
        public void Init()
        {
            var db = GetMemoryContext();
            db.Database.EnsureDeleted();
            db.Projects.Add(new Project { Id = "1", Libelle = "Lib1", Description = "Desc1", StartDate = "00/00/0000", EndDate = "00/00/0000" });
            db.Projects.Add(new Project { Id = "2", Libelle = "Lib2", Description = "Desc2", StartDate = "00/00/0000", EndDate = "00/00/0000" });
            db.Users.Add(new User { Id = "1", UserName = "User1" });
            db.Users.Add(new User { Id = "2", UserName = "User2" });
            db.UserProjects.Add(new UserProject { UserId = "1", ProjectId = "1" });
            db.UserProjects.Add(new UserProject { UserId = "2", ProjectId = "1" });
            db.SaveChanges();
        }

        [TestMethod]
        public async Task TestAdd()
        {
            // Arrange
            ProjectRepository repository = new ProjectRepository(GetMemoryContext());

            var projectToAdd = new Project()
            {
                Libelle = "Lib3",
                Description = "Desc3",
                StartDate = "00/00/0000",
                EndDate = "00/00/0000"
            };
            // Act
            var projectAdded = await repository.Add(projectToAdd);

            // Assert
            Assert.AreEqual(projectToAdd, projectAdded);
        }

        [TestMethod]
        public async Task TestFindById()
        {
            // Arrange
            ProjectRepository repository = new ProjectRepository(GetMemoryContext());

            // Act
            var project = await repository.GetById("1");

            // Assert
            Assert.AreEqual("Lib1", project.Libelle);
        }

        [TestMethod]
        public async Task TestDelete()
        {
            // Arrange
            ProjectRepository repository = new ProjectRepository(GetMemoryContext());

            // Act
            var project = await repository.GetById("1");
            await repository.Delete(project);
            var list = await repository.GetAllRoot();

            // Assert
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            // Arrange
            ProjectRepository repository = new ProjectRepository(GetMemoryContext());

            var projectToEdit = new Project()
            {
                Id = "1",
                Libelle = "Lib101",
                Description = "Desc1",
                StartDate = "00/00/0000",
                EndDate = "00/00/0000"
            };
            // Act
            var projectEdited = await repository.Update(projectToEdit);

            // Assert
            Assert.AreEqual("Lib101", projectEdited.Libelle);
        }

        [TestMethod]
        public async Task TestCount()
        {
            // Arrange
            ProjectRepository repository = new ProjectRepository(GetMemoryContext());

            // Act
            var count = await repository.Count();

            // Assert
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public async Task TestGetAllRoot()
        {
            // Arrange
            ProjectRepository repository = new ProjectRepository(GetMemoryContext());

            // Act
            var list = await repository.GetAllRoot();

            // Assert
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void TestGetAll()
        {
            // Arrange
            ProjectRepository repository = new ProjectRepository(GetMemoryContext());

            // Act
            var list = repository.GetAll();

            // Assert
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void TestGetAllProjectsByUserId()
        {
            // Arrange
            ProjectRepository repository = new ProjectRepository(GetMemoryContext());

            // Act
            var list = repository.GetAllProjectsByUserId("1");

            // Assert
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public async Task TestGetAllUsersByProject()
        {
            // Arrange
            ProjectRepository repository = new ProjectRepository(GetMemoryContext());

            // Act
            var users = await repository.GetAllUsersByProject("1");

            // Assert
            Assert.AreEqual(2, users.Count);
        }

        public static ApplicationContext GetMemoryContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .Options;
            return new ApplicationContext(options);
        }
    }
}
