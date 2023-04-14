using HRManagement.Web.Models;
using HRManagement.Web.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Web.Controllers
{
    [Route("")]
    [Route("Dashboard")]
    public class DashboardController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMissionRepository _missonRepository;

        private readonly Repository.IRepository<User> _userRepository;
        private readonly Repository.IRepository<Client> _clientRepository;

        public DashboardController(
            IProjectRepository projectRepository,
            Repository.IRepository<User> userRepository,
            Repository.IRepository<Client> clientRepository,
            IMissionRepository missonRepository
            )
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _clientRepository = clientRepository;
            _missonRepository = missonRepository;
        }

        [Route("")]
        [Authorize]
        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewData["CountUsers"] = await _userRepository.Count();
            ViewData["CountProjects"] = await _projectRepository.Count();
            ViewData["CountMissions"] = await _missonRepository.Count();
            ViewData["CountClients"] = await _clientRepository.Count();
            return View();
        }
    }
}
