using HRManagement.Web.Dto;
using HRManagement.Web.Models;
using HRManagement.Web.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Web.Controllers
{
    [Route("Project")]
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserProjectRepository _userProjectRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Client> _clientRepository;
        private readonly UserManager<User> _userManager;

        public ProjectController(
            IProjectRepository projectRepository,
            IUserProjectRepository userProjectRepository,
            IRepository<User> userRepository,
            IRepository<Client> clientRepository,
            UserManager<User> userManager
            )
        {
            _projectRepository = projectRepository;
            _userProjectRepository = userProjectRepository;
            _userRepository = userRepository;
            _clientRepository = clientRepository;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("GetAllProjects")]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _projectRepository.GetAll();
            return PartialView(@"~/Views/Shared/_Projects.cshtml", projects);
        }

        [HttpGet]
        public IActionResult UserEditor()
        {
            return PartialView(@"~/Views/Project/_UserEditor.cshtml", new User());
        }

        [HttpPost]
        [Route("UsersSearch")]
        public async Task<JsonResult> UsersSearch(string prefix)
        {
            //Searching records from list using LINQ query  
            var user = await GetCurrentUserAsync();
            var list = await _userRepository.GetAll();
            var usersList = list.Where(p => p != user);
            var Name = (from N in usersList
                        where N.FirstName.StartsWith(prefix)
                        select new
                        {
                            label = N.UserName,
                            val = N.Id
                        }).ToList();
            return Json(Name);
        }

        [HttpGet]
        [Route("Add")]
        public async Task<IActionResult> Add()
        {
            var clientsList = await _clientRepository.GetAll();
            this.ViewData["clients"] = clientsList
                .Select(c => new SelectListItem() { Text = c.Name, Value = c.Id })
                .ToList();

            var user = await GetCurrentUserAsync();
            var list = await _userRepository.GetAll();
            var usersList = list.Where(p => p != user);
            this.ViewData["users"] = usersList
                .Select(c => new SelectListItem() { Text = c.Email, Value = c.Id })
                .ToList();

            return View();
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(ProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                Project p = new Project
                {
                    Libelle = model.Libelle,
                    Description = model.Description,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    ProjectEnum = ProjectEnum.EN_PREPARATION, // A MODIFIER
                    ClientId = model.ClientId
                };

                var projectSaved = await _projectRepository.Add(p);

                foreach (var id in model.UsersIds)
                {
                    UserProject uP = new UserProject 
                    { 
                        ProjectId = projectSaved.Id,
                        UserId = id
                    };
                    //p.UserProjects.Add(uP);
                    await _userProjectRepository.Add(uP);
                }
                return RedirectToAction("Index", "Dashboard");
            }
            return View(model);
        }

        [HttpGet]
        [Route("Edit/{id?}")]
        public async Task<IActionResult> Edit(string id)
        {
            var clientsList = await _clientRepository.GetAll();
            this.ViewData["clients"] = clientsList
                .Select(c => new SelectListItem() { Text = c.Name, Value = c.Id })
                .ToList();

            var project = await _projectRepository.GetById(id);
            ProjectViewModel model = new ProjectViewModel
            {
                Id = project.Id,
                Libelle = project.Libelle,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                ProjectEnum = project.ProjectEnum.ToString(), 
                ClientId = project.ClientId
            };

            var users = await _projectRepository.GetAllUsersByProject(id);

            foreach(var u in users)
            {
                model.Users.Add(u);
            }

            return View(model);
        }

        [HttpGet]
        [Route("DeleteDirectly/{projectId?}/{userId?}")]
        public async Task<JsonResult> DeleteDirectly(string projectId, string userId)
        {
            Debug.Write("USERID -> " + userId + " PROJECTID -> " + projectId);
            var userProject = await _userProjectRepository.GetByIds(userId, projectId);
            Debug.Write("USERPROJECT TO DELETE -> " + userProject);

            await _userProjectRepository.Delete(userProject);
            return Json(new { status = true });
            // if deletion was failed for any reason, then return the following code
            //return Json(new { status = false });
        }

        [HttpPost]
        [Route("AddDirectly/{projectId?}/{userId?}")]
        public async Task<JsonResult> AddDirectly(string projectId, string userId)
        {
            UserProject uP = new UserProject
            {
                UserId = userId,
                ProjectId = projectId
            };
            var uPToSave = await _userProjectRepository.Add(uP);
            return Json(uPToSave);
            // if deletion was failed for any reason, then return the following code
            //return Json(new { status = false });
        }

        [HttpPost]
        [Route("Edit/{id?}")]
        public async Task<IActionResult> Edit(string id, ProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                var project = await _projectRepository.GetById(id);

                var users = await _projectRepository.GetAllUsersByProject(project.Id);

                project.Libelle = model.Libelle;
                project.Description = model.Description;
                project.StartDate = model.StartDate;
                project.EndDate = model.EndDate;
                project.ClientId = model.ClientId;

                foreach (var u in model.Users)
                {
                    if (!users.Contains(u))
                    {
                        var userProduct = await _userProjectRepository.GetByIds(u.Id, project.Id);
                        await _userProjectRepository.Delete(userProduct);
                    }
                   
                }
                await _projectRepository.Update(project);           

                return RedirectToAction("Index", "Dashboard");
            }
            return View(model);
        }

        [HttpGet, ActionName("Delete")]
        [Route("Delete/{id?}")]
        public async Task<IActionResult> Delete(string id)
        {
            var project = await _projectRepository.GetById(id);
            // ALERT SI NULL
            if (project == null)
            {
                return NotFound();
            }
            await _projectRepository.Delete(project);
            return RedirectToAction("Index", "Dashboard");
        }

        private async Task<User> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);

    }
}
