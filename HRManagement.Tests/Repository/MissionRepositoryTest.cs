using HRManagement.Web.Context;
using HRManagement.Web.Models;
using HRManagement.Web.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Tests.Repository
{
    [TestClass]
    public class MissionRepositoryTest
    {
        [TestInitialize]
        public void Init()
        {
            var db = GetMemoryContext();
            db.Database.EnsureDeleted();
            db.Missions.Add(new Mission { Id = "1", Name = "M1", Description = "Desc1", MissionEnum = StatusEnum.EN_COURS, UserId = "1" });
            db.Missions.Add(new Mission { Id = "2", Name = "M2", Description = "Desc2", MissionEnum = StatusEnum.EN_COURS, UserId = "1" });
            db.Users.Add(new User { Id = "1", UserName = "User1" });
            db.SaveChanges();
        }

        [TestMethod]
        public async Task TestAdd()
        {
            // Arrange
            MissionRepository repository = new MissionRepository(GetMemoryContext());

            var missionToAdd = new Mission()
            {
                Id = "3",
                Name = "M3",
                Description = "Desc3",
                MissionEnum = StatusEnum.EN_PREPARATION
            };
            // Act
            var missionAdded = await repository.Add(missionToAdd);

            // Assert
            Assert.AreEqual(missionToAdd, missionAdded);
        }

        [TestMethod]
        public async Task TestFindById()
        {
            // Arrange
            MissionRepository repository = new MissionRepository(GetMemoryContext());

            // Act
            var mission = await repository.GetById("1");

            // Assert
            Assert.AreEqual("M1", mission.Name);
        }

        [TestMethod]
        public async Task TestDelete()
        {
            // Arrange
            MissionRepository repository = new MissionRepository(GetMemoryContext());

            // Act
            var mission = await repository.GetById("1");
            await repository.Delete(mission);
            var list = await repository.GetAllRoot();

            // Assert
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            // Arrange
            MissionRepository repository = new MissionRepository(GetMemoryContext());

            var missionToEdit = new Mission()
            {
                Id = "1",
                Name = "MISSION1",
                Description = "Desc3",
                MissionEnum = StatusEnum.EN_PREPARATION
            };
            // Act
            var missionEdited = await repository.Update(missionToEdit);

            // Assert
            Assert.AreEqual("MISSION1", missionEdited.Name);
        }

        [TestMethod]
        public async Task TestCount()
        {
            // Arrange
            MissionRepository repository = new MissionRepository(GetMemoryContext());

            // Act
            var count = await repository.Count();

            // Assert
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public async Task TestGetAllRoot()
        {
            // Arrange
            MissionRepository repository = new MissionRepository(GetMemoryContext());

            // Act
            var list = await repository.GetAllRoot();

            // Assert
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void TestGetAll()
        {
            // Arrange
            MissionRepository repository = new MissionRepository(GetMemoryContext());

            // Act
            var list = repository.GetAll();

            // Assert
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void TestGetAllMissionsByUserId()
        {
            // Arrange
            MissionRepository repository = new MissionRepository(GetMemoryContext());

            // Act
            var list = repository.GetAllMissionsByUserId("1");

            // Assert
            Assert.AreEqual(2, list.Count);
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
