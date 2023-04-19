using HRManagement.Web.Controllers;
using HRManagement.Web.Dto;
using HRManagement.Web.Helpers;
using HRManagement.Web.Models;
using HRManagement.Web.Repository;
using HRManagement.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace HRManagement.Tests.Controllers
{
    [TestClass]
    public class MIssionControllerTest
    {
        private readonly Mock<IMissionRepository> _mockMissionRepo;
        private readonly Mock<IProjectRepository> _mockProjectRepo;
        private readonly Mock<IUserRepository> _mockUserRepo;
        private readonly Mock<Microsoft.AspNetCore.Identity.UserManager<User>> _mockUserManager;
        private readonly Mock<IEmailService> _mockEmailService;
        private readonly MissionController _controller;

        public MIssionControllerTest()
        {
            _mockMissionRepo = new Mock<IMissionRepository>();
            _mockProjectRepo = new Mock<IProjectRepository>();
            _mockUserRepo = new Mock<IUserRepository>();
            _mockUserManager = new Mock<Microsoft.AspNetCore.Identity.UserManager<User>>(Mock.Of<Microsoft.AspNetCore.Identity.IUserStore<User>>(), null, null, null, null, null, null, null, null);
            _mockEmailService = new Mock<IEmailService>();

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
            }));

            var appUser = new User
            {
                Id = "1",
                UserName = "John",
                PasswordHash = "1234"
            };

            _mockUserManager.Setup(x => x.GetUserAsync(user)).ReturnsAsync(appUser);

            _controller = new MissionController(
                _mockMissionRepo.Object,
                _mockProjectRepo.Object,
                _mockUserRepo.Object,
                _mockUserManager.Object,
                _mockEmailService.Object
                )
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                }
            };
        }

        [TestMethod]
        public void TestGetAllMissions()
        {
            // Arrange
            var missions = new List<Mission> { new Mission(), new Mission() };
            IPagedList<Mission> ipagedListMissionss = missions.ToPagedList(1, 5);

            _mockMissionRepo.Setup(x => x.GetAll(1)).Returns(ipagedListMissionss);

            var actionResult = _controller.GetAllMissions(1);
            var result = actionResult as PartialViewResult;

            // Assert
            Assert.AreEqual(@"~/Views/Shared/_Missions.cshtml", result.ViewName);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(IPagedList<Mission>));
        }

        //[TestMethod]
        //public async Task TestGetAllMissionsByUserId()
        //{
        //    // Arrange
        //    var missions = new List<Mission> { new Mission(), new Mission() };
        //    IPagedList<Mission> ipagedListMissionss = missions.ToPagedList(1, 5);

        //    _mockMissionRepo.Setup(x => x.GetAllMissionsByUserId("1", 1)).Returns(ipagedListMissionss);
            
        //    var actionResult = await _controller.GetAllMissionsByUserId(1);
        //    var result = actionResult as PartialViewResult;

        //    // Assert
        //    Assert.AreEqual(@"~/Views/Shared/_MissionsByUser.cshtml", result.ViewName);
        //    Assert.IsInstanceOfType(result.ViewData.Model, typeof(IPagedList<Mission>));

        //    _mockMissionRepo.Verify(repo => repo.GetAllMissionsByUserId(It.IsAny<string>(), It.IsAny<int>()), Times.Once);

        //}

        [TestMethod]
        public async Task TestDelete()
        {
            var mission = new Mission();

            _mockMissionRepo.Setup(x => x.GetById("1")).Returns(Task.FromResult(mission));
            _mockMissionRepo.Setup(x => x.Delete(mission)).Returns(Task.CompletedTask);

            var actionResult = await _controller.Delete("1");
            var result = actionResult as RedirectToActionResult;

            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Dashboard", result.ControllerName);

            _mockMissionRepo.Verify(repo => repo.Delete(It.IsAny<Mission>()), Times.Once);
        }

        [TestMethod]
        public async Task TestEdit()
        {
            var mission = new Mission();
            MissionViewModel model = new MissionViewModel() { Name = "M11", Description = "Desc1", StatusEnum = "", UserId = "1" };

            _mockMissionRepo.Setup(x => x.GetById("1")).Returns(Task.FromResult(mission));
            _mockMissionRepo.Setup(x => x.Update(mission)).Returns(Task.FromResult(mission));

            var actionResult = await _controller.Edit("1", model);
            var result = actionResult as RedirectToActionResult;

            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Dashboard", result.ControllerName);

            _mockMissionRepo.Verify(repo => repo.Update(It.IsAny<Mission>()), Times.Once);
        }

        [TestMethod]
        public async Task TestAdd()
        {
            var mission = new Mission();
            MissionViewModel model = new MissionViewModel() { Name = "M11", Description = "Desc1", StatusEnum = "", UserId = "1" };
            var project = new Project();
            _mockMissionRepo.Setup(x => x.Add(mission)).Returns(Task.FromResult(mission));
            _mockProjectRepo.Setup(x => x.GetById(mission.Id)).Returns(Task.FromResult(project));

            var actionResult = await _controller.Add(model);
            var result = actionResult as RedirectToActionResult;

            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Dashboard", result.ControllerName);

            _mockMissionRepo.Verify(repo => repo.Add(It.IsAny<Mission>()), Times.Once);
        }

    }
}
