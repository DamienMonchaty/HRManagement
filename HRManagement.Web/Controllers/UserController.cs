using HRManagement.Web.Models;
using HRManagement.Web.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Web.Controllers
{
    [Route("User")]
    public class UserController : Controller
    {
        private readonly IRepository<User> _userRepository;
        private readonly IUserProjectRepository _userProjectRepository;
        private readonly UserManager<User> _userManager;

        public UserController(
            IRepository<User> userRepository,
            IUserProjectRepository userProjectRepository,
            UserManager<User> userManager
            )
        {
            _userRepository = userRepository;
            _userProjectRepository = userProjectRepository;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await GetCurrentUserAsync();
            var list = await _userRepository.GetAll();
            var usersList = list.Where(p => p != user);
            return PartialView(@"~/Views/Shared/_Users.cshtml", usersList);
        }

        private async Task<User> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);
    }
}
