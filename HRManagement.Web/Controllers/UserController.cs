using HRManagement.Web.Extensions;
using HRManagement.Web.Models;
using HRManagement.Web.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace HRManagement.Web.Controllers
{
    [Authorize]
    [Route("User")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        //private readonly IRepository<Address> _addressRepository;
        //private readonly IRepository<Diploma> _diplomaRepository;
        //private readonly IRepository<School> _schoolRepository;
        private readonly IUserProjectRepository _userProjectRepository;
        private readonly UserManager<User> _userManager;

        public UserController(
            IUserRepository userRepository,
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
        public async Task<IActionResult> GetAllUsers(int? page = 1)
        {
            var user = await GetCurrentUserAsync();
            var list = _userRepository.GetAll(page);
            var usersList = list.Where(p => p != user).ToPagedList();
            return PartialView(@"~/Views/Shared/_Users.cshtml", usersList);
        }

        [HttpGet]
        [Route("GetUser/{id?}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userRepository.GetById(id);
            Debug.WriteLine("USER ->" + user);
            if (user == null)
            {
                return RedirectToAction("Index", "Dashboard").WithDanger("Erreur rencontré", "Veuiilez préciser une valeur pour pouvoir effectuer une recherche");
            }
            else
            {          
                return View(user);
            }
        }

        private async Task<User> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);
    }
}
