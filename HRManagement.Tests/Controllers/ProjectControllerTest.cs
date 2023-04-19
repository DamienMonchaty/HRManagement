using HRManagement.Web.Controllers;
using HRManagement.Web.Dto;
using HRManagement.Web.Models;
using HRManagement.Web.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace HRManagement.Tests.Controllers
{
    [TestClass]
    public class ProjectControllerTest
    {
        private readonly Mock<IProjectRepository> _mockProjectRepo;
        private readonly Mock<IUserProjectRepository> _mockUserProjectRepo;
        private readonly Mock<IUserRepository> _mockUserRepo;
        private readonly Mock<Web.Repository.IRepository<Client>> _mockClientRepo;
        private readonly Mock<Microsoft.AspNetCore.Identity.UserManager<User>> _mockUserManager;
        private readonly Mock<IElasticClient> _mockClient;

        private readonly ProjectController _controller;

        public ProjectControllerTest()
        {
            _mockProjectRepo = new Mock<IProjectRepository>();
            _mockUserProjectRepo = new Mock<IUserProjectRepository>();
            _mockUserRepo = new Mock<IUserRepository>();
            _mockClientRepo = new Mock<Web.Repository.IRepository<Client>>();
            _mockUserManager = new Mock<Microsoft.AspNetCore.Identity.UserManager<User>>(Mock.Of<Microsoft.AspNetCore.Identity.IUserStore<User>>(), null, null, null, null, null, null, null, null);
            _mockClient = new Mock<IElasticClient>();

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

            _controller = new ProjectController(
                _mockProjectRepo.Object,
                _mockUserProjectRepo.Object,
                _mockUserRepo.Object,
                _mockClientRepo.Object,
                _mockUserManager.Object,
                _mockClient.Object
                )
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                }
            };
        }

        //[TestMethod]
        //public async Task TestGetCurrentUserAsync()
        //{
        //    var currentUser = await _controller.GetCurrentUserAsync();
        //    // Assert
        //    Assert.AreEqual("John", currentUser.UserName);
        //}

        [TestMethod]
        public async Task TestAddDirectly()
        {
            UserProject uP = new UserProject
            {
                ProjectId = "1",
                UserId = "1"
            };

            _mockUserProjectRepo.Setup(x => x.Add(uP)).Returns(Task.FromResult(uP));

            JsonResult result = await _controller.AddDirectly("1", "1");

            // Assert.AreEqual("200", result.Value);

            _mockUserProjectRepo.Verify(repo => repo.Add(It.IsAny<UserProject>()), Times.Once);

        }

        [TestMethod]
        public async Task TestDeleteDirectly()
        {
            UserProject uP = new UserProject
            {
                ProjectId = "1",
                UserId = "1"
            };

            _mockUserProjectRepo.Setup(x => x.GetByIds("1", "1")).Returns(Task.FromResult(uP));

            _mockUserProjectRepo.Setup(x => x.Delete(uP)).Returns(Task.CompletedTask);

            JsonResult result = await _controller.DeleteDirectly("1", "1");

            // Assert.AreEqual("200", result.Value);

            _mockUserProjectRepo.Verify(repo => repo.Delete(It.IsAny<UserProject>()), Times.Once);
        }

        [TestMethod]
        public void TestDelete()
        {
            var project = new Project();

            _mockProjectRepo.Setup(x => x.GetById("1")).Returns(Task.FromResult(project));
            _mockProjectRepo.Setup(x => x.Delete(project)).Returns(Task.CompletedTask);

            _controller.Delete("1");

            _mockProjectRepo.Verify(repo => repo.Delete(It.IsAny<Project>()), Times.Once);
        }

        [TestMethod]
        public void TestGetAllProjects()
        {
            // Arrange
            var projects = new List<Project> { new Project(), new Project() };
            IPagedList<Project> ipagedListProjects = projects.ToPagedList(1, 5);

            _mockProjectRepo.Setup(x => x.GetAll(1)).Returns(ipagedListProjects);

            var actionResult = _controller.GetAllProjects(1);
            var result = actionResult as PartialViewResult;

            // Assert
            Assert.AreEqual(@"~/Views/Shared/_Projects.cshtml", result.ViewName);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(IPagedList<Project>));
        }

        [TestMethod]
        public async Task TestGetAllProjectsByUserId()
        {
            var projects = new List<Project> { new Project(), new Project() };
            IPagedList<Project> ipagedListProjects = projects.ToPagedList(1, 5);

            _mockProjectRepo.Setup(x => x.GetAllProjectsByUserId("1", 1)).Returns(ipagedListProjects);

            // var currentUser = await _controller.GetCurrentUserAsync();
            var actionResult = await _controller.GetAllProjectsByUserId(1);
            var result = actionResult as PartialViewResult;

            // Assert
            Assert.AreEqual(@"~/Views/Shared/_ProjectsByUser.cshtml", result.ViewName);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(IPagedList<Project>));

        }

        [TestMethod]
        public async Task TestGetProject()
        {
            var project = new Project();
            var users = new List<User> { new User(), new User() };

            _mockProjectRepo.Setup(x => x.GetById("1")).Returns(Task.FromResult(project));
            _mockProjectRepo.Setup(x => x.GetAllUsersByProject("1")).Returns(Task.FromResult(users));

            var actionResult = await _controller.GetProject("1");
            var result = actionResult as ViewResult;

            // Assert
            // Assert.AreEqual("GetProject", result.ViewName);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(ProjectViewModel));
        }

        [TestMethod]
        public async Task TestAdd()
        {
            Project project = new Project(){ Libelle = "lib1", Description = "t", StartDate = "10/10/2022", EndDate = "10/10/2022", ProjectEnum = StatusEnum.EN_PREPARATION, ClientId = "1" };
            ProjectViewModel model = new ProjectViewModel() { Libelle = "lib1", Description = "t", StartDate = "10/10/2022", EndDate = "10/10/2022", ClientId = "1" };

            _mockProjectRepo.Setup(x => x.Add(project)).Returns(Task.FromResult(project));

            UserProject uP = new UserProject
            {
                ProjectId = project.Id,
                UserId = "1"
            };

            _mockUserProjectRepo.Setup(x => x.Add(uP)).Returns(Task.FromResult(uP));

            List<string> idsList = new List<string>() { "1", "2" };

            model.UsersIds = idsList;

            var actionResult = await _controller.Add(model);
            var result = actionResult as RedirectToActionResult;

            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Dashboard", result.ControllerName);
        }

        [TestMethod]
        public async Task TestEdit()
        {
            var project = new Project();
            var users = new List<User> { new User(), new User() };
            ProjectViewModel model = new ProjectViewModel() { Libelle = "lib1", Description = "t", StartDate = "10/10/2022", EndDate = "10/10/2022", ClientId = "1", Users = users };

            _mockProjectRepo.Setup(x => x.GetById("1")).Returns(Task.FromResult(project));
            
            _mockProjectRepo.Setup(x => x.GetAllUsersByProject(project.Id)).Returns(Task.FromResult(users));

            _mockProjectRepo.Setup(x => x.Update(project)).Returns(Task.FromResult(project));

            var actionResult = await _controller.Edit("1", model);
            var result = actionResult as RedirectToActionResult;

            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Dashboard", result.ControllerName);
        }
    }
}
