using HRManagement.Web.Extensions;
using HRManagement.Web.Models;
using HRManagement.Web.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Web.Controllers
{
    [Route("User")]
    public class UserController : Controller
    {
        private readonly IRepository<User> _userRepository;
        //private readonly IRepository<Address> _addressRepository;
        //private readonly IRepository<Diploma> _diplomaRepository;
        //private readonly IRepository<School> _schoolRepository;
        private readonly IUserProjectRepository _userProjectRepository;
        private readonly UserManager<User> _userManager;

        public UserController(
            IRepository<User> userRepository,
            //IRepository<Address> addressRepository,
            //IRepository<Diploma> diplomaRepository,
            //IRepository<School> schooRepository,
            IUserProjectRepository userProjectRepository,
            UserManager<User> userManager
            )
        {
            _userRepository = userRepository;
            //_addressRepository = addressRepository;
            //_diplomaRepository = diplomaRepository;
            //_schoolRepository = schooRepository;
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
