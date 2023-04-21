using HRManagement.Web.Dto;
using HRManagement.Web.Extensions;
using HRManagement.Web.Models;
using HRManagement.Web.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nest;
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
        private readonly Repository.IUserRepository _userRepository;
        private readonly Repository.IRepository<Client> _clientRepository;
        private readonly UserManager<User> _userManager;
        private readonly Nest.IElasticClient _client;

        public ProjectController(
            IProjectRepository projectRepository,
            IUserProjectRepository userProjectRepository,
            Repository.IUserRepository userRepository,
            Repository.IRepository<Client> clientRepository,
            UserManager<User> userManager,
            Nest.IElasticClient client
            )
        {
            _projectRepository = projectRepository;
            _userProjectRepository = userProjectRepository;
            _userRepository = userRepository;
            _clientRepository = clientRepository;
            _userManager = userManager;
            _client = client;
        }

        [HttpGet]
        [Route("GetAllProjects")]
        public IActionResult GetAllProjects(int? page = 1)
        {
            var projects = _projectRepository.GetAll(page);
            return PartialView(@"~/Views/Shared/_Projects.cshtml", projects);
        }

        [HttpGet]
        [Route("GetAllProjectsByUserId")]
        public async Task<IActionResult> GetAllProjectsByUserId(int? page = 1)
        {
            var user = await GetCurrentUserAsync();
            var projects = _projectRepository.GetAllProjectsByUserId(user.Id, page);
            return PartialView(@"~/Views/Shared/_ProjectsByUser.cshtml", projects);
        }

        [HttpGet]
        [Route("GetProject/{id?}")]
        public async Task<IActionResult> GetProject(string id)
        {
            var project = await _projectRepository.GetById(id);
            if (project == null && id == null) {
                return RedirectToAction("Index", "Dashboard").WithDanger("Erreur rencontré", "Veuiilez préciser une valeur pour pouvoir effectuer une recherche");
            } else if (project == null && id != null)
            {
                return RedirectToAction("GetUser", "User", new { id = id });
            }
            else
            {
                var client = await _clientRepository.GetById(project.ClientId);

                ProjectViewModel model = new ProjectViewModel
                {
                    Id = project.Id,
                    Libelle = project.Libelle,
                    Description = project.Description,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                    Status = project.ProjectEnum.ToString(),
                    Client = client,
                    ClientId = project.ClientId
                };

                var users = await _projectRepository.GetAllUsersByProject(id);

                foreach (var u in users)
                {
                    model.Users.Add(u);
                }
                return View(model);
            }
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
            var list = await _userRepository.GetAllRoot();
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

        [HttpPost]
        [Route("ProjectsSearch")]
        public JsonResult GetAutocompleteSuggestions(string keyword)
        {
            var result = _client.MultiSearch(selector: ms => ms
                .Search<Project>("projects", s => s.MatchAll())
                .Search<User>("users", s => s.MatchAll())
            );

            var users = result.GetResponse<User>("users");
            var projects = result.GetResponse<Project>("projects");

            var Name = (from N in projects.Documents
                        where N.Libelle.StartsWith(keyword)
                        select new
                        {
                            label = N.Libelle,
                            val = N.Id
                        }).ToList();

            var Name2 = (from N in users.Documents
                        where N.UserName.StartsWith(keyword)
                        select new
                        {
                            label = N.UserName,
                            val = N.Id
                        }).ToList();

            var names = Name.Concat(Name2);
            return Json(names);
        }

        [HttpGet]
        [Route("Add")]
        public async Task<IActionResult> Add()
        {
            var clientsList = await _clientRepository.GetAllRoot();
            this.ViewData["clients"] = clientsList
                .Select(c => new SelectListItem() { Text = c.Name, Value = c.Id })
                .ToList();

            var user = await GetCurrentUserAsync();
            var list = await _userRepository.GetAllRoot();
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
            Project p = new Project
            {
                Libelle = model.Libelle,
                Description = model.Description,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                ProjectEnum = StatusEnum.EN_PREPARATION,
                ClientId = model.ClientId
            };

            var projectSaved = await _projectRepository.Add(p) ?? new Project();

            if(model.UsersIds != null)
            {
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
            else
            {
                return View(model).WithDanger("Erreur rencontré", "Veuillez selectionner un employé");
            }



            //return RedirectToAction("Index", "Dashboard").WithSuccess("Félicitations", "Ajout effectué !");
            //if (ModelState.IsValid)
            //{
            //    Project p = new Project
            //    {
            //        Libelle = model.Libelle,
            //        Description = model.Description,
            //        StartDate = model.StartDate,
            //        EndDate = model.EndDate,
            //        ProjectEnum = StatusEnum.EN_PREPARATION,
            //        ClientId = model.ClientId
            //    };

            //    var projectSaved = await _projectRepository.Add(p);

            //    foreach (var id in model.UsersIds)
            //    {
            //        UserProject uP = new UserProject 
            //        { 
            //            ProjectId = projectSaved.Id,
            //            UserId = id
            //        };
            //        //p.UserProjects.Add(uP);
            //        await _userProjectRepository.Add(uP);
            //    }
            //    return RedirectToAction("Index", "Dashboard").WithSuccess("Félicitations", "Ajout effectué !");
            //}
            //return View(model).WithDanger("Erreur rencontré", "Une erreur est survenue");
        }

        [HttpGet]
        [Route("Edit/{id?}")]
        public async Task<IActionResult> Edit(string id)
        {
            var clientsList = await _clientRepository.GetAllRoot();
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
                Status = project.ProjectEnum.ToString(), 
                ClientId = project.ClientId
            };

            var users = await _projectRepository.GetAllUsersByProject(id);

            foreach(var u in users)
            {
                model.Users.Add(u);
            }

            return View(model);
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
                //return RedirectToAction("Index", "Dashboard").WithSuccess("Félicitations", "Mise à jour effectuée !");
            }
            return View(model).WithDanger("Erreur rencontré", "Une erreur est survenue");
        }

        //[Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("DeleteDirectly/{projectId?}/{userId?}")]
        public async Task<JsonResult> DeleteDirectly(string projectId, string userId)
        {
            Debug.Write("USERID -> " + userId + " PROJECTID -> " + projectId);
            var userProject = await _userProjectRepository.GetByIds(userId, projectId);
            Debug.Write("USERPROJECT TO DELETE -> " + userProject);

            await _userProjectRepository.Delete(userProject);
            return Json(new { status = true });
        }

        //[Authorize(Roles = "Administrator")]
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
        }

        [HttpGet, ActionName("Delete")]
        [Route("Delete/{id?}")]
        public IActionResult Delete(string id)
        {
            var project = _projectRepository.GetById(id);
            // ALERT SI NULL
            if (project == null)
            {
                return NotFound();
            }

            _projectRepository.Delete(project.Result);
            return RedirectToAction("Index", "Dashboard");

            // return RedirectToAction("Index", "Dashboard").WithSuccess("Félicitations", "Suppression effectuée !");

            //if(project.Missios.Count() >= 1)
            //{
            //    return RedirectToAction("Index", "Dashboard").WithDanger("Erreur rencontré", "Impossible de supprimer un projet ayant des missions en cours !");               
            //}
            //else
            //{
            //    await _projectRepository.Delete(project);
            //    return RedirectToAction("Index", "Dashboard").WithSuccess("Félicitations", "Suppression effectuée !");
            //}
        }

        public async Task<User> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);

    }
}
