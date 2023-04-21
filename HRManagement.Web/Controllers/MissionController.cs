using HRManagement.Web.Dto;
using HRManagement.Web.Extensions;
using HRManagement.Web.Helpers;
using HRManagement.Web.Models;
using HRManagement.Web.Repository;
using HRManagement.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Web.Controllers
{
    [Route("Mission")]
    public class MissionController : Controller
    {
        private readonly IMissionRepository _missionRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;

        public MissionController(
            IMissionRepository missionRepository,
            IProjectRepository projectRepository,
            IUserRepository userRepository,
            UserManager<User> userManager,
            IEmailService emailService
            )
        {
            _missionRepository = missionRepository;
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _userManager = userManager;
            _emailService = emailService;
        }

        [HttpGet]
        [Route("GetAllMissions")]
        public IActionResult GetAllMissions(int? page = 1)
        {
            var missions = _missionRepository.GetAll(page);
            return PartialView(@"~/Views/Shared/_Missions.cshtml", missions);
        }

        [HttpGet]
        [Route("GetAllMissionsByUserId")]
        public async Task<IActionResult> GetAllMissionsByUserId(int? page = 1)
        {
            var user = await GetCurrentUserAsync();
            var missions = _missionRepository.GetAllMissionsByUserId(user.Id, page);
            return PartialView(@"~/Views/Shared/_MissionsByUser.cshtml", missions);
        }

        [HttpGet]
        [Route("Add")]
        public async Task<IActionResult> Add()
        {
            var projectsList = await _projectRepository.GetAllRoot();
            this.ViewData["projects"] = projectsList
                .Select(c => new SelectListItem() { Text = c.Libelle, Value = c.Id })
                .ToList();
            return View();
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(MissionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Mission m = new Mission
                {
                    Name = model.Name,
                    Description = model.Description,
                    MissionEnum = StatusEnum.EN_PREPARATION,
                    ProjectId = model.ProjectId,
                    UserId = model.UserId
                };

                await _missionRepository.Add(m);

                var project = await _projectRepository.GetById(m.ProjectId);

                project.ProjectEnum = StatusEnum.EN_COURS;

                await _projectRepository.Update(project);

                var user = await _userRepository.GetById(m.UserId);

                var msg = "Une nouvelle mission , " + m.Name + " vus a été attribué";

                string str = await ViewToStringRenderer.RenderViewToStringAsync(HttpContext.RequestServices, $"~/Views/Emails/EmailRegisterTemplate.cshtml", new Email { Message = msg });
                var message = new Message(new string[] { user.Email }, "Nouvelle mission", str, null);
                await _emailService.SendEmailAsync(message);

                return RedirectToAction("Index", "Dashboard");
            }
            return View(model).WithDanger("Erreur rencontré", "Une erreur est survenue");
        }

        [HttpGet]
        [Route("Edit/{id?}")]
        public async Task<IActionResult> Edit(string id)
        {
            var projectsList = await _projectRepository.GetAllRoot();
            this.ViewData["projects"] = projectsList
                .Select(c => new SelectListItem() { Text = c.Libelle, Value = c.Id })
                .ToList();

            var mission = await _missionRepository.GetById(id);
            
            MissionViewModel model = new MissionViewModel
            {
                Id = mission.Id,
                Name = mission.Name,
                Description = mission.Description,
                Project = mission.Project,
                User = mission.User
            };

            return View(model);
        }

        [HttpPost]
        [Route("Edit/{id?}")]
        public async Task<IActionResult> Edit(string id, MissionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mission = await _missionRepository.GetById(id);

                mission.Name = model.Name;
                mission.Description = model.Description;
                mission.ProjectId = model.ProjectId;
                mission.UserId = model.UserId;           
                await _missionRepository.Update(mission);

                //return RedirectToAction("Index", "Dashboard").WithSuccess("Félicitations", "Mise à jour effectuée !");
                return RedirectToAction("Index", "Dashboard");
            }
            return View(model).WithDanger("Erreur rencontré", "Une erreur est survenue");
        }
        
        [HttpGet, ActionName("Delete")]
        [Route("Delete/{id?}")]
        public async Task<IActionResult> Delete(string id)
        {
            var mission = await _missionRepository.GetById(id);
            if (mission == null)
            {
                return NotFound();
            }
            await _missionRepository.Delete(mission);
            return RedirectToAction("Index", "Dashboard");
            // return RedirectToAction("Index", "Dashboard").WithSuccess("Félicitations", "Suppression effectuée !");
        }

        [HttpGet]
        [Route("UsersProject/{id?}")]
        public async Task<JsonResult> UsersProject(string id)
        {
            var users = await _projectRepository.GetAllUsersByProject(id);
            return Json(users);
        }

        [HttpGet, ActionName("EditStatusAccepted")]
        [Route("EditStatusAccepted/{id?}")]
        public async Task<IActionResult> EditStatusAccepted(string id)
        {
            var mission = await _missionRepository.GetById(id);

            var project = await _projectRepository.GetById(mission.ProjectId);

            var users = await _projectRepository.GetAllUsersByProject(project.Id);

            var emp = users.FirstOrDefault(x => x.Id == mission.UserId);

            var userMan = users.FirstOrDefault(x => x.PositionEnum.ToString() == "MANAGER");

            var msg = "la mission " + mission.Name + " a été débuté par " + emp.UserName;

            string str = await ViewToStringRenderer.RenderViewToStringAsync(HttpContext.RequestServices, $"~/Views/Emails/EmailRegisterTemplate.cshtml", new Email { Message = msg });
            var message = new Message(new string[] { "damienmonchaty@gmail.com" }, "Nouvelle mission", str, null);
            await _emailService.SendEmailAsync(message);

            mission.MissionEnum = StatusEnum.EN_COURS;
            if (mission == null)
            {
                return NotFound();
            }
            await _missionRepository.Update(mission);
            return RedirectToAction("Index", "Dashboard").WithSuccess("Félicitations", "Tâche démarré !");
        }

        [HttpGet, ActionName("EditStatusValid")]
        [Route("EditStatusValid/{id?}")]
        public async Task<IActionResult> EditStatusValid(string id)
        {
            var mission = await _missionRepository.GetById(id);

            var project = await _projectRepository.GetById(mission.ProjectId);

            var users = await _projectRepository.GetAllUsersByProject(project.Id);

            var emp = users.FirstOrDefault(x => x.Id == mission.UserId);

            var userMan = users.FirstOrDefault(x => x.PositionEnum.ToString() == "MANAGER");

            var msg = "la mission " + mission.Name + " a été validé par " + emp.UserName;

            string str = await ViewToStringRenderer.RenderViewToStringAsync(HttpContext.RequestServices, $"~/Views/Emails/EmailRegisterTemplate.cshtml", new Email { Message = msg });
            var message = new Message(new string[] { userMan.Email }, "Nouvelle mission", str, null);
            await _emailService.SendEmailAsync(message);

            mission.MissionEnum = StatusEnum.TERMINE;
            if (mission == null)
            {
                return NotFound();
            }
            await _missionRepository.Update(mission);
            return RedirectToAction("Index", "Dashboard").WithSuccess("Félicitations", "Tâche Cloturé !");
        }

        private async Task<User> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);
    }
}
